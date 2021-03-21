
namespace Glob.UI
{
    partial class RegisterForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.acceptBtn = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.repeatPasswordInput = new System.Windows.Forms.MaskedTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.passwordInput = new System.Windows.Forms.MaskedTextBox();
            this.lastNameInput = new System.Windows.Forms.TextBox();
            this.firstNameInput = new System.Windows.Forms.TextBox();
            this.loginInput = new System.Windows.Forms.TextBox();
            this.topPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(96)))), ((int)(((byte)(176)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Pristina", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(144)))), ((int)(((byte)(47)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(700, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rejestracja";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.cancelBtn);
            this.panel2.Controls.Add(this.acceptBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 567);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 133);
            this.panel2.TabIndex = 2;
            // 
            // cancelBtn
            // 
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Image = ((System.Drawing.Image)(resources.GetObject("cancelBtn.Image")));
            this.cancelBtn.Location = new System.Drawing.Point(629, 18);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(94, 82);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // acceptBtn
            // 
            this.acceptBtn.FlatAppearance.BorderSize = 0;
            this.acceptBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.acceptBtn.Image = ((System.Drawing.Image)(resources.GetObject("acceptBtn.Image")));
            this.acceptBtn.Location = new System.Drawing.Point(323, 18);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(91, 82);
            this.acceptBtn.TabIndex = 0;
            this.acceptBtn.UseVisualStyleBackColor = true;
            this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox5.Location = new System.Drawing.Point(293, 250);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(84, 31);
            this.textBox5.TabIndex = 3;
            this.textBox5.Text = "Hasło";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox4.Location = new System.Drawing.Point(293, 200);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(84, 31);
            this.textBox4.TabIndex = 2;
            this.textBox4.Text = "Nazwisko";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox3.Location = new System.Drawing.Point(293, 150);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(84, 31);
            this.textBox3.TabIndex = 1;
            this.textBox3.Text = "Imię";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Location = new System.Drawing.Point(293, 100);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(84, 31);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "Login";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.repeatPasswordInput);
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Controls.Add(this.textBox5);
            this.panel4.Controls.Add(this.passwordInput);
            this.panel4.Controls.Add(this.textBox4);
            this.panel4.Controls.Add(this.lastNameInput);
            this.panel4.Controls.Add(this.textBox3);
            this.panel4.Controls.Add(this.firstNameInput);
            this.panel4.Controls.Add(this.textBox2);
            this.panel4.Controls.Add(this.loginInput);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 27);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1000, 540);
            this.panel4.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Heading", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(401, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 58);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rejestracja";
            // 
            // repeatPasswordInput
            // 
            this.repeatPasswordInput.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.repeatPasswordInput.Location = new System.Drawing.Point(447, 300);
            this.repeatPasswordInput.Name = "repeatPasswordInput";
            this.repeatPasswordInput.PasswordChar = '•';
            this.repeatPasswordInput.Size = new System.Drawing.Size(204, 34);
            this.repeatPasswordInput.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(293, 300);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(148, 31);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Powtórz hasło";
            // 
            // passwordInput
            // 
            this.passwordInput.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordInput.Location = new System.Drawing.Point(447, 250);
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.PasswordChar = '•';
            this.passwordInput.Size = new System.Drawing.Size(204, 34);
            this.passwordInput.TabIndex = 4;
            this.passwordInput.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.passwordInput_MaskInputRejected);
            // 
            // lastNameInput
            // 
            this.lastNameInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lastNameInput.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lastNameInput.Location = new System.Drawing.Point(447, 200);
            this.lastNameInput.MaxLength = 48;
            this.lastNameInput.Name = "lastNameInput";
            this.lastNameInput.PlaceholderText = "Opcjonalnie";
            this.lastNameInput.Size = new System.Drawing.Size(204, 36);
            this.lastNameInput.TabIndex = 2;
            // 
            // firstNameInput
            // 
            this.firstNameInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.firstNameInput.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.firstNameInput.Location = new System.Drawing.Point(447, 150);
            this.firstNameInput.MaxLength = 48;
            this.firstNameInput.Name = "firstNameInput";
            this.firstNameInput.PlaceholderText = "Opcjonalnie";
            this.firstNameInput.Size = new System.Drawing.Size(204, 36);
            this.firstNameInput.TabIndex = 1;
            // 
            // loginInput
            // 
            this.loginInput.BackColor = System.Drawing.Color.White;
            this.loginInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loginInput.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loginInput.Location = new System.Drawing.Point(447, 100);
            this.loginInput.MaxLength = 48;
            this.loginInput.Name = "loginInput";
            this.loginInput.Size = new System.Drawing.Size(204, 36);
            this.loginInput.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(100)))), ((int)(((byte)(204)))));
            this.topPanel.Controls.Add(this.label2);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(700, 27);
            this.topPanel.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Snap ITC", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(0, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Glob";
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(668, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 27);
            this.button3.TabIndex = 3;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RegisterForm";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox lastNameInput;
        private System.Windows.Forms.TextBox firstNameInput;
        private System.Windows.Forms.TextBox loginInput;
        private System.Windows.Forms.MaskedTextBox passwordInput;
        private System.Windows.Forms.Button acceptBtn;
        private System.Windows.Forms.MaskedTextBox repeatPasswordInput;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}