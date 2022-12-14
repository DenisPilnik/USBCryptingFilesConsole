
namespace USBCryptingFiles.ProgrammFunction
{
    public class USBInfo
    {
        public USBInfo(string deviceID, string description)
        {
            this.DeviceID = deviceID;
            this.Description = description;
        }
        public string DeviceID { get; private set; }
        public string Description { get; private set; }

    }
}
