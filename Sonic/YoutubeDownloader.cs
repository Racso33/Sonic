using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sonic {
    internal class YoutubeDownloader {
        /*
        download, getinfo.
        Get songs in a playlist.
        Giving a list of songs. Songs that dont have a disk path. That can be downloaded.
        A playlist? Or List of songs?
        Playlist makes more sense.

        New class which contains the process creation.
        How would this abstraction make my life easier? It would
        give me a way of compartamentalizing code. Theres no reason
        to abstract too much tho. Because this class is the 
        download, getinfo extractor. So theres no reason to make an
        abstraction for the process.

        YtInfoExtractor. Or make a new process
        Process object. Thats reusable.

        Getting info. Idrk what to do. I mean having the CreateYtInfoExtractor
        makes sense because its part of getplaylist. I dont see why I should
        try to abstract that.

        How do I get output. Maybe instead, make thing.
        GetPlaylist gets the playlist. Why would I make an abstraction internally?
        Bottom up. Download info from a playlist. Which involves creating a yt-dlp process.
        Using the yt-dlp process could be a function. I think thats actually logical. Of course.

        Whats the difference between a playlist and song? If you get data from a playlist it 
        should return a playlist. Otherwise return song. Make a function for recieving a playlist
        and one for song? It would have to identify a playlist then. Obviously, a playlist should
        have a unique process called on it. It wouldnt be the same. It would also return a different
        thing. Maybe I could then wrap it in a result thing. Which would either be a playlist or
        song. 
        Playlist process. New object? Or just function? Function is probably for the better. More dynamic.
        Objects are nice sometimes, but its a tool. That shouldnt be overused. Kind of like directories and files.
        Splitting things across directories can be nice. But can also make it harder to navigate.
        Anyways... ExtractPlaylist() -> Playlist
        Whether I create a bunch of useless functions is whatever. 

        Object that 


        TODOOOOO:
        Error reporting
        */
        private static bool CheckYtDlp() {
            return File.Exists(Program.YtDlpPath);
        }
        private static bool CheckFfmpeg() {
            return File.Exists(Program.FfmpegPath);
        }
        private static bool CheckDependencies() {
            var ytdlp = CheckYtDlp();
            var ffmpeg = CheckFfmpeg();
            if (!ytdlp) MessageBox.Show("Missing yt-dlp, you can set it in the preferences");
            if (!ffmpeg) MessageBox.Show("Missing ffmpeg, you can set it in the preferences");
            return ytdlp && ffmpeg;
        }
        public static Playlist? GetPlaylist(string url) {
            /* Fill playlist with title, and songs. And watchid. */
            if (!CheckDependencies()) return null;
            Playlist res = PlaylistExtractor.Extract(url);
            return res;
        }
        public static bool DownloadSong(Song s, string path) {
            if (!CheckDependencies()) return false;
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            var ytDlpProc = new Process();
            ytDlpProc.StartInfo.FileName = $"{Program.YtDlpPath}";
            ytDlpProc.StartInfo.Arguments = $"--ffmpeg-location {Program.FfmpegPath} -P {path} {s.WatchId}";
            ytDlpProc.StartInfo.UseShellExecute = false;
            ytDlpProc.Start();
            ytDlpProc.WaitForExit();
            if(ytDlpProc.ExitCode != 0) return false;
            s.DiskPath = $"{path}\\{s.DiskPath}";
            return true;
        }
    }

    class PlaylistExtractor {
        /* Create, then extract?
           Or, Create, which extracts.
        */
        Playlist res;
        string url;
        string errorlog;
        public static Playlist Extract(string url) {
            /* Create a object that does things */
            var extractor = new PlaylistExtractor(url);
            return extractor.res;
        }
        public PlaylistExtractor(string iurl) {
            url = iurl;
            res = new Playlist();
            var ytDlpProc = new Process();
            ytDlpProc.StartInfo.FileName = "E:\\yt-dlp\\yt-dlp.exe";
            ytDlpProc.StartInfo.Arguments = $"-j {url}";
            ytDlpProc.StartInfo.UseShellExecute = false;
            ytDlpProc.StartInfo.RedirectStandardOutput = true;
            ytDlpProc.OutputDataReceived += Extractor_OnDataRecieve;
            ytDlpProc.Start();
            ytDlpProc.BeginOutputReadLine();
            ytDlpProc.WaitForExit();
            ytDlpProc.CancelOutputRead();
        }
        private void Extractor_OnDataRecieve(object sender, DataReceivedEventArgs args) {
            var jsonString = args.Data;
            try {
                var jsonObject = JsonDocument.Parse(jsonString);
                var song = new Song();
                res.Songs.Add(song);
                AddJsonInfo(song, jsonObject);
            }
            catch {
                errorlog += "Somehting went wrong...\n";
            }
        }
        private void AddJsonInfo(Song song, JsonDocument json) {
            JsonElement watchId;
            JsonElement playlist;
            JsonElement playlistId;
            JsonElement title;
            JsonElement filename;
            if (json.RootElement.TryGetProperty("id", out watchId)) {
                song.WatchId = watchId.GetString();
            }
            if (json.RootElement.TryGetProperty("playlist_title", out playlist) && json.RootElement.TryGetProperty("playlist_id", out playlistId)) {
                res.Title = playlist.GetString();
                res.YoutubeId = playlistId.GetString();
            }
            if (json.RootElement.TryGetProperty("title", out title)) {
                song.Title = title.GetString();
            }
            if(json.RootElement.TryGetProperty("filename", out filename)) {
                song.DiskPath = filename.GetString();
            }
        }
    }
}

