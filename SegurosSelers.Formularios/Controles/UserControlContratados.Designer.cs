namespace SegurosSelers.Formularios.Controles
{
    partial class UserControlContratados
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
            dataGridViewContratados = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewContratados).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewContratados
            // 
            dataGridViewContratados.BackgroundColor = Color.White;
            dataGridViewContratados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewContratados.Dock = DockStyle.Fill;
            dataGridViewContratados.GridColor = Color.FromArgb(150, 178, 231);
            dataGridViewContratados.Location = new Point(0, 0);
            dataGridViewContratados.Margin = new Padding(4, 5, 4, 5);
            dataGridViewContratados.Name = "dataGridViewContratados";
            dataGridViewContratados.RowHeadersWidth = 62;
            dataGridViewContratados.Size = new Size(1143, 750);
            dataGridViewContratados.TabIndex = 0;
            // 
            // UserControlContratados
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridViewContratados);
            Margin = new Padding(4, 5, 4, 5);
            Name = "UserControlContratados";
            Size = new Size(1143, 750);
            ((System.ComponentModel.ISupportInitialize)dataGridViewContratados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewContratados;
    }
}