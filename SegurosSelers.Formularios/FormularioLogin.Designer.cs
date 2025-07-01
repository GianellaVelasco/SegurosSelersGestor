namespace SegurosSelers.Formularios
{
    partial class FormularioLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioLogin));
            BotonIniciarSesion = new Button();
            label1 = new Label();
            label2 = new Label();
            textBoxEmail = new TextBox();
            textBoxClave = new TextBox();
            label3 = new Label();
            ojito = new PictureBox();
            label4 = new Label();
            splitContainer1 = new SplitContainer();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)ojito).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // BotonIniciarSesion
            // 
            BotonIniciarSesion.BackColor = Color.FromArgb(42, 69, 155);
            BotonIniciarSesion.FlatAppearance.BorderColor = Color.FromArgb(226, 234, 255);
            BotonIniciarSesion.FlatAppearance.MouseDownBackColor = Color.FromArgb(226, 234, 255);
            BotonIniciarSesion.FlatAppearance.MouseOverBackColor = Color.FromArgb(226, 234, 255);
            BotonIniciarSesion.FlatStyle = FlatStyle.Flat;
            BotonIniciarSesion.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotonIniciarSesion.ForeColor = SystemColors.ButtonHighlight;
            BotonIniciarSesion.Location = new Point(74, 277);
            BotonIniciarSesion.Name = "BotonIniciarSesion";
            BotonIniciarSesion.Size = new Size(230, 29);
            BotonIniciarSesion.TabIndex = 0;
            BotonIniciarSesion.Text = "INICIAR SESIÓN";
            BotonIniciarSesion.UseVisualStyleBackColor = false;
            BotonIniciarSesion.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(382, 297);
            label1.Name = "label1";
            label1.Size = new Size(67, 25);
            label1.TabIndex = 1;
            label1.Text = "Email: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(382, 346);
            label2.Name = "label2";
            label2.Size = new Size(67, 25);
            label2.TabIndex = 2;
            label2.Text = "Clave: ";
            // 
            // textBoxEmail
            // 
            textBoxEmail.BackColor = Color.FromArgb(226, 234, 255);
            textBoxEmail.Location = new Point(74, 196);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(232, 23);
            textBoxEmail.TabIndex = 3;
            // 
            // textBoxClave
            // 
            textBoxClave.BackColor = Color.FromArgb(226, 234, 255);
            textBoxClave.Location = new Point(74, 240);
            textBoxClave.Name = "textBoxClave";
            textBoxClave.Size = new Size(232, 23);
            textBoxClave.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Cursor = Cursors.Hand;
            label3.Font = new Font("Segoe UI", 8F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(42, 69, 155);
            label3.Location = new Point(192, 326);
            label3.Name = "label3";
            label3.Size = new Size(85, 13);
            label3.TabIndex = 6;
            label3.Text = "Registrate acá ";
            label3.Click += label3_Click;
            // 
            // ojito
            // 
            ojito.BackgroundImageLayout = ImageLayout.Stretch;
            ojito.Image = Properties.Resources.cerrado;
            ojito.InitialImage = null;
            ojito.Location = new Point(309, 240);
            ojito.Name = "ojito";
            ojito.Size = new Size(31, 19);
            ojito.SizeMode = PictureBoxSizeMode.StretchImage;
            ojito.TabIndex = 7;
            ojito.TabStop = false;
            ojito.Click += ojito_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Cursor = Cursors.Hand;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(42, 69, 155);
            label4.Location = new Point(104, 362);
            label4.Name = "label4";
            label4.Size = new Size(158, 25);
            label4.TabIndex = 11;
            label4.Text = "No tenés cuenta?";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label8);
            splitContainer1.Panel1.Controls.Add(label7);
            splitContainer1.Panel1.Controls.Add(label6);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(pictureBox3);
            splitContainer1.Panel1.Controls.Add(pictureBox2);
            splitContainer1.Panel1.Controls.Add(textBoxClave);
            splitContainer1.Panel1.Controls.Add(textBoxEmail);
            splitContainer1.Panel1.Controls.Add(BotonIniciarSesion);
            splitContainer1.Panel1.Controls.Add(ojito);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pictureBox1);
            splitContainer1.Size = new Size(791, 449);
            splitContainer1.SplitterDistance = 390;
            splitContainer1.SplitterWidth = 3;
            splitContainer1.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Cursor = Cursors.Hand;
            label8.Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(42, 69, 155);
            label8.Location = new Point(104, 326);
            label8.Name = "label8";
            label8.Size = new Size(92, 14);
            label8.TabIndex = 13;
            label8.Text = "No tenes cuenta?";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(74, 224);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(66, 13);
            label7.TabIndex = 12;
            label7.Text = "Contraseña";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(74, 180);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(34, 13);
            label6.TabIndex = 11;
            label6.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(42, 69, 155);
            label5.Location = new Point(74, 143);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(57, 20);
            label5.TabIndex = 10;
            label5.Text = "Sign In";
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(206, 80);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(42, 20);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.abierto;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(154, 71);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(46, 38);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.abierto;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(398, 449);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // FormularioLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(791, 449);
            Controls.Add(splitContainer1);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormularioLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SegurosSelers";
            Load += FormularioLogin_Load;
            ((System.ComponentModel.ISupportInitialize)ojito).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BotonIniciarSesion;
        private Label label1;
        private Label label2;
        private TextBox textBoxEmail;
        private TextBox textBoxClave;
        private Label label3;
        private PictureBox ojito;
        private Label label4;
        private SplitContainer splitContainer1;
        private Label label5;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label label7;
        private Label label6;
        private Label label8;
    }
}
