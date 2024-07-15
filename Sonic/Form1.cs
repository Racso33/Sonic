using System.Security.Policy;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using IWshRuntimeLibrary;

namespace Sonic {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            LoadPlaylistView();
        }
        public enum PlaylistNodeType {
            All, Playlist, Creating
        }
        struct PlaylistNode {
            public object Tag;
            public PlaylistNodeType Type;
            public PlaylistNode(object t, PlaylistNodeType type) {
                Tag = t;
                Type = type;
            }
        }
        ListViewItem CreateSongItem(Song song) {
            var item = new ListViewItem(song.Title);
            item.SubItems.Add(song.WatchId);
            item.Tag = song;
            return item;
        }
        void LoadSongView() {
            listView1.Items.Clear();
            if (listView2.SelectedItems.Count > 0) {
                var p = listView2.SelectedItems[0];
                var tag = (PlaylistNode)p.Tag;
                if (tag.Type == PlaylistNodeType.All) {
                    foreach (Song s in Program.songdb.Songs) {
                        var i = CreateSongItem(s);
                        listView1.Items.Add(i);
                    }
                }
                if (tag.Type == PlaylistNodeType.Playlist) {
                    var pl = (Playlist)tag.Tag;
                    foreach (Song s in pl.Songs) {
                        var i = CreateSongItem(s);
                        listView1.Items.Add(i);
                    }
                }
            }
            else {
                return;
            }
        }
        void LoadPlaylistView() {
            listView2.Items.Clear();
            var a = new ListViewItem("All Songs");
            var atag = new PlaylistNode(null, PlaylistNodeType.All);
            a.Tag = atag;
            listView2.Items.Add(a);
            foreach (Playlist p in Program.songdb.Playlists) {
                var item = new ListViewItem(p.Title);
                var tag = new PlaylistNode(p, PlaylistNodeType.Playlist);
                item.Tag = tag;
                listView2.Items.Add(item);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e) {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e) {
            LoadSongView();
        }
        ListViewItem MakeSongItem(Song song) {
            ListViewItem item = new ListViewItem(song.Title);
            item.SubItems.Add(song.WatchId);
            item.Tag = song;
            return item;
        }

        void OnChangePlaylist(Playlist p) {
            listView1.Items.Clear();
            foreach (Song s in p.Songs) {
                listView1.Items.Add(MakeSongItem(s));
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            //var song = (Song)listView1.SelectedItems[listView1.SelectedItems.Count - 1].Tag;
            //var playlist = (Playlist)((LeftNodeTag)listView2.SelectedItems[listView2.SelectedItems.Count - 1].Tag).Tag;

            //playlist.Songs.Remove(song);
            //OnChangePlaylist(playlist);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void listView1_Click(object sender, EventArgs e) {

        }

        private void listView2_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.F2) {
                listView2.SelectedItems[0].BeginEdit();
            }
        }

        private void listView2_AfterLabelEdit(object sender, LabelEditEventArgs e) {
            var item = listView2.Items[e.Item];
            var tag = (PlaylistNode?)item.Tag;
            if (tag?.Type == PlaylistNodeType.Playlist) {
                var p = (Playlist)tag?.Tag;
                p.Title = e.Label;
            }
            if (tag?.Type == PlaylistNodeType.Creating && e.Label != "") {
                var p = new Playlist();
                p.Title = e.Label;
                Program.songdb.Playlists.Add(p);
            }
            e.CancelEdit = true;
            LoadPlaylistView();
        }

        private void listView2_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right && listView2.SelectedItems.Count > 0) {
                contextMenuStrip1.Show(Cursor.Position);
            }
            if (e.Button == MouseButtons.Right && listView2.SelectedItems.Count == 0) {
                contextMenuStrip3.Show(Cursor.Position);
            }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                ListViewItem? sel = null;
                foreach (ListViewItem i in listView1.Items) {
                    if (i.Selected) {
                        sel = i;
                    }
                }
                if (sel != null) {
                    LoadContextMenuSong((Song)sel.Tag);
                }
            }

        }
        private void LoadContextMenuSong(Song sel) {
            var addto = (ToolStripMenuItem)contextMenuStrip2.Items.Find("addToToolStripMenuItem", false)[0];
            var playlists = Program.songdb.Playlists;
            addto.DropDownItems.Clear();
            foreach (Playlist p in playlists) {
                if (p.Songs.Contains(sel)) {
                    continue;
                }
                var item = new ToolStripMenuItem();
                item.Text = p.Title;
                item.Tag = p;
                item.Click += ContextMenuItemSongPlaylistClick;
                addto.DropDownItems.Add(item);
            }
            contextMenuStrip2.Show(Cursor.Position);
        }

        private void ContextMenuItemSongPlaylistClick(object? sender, EventArgs e) {
            var o = (ToolStripMenuItem)sender;
            var p = (Playlist)o.Tag;
            foreach(ListViewItem s in listView1.SelectedItems) {
                p.Songs.Add((Song)s.Tag);
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e) {
            //var playlisttag = (LeftNodeTag)listView2.SelectedItems[0].Tag;
            //if (playlisttag.NodeType == LeftNodeType.Playlist) {
            //    var playlist = (Playlist)playlisttag.Tag;
            //    var song = (Song)listView1.SelectedItems[0].Tag;
            //    playlist.Songs.Remove(song);
            //    OnChangePlaylist(playlist);
            //}
        }

        private void newPlaylistToolStripMenuItem_Click(object sender, EventArgs e) {
            var item = new ListViewItem();
            var tag = new PlaylistNode(null, PlaylistNodeType.Creating);
            item.Tag = tag;
            listView2.Items.Add(item);
            item.BeginEdit();
        }

        private void textBox1_Leave(object sender, EventArgs e) {
            MessageBox.Show(textBox1.Text);
        }

        private void textBox1_ModifiedChanged(object sender, EventArgs e) {
            MessageBox.Show(textBox1.Text);
        }
        List<Song>? GetSelectedPlaylistSongs() {
            if (listView2.SelectedItems.Count == 0) {
                return null;
            }
            var tag = (PlaylistNode)listView2.SelectedItems[0].Tag;
            if (tag.Type == PlaylistNodeType.Playlist) {
                var p = (Playlist)tag.Tag;
                return p.Songs;
            }
            if (tag.Type == PlaylistNodeType.All) {
                return Program.songdb.Songs;
            }
            return null;
        }
        private void textBox1_TextChanged(object sender, EventArgs e) {
            var songs = GetSelectedPlaylistSongs();
            if (songs == null) {
                return;
            }
            listView1.Items.Clear();
            foreach (Song s in songs) {
                if (s.Title.StartsWith(textBox1.Text)) {
                    var si = CreateSongItem(s);
                    listView1.Items.Add(si);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            var dialog = new Export_FileTree();
            dialog.ShowDialog();
        }

    }
}
