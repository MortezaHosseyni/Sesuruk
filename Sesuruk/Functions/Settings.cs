using NAudio.Wave;
using System.Windows.Forms;

namespace Sesuruk.Functions
{
    public class Settings
    {
        public string OutputDevice { get; set; }
        public bool PlayWhenSelect { get; set; }

        private const string FilePath = "settings.json";

        public int GetVirtualCableDeviceIndex()
        {
            for (var i = 0; i < WaveOut.DeviceCount; i++)
            {
                var capabilities = WaveOut.GetCapabilities(i);
                if (capabilities.ProductName.Contains("CABLE Input") || capabilities.ProductName.Contains("Virtual Cable"))
                {
                    return i;
                }
            }

            MessageBox.Show("Virtual audio cable not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return -1000;
        }

        // TODO: Update settings logic
        // TODO: Backup logic
        // TODO: Restore logic
    }
}
