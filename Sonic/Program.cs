using System.Xml;

/* Should app config be in here?
   on one hand, it makes sense. But if you think that the program should be made up of multiple
   objects, then maybe it would make more sense to put the config in the appropriate locations.
   Because the YoutubeDownloader requires both ytdlp and ffmpeg, maybe it makes more sense to have
   those parameters in the YoutubeDownloader object... Im wondering about structure. In the end
   this program fulfills a purpose. The program itself, so should the program or the mainform
   be where things exist? The mainform is the interface, the program is the juice. Or more so,
   the rest of the program is the juice. Any forms are just the interface. Personally, just
   intuitevly, I think it makes sense to have basic stuff like dependency paths here. Or somewhere
   else really. Just right now, I think it makes sense to put it here. Theres no real reason to organize
   too much when its literally a line of code. Also, its kind of like a constant. So whatever. Right?
*/

namespace Sonic {
    internal static class Program {
        public static SongDatabase songdb;
        public static MainForm mainForm;
        public static string FfmpegPath;
        public static string YtDlpPath;
        public static string DownloadLocation;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            songdb = new SongDatabase();
            songdb.LoadSongDatabase("C:\\Users\\oscar\\Documents\\Programs\\Music\\SongDb.xml");
            mainForm = new MainForm();
            Application.Run(mainForm);
        }
    }
}