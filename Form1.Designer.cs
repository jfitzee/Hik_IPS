namespace Hik_IPS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DeleteCamera = new Button();
            AddCamera = new Button();
            Label8 = new Label();
            Label7 = new Label();
            CameraPort = new TextBox();
            CameraIp = new TextBox();
            Label6 = new Label();
            Label5 = new Label();
            SunsetToday = new TextBox();
            SunriseToday = new TextBox();
            Label4 = new Label();
            Label3 = new Label();
            IpsOff = new Button();
            Label2 = new Label();
            Password = new TextBox();
            Edit = new Button();
            CameraGrid = new DataGridView();
            CamName = new DataGridViewTextBoxColumn();
            ipsIsOn = new DataGridViewTextBoxColumn();
            IpAddress = new DataGridViewTextBoxColumn();
            PortNumber = new DataGridViewTextBoxColumn();
            IpsVersion = new DataGridViewTextBoxColumn();
            SunriseScene = new DataGridViewComboBoxColumn();
            SunriseOffset = new DataGridViewComboBoxColumn();
            SunsetScene = new DataGridViewComboBoxColumn();
            SunsetOffset = new DataGridViewComboBoxColumn();
            IpsOn = new Button();
            Label1 = new Label();
            Username = new TextBox();
            Latitude = new NumericUpDown();
            Longitude = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)CameraGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Latitude).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Longitude).BeginInit();
            SuspendLayout();
            // 
            // DeleteCamera
            // 
            DeleteCamera.Enabled = false;
            DeleteCamera.Location = new Point(505, 226);
            DeleteCamera.Name = "DeleteCamera";
            DeleteCamera.Size = new Size(75, 23);
            DeleteCamera.TabIndex = 10;
            DeleteCamera.Text = "Delete";
            DeleteCamera.UseVisualStyleBackColor = true;
            DeleteCamera.Click += DeleteCamera_Click;
            // 
            // AddCamera
            // 
            AddCamera.Enabled = false;
            AddCamera.Location = new Point(419, 226);
            AddCamera.Name = "AddCamera";
            AddCamera.Size = new Size(75, 23);
            AddCamera.TabIndex = 9;
            AddCamera.Text = "Add";
            AddCamera.UseVisualStyleBackColor = true;
            AddCamera.Click += AddCamera_Click;
            // 
            // Label8
            // 
            Label8.AutoSize = true;
            Label8.Location = new Point(377, 209);
            Label8.Name = "Label8";
            Label8.Size = new Size(29, 15);
            Label8.TabIndex = 53;
            Label8.Text = "Port";
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Location = new Point(279, 207);
            Label7.Name = "Label7";
            Label7.Size = new Size(62, 15);
            Label7.TabIndex = 52;
            Label7.Text = "IP Address";
            // 
            // CameraPort
            // 
            CameraPort.BorderStyle = BorderStyle.FixedSingle;
            CameraPort.Location = new Point(377, 226);
            CameraPort.Name = "CameraPort";
            CameraPort.Size = new Size(36, 23);
            CameraPort.TabIndex = 8;
            CameraPort.TextChanged += CameraPort_TextChanged;
            // 
            // CameraIp
            // 
            CameraIp.BorderStyle = BorderStyle.FixedSingle;
            CameraIp.Location = new Point(283, 226);
            CameraIp.Name = "CameraIp";
            CameraIp.Size = new Size(88, 23);
            CameraIp.TabIndex = 7;
            CameraIp.TextChanged += CameraIp_TextChanged;
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Location = new Point(130, 264);
            Label6.Name = "Label6";
            Label6.Size = new Size(77, 15);
            Label6.TabIndex = 51;
            Label6.Text = "Sunset Today";
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Location = new Point(46, 263);
            Label5.Name = "Label5";
            Label5.Size = new Size(80, 15);
            Label5.TabIndex = 50;
            Label5.Text = "Sunrise Today";
            // 
            // SunsetToday
            // 
            SunsetToday.BorderStyle = BorderStyle.FixedSingle;
            SunsetToday.Enabled = false;
            SunsetToday.Location = new Point(132, 281);
            SunsetToday.Name = "SunsetToday";
            SunsetToday.Size = new Size(77, 23);
            SunsetToday.TabIndex = 49;
            SunsetToday.TabStop = false;
            // 
            // SunriseToday
            // 
            SunriseToday.BorderStyle = BorderStyle.FixedSingle;
            SunriseToday.Enabled = false;
            SunriseToday.Location = new Point(49, 281);
            SunriseToday.Name = "SunriseToday";
            SunriseToday.Size = new Size(77, 23);
            SunriseToday.TabIndex = 48;
            SunriseToday.TabStop = false;
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Location = new Point(46, 210);
            Label4.Name = "Label4";
            Label4.Size = new Size(50, 15);
            Label4.TabIndex = 47;
            Label4.Text = "Latitude";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Location = new Point(129, 210);
            Label3.Name = "Label3";
            Label3.Size = new Size(61, 15);
            Label3.TabIndex = 46;
            Label3.Text = "Longitude";
            // 
            // IpsOff
            // 
            IpsOff.Location = new Point(504, 281);
            IpsOff.Name = "IpsOff";
            IpsOff.Size = new Size(75, 23);
            IpsOff.TabIndex = 3;
            IpsOff.Text = "IPS Off";
            IpsOff.UseVisualStyleBackColor = true;
            IpsOff.Click += IpsOff_Click;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(389, 264);
            Label2.Name = "Label2";
            Label2.Size = new Size(57, 15);
            Label2.TabIndex = 39;
            Label2.Text = "Password";
            // 
            // Password
            // 
            Password.BorderStyle = BorderStyle.FixedSingle;
            Password.Location = new Point(389, 282);
            Password.Name = "Password";
            Password.Size = new Size(100, 23);
            Password.TabIndex = 2;
            Password.UseSystemPasswordChar = true;
            Password.Leave += Password_Leave;
            // 
            // Edit
            // 
            Edit.Location = new Point(589, 226);
            Edit.Name = "Edit";
            Edit.Size = new Size(75, 23);
            Edit.TabIndex = 11;
            Edit.Text = "Edit";
            Edit.UseVisualStyleBackColor = true;
            Edit.Click += Edit_Click;
            // 
            // CameraGrid
            // 
            CameraGrid.AllowUserToAddRows = false;
            CameraGrid.AllowUserToDeleteRows = false;
            CameraGrid.AllowUserToResizeColumns = false;
            CameraGrid.AllowUserToResizeRows = false;
            CameraGrid.BackgroundColor = SystemColors.Control;
            CameraGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CameraGrid.Columns.AddRange(new DataGridViewColumn[] { CamName, ipsIsOn, IpAddress, PortNumber, IpsVersion, SunriseScene, SunriseOffset, SunsetScene, SunsetOffset });
            CameraGrid.EditMode = DataGridViewEditMode.EditOnEnter;
            CameraGrid.Location = new Point(22, 20);
            CameraGrid.MultiSelect = false;
            CameraGrid.Name = "CameraGrid";
            CameraGrid.ReadOnly = true;
            CameraGrid.ScrollBars = ScrollBars.Vertical;
            CameraGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            CameraGrid.ShowEditingIcon = false;
            CameraGrid.Size = new Size(671, 164);
            CameraGrid.TabIndex = 35;
            CameraGrid.TabStop = false;
            // 
            // CamName
            // 
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CamName.DefaultCellStyle = dataGridViewCellStyle1;
            CamName.HeaderText = "Camera Name";
            CamName.Name = "CamName";
            CamName.ReadOnly = true;
            // 
            // ipsIsOn
            // 
            ipsIsOn.HeaderText = "IPS On";
            ipsIsOn.Name = "ipsIsOn";
            ipsIsOn.ReadOnly = true;
            ipsIsOn.Resizable = DataGridViewTriState.True;
            ipsIsOn.Width = 40;
            // 
            // IpAddress
            // 
            IpAddress.HeaderText = "IP Address";
            IpAddress.MaxInputLength = 15;
            IpAddress.Name = "IpAddress";
            IpAddress.ReadOnly = true;
            IpAddress.Resizable = DataGridViewTriState.False;
            IpAddress.Width = 90;
            // 
            // PortNumber
            // 
            PortNumber.HeaderText = "Port";
            PortNumber.MaxInputLength = 5;
            PortNumber.Name = "PortNumber";
            PortNumber.ReadOnly = true;
            PortNumber.Width = 50;
            // 
            // IpsVersion
            // 
            IpsVersion.HeaderText = "IPS Version";
            IpsVersion.Name = "IpsVersion";
            IpsVersion.ReadOnly = true;
            IpsVersion.Resizable = DataGridViewTriState.True;
            IpsVersion.Width = 50;
            // 
            // SunriseScene
            // 
            SunriseScene.HeaderText = "Sunrise Scene";
            SunriseScene.Items.AddRange(new object[] { "Normal", "Morning", "Day", "Nightfall", "Night", "Low Illumination", "Indoor", "Outdoor", "Street", "Back light", "Front light", "Custom1", "Custom2" });
            SunriseScene.Name = "SunriseScene";
            SunriseScene.ReadOnly = true;
            SunriseScene.Resizable = DataGridViewTriState.True;
            SunriseScene.SortMode = DataGridViewColumnSortMode.Automatic;
            SunriseScene.Width = 90;
            // 
            // SunriseOffset
            // 
            SunriseOffset.HeaderText = "Sunrise Offset";
            SunriseOffset.Items.AddRange(new object[] { "-60", "-59", "-58", "-57", "-56", "-55", "-54", "-53", "-52", "-51", "-50", "-49", "-48", "-47", "-46", "-45", "-44", "-43", "-42", "-41", "-40", "-39", "-38", "-37", "-36", "-35", "-34", "-33", "-32", "-31", "-30", "-29", "-28", "-27", "-26", "-25", "-24", "-23", "-22", "-21", "-20", "-19", "-18", "-17", "-16", "-15", "-14", "-13", "-12", "-11", "-10", "-9", "-8", "-7", "-6", "-5", "-4", "-3", "-2", "-1", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60" });
            SunriseOffset.Name = "SunriseOffset";
            SunriseOffset.ReadOnly = true;
            SunriseOffset.Resizable = DataGridViewTriState.True;
            SunriseOffset.SortMode = DataGridViewColumnSortMode.Automatic;
            SunriseOffset.Width = 50;
            // 
            // SunsetScene
            // 
            SunsetScene.HeaderText = "Sunset Scene";
            SunsetScene.Items.AddRange(new object[] { "Normal", "Morning", "Day", "Nightfall", "Night", "Low Illumination", "Indoor", "Outdoor", "Street", "Back light", "Front light", "Custom1", "Custom2" });
            SunsetScene.Name = "SunsetScene";
            SunsetScene.ReadOnly = true;
            SunsetScene.Resizable = DataGridViewTriState.True;
            SunsetScene.SortMode = DataGridViewColumnSortMode.Automatic;
            SunsetScene.Width = 90;
            // 
            // SunsetOffset
            // 
            SunsetOffset.HeaderText = "Sunset Offset";
            SunsetOffset.Items.AddRange(new object[] { "-60", "-59", "-58", "-57", "-56", "-55", "-54", "-53", "-52", "-51", "-50", "-49", "-48", "-47", "-46", "-45", "-44", "-43", "-42", "-41", "-40", "-39", "-38", "-37", "-36", "-35", "-34", "-33", "-32", "-31", "-30", "-29", "-28", "-27", "-26", "-25", "-24", "-23", "-22", "-21", "-20", "-19", "-18", "-17", "-16", "-15", "-14", "-13", "-12", "-11", "-10", "-9", "-8", "-7", "-6", "-5", "-4", "-3", "-2", "-1", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60" });
            SunsetOffset.Name = "SunsetOffset";
            SunsetOffset.ReadOnly = true;
            SunsetOffset.Resizable = DataGridViewTriState.True;
            SunsetOffset.SortMode = DataGridViewColumnSortMode.Automatic;
            SunsetOffset.Width = 50;
            // 
            // IpsOn
            // 
            IpsOn.Location = new Point(588, 281);
            IpsOn.Name = "IpsOn";
            IpsOn.Size = new Size(75, 23);
            IpsOn.TabIndex = 4;
            IpsOn.Text = "IPS On";
            IpsOn.UseVisualStyleBackColor = true;
            IpsOn.Click += IpsOn_Click;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(283, 264);
            Label1.Name = "Label1";
            Label1.Size = new Size(60, 15);
            Label1.TabIndex = 33;
            Label1.Text = "Username";
            // 
            // Username
            // 
            Username.BorderStyle = BorderStyle.FixedSingle;
            Username.Location = new Point(283, 282);
            Username.Name = "Username";
            Username.Size = new Size(100, 23);
            Username.TabIndex = 1;
            Username.Text = "admin";
            Username.Leave += Username_Leave;
            // 
            // Latitude
            // 
            Latitude.BorderStyle = BorderStyle.FixedSingle;
            Latitude.DecimalPlaces = 4;
            Latitude.Location = new Point(49, 226);
            Latitude.Maximum = new decimal(new int[] { 90, 0, 0, 0 });
            Latitude.Minimum = new decimal(new int[] { 90, 0, 0, int.MinValue });
            Latitude.Name = "Latitude";
            Latitude.Size = new Size(77, 23);
            Latitude.TabIndex = 5;
            Latitude.ValueChanged += Latitude_ValueChanged;
            Latitude.Leave += Latitude_Leave;
            // 
            // Longitude
            // 
            Longitude.BorderStyle = BorderStyle.FixedSingle;
            Longitude.DecimalPlaces = 4;
            Longitude.Location = new Point(132, 226);
            Longitude.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            Longitude.Minimum = new decimal(new int[] { 180, 0, 0, int.MinValue });
            Longitude.Name = "Longitude";
            Longitude.Size = new Size(77, 23);
            Longitude.TabIndex = 6;
            Longitude.ValueChanged += Longitude_ValueChanged;
            Longitude.Leave += Longitude_Leave;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(711, 321);
            Controls.Add(Longitude);
            Controls.Add(Latitude);
            Controls.Add(DeleteCamera);
            Controls.Add(AddCamera);
            Controls.Add(Label8);
            Controls.Add(Label7);
            Controls.Add(CameraPort);
            Controls.Add(CameraIp);
            Controls.Add(Label6);
            Controls.Add(Label5);
            Controls.Add(SunsetToday);
            Controls.Add(SunriseToday);
            Controls.Add(Label4);
            Controls.Add(Label3);
            Controls.Add(IpsOff);
            Controls.Add(Label2);
            Controls.Add(Password);
            Controls.Add(Edit);
            Controls.Add(CameraGrid);
            Controls.Add(IpsOn);
            Controls.Add(Label1);
            Controls.Add(Username);
            Name = "Form1";
            Text = "Hik IPS/Scene Settings V1.2";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)CameraGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)Latitude).EndInit();
            ((System.ComponentModel.ISupportInitialize)Longitude).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal Button DeleteCamera;
        internal Button AddCamera;
        internal Label Label8;
        internal Label Label7;
        internal TextBox CameraPort;
        internal TextBox CameraIp;
        internal Label Label6;
        internal Label Label5;
        internal TextBox SunsetToday;
        internal TextBox SunriseToday;
        internal Label Label4;
        internal Label Label3;
        internal Button IpsOff;
        internal Label Label2;
        internal TextBox Password;
        internal Button Edit;
        internal DataGridView CameraGrid;
        internal DataGridViewTextBoxColumn CamName;
        internal DataGridViewTextBoxColumn ipsIsOn;
        internal DataGridViewTextBoxColumn IpAddress;
        internal DataGridViewTextBoxColumn PortNumber;
        internal DataGridViewTextBoxColumn IpsVersion;
        internal DataGridViewComboBoxColumn SunriseScene;
        internal DataGridViewComboBoxColumn SunriseOffset;
        internal DataGridViewComboBoxColumn SunsetScene;
        internal DataGridViewComboBoxColumn SunsetOffset;
        internal Button IpsOn;
        internal Label Label1;
        internal TextBox Username;
        private NumericUpDown Latitude;
        private NumericUpDown Longitude;
    }
}
