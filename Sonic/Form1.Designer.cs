namespace Sonic {
    partial class Form1 {
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
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            listView2 = new ListView();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
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
            toolStripMenuItem1 = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            contextMenuStrip3.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listView1.Location = new Point(562, 57);
            listView1.Name = "listView1";
            listView1.Size = new Size(690, 532);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.MouseDown += listView1_MouseDown;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Vid id";
            columnHeader2.Width = 120;
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4 });
            listView2.LabelEdit = true;
            listView2.Location = new Point(12, 56);
            listView2.Name = "listView2";
            listView2.Size = new Size(544, 533);
            listView2.TabIndex = 1;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            listView2.AfterLabelEdit += listView2_AfterLabelEdit;
            listView2.SelectedIndexChanged += listView2_SelectedIndexChanged;
            listView2.KeyDown += listView2_KeyDown;
            listView2.MouseDown += listView2_MouseDown;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Name";
            columnHeader3.Width = 300;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Yt id";
            columnHeader4.Width = 120;
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
            textBox1.Location = new Point(1005, 28);
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
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.ShowDropDownArrow = false;
            toolStripDropDownButton1.Size = new Size(29, 22);
            toolStripDropDownButton1.Text = "File";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(180, 22);
            toolStripMenuItem1.Text = "Export As File Tree";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 601);
            Controls.Add(toolStrip1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            contextMenuStrip1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            contextMenuStrip3.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ListView listView2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
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
    }
}
