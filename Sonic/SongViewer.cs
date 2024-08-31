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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Sonic {
    public partial class SongViewer : UserControl {
        private Playlist _ShownPlaylist;
        private string _Filter;
        public void SetPlaylist(Playlist playlist) {
            _ShownPlaylist = playlist;
            ReloadView();
        }
        public void SetFilter(string s) {
            _Filter = s;
            ReloadView();
        }
        public Playlist GetPlaylist() {
            return _ShownPlaylist;
        }
        public SongViewer() {
            InitializeComponent();
        }
        ListViewItem CreateSongItem(Song song) {
            var item = new ListViewItem(song.Title);
            item.SubItems.Add(song.WatchId);
            item.SubItems.Add(song.DiskPath);
            item.Tag = song;
            return item;
        }
        private bool FilterMatch(string filter, Song song) {
            var res = true;
            foreach(string s in filter.ToLower().Split(" ")) {
                if(!song.Title.ToLower().Contains(s)) {
                    res = false;
                }
            }
            return res;
        }
        public void ReloadView() {
            if(_ShownPlaylist == null) {
                return;
            }
            Program.mainForm.playlistlabel = _ShownPlaylist.Title;
            listView1.Items.Clear();
            foreach (Song s in _ShownPlaylist.Songs) {
                if(_Filter != null && !FilterMatch(_Filter, s)) {
                    continue;
                }
                var item = SongToListItem(s);
                listView1.Items.Add(item);
            }
        }
        ListViewItem SongToListItem(Song song) {
            var res = new ListViewItem(song.Title);
            res.Tag = song;
            res.SubItems.Add(song.WatchId);
            res.SubItems.Add(song.DiskPath);
            return res;
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Right && listView1.SelectedItems.Count > 0) {
                var p = PointToScreen(e.Location);
                ShowContextMenu(p);
            }
        }
        private void ShowContextMenu(Point p) {
            var menu = (ToolStripMenuItem)Program.mainForm.menustrip2.Items.Find("addToToolStripMenuItem", false)[0];
            menu.DropDownItems.Clear();
            foreach(Playlist pl in Program.songdb.Playlists) {
                var item = new ToolStripMenuItem(pl.Title);
                item.Tag = pl;
                item.Click += Item_Click;
                menu.DropDownItems.Add(item);
            }
            Program.mainForm.menustrip2.Show(p);
        }
        private void Item_Click(object? sender, EventArgs e) {
            var p = ((ToolStripMenuItem)sender).Tag as Playlist;
            foreach(ListViewItem s in listView1.SelectedItems) {
                var song = s.Tag as Song;
                p.Songs.Add(song);
            }
        }
        public List<Song> GetSelected() {
            var res = new List<Song>();
            foreach(ListViewItem item in  listView1.SelectedItems) {
                res.Add(item.Tag as Song);
            }
            return res;
        }
    }
}
