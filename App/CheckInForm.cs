using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using DataAccess.Models;

namespace App
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _http = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:5000/")
        };

       

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            btnSearch = new Button();
            txtPassport = new TextBox();
            lblName = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(12, 64);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(150, 51);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += button1_Click;
            // 
            // txtPassport
            // 
            txtPassport.Location = new Point(12, 12);
            txtPassport.Name = "txtPassport";
            txtPassport.Size = new Size(200, 39);
            txtPassport.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 137);
            lblName.Name = "lblName";
            lblName.Size = new Size(78, 32);
            lblName.TabIndex = 2;
            lblName.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(210, 399);
            label1.Name = "label1";
            label1.Size = new Size(78, 32);
            label1.TabIndex = 3;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(1379, 784);
            Controls.Add(label1);
            Controls.Add(lblName);
            Controls.Add(txtPassport);
            Controls.Add(btnSearch);
            Name = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var passport = txtPassport.Text;
            var response = await _http.GetAsync($"api/passengers/{passport}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var passenger = JsonConvert.DeserializeObject<Passenger>(json);
                lblName.Text = passenger?.Name ?? "Not Found";
                MessageBox.Show($"Check-in successful: {passenger?.Name}");
            }
            else
            {
                MessageBox.Show("Check-in failed. Please try again.");
            }
        }
        private Label label1;
        private Button btnSearch;
        private TextBox txtPassport;
        private Label lblName;

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
