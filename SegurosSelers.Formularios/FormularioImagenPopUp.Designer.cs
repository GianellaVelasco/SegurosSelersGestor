namespace SegurosSelers.Formularios
{
    partial class FormularioImagenPopUp
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
            botonVolver = new Button();
            SuspendLayout();
            // 
            // botonVolver
            // 
            botonVolver.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            botonVolver.Location = new Point(119, 298);
            botonVolver.Name = "botonVolver";
            botonVolver.Size = new Size(82, 28);
            botonVolver.TabIndex = 1;
            botonVolver.Text = "Cerrar";
            botonVolver.UseVisualStyleBackColor = true;
            botonVolver.Click += botonVolver_Click;
            // 
            // FormularioImagenPopUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 357);
            Controls.Add(botonVolver);
            Name = "FormularioImagenPopUp";
            Text = "FormularioImagenPopUp";
            ResumeLayout(false);
        }

        #endregion
        private Button botonVolver;
    }
}