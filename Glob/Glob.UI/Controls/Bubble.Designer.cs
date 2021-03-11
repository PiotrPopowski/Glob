
namespace Glob.UI.Controls
{
    partial class Bubble
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.messagelbl = new System.Windows.Forms.Label();
            this.timelbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // messagelbl
            // 
            this.messagelbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.messagelbl.ForeColor = System.Drawing.Color.White;
            this.messagelbl.Location = new System.Drawing.Point(0, 5);
            this.messagelbl.Name = "messagelbl";
            this.messagelbl.Size = new System.Drawing.Size(550, 49);
            this.messagelbl.TabIndex = 0;
            this.messagelbl.Text = "Hej, co słychać, żyrafy dużo tych a teraz to już wgl nie wiem ocb persona non gra" +
    "ta hihi he xd literek lorem ipsum mołgbym zastosować";
            // 
            // timelbl
            // 
            this.timelbl.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timelbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.timelbl.Location = new System.Drawing.Point(0, 71);
            this.timelbl.Name = "timelbl";
            this.timelbl.Size = new System.Drawing.Size(550, 15);
            this.timelbl.TabIndex = 1;
            this.timelbl.Text = "26.02.2021 18:15";
            // 
            // Bubble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(100)))), ((int)(((byte)(204)))));
            this.Controls.Add(this.timelbl);
            this.Controls.Add(this.messagelbl);
            this.Name = "Bubble";
            this.Size = new System.Drawing.Size(550, 86);
            this.Resize += new System.EventHandler(this.Bubble_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label messagelbl;
        private System.Windows.Forms.Label timelbl;
    }
}
