namespace SegurosSelers.Formularios.Controles
{
    partial class UserControlUsuarios
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
            dataGridViewUsuarios = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewUsuarios
            // 
            dataGridViewUsuarios.BackgroundColor = Color.White;
            dataGridViewUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsuarios.GridColor = Color.FromArgb(150, 178, 231);
            dataGridViewUsuarios.Location = new Point(0, 0);
            dataGridViewUsuarios.Margin = new Padding(5, 6, 5, 6);
            dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            dataGridViewUsuarios.RowHeadersWidth = 62;
            dataGridViewUsuarios.Size = new Size(1000, 769);
            dataGridViewUsuarios.TabIndex = 0;
            // 
            // UserControlUsuarios
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridViewUsuarios);
            Margin = new Padding(5, 6, 5, 6);
            Name = "UserControlUsuarios";
            Size = new Size(1000, 769);
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUsuarios;
        private Label label1;
    }
}