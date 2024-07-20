using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sonic {
    public class Song {
        public Song() {

        }
        public bool IsDownloaded;
        public string DiskPath;
        public string WatchId;
        public string Title;
        public string FileName;
        public SongDatabase database;
        //public void OnChange() {
        //    //if (database != null && database.OnSongChange != null) {
        //    //    database.OnSongChange();
        //    //}
        //}
        //public bool IsDownloaded {
        //    set { OnChange(); IsDownloaded = value; }
        //    get { return IsDownloaded; }
        //}
        //public string DiskPath {
        //    set { OnChange(); DiskPath = value; }
        //    get { return DiskPath; }
        //}
        //public string WatchId {
        //    set { OnChange(); WatchId = value; }
        //    get { return WatchId; }
        //}
        //public string Title {
        //    set { OnChange(); Title = value; }
        //    get { return Title; }
        //}
        //public string FileName {
        //    set { OnChange(); FileName = value; }
        //    get { return FileName; }
        //}
        //public SongDatabase database;
    }
    public class Playlist {
        //public SongDatabase database;
        //private string _Title;
        //public string Title {
        //    set {
        //        _Title = value;
        //        OnChange();
        //    }
        //    get { return _Title; }
        //}
        //private string _YoutubeId;
        //public string YoutubeId {
        //    set {
        //        _YoutubeId = value;
        //        OnChange();
        //    }
        //    get { return _YoutubeId; }
        //}
        //private List<Song> _Songs;
        //public List<Song> Songs {
        //    set {
        //        _Songs = value;
        //        OnChange();
        //    }
        //    get { return _Songs; }
        //}
        //void OnChange() {
        //    if (database != null && database.OnPlaylistChange != null) {
        //        database.OnPlaylistChange();
        //    }
        //}
        public SongDatabase database;
        public string Title;
        public string YoutubeId;
        public List<Song> Songs;
        public Playlist() {
            Songs = new List<Song>();
        }
    }

    public class SongDatabase {
        public List<Song> Songs;
        public List<Playlist> Playlists;
        public Action OnPlaylistChange;
        public Action OnSongChange;
        public SongDatabase() {
            Songs = new List<Song>();
            Playlists = new List<Playlist>();
        }
        public Playlist GetAllSongs() {
            var res = new Playlist();
            res.Title = "All Songs";
            res.Songs = Songs;
            return res;
        }
        public void LoadSongDatabase(string dbPath) {
            XmlDocument db = new XmlDocument();
            db.Load(dbPath);
            var songs = db.DocumentElement.SelectSingleNode("/Songs").ChildNodes;
            foreach (XmlNode node in songs) {
                Song song = new Song();

                song.Title = node.SelectSingleNode("Title").InnerText;
                song.WatchId = node.SelectSingleNode("YoutubeId").InnerText;
                song.FileName = node.SelectSingleNode("FileName").InnerText;
                song.DiskPath = node.SelectSingleNode("DiskPath").InnerText;
                Songs.Add(song);

                var playlistnodes = node.SelectSingleNode("Playlists")?.ChildNodes;
                if (playlistnodes != null) {
                    for (int i = 0; i < playlistnodes.Count; i += 2) {
                        var id = playlistnodes[i].InnerText;
                        var title = playlistnodes[i + 1].InnerText;
                        Playlist playlist;
                        if (!PlaylistExists(title)) {
                            playlist = new Playlist();
                            playlist.Title = title;
                            playlist.YoutubeId = id;
                            Playlists.Add(playlist);
                        }
                        else {
                            playlist = GetPlaylist(title);
                        }
                        playlist.Songs.Add(song);
                    }
                }

            }
        }
        public static bool DeleteDirOkNo(string path) {
            var res = MessageBox.Show($"Clearing '{path}'...", "Delete", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK) {
                Directory.Delete(path, true);
                return true;
            }
            return false;
        }
        public void CreatePlaylistDirectory(string path) {
            // go through songs and link the songs to the songs playlists
            foreach (Playlist playlist in Playlists) {
                var playlistTitle = $"{path}\\{playlist.Title}".Replace('?', 'A');
                if(playlistTitle == "" || Directory.Exists(playlistTitle)) {
                    return;
                }
                Directory.CreateDirectory(playlistTitle);
                int i = 0;
                foreach (Song song in playlist.Songs) {
                    var hasExtension = song.Title.LastIndexOf('.');
                    var linkPathE = hasExtension != -1 ? $"{playlistTitle}\\{song.Title}".LastIndexOf('.') : -1;
                    var linkPath = linkPathE != -1 ? $"{playlistTitle}\\{song.Title.Replace(':', '：').Replace('?', '？')}".Substring(0, linkPathE) + ".lnk" : $"{playlistTitle}\\{song.Title.Replace(':', '：').Replace('?', '？').Replace('"', ' ').Replace('/', ' ').Replace('|', ' ')}" + ".lnk";
                    var linkPathFL = linkPath.LastIndexOf("\\") + 1;
                    var linkPathF = linkPath.Substring(linkPathFL, linkPath.Length - linkPathFL);

                    System.IO.File.WriteAllBytes(linkPath, new byte[0]);
                    // Create a ShellLinkObject that references the .lnk file
                    Shell32.Shell shl = new Shell32.Shell();
                    Shell32.Folder dir = shl.NameSpace(playlistTitle);
                    Shell32.FolderItem itm = dir.Items().Item(linkPathF);
                    Shell32.ShellLinkObject lnk = (Shell32.ShellLinkObject)itm.GetLink;
                    // Set the .lnk file properties
                    lnk.Path = song.DiskPath;
                    lnk.Save(linkPath);
                    i++;
                }
            }
        }
        public Playlist? GetPlaylist(string title) {
            foreach (Playlist p in Playlists) {
                if (p.Title == title) {
                    return p;
                }
            }
            return null;
        }
        public bool PlaylistExists(string title) {
            foreach (Playlist p in Playlists) {
                if (p.Title == title) {
                    return true;
                }
            }
            return false;
        }
        public List<Playlist> GetPlaylistsFromSong(Song s) {
            var res = new List<Playlist>();
            foreach (Playlist p in Playlists) {
                foreach (Song s2 in p.Songs) {
                    if (s2.Title == s.Title) {
                        res.Add(p);
                    }
                }
            }
            return res;
        }
    }
}
