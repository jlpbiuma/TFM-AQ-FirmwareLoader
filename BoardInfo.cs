namespace ESP32FirmwareUploader
{
    public class BoardInfo
    {
        public string DisplayName { get; set; }
        public string Fqbn { get; set; }

        public BoardInfo(string displayName, string fqbn)
        {
            DisplayName = displayName;
            Fqbn = fqbn;
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
