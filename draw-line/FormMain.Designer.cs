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
            this.Tittle = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.workSpace = new System.Windows.Forms.PictureBox();
            this.labelAdd = new System.Windows.Forms.Label();
            this.labelBresenham = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.workSpace)).BeginInit();
            this.SuspendLayout();
            // 
            // Tittle
            // 
            this.Tittle.AutoSize = true;
            this.Tittle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tittle.Location = new System.Drawing.Point(164, 22);
            this.Tittle.Name = "Tittle";
            this.Tittle.Size = new System.Drawing.Size(161, 24);
            this.Tittle.TabIndex = 2;
            this.Tittle.Text = "ADD / Bresenham";
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.Location = new System.Drawing.Point(411, 22);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(92, 35);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // workSpace
            // 
            this.workSpace.BackColor = System.Drawing.SystemColors.Window;
            this.workSpace.Location = new System.Drawing.Point(22, 123);
            this.workSpace.Name = "workSpace";
            this.workSpace.Size = new System.Drawing.Size(500, 500);
            this.workSpace.TabIndex = 5;
            this.workSpace.TabStop = false;
            this.workSpace.MouseClick += new System.Windows.Forms.MouseEventHandler(this.workSpace_MouseClick);
            // 
            // labelAdd
            // 
            this.labelAdd.AutoSize = true;
            this.labelAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdd.Location = new System.Drawing.Point(47, 79);
            this.labelAdd.Name = "labelAdd";
            this.labelAdd.Size = new System.Drawing.Size(83, 24);
            this.labelAdd.TabIndex = 6;
            this.labelAdd.Text = "ADD: 0 s";
            // 
            // labelBresenham
            // 
            this.labelBresenham.AutoSize = true;
            this.labelBresenham.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBresenham.Location = new System.Drawing.Point(266, 79);
            this.labelBresenham.Name = "labelBresenham";
            this.labelBresenham.Size = new System.Drawing.Size(141, 24);
            this.labelBresenham.TabIndex = 7;
            this.labelBresenham.Text = "Bresenham: 0 s";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 645);
            this.Controls.Add(this.labelBresenham);
            this.Controls.Add(this.labelAdd);
            this.Controls.Add(this.workSpace);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.Tittle);
            this.Name = "FormMain";
            this.Text = "Prinpal";
            ((System.ComponentModel.ISupportInitialize)(this.workSpace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Tittle;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.PictureBox workSpace;
        private System.Windows.Forms.Label labelAdd;
        private System.Windows.Forms.Label labelBresenham;
    }
}

