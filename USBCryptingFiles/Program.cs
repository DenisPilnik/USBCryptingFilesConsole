using USBCryptingFiles.ProgrammFunction;

namespace USBCryptingFiles
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();
            StartProgramm(mainMenu);
            mainMenu.MainMenuDispose();
        }

        private static void StartProgramm(MainMenu menu)
        {
            while (!(menu.OpenMainMenu() is CloseProgramm)){}
        }
    }
}
