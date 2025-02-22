﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sonic {
    public partial class ImportDialog : Form {
        private string filter;
        private List<Song> songs;
        private List<Playlist> playlists;
        public ImportDialog() {
            InitializeComponent();
            songs = new List<Song>();
            playlists = new List<Playlist>();
        }

        private void AddSong(Song song) {
            if(!songs.Exists(s => s.Title == song.Title)) {
                songs.Add(song);
            }
        }
        private void AddPlaylist(Playlist playlist) {
            if (!playlists.Exists(s => s.Title == playlist.Title)) {
                playlists.Add(playlist);
            }
        }
        private List<Song> GetSongsFromDir(string path) {
            var files = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories);
            List<Song> songs = new List<Song>();
            foreach (string s in files) {
                if (s.EndsWith(".mkv") || s.EndsWith(".webm") || s.EndsWith(".flac") || s.EndsWith(".mp3")) {
                    var song = new Song();
                    song.Title = s.Substring(s.LastIndexOf('\\') + 1);
                    song.DiskPath = s;
                    songs.Add(song);
                }
            }
            return songs;
        }
        private ListViewItem SongToListViewItem(Song song) {
            ListViewItem item = new ListViewItem(song.Title);
            var downloaded = item.SubItems.Add(new ListViewItem.ListViewSubItem());
            downloaded.Text = File.Exists(song.DiskPath) ? "Yes" : "No";
            item.Tag = song;
            return item;
        }
        private void button1_Click(object sender, EventArgs e) {
            var dialog = new FolderBrowserDialog();
            var error = dialog.ShowDialog(this);
            if (error != DialogResult.OK) return;
            var songss = GetSongsFromDir(dialog.SelectedPath);
            foreach (Song s in songss) {
                AddSong(s);
            }
            Reload();
        }

        private void button3_Click(object sender, EventArgs e) {
            var items = listView1.SelectedItems;
            foreach (ListViewItem item in items) {
                songs.Remove(item.Tag as Song);
            }
            Reload();
        }

        private void button4_Click(object sender, EventArgs e) {
            var failed = new List<Song>();
            foreach (Song s in songs) {
                var exists = false;
                foreach (Song s2 in Program.songdb.Songs) {
                    if (s.Title == s2.Title) {
                        exists = true;
                    }
                }
                if (!exists) {
                    if(!File.Exists(s.DiskPath)) {
                        /* if this fails, it shouldnt add the song. Also,
                           Show a dialog of the failed song downloads.
                        */
                        if(Program.DownloadLocation == null) {
                            MessageBox.Show("Download location hasnt been set, you can set it in preferences");
                            return;
                        }
                        var downerror = YoutubeDownloader.DownloadSong(s, Program.DownloadLocation);
                        if (!downerror) {
                            failed.Add(s);
                            continue;
                        }
                    }
                    Program.songdb.Songs.Add(s);
                }
            }
            foreach (Playlist p in playlists) {
                var exists = false;
                foreach (Playlist p2 in Program.songdb.Playlists) {
                    if (p.Title == null || p.Title == p2.Title) {
                        exists = true;
                    }
                }
                if (!exists) {
                    Program.songdb.Playlists.Add(p);
                }
            }
            Program.mainForm.songviewer.ReloadView();
            Program.mainForm.playlistviewer.LoadView();
            if(failed.Count > 0) {
                foreach(Song s in failed) {
                    foreach (Playlist p in playlists) {
                        p.Songs.Remove(s);
                    }
                }
                string str = "";
                foreach(Song s in failed) {
                    str += $"{s.Title}\n";
                }
                MessageBox.Show(str, "Downloads that failed", MessageBoxButtons.OK);
            }
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            filter = textBox1.Text;
            Reload();
        }
        private void Reload() {
            listView1.Items.Clear();
            foreach (Song s in songs) {
                if (filter != null && !FilterMatch(filter, s)) {
                    continue;
                }
                var item = SongToListViewItem(s);
                listView1.Items.Add(item);
            }
        }
        private bool FilterMatch(string filter, Song song) {
            var res = true;
            foreach (string s in filter.ToLower().Split(" ")) {
                if (!song.Title.ToLower().Contains(s)) {
                    res = false;
                }
            }
            return res;
        }

        private void button2_Click(object sender, EventArgs e) {
            /* Try and match songs that already exist, and say that they already 
               are downloaded
            */
            PlaylistDialog dialog = new PlaylistDialog();
            dialog.ShowDialog(this);
            if (dialog.DialogResult != DialogResult.OK) return;
            foreach(Song s in dialog.result.Songs) {
                Song song = s;
                foreach (Song s2 in Program.songdb.Songs) {
                    if (s.Title == s2.Title) {
                        song = s2;
                    }
                }
                AddSong(song);
            }
            playlists.Add(dialog.result);
            Reload();
        }
    }
}
