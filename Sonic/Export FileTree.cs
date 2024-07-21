using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sonic {
    public partial class Export_FileTree : Form {
        public Export_FileTree() {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) {
            Close();
        }
        private void button1_Click(object sender, EventArgs e) {
            if(textBox1.Text == "") {
                MessageBox.Show(this, "No path specified");
                return;
            }
            if(Directory.Exists(textBox1.Text) && Directory.EnumerateFileSystemEntries(textBox1.Text).Count() > 0) { 
                var r = SongDatabase.DeleteDirOkNo(textBox1.Text);
                if (!r) return;
            }
            Program.songdb.CreatePlaylistDirectory(textBox1.Text);
            progressBar1.Value = 100;
            //double prog=0;
            //var thread = new Thread(() => Program.songdb.CreatePlaylistDirectory(textBox1.Text, out prog));
            //thread.Start();
            //while (prog < 1) {
            //    progressBar1.Value = (int)prog*100;
            //    Thread.Sleep(50);
            //}
            Process.Start("explorer.exe", textBox1.Text);
            Close();
        }

        private void button3_Click(object sender, EventArgs e) {
            var dialog = new FolderBrowserDialog();
            dialog.ShowDialog(this);
            textBox1.Text = dialog.SelectedPath;
        }
    }
}
