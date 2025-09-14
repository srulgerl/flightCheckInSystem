using System.Text;
using Newtonsoft.Json;
using BusinessLogic.DTOs;
using System.Drawing.Printing;
using DataAccess.Models;
using System.Net.Http.Json;

namespace WinFormsApp
{
    public partial class CheckInForm : Form
    {
        private readonly HttpClient _http = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5000/")
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
            flightNumComboBox.DisplayMember = "FlightNumber"; 
            flightNumComboBox.ValueMember = "FlightId";

            Tolow.Items.Clear();
            Tolow.Items.AddRange(Enum.GetNames(typeof(FlightStatus)));
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

                // суудлын төлөв дахин шинэчлэх
                await RefreshSeatButtons(flightId);
            }
            else
            {
                var err = await resp.Content.ReadAsStringAsync();
                MessageBox.Show($"Алдаа: {err}");
            }
        }
        private async void btnChangeTolow_Click(object sender, EventArgs e)
        {
            // btnChangeTolow_Click дотор:
            if (flightNumComboBox.SelectedValue == null) { MessageBox.Show("Эхлээд нислэгээ сонгоно уу."); return; }
            if (Tolow.SelectedItem == null) { MessageBox.Show("Шинэ төлөв сонгоно уу."); return; }

            int flightId = (int)flightNumComboBox.SelectedValue;
            string statusName = Tolow.SelectedItem.ToString(); // ж: "Boarding", "Delayed" гэх мэт НЭР

            var payload = new { FlightId = flightId, Status = statusName }; // enum НЭР

            try
            {
                // 1) route-оо updatestatus болгосон!
                var resp = await _http.PutAsJsonAsync("api/flight/status", payload);

                if (resp.IsSuccessStatusCode)
                {
                    MessageBox.Show("Нислэгийн төлөв амжилттай солигдлоо.");
                    return;
                }

                // Амжилтгүй бол — статус кодыг нь харуул
                var err = await resp.Content.ReadAsStringAsync();
                MessageBox.Show($"Алдаа ({(int)resp.StatusCode} {resp.StatusCode}): {err}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Холболтын алдаа: " + ex.Message);
            }

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

            foreach (Control ctrl in panel2.Controls)
            {
                if (ctrl is Button btn && btn.Text.Length >= 2)
                {
                    btn.Enabled = true;
                    btn.BackColor = SystemColors.Control;
                }
            }

            foreach (Control ctrl in panel2.Controls)
            {
                if (ctrl is Button btn && reservedSeats.Contains(btn.Text))
                {
                    btn.Enabled = false;
                    btn.BackColor = Color.LightGray;
                }
            }

            if (!string.IsNullOrEmpty(selectedSeat))
            {
                var btn = panel2.Controls.OfType<Button>().FirstOrDefault(b => b.Text == selectedSeat);
                if (btn != null)
                {
                    btn.BackColor = Color.LightGreen;
                    btn.Enabled = false; 
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
