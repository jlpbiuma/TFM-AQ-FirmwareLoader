using System.Diagnostics;
using System.IO.Ports;
using System.Text;


namespace ESP32FirmwareUploader
{
    public partial class MainForm : Form
    {
        private SerialPort serialPort;
        private bool isConnected = false;

        public MainForm()
        {
            InitializeComponent();
            LoadPorts();
            LoadBoards();
            InitializeSerialPort();
            PopulateBaudRateComboBox();
        }

        private void LoadPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            // Load available COM ports
            foreach (string port in ports)
            {
                cmbPort.Items.Add(port);
            }
        }

        private async void LoadBoards()
        {
            // Execute the arduino-cli command to list all boards
            string listBoardsCommand = "board listall";
            string output = await ExecuteCommandAsync(listBoardsCommand, false);

            if (output == null)
            {
                LogMessage("Failed to retrieve the list of boards.");
                return;
            }

            // Split the output into lines
            string[] lines = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Iterate over each line and parse the board name and FQBN
            foreach (string line in lines.Skip(1)) // Skip the first line which contains header
            {
                string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 2)
                {
                    string fqbn = parts.Last();
                    string displayName = string.Join(" ", parts.Take(parts.Length - 1));
                    cmbBoard.Items.Add(new BoardInfo(displayName, fqbn));
                }
            }

