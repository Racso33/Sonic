using System.Xml;

namespace Sonic {
    internal static class Program {
        public static SongDatabase songdb;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            songdb = new SongDatabase();
            songdb.LoadSongDatabase("C:\\Users\\oscar\\Documents\\Programs\\Music\\SongDb.xml");

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}