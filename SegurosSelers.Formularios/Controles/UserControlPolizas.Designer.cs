namespace SegurosSelers.Formularios.Controles
{
    partial class UserControlPolizas
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
            dataGridViewPolizas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPolizas).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewPolizas
            // 
            dataGridViewPolizas.BackgroundColor = Color.White;
            dataGridViewPolizas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPolizas.Dock = DockStyle.Fill;
            dataGridViewPolizas.GridColor = Color.FromArgb(150, 178, 231);
            dataGridViewPolizas.Location = new Point(0, 0);
            dataGridViewPolizas.Margin = new Padding(4, 5, 4, 5);
            dataGridViewPolizas.Name = "dataGridViewPolizas";
            dataGridViewPolizas.RowHeadersWidth = 62;
            dataGridViewPolizas.Size = new Size(1143, 750);
            dataGridViewPolizas.TabIndex = 0;
            // 
            // UserControlPolizas
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridViewPolizas);
            Margin = new Padding(4, 5, 4, 5);
            Name = "UserControlPolizas";
            Size = new Size(1143, 750);
            ((System.ComponentModel.ISupportInitialize)dataGridViewPolizas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewPolizas;
    }
}