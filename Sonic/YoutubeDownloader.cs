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
        Playlist res;
        string url;
        string errorlog;
        public static Playlist Extract(string url) {
            var extractor = new PlaylistExtractor(url);
            return extractor.res;
        }
        public PlaylistExtractor(string iurl) {
            url = iurl;
            res = new Playlist();
            var ytDlpProc = new Process();
            ytDlpProc.StartInfo.FileName = Program.YtDlpPath;
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

