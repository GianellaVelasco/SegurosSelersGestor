namespace SegurosSelers.Formularios.Controles
{
    partial class UserControlSiniestros
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
            dataGridViewSiniestros = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSiniestros).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewSiniestros
            // 
            dataGridViewSiniestros.BackgroundColor = Color.White;
            dataGridViewSiniestros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSiniestros.Dock = DockStyle.Fill;
            dataGridViewSiniestros.GridColor = Color.FromArgb(150, 178, 231);
            dataGridViewSiniestros.Location = new Point(0, 0);
            dataGridViewSiniestros.Margin = new Padding(4, 5, 4, 5);
            dataGridViewSiniestros.Name = "dataGridViewSiniestros";
            dataGridViewSiniestros.RowHeadersWidth = 62;
            dataGridViewSiniestros.Size = new Size(1143, 750);
            dataGridViewSiniestros.TabIndex = 0;
            // 
            // UserControlSiniestros
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridViewSiniestros);
            Margin = new Padding(4, 5, 4, 5);
            Name = "UserControlSiniestros";
            Size = new Size(1143, 750);
            ((System.ComponentModel.ISupportInitialize)dataGridViewSiniestros).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewSiniestros;
    }
}