namespace MySnake
{
    partial class Form1
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
            this.view = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            this.SuspendLayout();
            // 
            // view
            // 
            this.view.BackColor = System.Drawing.Color.Black;
            this.view.Location = new System.Drawing.Point(-1, 0);
            this.view.Name = "view";
            this.view.Size = new System.Drawing.Size(800, 640);
            this.view.TabIndex = 0;
            this.view.TabStop = false;
            this.view.Click += new System.EventHandler(this.view_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(799, 640);
            this.Controls.Add(this.view);
            this.Name = "Form1";
            this.Text = "MySnake";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox view;
    }
}