            // Select the first board by default
            if (cmbBoard.Items.Count > 0)
            {
                cmbBoard.SelectedIndex = 0;
            }
        }


        private void InitializeSerialPort()
        {
            serialPort = new SerialPort();
            serialPort.DataReceived += SerialPort_DataReceived;
        }

        private void PopulateBaudRateComboBox()
        {
            cmbBaudRate.Items.Add(9600);
            cmbBaudRate.Items.Add(19200);
            cmbBaudRate.Items.Add(38400);
            cmbBaudRate.Items.Add(57600);
            cmbBaudRate.Items.Add(115200);
            cmbBaudRate.SelectedIndex = 0; // Default to 9600
        }

        private void btnBrowseTemplate_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Header Files (*.h)|*.h|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtTemplatePath.Text = openFileDialog.FileName;
            }
        }

        private void btnBrowseMainFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arduino Files (*.ino)|*.ino|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtMainFilePath.Text = openFileDialog.FileName;
            }
        }

        private async void btnUpload_Click(object sender, EventArgs e)
        {
            string ssid = txtSSID.Text;
            string password = txtPassword.Text;
            string mqttBroker = txtMQTTBroker.Text;
            string mqttPort = txtMQTTPort.Text;
            string idEstacion = txtIDEstacion.Text;
            string templatePath = txtTemplatePath.Text;
            string mainFilePath = txtMainFilePath.Text;
            string sketchDir = Path.Combine(Path.GetDirectoryName(mainFilePath), "output");
            string buildDir = Path.Combine(sketchDir, "build");
            string outputDir = Path.Combine(sketchDir, "output");  // Specify the output directory for compiled binaries
            string mainFileName = "output.ino";  // Name the sketch file as output.ino

            if (!Directory.Exists(sketchDir))
            {
                Directory.CreateDirectory(sketchDir);
            }
            if (!Directory.Exists(buildDir))
            {
                Directory.CreateDirectory(buildDir);
            }
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string configOutputPath = Path.Combine(sketchDir, "config.h");

            try
            {
                // Read the template file
                string configContent = File.ReadAllText(templatePath);

                // Replace placeholders with user input
                configContent = configContent
                    .Replace("{SSID}", ssid)
                    .Replace("{PASSWORD}", password)
                    .Replace("{MQTT_BROKER}", mqttBroker)
                    .Replace("{MQTT_PORT}", mqttPort)
                    .Replace("{ID_ESTACION}", idEstacion);

                // Write the modified content to config.h
                File.WriteAllText(configOutputPath, configContent);

                // Copy main.ino to output directory and rename it to output.ino
                string mainFileOutputPath = Path.Combine(sketchDir, mainFileName);
                File.Copy(mainFilePath, mainFileOutputPath, true);

                // Compile and upload using arduino-cli
                BoardInfo selectedBoard = (BoardInfo)cmbBoard.SelectedItem;
                string fqbn = selectedBoard.Fqbn;
                string port = cmbPort.SelectedItem.ToString();

                // Commands
                string compileCommand = $"compile --fqbn \"{fqbn}\" --build-path \"{buildDir}\" --output-dir \"{outputDir}\" \"{sketchDir}\"";
                string uploadCommand = $"upload -p {port} --fqbn \"{fqbn}\" --input-dir \"{outputDir}\"";


                await ExecuteCommandAsync(compileCommand, true);
                await ExecuteCommandAsync(uploadCommand, true);

                // Start automatically the serial communication
                btnToggleConnection_Click(sender, e);

                LogMessage("Upload completed successfully.");
            }
            catch (Exception ex)
            {
                LogMessage($"Error: {ex.Message}");
            }
        }
        private void btnToggleConnection_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isConnected)
                {
                    if (cmbPort.SelectedItem == null)
                    {
                        MessageBox.Show("Please select a port.");
                        return;
                    }

                    if (cmbBaudRate.SelectedItem == null)
                    {
                        MessageBox.Show("Please select a baud rate.");
                        return;
                    }

                    serialPort.PortName = cmbPort.SelectedItem.ToString();
                    serialPort.BaudRate = (int)cmbBaudRate.SelectedItem;
                    serialPort.Open();
                    isConnected = true;
                    btnToggleConnection.Text = "Disconnect";
                }
                else
                {
                    if (serialPort.IsOpen)
                    {
                        serialPort.Close();
                    }
                    isConnected = false;
                    btnToggleConnection.Text = "Connect";
                }
            }
            catch (Exception ex)
            {
                LogMessage("Error: " + ex.Message);
            }
        }

        private async Task<string> ExecuteCommandAsync(string arguments, bool showLogs = true)
        {
            string arduinoCLIDir = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "arduino-cli.exe");

            if (!File.Exists(arduinoCLIDir))
            {
                LogMessage($"Arduino CLI not found at: {arduinoCLIDir}");
                return null;
            }

            LogMessage($"Executing command: {arduinoCLIDir} {arguments}");

            using (Process process = new Process())
            {
                process.StartInfo.FileName = arduinoCLIDir;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                StringBuilder outputBuilder = new StringBuilder();

                if (showLogs)
                {
                    process.OutputDataReceived += (sender, e) =>
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                        {
                            outputBuilder.AppendLine(e.Data);
                            LogMessage(e.Data);
                        }
                    };
                    process.ErrorDataReceived += (sender, e) =>
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                        {
                            LogMessage(e.Data);
                        }
                    };
                }
                else
                {
                    process.OutputDataReceived += (sender, e) =>
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                        {
                            outputBuilder.AppendLine(e.Data);
                        }
                    };
                }

                try
                {
                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    await process.WaitForExitAsync();

                    return outputBuilder.ToString(); // Return the output of the command
                }
                catch (Exception ex)
                {
                    LogMessage($"Exception while executing command: {ex.Message}");
                    return null;
                }
            }
        }






        private void LogMessage(string message)
        {
            if (txtLog.InvokeRequired)
            {
                // If we are not on the UI thread, marshal the call to the UI thread
                txtLog.Invoke(new Action<string>(LogMessage), new object[] { message });
            }
            else
            {
                // If we are on the UI thread, update the control directly
                if (message != null)
                {
                    txtLog.AppendText(message + Environment.NewLine);
                }
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort.ReadExisting();
                Invoke(new Action(() => txtSerialOutput.AppendText(data)));
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => LogMessage("Error: " + ex.Message)));
            }
        }
    }
}
