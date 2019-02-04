namespace Flight_Sim_Toolkit
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.initialiseFlightBtn = new System.Windows.Forms.Button();
            this.initControlsBox2 = new System.Windows.Forms.GroupBox();
            this.aircraftName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.initControlsBox1 = new System.Windows.Forms.GroupBox();
            this.initialiseViaVatsimAPIbtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.onlineNetworkSelect = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cruiseFlightLevelSelect = new System.Windows.Forms.NumericUpDown();
            this.arrivalICAOtextbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.departureICAOtextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.callsignTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flightNumberTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.discordCheckbox = new System.Windows.Forms.CheckBox();
            this.scenariosCheckbox = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.debugTextbox = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.currentStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.initControlsBox2.SuspendLayout();
            this.initControlsBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cruiseFlightLevelSelect)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 419);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.initialiseFlightBtn);
            this.tabPage1.Controls.Add(this.initControlsBox2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.initControlsBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 391);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label12.Location = new System.Drawing.Point(302, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(482, 148);
            this.label12.TabIndex = 9;
            this.label12.Text = "I can show your flight status on Discord!\r\n\r\nCheck the Settings tab for more info" +
    ".";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 7.55F);
            this.label11.Location = new System.Drawing.Point(8, 318);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(288, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "This information CANNOT be changed after clicking Fly";
            // 
            // initialiseFlightBtn
            // 
            this.initialiseFlightBtn.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.initialiseFlightBtn.Location = new System.Drawing.Point(8, 334);
            this.initialiseFlightBtn.Name = "initialiseFlightBtn";
            this.initialiseFlightBtn.Size = new System.Drawing.Size(288, 41);
            this.initialiseFlightBtn.TabIndex = 7;
            this.initialiseFlightBtn.Text = "FLY!";
            this.initialiseFlightBtn.UseVisualStyleBackColor = true;
            this.initialiseFlightBtn.Click += new System.EventHandler(this.initialiseFlightBtn_Click);
            // 
            // initControlsBox2
            // 
            this.initControlsBox2.Controls.Add(this.aircraftName);
            this.initControlsBox2.Controls.Add(this.label7);
            this.initControlsBox2.Location = new System.Drawing.Point(8, 257);
            this.initControlsBox2.Name = "initControlsBox2";
            this.initControlsBox2.Size = new System.Drawing.Size(288, 58);
            this.initControlsBox2.TabIndex = 6;
            this.initControlsBox2.TabStop = false;
            this.initControlsBox2.Text = "Aircraft Information";
            // 
            // aircraftName
            // 
            this.aircraftName.Location = new System.Drawing.Point(132, 22);
            this.aircraftName.MaxLength = 25;
            this.aircraftName.Name = "aircraftName";
            this.aircraftName.Size = new System.Drawing.Size(150, 23);
            this.aircraftName.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "A/C Name/Code *";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(426, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(358, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "All fields marked by an asterisk are required to initialise the program";
            // 
            // initControlsBox1
            // 
            this.initControlsBox1.Controls.Add(this.initialiseViaVatsimAPIbtn);
            this.initControlsBox1.Controls.Add(this.label10);
            this.initControlsBox1.Controls.Add(this.onlineNetworkSelect);
            this.initControlsBox1.Controls.Add(this.label9);
            this.initControlsBox1.Controls.Add(this.label6);
            this.initControlsBox1.Controls.Add(this.cruiseFlightLevelSelect);
            this.initControlsBox1.Controls.Add(this.arrivalICAOtextbox);
            this.initControlsBox1.Controls.Add(this.label8);
            this.initControlsBox1.Controls.Add(this.departureICAOtextbox);
            this.initControlsBox1.Controls.Add(this.label5);
            this.initControlsBox1.Controls.Add(this.callsignTextbox);
            this.initControlsBox1.Controls.Add(this.label2);
            this.initControlsBox1.Controls.Add(this.flightNumberTextbox);
            this.initControlsBox1.Controls.Add(this.label1);
            this.initControlsBox1.Location = new System.Drawing.Point(8, 6);
            this.initControlsBox1.Name = "initControlsBox1";
            this.initControlsBox1.Size = new System.Drawing.Size(288, 243);
            this.initControlsBox1.TabIndex = 3;
            this.initControlsBox1.TabStop = false;
            this.initControlsBox1.Text = "Flight Information";
            // 
            // initialiseViaVatsimAPIbtn
            // 
            this.initialiseViaVatsimAPIbtn.Enabled = false;
            this.initialiseViaVatsimAPIbtn.Location = new System.Drawing.Point(6, 79);
            this.initialiseViaVatsimAPIbtn.Name = "initialiseViaVatsimAPIbtn";
            this.initialiseViaVatsimAPIbtn.Size = new System.Drawing.Size(276, 23);
            this.initialiseViaVatsimAPIbtn.TabIndex = 14;
            this.initialiseViaVatsimAPIbtn.Text = "Get flight info from VATSIM";
            this.initialiseViaVatsimAPIbtn.UseVisualStyleBackColor = true;
            this.initialiseViaVatsimAPIbtn.Click += new System.EventHandler(this.initialiseViaVatsimAPIbtn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 212);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 15);
            this.label10.TabIndex = 13;
            this.label10.Text = "Network *";
            // 
            // onlineNetworkSelect
            // 
            this.onlineNetworkSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.onlineNetworkSelect.FormattingEnabled = true;
            this.onlineNetworkSelect.Items.AddRange(new object[] {
            "Offline",
            "VATSIM",
            "IVAO",
            "Online"});
            this.onlineNetworkSelect.Location = new System.Drawing.Point(160, 209);
            this.onlineNetworkSelect.Name = "onlineNetworkSelect";
            this.onlineNetworkSelect.Size = new System.Drawing.Size(121, 23);
            this.onlineNetworkSelect.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(174, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "FL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cruise level *";
            // 
            // cruiseFlightLevelSelect
            // 
            this.cruiseFlightLevelSelect.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.cruiseFlightLevelSelect.Location = new System.Drawing.Point(199, 180);
            this.cruiseFlightLevelSelect.Maximum = new decimal(new int[] {
            450,
            0,
            0,
            0});
            this.cruiseFlightLevelSelect.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.cruiseFlightLevelSelect.Name = "cruiseFlightLevelSelect";
            this.cruiseFlightLevelSelect.Size = new System.Drawing.Size(82, 23);
            this.cruiseFlightLevelSelect.TabIndex = 10;
            this.cruiseFlightLevelSelect.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // arrivalICAOtextbox
            // 
            this.arrivalICAOtextbox.Location = new System.Drawing.Point(132, 142);
            this.arrivalICAOtextbox.MaxLength = 5;
            this.arrivalICAOtextbox.Name = "arrivalICAOtextbox";
            this.arrivalICAOtextbox.Size = new System.Drawing.Size(150, 23);
            this.arrivalICAOtextbox.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "Arrival airport *";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // departureICAOtextbox
            // 
            this.departureICAOtextbox.Location = new System.Drawing.Point(132, 113);
            this.departureICAOtextbox.MaxLength = 5;
            this.departureICAOtextbox.Name = "departureICAOtextbox";
            this.departureICAOtextbox.Size = new System.Drawing.Size(150, 23);
            this.departureICAOtextbox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Departure airport *";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // callsignTextbox
            // 
            this.callsignTextbox.Location = new System.Drawing.Point(132, 50);
            this.callsignTextbox.MaxLength = 8;
            this.callsignTextbox.Name = "callsignTextbox";
            this.callsignTextbox.Size = new System.Drawing.Size(150, 23);
            this.callsignTextbox.TabIndex = 3;
            this.callsignTextbox.TextChanged += new System.EventHandler(this.callsignTextbox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Callsign";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // flightNumberTextbox
            // 
            this.flightNumberTextbox.Location = new System.Drawing.Point(132, 21);
            this.flightNumberTextbox.MaxLength = 8;
            this.flightNumberTextbox.Name = "flightNumberTextbox";
            this.flightNumberTextbox.Size = new System.Drawing.Size(150, 23);
            this.flightNumberTextbox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Flight number";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 393);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Audio";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(792, 393);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 217);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Miscellaneous";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.discordCheckbox);
            this.flowLayoutPanel1.Controls.Add(this.scenariosCheckbox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(770, 195);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // discordCheckbox
            // 
            this.discordCheckbox.AutoSize = true;
            this.discordCheckbox.Location = new System.Drawing.Point(3, 3);
            this.discordCheckbox.Name = "discordCheckbox";
            this.discordCheckbox.Size = new System.Drawing.Size(145, 19);
            this.discordCheckbox.TabIndex = 0;
            this.discordCheckbox.Text = "Show status in Discord";
            this.discordCheckbox.UseVisualStyleBackColor = true;
            this.discordCheckbox.CheckedChanged += new System.EventHandler(this.SettingChanged);
            // 
            // scenariosCheckbox
            // 
            this.scenariosCheckbox.AutoSize = true;
            this.scenariosCheckbox.Location = new System.Drawing.Point(3, 28);
            this.scenariosCheckbox.Name = "scenariosCheckbox";
            this.scenariosCheckbox.Size = new System.Drawing.Size(170, 19);
            this.scenariosCheckbox.TabIndex = 1;
            this.scenariosCheckbox.Text = "Generate random scenarios";
            this.scenariosCheckbox.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.debugTextbox);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(792, 391);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Debug";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // debugTextbox
            // 
            this.debugTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debugTextbox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debugTextbox.Location = new System.Drawing.Point(3, 3);
            this.debugTextbox.Name = "debugTextbox";
            this.debugTextbox.ReadOnly = true;
            this.debugTextbox.Size = new System.Drawing.Size(786, 385);
            this.debugTextbox.TabIndex = 0;
            this.debugTextbox.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.currentStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(84, 17);
            this.toolStripStatusLabel1.Text = "Current status:";
            // 
            // currentStatusLabel
            // 
            this.currentStatusLabel.Name = "currentStatusLabel";
            this.currentStatusLabel.Size = new System.Drawing.Size(69, 17);
            this.currentStatusLabel.Text = "UNKNOWN";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Flight Sim Toolbox v1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.initControlsBox2.ResumeLayout(false);
            this.initControlsBox2.PerformLayout();
            this.initControlsBox1.ResumeLayout(false);
            this.initControlsBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cruiseFlightLevelSelect)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox discordCheckbox;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RichTextBox debugTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox initControlsBox1;
        private System.Windows.Forms.TextBox callsignTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox flightNumberTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox initControlsBox2;
        private System.Windows.Forms.TextBox aircraftName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox arrivalICAOtextbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox departureICAOtextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown cruiseFlightLevelSelect;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox onlineNetworkSelect;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button initialiseFlightBtn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox scenariosCheckbox;
        private System.Windows.Forms.Button initialiseViaVatsimAPIbtn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel currentStatusLabel;
    }
}

