using Glob.UI.Controls;
namespace Glob.UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.contactControl1 = new Glob.UI.Controls.ContactControl();
            this.contactControl = new Glob.UI.Controls.ContactControl();
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.optionPanel = new System.Windows.Forms.Panel();
            this.addContactBtn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.contactPanel = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.chatbox1 = new Glob.UI.Controls.Chatbox();
            this.optionPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contactPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // optionPanel
            // 
            this.optionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(139)))), ((int)(((byte)(235)))));
            this.optionPanel.Controls.Add(this.addContactBtn);
            this.optionPanel.Controls.Add(this.panel4);
            this.optionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.optionPanel.Location = new System.Drawing.Point(0, 27);
            this.optionPanel.Name = "optionPanel";
            this.optionPanel.Size = new System.Drawing.Size(1000, 44);
            this.optionPanel.TabIndex = 1;
            // 
            // addContactBtn
            // 
            this.addContactBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.addContactBtn.FlatAppearance.BorderSize = 0;
            this.addContactBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addContactBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addContactBtn.Image = ((System.Drawing.Image)(resources.GetObject("addContactBtn.Image")));
            this.addContactBtn.Location = new System.Drawing.Point(962, 0);
            this.addContactBtn.Name = "addContactBtn";
            this.addContactBtn.Size = new System.Drawing.Size(38, 44);
            this.addContactBtn.TabIndex = 4;
            this.toolTip1.SetToolTip(this.addContactBtn, "Dodaj kontakt");
            this.addContactBtn.UseVisualStyleBackColor = true;
            this.addContactBtn.Click += new System.EventHandler(this.addContactBtn_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(131)))), ((int)(((byte)(222)))));
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.searchBox);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(250, 44);
            this.panel4.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // searchBox
            // 
            this.searchBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchBox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchBox.Location = new System.Drawing.Point(44, 6);
            this.searchBox.MaxLength = 128;
            this.searchBox.Name = "searchBox";
            this.searchBox.PlaceholderText = "Szukaj";
            this.searchBox.Size = new System.Drawing.Size(193, 32);
            this.searchBox.TabIndex = 0;
            // 
            // contactPanel
            // 
            this.contactPanel.AutoScroll = true;
            this.contactPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(250)))));
            this.contactPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.contactPanel.Location = new System.Drawing.Point(0, 71);
            this.contactPanel.Margin = new System.Windows.Forms.Padding(0);
            this.contactPanel.Name = "contactPanel";
            this.contactPanel.Size = new System.Drawing.Size(250, 629);
            this.contactPanel.TabIndex = 2;
                // 
                // contactControl1
                // 
                this.contactControl1.Dock = System.Windows.Forms.DockStyle.Top;
                this.contactControl1.Location = new System.Drawing.Point(0, 39);
                this.contactControl1.Margin = new System.Windows.Forms.Padding(0);
                this.contactControl1.Name = "contactControl1";
                this.contactControl1.Size = new System.Drawing.Size(250, 39);
                this.contactControl1.TabIndex = 3;
                this.contactControl1.Click += new System.EventHandler(this.contactBtn_Click);
                // 
                // contactControl
                // 
                this.contactControl.Dock = System.Windows.Forms.DockStyle.Top;
                this.contactControl.Location = new System.Drawing.Point(0, 0);
                this.contactControl.Margin = new System.Windows.Forms.Padding(0);
                this.contactControl.Name = "contactControl";
                this.contactControl.Size = new System.Drawing.Size(250, 39);
                this.contactControl.TabIndex = 2;
                this.contactControl.Load += new System.EventHandler(this.contactControl_Load);
                this.contactControl.Click += new System.EventHandler(this.contactBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chatbox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(250, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 629);
            this.panel1.TabIndex = 3;
            // 
            // chatbox1
            // 
            this.chatbox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatbox1.Location = new System.Drawing.Point(0, 0);
            this.chatbox1.Name = "chatbox1";
            this.chatbox1.Size = new System.Drawing.Size(750, 629);
            this.chatbox1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.contactPanel);
            this.Controls.Add(this.optionPanel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.optionPanel, 0);
            this.Controls.SetChildIndex(this.contactPanel, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.optionPanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contactPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel optionPanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel contactPanel;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button addContactBtn;
        private System.Windows.Forms.ToolTip toolTip1;
        private Glob.UI.Controls.ContactControl contactControl; // only in DesignMode
        private ContactControl contactControl1;                 // only in DesignMode
        private System.Windows.Forms.Panel panel1;
        private Chatbox chatbox1;
    }
}

