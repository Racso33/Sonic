using System.Security.Policy;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Sonic {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
            songViewer3.SetPlaylist(Program.songdb.Playlists[0]);
        }



        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void textBox1_Leave(object sender, EventArgs e) {
            MessageBox.Show(textBox1.Text);
        }

        private void textBox1_ModifiedChanged(object sender, EventArgs e) {
            MessageBox.Show(textBox1.Text);
        }
        private void textBox1_TextChanged(object sender, EventArgs e) {
            songViewer3.SetFilter(textBox1.Text);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            var dialog = new Export_FileTree();
            dialog.ShowDialog();
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e) {

        }
        private void newPlaylistToolStripMenuItem_Click(object sender, EventArgs e) {
            playlistViewer1.CreateItem();
        }
    }
}
