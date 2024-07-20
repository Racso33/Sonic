namespace Sonic {
    partial class MainForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            sfToolStripMenuItem = new ToolStripMenuItem();
            renameToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            contextMenuStrip2 = new ContextMenuStrip(components);
            addToToolStripMenuItem = new ToolStripMenuItem();
            aToolStripMenuItem = new ToolStripMenuItem();
            removeToolStripMenuItem = new ToolStripMenuItem();
            renameToolStripMenuItem1 = new ToolStripMenuItem();
            contextMenuStrip3 = new ContextMenuStrip(components);
            newPlaylistToolStripMenuItem = new ToolStripMenuItem();
            textBox1 = new TextBox();
            toolStrip1 = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            importToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            preferencesToolStripMenuItem = new ToolStripMenuItem();
            songViewer3 = new SongViewer();
            label1 = new Label();
            label2 = new Label();
            playlistViewer2 = new PlaylistViewer();
            contextMenuStrip1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            contextMenuStrip3.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { sfToolStripMenuItem, renameToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(148, 48);
            // 
            // sfToolStripMenuItem
            // 
            sfToolStripMenuItem.Name = "sfToolStripMenuItem";
            sfToolStripMenuItem.Size = new Size(147, 22);
            sfToolStripMenuItem.Text = "Delete Playlist";
            // 
            // renameToolStripMenuItem
            // 
            renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            renameToolStripMenuItem.Size = new Size(147, 22);
            renameToolStripMenuItem.Text = "Rename";
            // 
            // button1
            // 
            button1.Location = new Point(12, 27);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { addToToolStripMenuItem, removeToolStripMenuItem, renameToolStripMenuItem1 });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(118, 70);
            // 
            // addToToolStripMenuItem
            // 
            addToToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aToolStripMenuItem });
            addToToolStripMenuItem.Name = "addToToolStripMenuItem";
            addToToolStripMenuItem.Size = new Size(117, 22);
            addToToolStripMenuItem.Text = "Add To";
            // 
            // aToolStripMenuItem
            // 
            aToolStripMenuItem.Name = "aToolStripMenuItem";
            aToolStripMenuItem.Size = new Size(80, 22);
            aToolStripMenuItem.Text = "a";
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            removeToolStripMenuItem.Size = new Size(117, 22);
            removeToolStripMenuItem.Text = "Remove";
            removeToolStripMenuItem.Click += removeToolStripMenuItem_Click;
            // 
            // renameToolStripMenuItem1
            // 
            renameToolStripMenuItem1.Name = "renameToolStripMenuItem1";
            renameToolStripMenuItem1.Size = new Size(117, 22);
            renameToolStripMenuItem1.Text = "Rename";
            // 
            // contextMenuStrip3
            // 
            contextMenuStrip3.Items.AddRange(new ToolStripItem[] { newPlaylistToolStripMenuItem });
            contextMenuStrip3.Name = "contextMenuStrip3";
            contextMenuStrip3.Size = new Size(139, 26);
            // 
            // newPlaylistToolStripMenuItem
            // 
            newPlaylistToolStripMenuItem.Name = "newPlaylistToolStripMenuItem";
            newPlaylistToolStripMenuItem.Size = new Size(138, 22);
            newPlaylistToolStripMenuItem.Text = "New Playlist";
            newPlaylistToolStripMenuItem.Click += newPlaylistToolStripMenuItem_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1005, 27);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Filter";
            textBox1.Size = new Size(247, 23);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = SystemColors.Control;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1264, 25);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { importToolStripMenuItem, toolStripMenuItem1, toolStripSeparator1, preferencesToolStripMenuItem });
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.ShowDropDownArrow = false;
            toolStripDropDownButton1.Size = new Size(29, 22);
            toolStripDropDownButton1.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(135, 22);
            importToolStripMenuItem.Text = "Import";
            importToolStripMenuItem.Click += importToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(135, 22);
            toolStripMenuItem1.Text = "Export";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(132, 6);
            // 
            // preferencesToolStripMenuItem
            // 
            preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            preferencesToolStripMenuItem.Size = new Size(135, 22);
            preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // songViewer3
            // 
            songViewer3.Location = new Point(503, 56);
            songViewer3.Name = "songViewer3";
            songViewer3.Size = new Size(749, 533);
            songViewer3.TabIndex = 5;
            // 
            // playlistViewer1
            // 
            playlistViewer2.Location = new Point(12, 56);
            playlistViewer2.Name = "playlistViewer1";
            playlistViewer2.Size = new Size(570, 533);
            playlistViewer2.TabIndex = 6;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 6;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(503, 25);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 7;
            label2.Text = "label2";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 601);
            Controls.Add(label2);
            Controls.Add(songViewer3);
            Controls.Add(playlistViewer2);
            Controls.Add(toolStrip1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "Form1";
            contextMenuStrip1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            contextMenuStrip3.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem sfToolStripMenuItem;
        private Button button1;
        private ToolStripMenuItem renameToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem addToToolStripMenuItem;
        private ToolStripMenuItem removeToolStripMenuItem;
        private ToolStripMenuItem renameToolStripMenuItem1;
        private ToolStripMenuItem aToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip3;
        private ToolStripMenuItem newPlaylistToolStripMenuItem;
        private TextBox textBox1;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem toolStripMenuItem1;
        private SongViewer songviewer2;
        private SongViewer songviewer1;
        private SongViewer songViewer3;
        private ToolStripMenuItem importToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem preferencesToolStripMenuItem;
        private Label label1;
        private PlaylistViewer playlistViewer2;
        private Label label2;
    }
}
