using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sonic {
    public partial class ImportDialog : Form {
        public ImportDialog() {
            InitializeComponent();
        }

        private List<Song> GetSongsFromDir(string path) {
            var files = Directory.EnumerateFileSystemEntries(path);
            List<Song> songs = new List<Song>();
            foreach (string s in files) {
                if (s.EndsWith(".mkv") || s.EndsWith(".webm") || s.EndsWith(".flac")) {
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
            item.Tag = song;
            return item;
        }
        private void button1_Click(object sender, EventArgs e) {
            var dialog = new FolderBrowserDialog();
            var error = dialog.ShowDialog(this);
            if (error != DialogResult.OK) return;
            var songs = GetSongsFromDir(dialog.SelectedPath);
            foreach (Song s in songs) {
                var item = SongToListViewItem(s);
                listView1.Items.Add(item);
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            var items = listView1.SelectedItems;
            foreach (ListViewItem item in items) {
                listView1.Items.Remove(item);
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            foreach (ListViewItem i in listView1.Items) {
                var s = i.Tag as Song;
                var exists = false;
                foreach(Song s2 in Program.songdb.Songs) {
                    if (s.Title == s2.Title) {
                        exists = true;
                    }
                }
                if(!exists) {
                    Program.songdb.Songs.Add(s);
                }
            }
            Program.mainForm.songviewer.ReloadView();
            Close();
        }

    }
}
