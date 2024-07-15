namespace Sonic {
    partial class Export_FileTree {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            button3 = new Button();
            label1 = new Label();
            progressBar1 = new ProgressBar();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(248, 151);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Export!";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(329, 151);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(52, 72);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(271, 23);
            textBox1.TabIndex = 2;
            // 
            // button3
            // 
            button3.Location = new Point(329, 71);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "Browse";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 75);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 4;
            label1.Text = "Path:";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 122);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(392, 23);
            progressBar1.TabIndex = 5;
            // 
            // Export_FileTree
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 186);
            Controls.Add(progressBar1);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Export_FileTree";
            Text = "Export_FileTree";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Button button3;
        private Label label1;
        private ProgressBar progressBar1;
    }
}