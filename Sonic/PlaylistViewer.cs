﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sonic {
    public partial class PlaylistViewer : UserControl {
        public PlaylistViewer() {
            InitializeComponent();
            LoadView();
        }

        public void LoadView() {
            listView1.Items.Clear();
            var i = new ListViewItem("All Songs");
            i.Tag = Program.songdb.GetAllSongs();
            listView1.Items.Add(i);
            foreach (Playlist p in Program.songdb.Playlists) {
                var pi = PlaylistToListItem(p);
                listView1.Items.Add(pi);
            }
        }
        public Playlist GetDefaultPlaylist() {
            return listView1.Items[0].Tag as Playlist;
        }
        private ListViewItem PlaylistToListItem(Playlist p) {
            var res = new ListViewItem(p.Title);
            res.SubItems.Add(p.YoutubeId);
            res.Tag = p;
            return res;
        }
        public void CreateItem() {
            var item = new ListViewItem();
            listView1.Items.Add(item);
            item.BeginEdit();
        }
        public List<Playlist> GetSelected() {
            var res = new List<Playlist>();
            foreach(ListViewItem p in listView1.SelectedItems) {
                if (p.Text == "All Songs") continue;
                res.Add(p.Tag as Playlist);
            }
            return res;
        }

        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e) {
            if (e.Label == "" && listView1.Items[e.Item].Tag == null) {
                e.CancelEdit = true;
                LoadView();
            }
            if (e.Label != "" && listView1.Items[e.Item].Tag == null) {
                var item = listView1.Items[e.Item];
                var p = new Playlist();
                p.Title = e.Label;
                item.Tag = p;
                Program.songdb.Playlists.Add(p);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {
            if (listView1.SelectedItems.Count > 0) {
                Program.mainForm.songviewer.SetPlaylist((Playlist)listView1.SelectedItems[0].Tag);
            }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                var p = PointToScreen(e.Location);
                Program.mainForm.menustrip3.Show(p);
            }
        }
    }
}
