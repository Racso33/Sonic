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
    public partial class PlaylistDialog : Form {
        public Playlist? result;
        public PlaylistDialog() {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            result = YoutubeDownloader.GetPlaylist(textBox1.Text);
            if(result != null) {
                DialogResult = DialogResult.OK;
            }
            Close();
        }
    }
}
