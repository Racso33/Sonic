namespace Sonic {
    public partial class MainForm : Form {
        public string playlistlabel { set { label2.Text = value; } }
        public SongViewer songviewer { get { return songViewer3; } }
        public ContextMenuStrip menustrip1 { get { return contextMenuStrip1; } }
        public ContextMenuStrip menustrip2 { get { return contextMenuStrip2; } }
        public ContextMenuStrip menustrip3 { get { return contextMenuStrip3; } }
        public PlaylistViewer playlistviewer { get { return playlistViewer2; } }
        public MainForm() {
            Program.mainForm = this;
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
            playlistviewer.CreateItem();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e) {
            var dialog = new ImportDialog();
            dialog.ShowDialog();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e) {
            var dialog = new Preferences();
            dialog.ShowDialog(this);
        }
    }
}
