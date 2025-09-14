using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq; 
using System.Drawing;
using Font = System.Drawing.Font;

namespace WinFormsApp
{
    partial class CheckInForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            appbar = new Label();
            lblNislegNumber = new Label();
            lbldate = new Label();
            lblEmployee = new Label();
            exitBtn = new Button();
            label1 = new Label();
            lblUserSearch = new Label();
            LblPasswordNumber = new Label();
            passportNumTxtBx = new TextBox();
            btnPassportSearch = new Button();
            btnSeatA1 = new Button();
            BtnSeatC1 = new Button();
            BtnSeatB2 = new Button();
            BtnSeatA2 = new Button();
            BtnSeatB1 = new Button();
            BtnSeatB4 = new Button();
            BtnSeatA4 = new Button();
            BtnSeatB3 = new Button();
            BtnSeatA3 = new Button();
            BtnSeatD2 = new Button();
            BtnSeatC2 = new Button();
            BtnSeatD1 = new Button();
            BtnSeatB6 = new Button();
            BtnSeatA6 = new Button();
            BtnSeatB5 = new Button();
            BtnSeatA5 = new Button();
            BtnSeatC4 = new Button();
            BtnSeatD4 = new Button();
            BtnSeatD3 = new Button();
            BtnSeatC3 = new Button();
            BtnSeatC6 = new Button();
            BtnSeatC5 = new Button();
            BtnSeatD5 = new Button();
            BtnSeatD6 = new Button();
            LabelSeatsLoc = new Label();
            lblbusinessSeats = new Label();
            lblEngiinSeats = new Label();
            btnSuudalConfirm = new Button();
            lblUserInfo = new Label();
            label3 = new Label();
            Tolow = new ComboBox();
            btnChangeTolow = new Button();
            btnPrint = new Button();
            userLbl = new Label();
            flightNumComboBox = new ComboBox();
            panel1 = new Panel();
            panel2 = new Panel();
            listView1 = new ListView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // appbar
            // 
            appbar.BackColor = SystemColors.ControlLight;
            appbar.Location = new Point(0, -3);
            appbar.Margin = new Padding(5, 0, 5, 0);
            appbar.Name = "appbar";
            appbar.Size = new Size(1633, 130);
            appbar.TabIndex = 0;
            appbar.Click += appbar_Click;
            // 
            // lblNislegNumber
            // 
            lblNislegNumber.AutoSize = true;
            lblNislegNumber.BackColor = SystemColors.ControlLight;
            lblNislegNumber.Location = new Point(0, 38);
            lblNislegNumber.Margin = new Padding(5, 0, 5, 0);
            lblNislegNumber.Name = "lblNislegNumber";
            lblNislegNumber.Size = new Size(210, 32);
            lblNislegNumber.TabIndex = 1;
            lblNislegNumber.Text = "Нислэгийн дугаар";
            // 
            // lbldate
            // 
            lbldate.AutoSize = true;
            lbldate.BackColor = SystemColors.ControlLight;
            lbldate.Location = new Point(474, 38);
            lbldate.Margin = new Padding(5, 0, 5, 0);
            lbldate.Name = "lbldate";
            lbldate.Size = new Size(83, 32);
            lbldate.TabIndex = 2;
            lbldate.Text = "Огноо";
            lbldate.Click += lbldate_Click;
            // 
            // lblEmployee
            // 
            lblEmployee.AutoSize = true;
            lblEmployee.BackColor = SystemColors.ControlLight;
            lblEmployee.Location = new Point(856, 38);
            lblEmployee.Margin = new Padding(5, 0, 5, 0);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(122, 32);
            lblEmployee.TabIndex = 3;
            lblEmployee.Text = "Ажилтан: ";
            // 
            // exitBtn
            // 
            exitBtn.Location = new Point(1308, 32);
            exitBtn.Margin = new Padding(5);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(153, 46);
            exitBtn.TabIndex = 4;
            exitBtn.Text = "Гарах";
            exitBtn.UseVisualStyleBackColor = true;
            exitBtn.Click += btnexit_Click;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ControlLight;
            label1.Location = new Point(0, 142);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(499, 483);
            label1.TabIndex = 5;
            // 
            // lblUserSearch
            // 
            lblUserSearch.AutoSize = true;
            lblUserSearch.BackColor = SystemColors.ControlLight;
            lblUserSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserSearch.Location = new Point(127, 142);
            lblUserSearch.Margin = new Padding(5, 0, 5, 0);
            lblUserSearch.Name = "lblUserSearch";
            lblUserSearch.Size = new Size(171, 32);
            lblUserSearch.TabIndex = 6;
            lblUserSearch.Text = "Зорчигч хайх";
            // 
            // LblPasswordNumber
            // 
            LblPasswordNumber.AutoSize = true;
            LblPasswordNumber.BackColor = SystemColors.ControlLight;
            LblPasswordNumber.Location = new Point(0, 200);
            LblPasswordNumber.Margin = new Padding(5, 0, 5, 0);
            LblPasswordNumber.Name = "LblPasswordNumber";
            LblPasswordNumber.Size = new Size(216, 32);
            LblPasswordNumber.TabIndex = 7;
            LblPasswordNumber.Text = "Паспортын дугаар";
            // 
            // passportNumTxtBx
            // 
            passportNumTxtBx.Location = new Point(15, 237);
            passportNumTxtBx.Margin = new Padding(5);
            passportNumTxtBx.Name = "passportNumTxtBx";
            passportNumTxtBx.Size = new Size(201, 39);
            passportNumTxtBx.TabIndex = 12;
            // 
            // btnPassportSearch
            // 
            btnPassportSearch.Location = new Point(228, 235);
            btnPassportSearch.Margin = new Padding(5);
            btnPassportSearch.Name = "btnPassportSearch";
            btnPassportSearch.Size = new Size(107, 46);
            btnPassportSearch.TabIndex = 13;
            btnPassportSearch.Text = "Хайх";
            btnPassportSearch.UseVisualStyleBackColor = true;
            btnPassportSearch.Click += btnPassportSearch_Click;
            // 
            // btnSeatA1
            // 
            btnSeatA1.Location = new Point(114, 56);
            btnSeatA1.Margin = new Padding(5);
            btnSeatA1.Name = "btnSeatA1";
            btnSeatA1.Size = new Size(60, 46);
            btnSeatA1.TabIndex = 19;
            btnSeatA1.Text = "A1";
            btnSeatA1.UseVisualStyleBackColor = true;
            btnSeatA1.Click += SeatButton_Click;
            // 
            // BtnSeatC1
            // 
            BtnSeatC1.Location = new Point(318, 56);
            BtnSeatC1.Margin = new Padding(5);
            BtnSeatC1.Name = "BtnSeatC1";
            BtnSeatC1.Size = new Size(60, 46);
            BtnSeatC1.TabIndex = 20;
            BtnSeatC1.Text = "C1";
            BtnSeatC1.UseVisualStyleBackColor = true;
            BtnSeatC1.Click += SeatButton_Click;
            // 
            // BtnSeatB2
            // 
            BtnSeatB2.Location = new Point(184, 112);
            BtnSeatB2.Margin = new Padding(5);
            BtnSeatB2.Name = "BtnSeatB2";
            BtnSeatB2.Size = new Size(60, 46);
            BtnSeatB2.TabIndex = 21;
            BtnSeatB2.Text = "B2";
            BtnSeatB2.UseVisualStyleBackColor = true;
            BtnSeatB2.Click += SeatButton_Click;
            // 
            // BtnSeatA2
            // 
            BtnSeatA2.Location = new Point(114, 112);
            BtnSeatA2.Margin = new Padding(5);
            BtnSeatA2.Name = "BtnSeatA2";
            BtnSeatA2.Size = new Size(60, 46);
            BtnSeatA2.TabIndex = 22;
            BtnSeatA2.Text = "A2";
            BtnSeatA2.UseVisualStyleBackColor = true;
            BtnSeatA2.Click += SeatButton_Click;
            // 
            // BtnSeatB1
            // 
            BtnSeatB1.Location = new Point(184, 56);
            BtnSeatB1.Margin = new Padding(5);
            BtnSeatB1.Name = "BtnSeatB1";
            BtnSeatB1.Size = new Size(60, 46);
            BtnSeatB1.TabIndex = 23;
            BtnSeatB1.Text = "B1";
            BtnSeatB1.UseVisualStyleBackColor = true;
            BtnSeatB1.Click += SeatButton_Click;
            // 
            // BtnSeatB4
            // 
            BtnSeatB4.Location = new Point(184, 254);
            BtnSeatB4.Margin = new Padding(5);
            BtnSeatB4.Name = "BtnSeatB4";
            BtnSeatB4.Size = new Size(60, 46);
            BtnSeatB4.TabIndex = 24;
            BtnSeatB4.Text = "B4";
            BtnSeatB4.UseVisualStyleBackColor = true;
            BtnSeatB4.Click += SeatButton_Click;
            // 
            // BtnSeatA4
            // 
            BtnSeatA4.Location = new Point(114, 254);
            BtnSeatA4.Margin = new Padding(5);
            BtnSeatA4.Name = "BtnSeatA4";
            BtnSeatA4.Size = new Size(60, 46);
            BtnSeatA4.TabIndex = 25;
            BtnSeatA4.Text = "A4";
            BtnSeatA4.UseVisualStyleBackColor = true;
            BtnSeatA4.Click += SeatButton_Click;
            // 
            // BtnSeatB3
            // 
            BtnSeatB3.Location = new Point(184, 200);
            BtnSeatB3.Margin = new Padding(5);
            BtnSeatB3.Name = "BtnSeatB3";
            BtnSeatB3.Size = new Size(60, 46);
            BtnSeatB3.TabIndex = 26;
            BtnSeatB3.Text = "B3";
            BtnSeatB3.UseVisualStyleBackColor = true;
            BtnSeatB3.Click += SeatButton_Click;
            // 
            // BtnSeatA3
            // 
            BtnSeatA3.Location = new Point(114, 200);
            BtnSeatA3.Margin = new Padding(5);
            BtnSeatA3.Name = "BtnSeatA3";
            BtnSeatA3.Size = new Size(60, 46);
            BtnSeatA3.TabIndex = 27;
            BtnSeatA3.Text = "A3";
            BtnSeatA3.UseVisualStyleBackColor = true;
            BtnSeatA3.Click += SeatButton_Click;
            // 
            // BtnSeatD2
            // 
            BtnSeatD2.Location = new Point(388, 112);
            BtnSeatD2.Margin = new Padding(5);
            BtnSeatD2.Name = "BtnSeatD2";
            BtnSeatD2.Size = new Size(60, 46);
            BtnSeatD2.TabIndex = 28;
            BtnSeatD2.Text = "D2";
            BtnSeatD2.UseVisualStyleBackColor = true;
            BtnSeatD2.Click += SeatButton_Click;
            // 
            // BtnSeatC2
            // 
            BtnSeatC2.Location = new Point(318, 112);
            BtnSeatC2.Margin = new Padding(5);
            BtnSeatC2.Name = "BtnSeatC2";
            BtnSeatC2.Size = new Size(60, 46);
            BtnSeatC2.TabIndex = 29;
            BtnSeatC2.Text = "C2";
            BtnSeatC2.UseVisualStyleBackColor = true;
            BtnSeatC2.Click += SeatButton_Click;
            // 
            // BtnSeatD1
            // 
            BtnSeatD1.Location = new Point(388, 59);
            BtnSeatD1.Margin = new Padding(5);
            BtnSeatD1.Name = "BtnSeatD1";
            BtnSeatD1.Size = new Size(60, 46);
            BtnSeatD1.TabIndex = 30;
            BtnSeatD1.Text = "D1";
            BtnSeatD1.UseVisualStyleBackColor = true;
            BtnSeatD1.Click += SeatButton_Click;
            // 
            // BtnSeatB6
            // 
            BtnSeatB6.Location = new Point(184, 366);
            BtnSeatB6.Margin = new Padding(5);
            BtnSeatB6.Name = "BtnSeatB6";
            BtnSeatB6.Size = new Size(60, 46);
            BtnSeatB6.TabIndex = 31;
            BtnSeatB6.Text = "B6";
            BtnSeatB6.UseVisualStyleBackColor = true;
            BtnSeatB6.Click += SeatButton_Click;
            // 
            // BtnSeatA6
            // 
            BtnSeatA6.Location = new Point(114, 366);
            BtnSeatA6.Margin = new Padding(5);
            BtnSeatA6.Name = "BtnSeatA6";
            BtnSeatA6.Size = new Size(60, 46);
            BtnSeatA6.TabIndex = 32;
            BtnSeatA6.Text = "A6";
            BtnSeatA6.UseVisualStyleBackColor = true;
            BtnSeatA6.Click += SeatButton_Click;
            // 
            // BtnSeatB5
            // 
            BtnSeatB5.Location = new Point(184, 310);
            BtnSeatB5.Margin = new Padding(5);
            BtnSeatB5.Name = "BtnSeatB5";
            BtnSeatB5.Size = new Size(60, 46);
            BtnSeatB5.TabIndex = 33;
            BtnSeatB5.Text = "B5";
            BtnSeatB5.UseVisualStyleBackColor = true;
            BtnSeatB5.Click += SeatButton_Click;
            // 
            // BtnSeatA5
            // 
            BtnSeatA5.Location = new Point(114, 310);
            BtnSeatA5.Margin = new Padding(5);
            BtnSeatA5.Name = "BtnSeatA5";
            BtnSeatA5.Size = new Size(60, 46);
            BtnSeatA5.TabIndex = 34;
            BtnSeatA5.Text = "A5";
            BtnSeatA5.UseVisualStyleBackColor = true;
            BtnSeatA5.Click += SeatButton_Click;
            // 
            // BtnSeatC4
            // 
            BtnSeatC4.Location = new Point(318, 254);
            BtnSeatC4.Margin = new Padding(5);
            BtnSeatC4.Name = "BtnSeatC4";
            BtnSeatC4.Size = new Size(60, 46);
            BtnSeatC4.TabIndex = 35;
            BtnSeatC4.Text = "C4";
            BtnSeatC4.UseVisualStyleBackColor = true;
            BtnSeatC4.Click += SeatButton_Click;
            // 
            // BtnSeatD4
            // 
            BtnSeatD4.Location = new Point(388, 254);
            BtnSeatD4.Margin = new Padding(5);
            BtnSeatD4.Name = "BtnSeatD4";
            BtnSeatD4.Size = new Size(60, 46);
            BtnSeatD4.TabIndex = 36;
            BtnSeatD4.Text = "D4";
            BtnSeatD4.UseVisualStyleBackColor = true;
            BtnSeatD4.Click += SeatButton_Click;
            // 
            // BtnSeatD3
            // 
            BtnSeatD3.Location = new Point(388, 200);
            BtnSeatD3.Margin = new Padding(5);
            BtnSeatD3.Name = "BtnSeatD3";
            BtnSeatD3.Size = new Size(60, 46);
            BtnSeatD3.TabIndex = 37;
            BtnSeatD3.Text = "D3";
            BtnSeatD3.UseVisualStyleBackColor = true;
            BtnSeatD3.Click += SeatButton_Click;
            // 
            // BtnSeatC3
            // 
            BtnSeatC3.Location = new Point(318, 200);
            BtnSeatC3.Margin = new Padding(5);
            BtnSeatC3.Name = "BtnSeatC3";
            BtnSeatC3.Size = new Size(60, 46);
            BtnSeatC3.TabIndex = 38;
            BtnSeatC3.Text = "C3";
            BtnSeatC3.UseVisualStyleBackColor = true;
            BtnSeatC3.Click += SeatButton_Click;
            // 
            // BtnSeatC6
            // 
            BtnSeatC6.Location = new Point(318, 366);
            BtnSeatC6.Margin = new Padding(5);
            BtnSeatC6.Name = "BtnSeatC6";
            BtnSeatC6.Size = new Size(60, 46);
            BtnSeatC6.TabIndex = 39;
            BtnSeatC6.Text = "C6";
            BtnSeatC6.UseVisualStyleBackColor = true;
            BtnSeatC6.Click += SeatButton_Click;
            // 
            // BtnSeatC5
            // 
            BtnSeatC5.Location = new Point(318, 310);
            BtnSeatC5.Margin = new Padding(5);
            BtnSeatC5.Name = "BtnSeatC5";
            BtnSeatC5.Size = new Size(60, 46);
            BtnSeatC5.TabIndex = 40;
            BtnSeatC5.Text = "C5";
            BtnSeatC5.UseVisualStyleBackColor = true;
            BtnSeatC5.Click += SeatButton_Click;
            // 
            // BtnSeatD5
            // 
            BtnSeatD5.Location = new Point(388, 310);
            BtnSeatD5.Margin = new Padding(5);
            BtnSeatD5.Name = "BtnSeatD5";
            BtnSeatD5.Size = new Size(60, 46);
            BtnSeatD5.TabIndex = 41;
            BtnSeatD5.Text = "D5";
            BtnSeatD5.UseVisualStyleBackColor = true;
            BtnSeatD5.Click += SeatButton_Click;
            // 
            // BtnSeatD6
            // 
            BtnSeatD6.Location = new Point(388, 366);
            BtnSeatD6.Margin = new Padding(5);
            BtnSeatD6.Name = "BtnSeatD6";
            BtnSeatD6.Size = new Size(60, 46);
            BtnSeatD6.TabIndex = 42;
            BtnSeatD6.Text = "D6";
            BtnSeatD6.UseVisualStyleBackColor = true;
            BtnSeatD6.Click += SeatButton_Click;
            // 
            // LabelSeatsLoc
            // 
            LabelSeatsLoc.AutoSize = true;
            LabelSeatsLoc.BackColor = SystemColors.ControlLight;
            LabelSeatsLoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelSeatsLoc.Location = new Point(202, 0);
            LabelSeatsLoc.Margin = new Padding(5, 0, 5, 0);
            LabelSeatsLoc.Name = "LabelSeatsLoc";
            LabelSeatsLoc.Size = new Size(233, 32);
            LabelSeatsLoc.TabIndex = 43;
            LabelSeatsLoc.Text = "Суудлын байршил";
            // 
            // lblbusinessSeats
            // 
            lblbusinessSeats.AutoSize = true;
            lblbusinessSeats.BackColor = SystemColors.ControlLight;
            lblbusinessSeats.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblbusinessSeats.Location = new Point(236, 22);
            lblbusinessSeats.Margin = new Padding(5, 0, 5, 0);
            lblbusinessSeats.Name = "lblbusinessSeats";
            lblbusinessSeats.Size = new Size(79, 30);
            lblbusinessSeats.TabIndex = 44;
            lblbusinessSeats.Text = "Бизнес";
            // 
            // lblEngiinSeats
            // 
            lblEngiinSeats.AutoSize = true;
            lblEngiinSeats.BackColor = SystemColors.ControlLight;
            lblEngiinSeats.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEngiinSeats.Location = new Point(236, 168);
            lblEngiinSeats.Margin = new Padding(5, 0, 5, 0);
            lblEngiinSeats.Name = "lblEngiinSeats";
            lblEngiinSeats.Size = new Size(82, 30);
            lblEngiinSeats.TabIndex = 45;
            lblEngiinSeats.Text = "Энгийн";
            // 
            // btnSuudalConfirm
            // 
            btnSuudalConfirm.BackColor = SystemColors.InactiveCaption;
            btnSuudalConfirm.Location = new Point(395, 605);
            btnSuudalConfirm.Margin = new Padding(5);
            btnSuudalConfirm.Name = "btnSuudalConfirm";
            btnSuudalConfirm.Size = new Size(218, 46);
            btnSuudalConfirm.TabIndex = 48;
            btnSuudalConfirm.Text = "Баталгаажуулах";
            btnSuudalConfirm.UseVisualStyleBackColor = false;
            btnSuudalConfirm.Click += btnSuudalConfirm_Click;
            // 
            // lblUserInfo
            // 
            lblUserInfo.AutoSize = true;
            lblUserInfo.BackColor = SystemColors.ControlLight;
            lblUserInfo.Location = new Point(0, 285);
            lblUserInfo.Margin = new Padding(5, 0, 5, 0);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(255, 32);
            lblUserInfo.TabIndex = 50;
            lblUserInfo.Text = "Зорчигчийн мэдээлэл";
            // 
            // label3
            // 
            label3.BackColor = SystemColors.ControlLight;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(1171, 142);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(462, 146);
            label3.TabIndex = 53;
            label3.Text = "   Нислэгийн төлөв";
            // 
            // Tolow
            // 
            Tolow.FormattingEnabled = true;
            Tolow.Items.AddRange(new object[] { "Бүртгэж байна", "Онгоцонд сууж байна", "Ниссэн", "Хойшилсон", "Цуцалсан" });
            Tolow.Location = new Point(1195, 195);
            Tolow.Margin = new Padding(5);
            Tolow.Name = "Tolow";
            Tolow.Size = new Size(243, 40);
            Tolow.TabIndex = 54;
            Tolow.SelectedIndexChanged += Tolow_SelectedIndexChanged;
            // 
            // btnChangeTolow
            // 
            btnChangeTolow.Location = new Point(1450, 195);
            btnChangeTolow.Margin = new Padding(5);
            btnChangeTolow.Name = "btnChangeTolow";
            btnChangeTolow.Size = new Size(153, 46);
            btnChangeTolow.TabIndex = 55;
            btnChangeTolow.Text = "Солих";
            btnChangeTolow.UseVisualStyleBackColor = true;
            btnChangeTolow.Click += btnChangeTolow_Click;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = SystemColors.ActiveCaptionText;
            btnPrint.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrint.ForeColor = SystemColors.ControlLightLight;
            btnPrint.Location = new Point(1171, 308);
            btnPrint.Margin = new Padding(5);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(408, 122);
            btnPrint.TabIndex = 56;
            btnPrint.Text = "Тасалбар хэвлэх";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // userLbl
            // 
            userLbl.AutoSize = true;
            userLbl.Location = new Point(973, 42);
            userLbl.Name = "userLbl";
            userLbl.Size = new Size(177, 32);
            userLbl.TabIndex = 57;
            userLbl.Text = "Ажилтан";
            // 
            // flightNumComboBox
            // 
            flightNumComboBox.FormattingEnabled = true;
            flightNumComboBox.Location = new Point(210, 38);
            flightNumComboBox.Name = "flightNumComboBox";
            flightNumComboBox.Size = new Size(241, 40);
            flightNumComboBox.TabIndex = 58;
            flightNumComboBox.SelectedIndexChanged += flightNumComboBox_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(LabelSeatsLoc);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btnSuudalConfirm);
            panel1.Location = new Point(510, 142);
            panel1.Name = "panel1";
            panel1.Size = new Size(653, 779);
            panel1.TabIndex = 59;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonFace;
            panel2.Controls.Add(BtnSeatB1);
            panel2.Controls.Add(BtnSeatA6);
            panel2.Controls.Add(lblEngiinSeats);
            panel2.Controls.Add(BtnSeatB5);
            panel2.Controls.Add(BtnSeatB6);
            panel2.Controls.Add(btnSeatA1);
            panel2.Controls.Add(BtnSeatA5);
            panel2.Controls.Add(BtnSeatD1);
            panel2.Controls.Add(lblbusinessSeats);
            panel2.Controls.Add(BtnSeatC4);
            panel2.Controls.Add(BtnSeatC2);
            panel2.Controls.Add(BtnSeatC1);
            panel2.Controls.Add(BtnSeatD4);
            panel2.Controls.Add(BtnSeatD2);
            panel2.Controls.Add(BtnSeatD3);
            panel2.Controls.Add(BtnSeatB2);
            panel2.Controls.Add(BtnSeatA3);
            panel2.Controls.Add(BtnSeatC3);
            panel2.Controls.Add(BtnSeatD6);
            panel2.Controls.Add(BtnSeatB3);
            panel2.Controls.Add(BtnSeatC6);
            panel2.Controls.Add(BtnSeatA2);
            panel2.Controls.Add(BtnSeatA4);
            panel2.Controls.Add(BtnSeatC5);
            panel2.Controls.Add(BtnSeatD5);
            panel2.Controls.Add(BtnSeatB4);
            panel2.Location = new Point(49, 54);
            panel2.Name = "panel2";
            panel2.Size = new Size(564, 533);
            panel2.TabIndex = 60;
            // 
            // listView1
            // 
            listView1.Location = new Point(15, 322);
            listView1.Margin = new Padding(5);
            listView1.Name = "listView1";
            listView1.Size = new Size(436, 279);
            listView1.TabIndex = 60;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // CheckInForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1628, 1037);
            Controls.Add(listView1);
            Controls.Add(panel1);
            Controls.Add(flightNumComboBox);
            Controls.Add(userLbl);
            Controls.Add(btnPrint);
            Controls.Add(btnChangeTolow);
            Controls.Add(Tolow);
            Controls.Add(label3);
            Controls.Add(lblUserInfo);
            Controls.Add(btnPassportSearch);
            Controls.Add(passportNumTxtBx);
            Controls.Add(LblPasswordNumber);
            Controls.Add(lblUserSearch);
            Controls.Add(label1);
            Controls.Add(exitBtn);
            Controls.Add(lblEmployee);
            Controls.Add(lbldate);
            Controls.Add(lblNislegNumber);
            Controls.Add(appbar);
            Margin = new Padding(5);
            Name = "CheckInForm";
            Text = "CheckInForm";
            Load += CheckInForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label appbar;
        private Label lblNislegNumber;
        private Label lbldate;
        private Label lblEmployee;
        private Button exitBtn;
        private Label label1;
        private Label lblUserSearch;
        private Label LblPasswordNumber;
        private TextBox passportNumTxtBx;
        private Button btnPassportSearch;
        private Button btnSeatA1;
        private Button BtnSeatC1;
        private Button BtnSeatB2;
        private Button BtnSeatA2;
        private Button BtnSeatB1;
        private Button BtnSeatB4;
        private Button BtnSeatA4;
        private Button BtnSeatB3;
        private Button BtnSeatA3;
        private Button BtnSeatD2;
        private Button BtnSeatC2;
        private Button BtnSeatD1;
        private Button BtnSeatB6;
        private Button BtnSeatA6;
        private Button BtnSeatB5;
        private Button BtnSeatA5;
        private Button BtnSeatC4;
        private Button BtnSeatD4;
        private Button BtnSeatD3;
        private Button BtnSeatC3;
        private Button BtnSeatC6;
        private Button BtnSeatC5;
        private Button BtnSeatD5;
        private Button BtnSeatD6;
        private Label LabelSeatsLoc;
        private Label lblbusinessSeats;
        private Label lblEngiinSeats;
        private Button btnSuudalConfirm;
        private Label lblUserInfo;
        private Label label3;
        private ComboBox Tolow;
        private Button btnChangeTolow;
        private Button btnPrint;
        private Label userLbl;
        private ComboBox flightNumComboBox;
        private Panel panel1;
        private Panel panel2;
        private ListView listView1;

    }
}