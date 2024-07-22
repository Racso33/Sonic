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
    public partial class Preferences : Form {
        public Preferences() {
            InitializeComponent();
            textBox1.Text = Program.FfmpegPath;
            textBox2.Text = Program.YtDlpPath;
            textBox3.Text = Program.DownloadLocation;
        }

        private void button2_Click(object sender, EventArgs e) {
            Program.FfmpegPath = textBox1.Text;
            Program.YtDlpPath = textBox2.Text;
            Program.DownloadLocation = textBox3.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
