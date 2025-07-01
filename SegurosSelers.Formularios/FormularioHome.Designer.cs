namespace SegurosSelers.Formularios
{
    partial class FormularioHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioHome));
            panelMenu = new Panel();
            pictureBox11 = new PictureBox();
            pbInicioMenu = new Label();
            lblNombreGestor = new Label();
            panel4 = new Panel();
            pictureBox5 = new PictureBox();
            labelCobertura = new Label();
            panel3 = new Panel();
            pictureBox4 = new PictureBox();
            labelSiniestro = new Label();
            panel2 = new Panel();
            pictureBox3 = new PictureBox();
            labelPoliza = new Label();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            labelUsuario = new Label();
            pictureBox10 = new PictureBox();
            label2 = new Label();
            pictureBox8 = new PictureBox();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            pictureBox6 = new PictureBox();
            labelSalir = new Label();
            panelInformacion = new Panel();
            pictureBox7 = new PictureBox();
            panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panelInformacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(206, 227, 255);
            panelMenu.Controls.Add(pictureBox11);
            panelMenu.Controls.Add(pbInicioMenu);
            panelMenu.Controls.Add(lblNombreGestor);
            panelMenu.Controls.Add(panel4);
            panelMenu.Controls.Add(panel3);
            panelMenu.Controls.Add(panel2);
            panelMenu.Controls.Add(panel1);
            panelMenu.Controls.Add(pictureBox10);
            panelMenu.Controls.Add(label2);
            panelMenu.Controls.Add(pictureBox8);
            panelMenu.Controls.Add(pictureBox1);
            panelMenu.Controls.Add(label3);
            panelMenu.Controls.Add(pictureBox6);
            panelMenu.Controls.Add(labelSalir);
            panelMenu.Location = new Point(-2, -1);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(244, 449);
            panelMenu.TabIndex = 7;
            // 
            // pictureBox11
            // 
            pictureBox11.Image = Properties.Resources.home;
            pictureBox11.Location = new Point(131, 407);
            pictureBox11.Name = "pictureBox11";
            pictureBox11.Size = new Size(25, 19);
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.TabIndex = 25;
            pictureBox11.TabStop = false;
            pictureBox11.Click += pbInicioMenu_Click;
            // 
            // pbInicioMenu
            // 
            pbInicioMenu.AutoSize = true;
            pbInicioMenu.Cursor = Cursors.Hand;
            pbInicioMenu.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pbInicioMenu.Location = new Point(171, 410);
            pbInicioMenu.Name = "pbInicioMenu";
            pbInicioMenu.Size = new Size(41, 19);
            pbInicioMenu.TabIndex = 24;
            pbInicioMenu.Text = "Inicio";
            pbInicioMenu.Click += lblInicioMenu_Click;
            // 
            // lblNombreGestor
            // 
            lblNombreGestor.AutoSize = true;
            lblNombreGestor.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreGestor.ForeColor = Color.FromArgb(42, 69, 155);
            lblNombreGestor.Location = new Point(56, 97);
            lblNombreGestor.Name = "lblNombreGestor";
            lblNombreGestor.Size = new Size(100, 19);
            lblNombreGestor.TabIndex = 23;
            lblNombreGestor.Text = "NombreGestor";
            // 
            // panel4
            // 
            panel4.Controls.Add(pictureBox5);
            panel4.Controls.Add(labelCobertura);
            panel4.Location = new Point(2, 218);
            panel4.Margin = new Padding(2);
            panel4.Name = "panel4";
            panel4.Size = new Size(239, 31);
            panel4.TabIndex = 12;
            panel4.MouseEnter += panel4_MouseEnter;
            panel4.MouseLeave += panel4_MouseLeave;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.seguro;
            pictureBox5.Location = new Point(23, 5);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(25, 21);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 13;
            pictureBox5.TabStop = false;
            // 
            // labelCobertura
            // 
            labelCobertura.AutoSize = true;
            labelCobertura.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCobertura.Location = new Point(63, 10);
            labelCobertura.Name = "labelCobertura";
            labelCobertura.Size = new Size(144, 19);
            labelCobertura.TabIndex = 9;
            labelCobertura.Text = "Gestión de coberturas";
            // 
            // panel3
            // 
            panel3.Controls.Add(pictureBox4);
            panel3.Controls.Add(labelSiniestro);
            panel3.Location = new Point(2, 248);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(239, 31);
            panel3.TabIndex = 12;
            panel3.MouseEnter += panel3_MouseEnter;
            panel3.MouseLeave += panel3_MouseLeave;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.siniestro;
            pictureBox4.Location = new Point(23, 5);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(25, 23);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 12;
            pictureBox4.TabStop = false;
            // 
            // labelSiniestro
            // 
            labelSiniestro.AutoSize = true;
            labelSiniestro.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSiniestro.Location = new Point(63, 11);
            labelSiniestro.Name = "labelSiniestro";
            labelSiniestro.Size = new Size(137, 19);
            labelSiniestro.TabIndex = 8;
            labelSiniestro.Text = "Gestión de Siniestros";
            labelSiniestro.Click += labelSiniestro_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(labelPoliza);
            panel2.Location = new Point(2, 188);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(239, 31);
            panel2.TabIndex = 11;
            panel2.MouseEnter += panel2_MouseEnter;
            panel2.MouseLeave += panel2_MouseLeave;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.poliza;
            pictureBox3.Location = new Point(23, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(25, 23);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 11;
            pictureBox3.TabStop = false;
            // 
            // labelPoliza
            // 
            labelPoliza.AutoSize = true;
            labelPoliza.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPoliza.Location = new Point(63, 10);
            labelPoliza.Name = "labelPoliza";
            labelPoliza.Size = new Size(120, 19);
            labelPoliza.TabIndex = 7;
            labelPoliza.Text = "Gestión de pólizas";
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(labelUsuario);
            panel1.Location = new Point(2, 157);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(239, 31);
            panel1.TabIndex = 2;
            panel1.MouseEnter += panel1_MouseEnter_1;
            panel1.MouseLeave += panel1_MouseLeave;
            // 
            // pictureBox2
            // 
            pictureBox2.ErrorImage = null;
            pictureBox2.Image = Properties.Resources.usuario;
            pictureBox2.Location = new Point(23, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(25, 22);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // labelUsuario
            // 
            labelUsuario.AutoSize = true;
            labelUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelUsuario.Location = new Point(63, 8);
            labelUsuario.Name = "labelUsuario";
            labelUsuario.Size = new Size(130, 19);
            labelUsuario.TabIndex = 6;
            labelUsuario.Text = "Gestión de usuarios";
            // 
            // pictureBox10
            // 
            pictureBox10.ErrorImage = null;
            pictureBox10.Image = Properties.Resources.usuario;
            pictureBox10.Location = new Point(25, 94);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(25, 22);
            pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox10.TabIndex = 23;
            pictureBox10.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(42, 69, 155);
            label2.Location = new Point(8, 104);
            label2.Name = "label2";
            label2.Size = new Size(234, 21);
            label2.TabIndex = 22;
            label2.Text = "________________________________";
            // 
            // pictureBox8
            // 
            pictureBox8.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(77, 43);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(42, 20);
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.TabIndex = 21;
            pictureBox8.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(25, 34);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(46, 38);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Cursor = Cursors.Hand;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(42, 69, 155);
            label3.Location = new Point(21, 131);
            label3.Name = "label3";
            label3.Size = new Size(51, 19);
            label3.TabIndex = 19;
            label3.Text = "HOME";
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(25, 407);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(25, 19);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 15;
            pictureBox6.TabStop = false;
            // 
            // labelSalir
            // 
            labelSalir.AutoSize = true;
            labelSalir.Cursor = Cursors.Hand;
            labelSalir.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSalir.Location = new Point(65, 410);
            labelSalir.Name = "labelSalir";
            labelSalir.Size = new Size(34, 19);
            labelSalir.TabIndex = 14;
            labelSalir.Text = "Salir";
            labelSalir.Click += labelSalir_Click;
            // 
            // panelInformacion
            // 
            panelInformacion.BackColor = SystemColors.HighlightText;
            panelInformacion.Controls.Add(pictureBox7);
            panelInformacion.Location = new Point(235, -1);
            panelInformacion.Name = "panelInformacion";
            panelInformacion.Size = new Size(650, 449);
            panelInformacion.TabIndex = 8;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.InitialImage = (Image)resources.GetObject("pictureBox7.InitialImage");
            pictureBox7.Location = new Point(57, 104);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(541, 293);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 0;
            pictureBox7.TabStop = false;
            // 
            // FormularioHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(886, 449);
            Controls.Add(panelInformacion);
            Controls.Add(panelMenu);
            Name = "FormularioHome";
            Text = "FormularioHome";
            Load += FormularioHome_Load;
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panelInformacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelMenu;
        private Label labelUsuario;
        private Label labelCobertura;
        private Label labelSiniestro;
        private Label labelPoliza;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Label labelSalir;
        private PictureBox pictureBox6;
        private Panel panelInformacion;
        private PictureBox pictureBox7;
        private PictureBox pictureBox9;
        private Label label3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox8;
        private Label label2;
        private PictureBox pictureBox10;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Label lblNombreGestor;
        private PictureBox pictureBox11;
        private Label pbInicioMenu;
    }
}