namespace draw_line
{
    partial class FormMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.workSpace = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // workSpace
            // 
            this.workSpace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.workSpace.Location = new System.Drawing.Point(12, 12);
            this.workSpace.Name = "workSpace";
            this.workSpace.Size = new System.Drawing.Size(600, 600);
            this.workSpace.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 645);
            this.Controls.Add(this.workSpace);
            this.Name = "FormMain";
            this.Text = "Prinpal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel workSpace;
    }
}

