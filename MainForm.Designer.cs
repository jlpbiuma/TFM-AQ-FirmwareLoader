namespace ESP32FirmwareUploader
{
    partial class MainForm
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
            cmbPort = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            cmbBoard = new ComboBox();
            txtSSID = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtPassword = new TextBox();
            label5 = new Label();
            txtMQTTBroker = new TextBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            label8 = new Label();
            txtIDEstacion = new TextBox();
            label6 = new Label();
            txtMQTTPort = new TextBox();
            label7 = new Label();
            txtTemplatePath = new TextBox();
            btnBrowseTemplate = new Button();
            btnBrowseMainFile = new Button();
            label9 = new Label();
            txtMainFilePath = new TextBox();
            btnUpload = new Button();
            groupBox4 = new GroupBox();
            txtLog = new RichTextBox();
            cmbBaudRate = new ComboBox();
            label10 = new Label();
            groupBox5 = new GroupBox();
            label11 = new Label();
            txtSerialOutput = new RichTextBox();
            btnToggleConnection = new Button();
            label12 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // cmbPort
            // 
            cmbPort.FormattingEnabled = true;
            cmbPort.Location = new Point(20, 46);
            cmbPort.Name = "cmbPort";
            cmbPort.Size = new Size(121, 23);
            cmbPort.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 28);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 1;
            label1.Text = "Puerto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 83);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 3;
            label2.Text = "Placa";
            // 
            // cmbBoard
            // 
            cmbBoard.FormattingEnabled = true;
            cmbBoard.Location = new Point(20, 101);
            cmbBoard.Name = "cmbBoard";
            cmbBoard.Size = new Size(121, 23);
            cmbBoard.TabIndex = 2;
            // 
            // txtSSID
            // 
            txtSSID.Location = new Point(20, 44);
            txtSSID.Name = "txtSSID";
            txtSSID.Size = new Size(121, 23);
            txtSSID.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 26);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 5;
            label3.Text = "Nombre de red";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 88);
            label4.Name = "label4";
            label4.Size = new Size(103, 15);
            label4.TabIndex = 7;
            label4.Text = "Contraseña de red";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(20, 106);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(121, 23);
            txtPassword.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 25);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 9;
            label5.Text = "Broker IP";
            // 
            // txtMQTTBroker
            // 
            txtMQTTBroker.Location = new Point(6, 43);
            txtMQTTBroker.Name = "txtMQTTBroker";
            txtMQTTBroker.Size = new Size(121, 23);
            txtMQTTBroker.TabIndex = 8;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbPort);
            groupBox1.Controls.Add(cmbBoard);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 9);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 148);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Upload";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtSSID);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtPassword);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(12, 163);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 143);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Red";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(txtIDEstacion);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(txtMQTTPort);
            groupBox3.Controls.Add(txtMQTTBroker);
            groupBox3.Location = new Point(218, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(300, 145);
            groupBox3.TabIndex = 12;
            groupBox3.TabStop = false;
            groupBox3.Text = "MQTT";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(163, 25);
            label8.Name = "label8";
            label8.Size = new Size(65, 15);
            label8.TabIndex = 16;
            label8.Text = "ID Estacion";
            // 
            // txtIDEstacion
            // 
            txtIDEstacion.Location = new Point(163, 43);
            txtIDEstacion.Name = "txtIDEstacion";
            txtIDEstacion.Size = new Size(121, 23);
            txtIDEstacion.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 80);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 14;
            label6.Text = "Puerto";
            // 
            // txtMQTTPort
            // 
            txtMQTTPort.Location = new Point(6, 98);
            txtMQTTPort.Name = "txtMQTTPort";
            txtMQTTPort.Size = new Size(121, 23);
            txtMQTTPort.TabIndex = 13;
            txtMQTTPort.Text = "1883";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 19);
            label7.Name = "label7";
            label7.Size = new Size(126, 15);
            label7.TabIndex = 18;
            label7.Text = "Plantilla configuración";
            // 
            // txtTemplatePath
            // 
            txtTemplatePath.Location = new Point(6, 37);
            txtTemplatePath.Name = "txtTemplatePath";
            txtTemplatePath.Size = new Size(121, 23);
            txtTemplatePath.TabIndex = 17;
            // 
            // btnBrowseTemplate
            // 
            btnBrowseTemplate.Location = new Point(133, 37);
            btnBrowseTemplate.Name = "btnBrowseTemplate";
            btnBrowseTemplate.Size = new Size(75, 23);
            btnBrowseTemplate.TabIndex = 19;
            btnBrowseTemplate.Text = "Explorar";
            btnBrowseTemplate.UseVisualStyleBackColor = true;
            btnBrowseTemplate.Click += btnBrowseTemplate_Click;
            // 
            // btnBrowseMainFile
            // 
            btnBrowseMainFile.Location = new Point(133, 99);
            btnBrowseMainFile.Name = "btnBrowseMainFile";
            btnBrowseMainFile.Size = new Size(75, 23);
            btnBrowseMainFile.TabIndex = 22;
            btnBrowseMainFile.Text = "Explorar";
            btnBrowseMainFile.UseVisualStyleBackColor = true;
            btnBrowseMainFile.Click += btnBrowseMainFile_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 81);
            label9.Name = "label9";
            label9.Size = new Size(98, 15);
            label9.TabIndex = 21;
            label9.Text = "Plantilla principal";
            // 
            // txtMainFilePath
            // 
            txtMainFilePath.Location = new Point(6, 99);
            txtMainFilePath.Name = "txtMainFilePath";
            txtMainFilePath.Size = new Size(121, 23);
            txtMainFilePath.TabIndex = 20;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(226, 92);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(68, 37);
            btnUpload.TabIndex = 23;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(txtTemplatePath);
            groupBox4.Controls.Add(btnUpload);
            groupBox4.Controls.Add(btnBrowseMainFile);
            groupBox4.Controls.Add(btnBrowseTemplate);
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(txtMainFilePath);
            groupBox4.Location = new Point(218, 163);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(300, 143);
            groupBox4.TabIndex = 24;
            groupBox4.TabStop = false;
            groupBox4.Text = "Plantillas";
            // 
            // txtLog
            // 
            txtLog.Location = new Point(12, 327);
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.Size = new Size(506, 111);
            txtLog.TabIndex = 25;
            txtLog.Text = "";
            // 
            // cmbBaudRate
            // 
            cmbBaudRate.FormattingEnabled = true;
            cmbBaudRate.Location = new Point(6, 41);
            cmbBaudRate.Name = "cmbBaudRate";
            cmbBaudRate.Size = new Size(171, 23);
            cmbBaudRate.TabIndex = 26;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 23);
            label10.Name = "label10";
            label10.Size = new Size(60, 15);
            label10.TabIndex = 27;
            label10.Text = "Baud Rate";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label11);
            groupBox5.Controls.Add(txtSerialOutput);
            groupBox5.Controls.Add(btnToggleConnection);
            groupBox5.Controls.Add(label10);
            groupBox5.Controls.Add(cmbBaudRate);
            groupBox5.Location = new Point(524, 14);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(264, 424);
            groupBox5.TabIndex = 28;
            groupBox5.TabStop = false;
            groupBox5.Text = "Conexión Serie";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 78);
            label11.Name = "label11";
            label11.Size = new Size(62, 15);
            label11.TabIndex = 32;
            label11.Text = "Serial Data";
            // 
            // txtSerialOutput
            // 
            txtSerialOutput.Location = new Point(6, 96);
            txtSerialOutput.Name = "txtSerialOutput";
            txtSerialOutput.ReadOnly = true;
            txtSerialOutput.Size = new Size(252, 322);
            txtSerialOutput.TabIndex = 31;
            txtSerialOutput.Text = "";
            // 
            // btnToggleConnection
            // 
            btnToggleConnection.Location = new Point(183, 41);
            btnToggleConnection.Name = "btnToggleConnection";
            btnToggleConnection.Size = new Size(75, 23);
            btnToggleConnection.TabIndex = 28;
            btnToggleConnection.Text = "Conectar";
            btnToggleConnection.UseVisualStyleBackColor = true;
            btnToggleConnection.Click += btnToggleConnection_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(12, 309);
            label12.Name = "label12";
            label12.Size = new Size(109, 15);
            label12.TabIndex = 33;
            label12.Text = "Uploader messages";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label12);
            Controls.Add(groupBox5);
            Controls.Add(txtLog);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "MainForm";
            Text = "ESP32 Firmware Uploader";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbPort;
        private Label label1;
        private Label label2;
        private ComboBox cmbBoard;
        private TextBox txtSSID;
        private Label label3;
        private Label label4;
        private TextBox txtPassword;
        private Label label5;
        private TextBox txtMQTTBroker;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label6;
        private TextBox txtMQTTPort;
        private Label label8;
        private TextBox txtIDEstacion;
        private Label label7;
        private TextBox txtTemplatePath;
        private Button btnBrowseTemplate;
        private Button btnBrowseMainFile;
        private Label label9;
        private TextBox txtMainFilePath;
        private Button btnUpload;
        private GroupBox groupBox4;
        private RichTextBox txtLog;
        private ComboBox cmbBaudRate;
        private Label label10;
        private GroupBox groupBox5;
        private Button btnToggleConnection;
        private RichTextBox txtSerialOutput;
        private Label label11;
        private Label label12;
    }
}