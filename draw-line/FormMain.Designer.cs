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
            this.workSpace1 = new System.Windows.Forms.Panel();
            this.workSpace2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // workSpace1
            // 
            this.workSpace1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.workSpace1.Location = new System.Drawing.Point(12, 133);
            this.workSpace1.Name = "workSpace1";
            this.workSpace1.Size = new System.Drawing.Size(500, 500);
            this.workSpace1.TabIndex = 0;
            // 
            // workSpace2
            // 
            this.workSpace2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.workSpace2.Location = new System.Drawing.Point(558, 133);
            this.workSpace2.Name = "workSpace2";
            this.workSpace2.Size = new System.Drawing.Size(500, 500);
            this.workSpace2.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 645);
            this.Controls.Add(this.workSpace2);
            this.Controls.Add(this.workSpace1);
            this.Name = "FormMain";
            this.Text = "Prinpal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel workSpace1;
        private System.Windows.Forms.Panel workSpace2;
    }
}

