using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using BusinessLogic.DTOs;
using System.Drawing.Printing;

namespace WinFormsApp
{
    public partial class CheckInForm : Form
    {
        private readonly HttpClient _http = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5000/") // серверийн API хаяг
        };

        private PassengerDto? currentPassenger;
        private string? selectedSeat;

        public CheckInForm()
        {
            InitializeComponent();
        }

        // --- FORM LOAD ---
        private async void CheckInForm_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            var resp = await _http.GetAsync("api/flight/list");
            if (!resp.IsSuccessStatusCode) return;

            var json = await resp.Content.ReadAsStringAsync();
            var flights = JsonConvert.DeserializeObject<List<FlightDto>>(json);

            flightNumComboBox.DataSource = flights;
            flightNumComboBox.DisplayMember = "FlightNumber"; // UI дээр FlightNumber харагдана
            flightNumComboBox.ValueMember = "FlightId";       // Backend руу дамжуулах FlightId
        }

        // --- EXIT BTN ---
        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- Passport хайх ---
        private async void btnPassportSearch_Click(object sender, EventArgs e)
        {
            if (flightNumComboBox.SelectedValue == null)
            {
                MessageBox.Show("Эхлээд нислэгээ сонгоно уу.");
                return;
            }

            int flightId = (int)flightNumComboBox.SelectedValue;
            var passport = passportNumTxtBx.Text.Trim();

            var response = await _http.GetAsync($"api/passenger/{flightId}/{passport}");
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Энэ зорчигч сонгосон нислэгт олдсонгүй!");
                return;
            }

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PassengerWithSeatDto>(json);

            currentPassenger = new PassengerDto
            {
                PassengerId = result.PassengerId,
                Name = result.Name,
                PassportNumber = result.PassportNumber
            };

            lblUserInfo.Text = $"Зорчигч: {currentPassenger.Name} ({currentPassenger.PassportNumber})";

            selectedSeat = result.SeatNumber;

            await RefreshSeatButtons(flightId);
        }


        // --- Суудал сонгох (A1..D6 button-ууд бүгд энэ эвентэд холбогдсон) ---
        private void SeatButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            selectedSeat = btn.Text;
            panelSeatConfirm.Visible = true;
            lblSeatConfirm.Text = $"Сонгосон суудал: {selectedSeat}";
        }

        // --- Суудал баталгаажуулах ---
        private async void btnSuudalConfirm_Click(object sender, EventArgs e)
        {
            if (currentPassenger == null || string.IsNullOrEmpty(selectedSeat))
            {
                MessageBox.Show("Эхлээд зорчигч хайж, дараа нь суудал сонгоно уу.");
                return;
            }

            if (flightNumComboBox.SelectedValue == null)
            {
                MessageBox.Show("Эхлээд нислэг сонгоно уу.");
                return;
            }

            int flightId = (int)flightNumComboBox.SelectedValue;

            var reservation = new
            {
                flightId = flightId,
                passengerId = currentPassenger.PassengerId,
                seatNumber = selectedSeat
            };

            var json = JsonConvert.SerializeObject(reservation);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var resp = await _http.PostAsync("api/reservation", content);

            if (resp.IsSuccessStatusCode)
            {
                MessageBox.Show($"Суудал {selectedSeat} амжилттай баталгаажлаа!");
                panelSeatConfirm.Visible = false;

                // суудлын төлөв дахин шинэчлэх
                await RefreshSeatButtons(flightId);
            }
            else
            {
                var err = await resp.Content.ReadAsStringAsync();
                MessageBox.Show($"Алдаа: {err}");
            }
        }

        // --- Суудал сонголт цуцлах ---
        private void btnSuudalCancel_Click(object sender, EventArgs e)
        {
            selectedSeat = null;
            panelSeatConfirm.Visible = false;
            lblSeatConfirm.Text = string.Empty;
        }

        // --- Төлөв солих ---
        private async void btnChangeTolow_Click(object sender, EventArgs e)
        {
            if (Tolow.SelectedItem == null)
            {
                MessageBox.Show("Төлөв сонгоно уу.");
                return;
            }

            string status = Tolow.SelectedItem.ToString();

            var resp = await _http.PostAsync($"api/flight/updateStatus?flightId=1&status={status}", null);

            if (resp.IsSuccessStatusCode)
                MessageBox.Show("Төлөв шинэчлэгдлээ!");
            else
                MessageBox.Show("Төлөв шинэчлэхэд алдаа гарлаа!");
        }

        // --- Boarding pass хэвлэх ---
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (currentPassenger == null || string.IsNullOrEmpty(selectedSeat))
            {
                MessageBox.Show("Эхлээд зорчигчийг хайж, суудал сонгоод баталгаажуулна уу.");
                return;
            }

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (s, ev) =>
            {
                ev.Graphics.DrawString("✈ Boarding Pass", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, 10, 10);
                ev.Graphics.DrawString($"Passenger: {currentPassenger.Name}", new Font("Arial", 12), Brushes.Black, 10, 40);
                ev.Graphics.DrawString($"Passport: {currentPassenger.PassportNumber}", new Font("Arial", 12), Brushes.Black, 10, 60);
                ev.Graphics.DrawString($"Flight: FL123", new Font("Arial", 12), Brushes.Black, 10, 80);
                ev.Graphics.DrawString($"Seat: {selectedSeat}", new Font("Arial", 12), Brushes.Black, 10, 100);
                ev.Graphics.DrawString($"Date: {DateTime.Now:yyyy-MM-dd HH:mm}", new Font("Arial", 12), Brushes.Black, 10, 120);
            };

            PrintDialog dlg = new PrintDialog();
            dlg.Document = pd;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }

        }

        private async Task RefreshSeatButtons(int flightId)
        {
            var resp = await _http.GetAsync($"api/reservation/flight/{flightId}/seats");
            if (!resp.IsSuccessStatusCode) return;

            var json = await resp.Content.ReadAsStringAsync();
            var reservedSeats = JsonConvert.DeserializeObject<List<string>>(json) ?? new List<string>();

            // 1. бүх товчлууруудыг reset хийнэ (сул = цагаан)
            foreach (Control ctrl in panel2.Controls)
            {
                if (ctrl is Button btn && btn.Text.Length >= 2)
                {
                    btn.Enabled = true;
                    btn.BackColor = SystemColors.Control;
                }
            }

            // 2. бүх захиалагдсан суудлыг саарал болгоно
            foreach (Control ctrl in panel2.Controls)
            {
                if (ctrl is Button btn && reservedSeats.Contains(btn.Text))
                {
                    btn.Enabled = false;
                    btn.BackColor = Color.LightGray;
                }
            }

            // 3. Хэрэв энэ зорчигч өөрийн суудалтай бол → ногооноор тэмдэглэнэ
            if (!string.IsNullOrEmpty(selectedSeat))
            {
                var btn = panel2.Controls.OfType<Button>().FirstOrDefault(b => b.Text == selectedSeat);
                if (btn != null)
                {
                    btn.BackColor = Color.LightGreen;
                    btn.Enabled = false; // өөрийн seat-ийг дахиж дарж солихгүй
                }
            }
        }

        private void appbar_Click(object sender, EventArgs e) { }
        private void lbldate_Click(object sender, EventArgs e) { }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void panelSeatConfirm_Paint(object sender, PaintEventArgs e) { }
        private void Tolow_SelectedIndexChanged(object sender, EventArgs e) { }

        private void flightNumComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
