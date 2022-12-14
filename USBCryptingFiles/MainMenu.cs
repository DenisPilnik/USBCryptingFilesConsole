using System;
using USBCryptingFiles.ProgrammFunction;

namespace USBCryptingFiles
{
    public class MainMenu
    {
        private CloseProgramm close = new CloseProgramm();
        private FindUsb usb = new FindUsb();

        public object OpenMainMenu()
        {
            try
            {
                switch (MainMenuText())
                {
                    case Answer.Ecrypt:
                        usb.FindUsbDevices();
                        return null;
                    case Answer.Decrypt:
                        usb.FindUsbDevices();
                        return null;
                    case Answer.Close:
                        close.ClosingProgramm();
                        return close;
                    default:
                        return null;
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }

        private Answer MainMenuText() 
        {
            Console.WriteLine("1. Start Ecrypting");
            Console.WriteLine("2. Start Decrypting");
            Console.WriteLine("3. Close programm");
            Console.Write("Select : ");
            switch (Console.ReadLine())
            {
                case "1":
                    return Answer.Ecrypt;
                case "2":
                    return Answer.Decrypt;
                case "3":
                    return Answer.Close;
                default:
                    return Answer.WrongAnswer;
            }
        }

        public void MainMenuDispose()
        {
            close = null;
        }
    }
}
