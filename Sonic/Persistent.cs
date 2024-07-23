using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sonic {

    internal class Persistent {
        /* id songs internally? 
           or just use title.
           then, playlists reference songs with ids.
           One thing that slightly confuses me is, how a song represents a song on disk,
           while also being a thing that exists in memory. Idk for some reason that makes me feel
           a lil weird when imagining.

           The ids are internal to xml file.
           Find song.
           Internal ids wont work, because they become dependent on the songs having been created.
           Having the same title is the most practical. For sure. Also the most simple.
        */
        private XmlDocument db;
        public string XmlFile;
        public Song ToSong(XmlNode node) {
            var si = new Song();
            var title = node.SelectSingleNode("Title");
            si.Title = title.InnerText;
            return si;
        }
        public Song? FindSong(int id) {
            /* returns song object, or node...
            */
            var nodes = db.DocumentElement.SelectNodes("Songs/*");
            foreach(XmlNode n in nodes) {
                var idnode = n.SelectSingleNode("Id");
                if (Int32.Parse(idnode.InnerText) == id) {
                    var song = ToSong(n);
                    return song;
                }
            }
            return null;
        }
        public void SetPlaylists(List<Playlist> p) {

            var playlistnode = db.DocumentElement.SelectSingleNode("Playlists");
            if (playlistnode != null) {
                db.DocumentElement.RemoveChild(playlistnode);
            }
            playlistnode = db.CreateElement("Playlists");
            db.DocumentElement.AppendChild(playlistnode);
            foreach(Playlist pi in p) {
                var node = db.CreateElement("Playlist");
                var title = db.CreateElement("Title");
                var songs = db.CreateElement("Songs");
                foreach(Song s in pi.Songs) {
                    var songssub = db.CreateElement("Song");
                    songssub.InnerText = s.Title;
                    songs.AppendChild(songssub);
                }
                node.AppendChild(songs);
                title.InnerText = pi.Title;
                node.AppendChild(title);
                playlistnode.AppendChild(node);
            }
            db.Save(XmlFile);
        }
        public void SetSongs(List<Song> s) {
            var songsnode = db.DocumentElement.SelectSingleNode("Songs");
            if(songsnode != null) {
                db.DocumentElement.RemoveChild(songsnode);
            }
            songsnode = db.CreateElement("Songs");
            db.DocumentElement.AppendChild(songsnode);
            foreach(Song si in s) {
                var node = db.CreateElement("Song");
                var title = db.CreateElement("Title");
                title.InnerText = si.Title;
                node.AppendChild(title);
                var diskpath = db.CreateElement("DiskPath");
                diskpath.InnerText = si.DiskPath;
                node.AppendChild(diskpath);
                songsnode.AppendChild(node);
            }
            db.Save(XmlFile);
        }
        public void SetYtDlpPath(string path) {
            var ytnode = db.DocumentElement.SelectSingleNode("YtDlpPath");
            if (ytnode != null) {
                db.DocumentElement.RemoveChild(ytnode);
            }
            ytnode = db.CreateElement("YtDlpPath");
            db.DocumentElement.AppendChild(ytnode);
            ytnode.InnerText = path;
            db.Save(XmlFile);
        }
        public void SetFfmpegPath(string path) {
            var ytnode = db.DocumentElement.SelectSingleNode("FfmpegPath");
            if (ytnode != null) {
                db.DocumentElement.RemoveChild(ytnode);
            }
            ytnode = db.CreateElement("FfmpegPath");
            db.DocumentElement.AppendChild(ytnode);
            ytnode.InnerText = path;
            db.Save(XmlFile);
        }
        public void SetDownloadDir(string path) {
            var ytnode = db.DocumentElement.SelectSingleNode("DownloadDir");
            if (ytnode != null) {
                db.DocumentElement.RemoveChild(ytnode);
            }
            ytnode = db.CreateElement("DownloadDir");
            db.DocumentElement.AppendChild(ytnode);
            ytnode.InnerText = path;
            db.Save(XmlFile);
        }
        public void Write() {
            SetSongs(Program.songdb.Songs);
            SetPlaylists(Program.songdb.Playlists);
            SetYtDlpPath(Program.YtDlpPath);
            SetFfmpegPath(Program.FfmpegPath);
            SetDownloadDir(Program.DownloadLocation);
        }
        public List<Song> GetSongs() {
            var res = new List<Song>();
            var nodes = db.DocumentElement.SelectNodes("Songs/*");
            foreach(XmlNode i in nodes) {
                var si = new Song();
                var title = i.SelectSingleNode("Title");
                si.Title = title.InnerText;
                var diskpath = i.SelectSingleNode("DiskPath");
                if(diskpath != null) si.DiskPath = diskpath.InnerText;
                res.Add(si);
            }
            return res;
        }
        public List<Playlist> GetPlaylists() {
            var res = new List<Playlist>();
            var nodes = db.DocumentElement.SelectNodes("Playlists/*");
            foreach (XmlNode i in nodes) {
                var si = new Playlist();
                var title = i.SelectSingleNode("Title");
                si.Title = title.InnerText;
                var songs = i.SelectNodes("Songs/*");
                foreach(XmlNode n in songs) {
                    foreach(Song s in Program.songdb.Songs) {
                        if(n.InnerText == s.Title) {
                            si.Songs.Add(s);
                        }
                    }
                }
                res.Add(si);
            }
            return res;
        }
        public string? GetFfmpegPath() {
            var nodes = db.DocumentElement.SelectSingleNode("FfmpegPath");
            return nodes != null ? nodes.InnerText : null;
        }
        public string? GetDownloadDir() {
            var nodes = db.DocumentElement.SelectSingleNode("DownloadDir");
            return nodes != null ? nodes.InnerText : null;
        }
        public string? GetYtDlpPath() {
            var nodes = db.DocumentElement.SelectSingleNode("YtDlpPath");
            return nodes != null ? nodes.InnerText : null;
        }
        public void Load() {
            Program.songdb.Songs = GetSongs();
            Program.songdb.Playlists = GetPlaylists();
            Program.FfmpegPath = GetFfmpegPath();
            Program.YtDlpPath = GetYtDlpPath();
            Program.DownloadLocation = GetDownloadDir();
        }
        public Persistent(string path) {
            db = new XmlDocument();
            XmlFile = path;
            if(File.Exists(path)) {
                db.Load(path);
            }
            else {
                var n = db.CreateXmlDeclaration("1.0", "UTF-8", null);
                db.InsertBefore(n, db.DocumentElement);
                var root = db.CreateElement("Data");
                db.AppendChild(root);
            }   
        }
    }
}
