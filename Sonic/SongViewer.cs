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
        public SongViewer() {
            InitializeComponent();
        }
        ListViewItem CreateSongItem(Song song) {
            var item = new ListViewItem(song.Title);
            item.SubItems.Add(song.WatchId);
            item.Tag = song;
            return item;
        }
        void ReloadView() {
            if(_ShownPlaylist == null) {
                return;
            }
            listView1.Items.Clear();
            foreach (Song s in _ShownPlaylist.Songs) {
                if(_Filter != null && !s.Title.StartsWith(_Filter)) {
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
            return res;
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Right && listView1.SelectedItems.Count > 0) {
                ShowContextMenu(e.Location);
            }
        }
        private void ShowContextMenu(Point p) {
            var menu = (ToolStripMenuItem)Program.mainForm.contextMenuStrip2.Items.Find("addToToolStripMenuItem", false)[0];
            menu.DropDownItems.Clear();
            foreach(Playlist pl in Program.songdb.Playlists) {
                var item = new ToolStripMenuItem(pl.Title);
                item.Tag = pl;
                item.Click += Item_Click;
                menu.DropDownItems.Add(item);
            }
            Program.mainForm.contextMenuStrip2.Show(p);
        }
        private void Item_Click(object? sender, EventArgs e) {
            var p = ((ToolStripMenuItem)sender).Tag as Playlist;
            p.Songs.Add((Song)listView1.SelectedItems[0].Tag);
        }
    }
}
