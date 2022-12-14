using System;
using System.Collections.Generic;
using System.Management;

namespace USBCryptingFiles.ProgrammFunction
{
    public class FindUsb
    {
        public USBInfo FindUsbDevices() 
        {
            var UsbDevices = GetUSBInfos();
            if(UsbDevices != null)
                Console.WriteLine("USB list : ");
            foreach (var usbDevice in UsbDevices)
            {
                Console.WriteLine("{0}. USB : {1}",
                    UsbDevices.IndexOf(usbDevice) + 1, usbDevice.Description);
            }
            if (UsbDevices != null)
                Console.WriteLine("{0}. Go to main menu", UsbDevices.Count + 1);
            if (UsbDevices.Count > 0)
                return SelectUSB(UsbDevices);
            else
            {
                Console.WriteLine("USB not found");
                return null;
            }
        }

        private USBInfo SelectUSB(List<USBInfo> usbList)
        {
            USBInfo usb = null;

            while(usb == null)
            {
                try
                {
                    Console.Write("Select USB : ");
                    int usbIndex = Convert.ToInt32(Console.ReadLine());
                    if (usbIndex == usbList.Count + 1)
                        break;
                    if (usbIndex <= usbList.Count + 1 && usbIndex >= 1)
                        return usbList[usbIndex - 1];
                }
                catch(Exception e){ }
            }
            return null;
        }

        private List<USBInfo> GetUSBInfos()
        {
            ManagementObjectCollection collection;
            List<USBInfo> devices = new List<USBInfo>();
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity"))
                collection = searcher.Get();

            foreach (var device in collection)
            {
                var id = (string)device.GetPropertyValue("DeviceID");
                if (id.StartsWith("USBSTOR", StringComparison.OrdinalIgnoreCase))
                {
                    devices.Add(new USBInfo(
                        (string)device.GetPropertyValue("DeviceID"),
                        (string)device.GetPropertyValue("Name")
                        ));
                }
            }

            collection.Dispose();
            return devices;
        }
    }
}
