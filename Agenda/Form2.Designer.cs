
namespace Agenda
{
    partial class Form2
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
            this.confirmTextbox = new System.Windows.Forms.TextBox();
            this.addButtonConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // confirmTextbox
            // 
            this.confirmTextbox.Location = new System.Drawing.Point(12, 12);
            this.confirmTextbox.Name = "confirmTextbox";
            this.confirmTextbox.Size = new System.Drawing.Size(303, 23);
            this.confirmTextbox.TabIndex = 0;
            // 
            // addButtonConfirm
            // 
            this.addButtonConfirm.Location = new System.Drawing.Point(129, 41);
            this.addButtonConfirm.Name = "addButtonConfirm";
            this.addButtonConfirm.Size = new System.Drawing.Size(75, 23);
            this.addButtonConfirm.TabIndex = 1;
            this.addButtonConfirm.Text = "Adicionar";
            this.addButtonConfirm.UseVisualStyleBackColor = true;
            this.addButtonConfirm.Click += new System.EventHandler(this.addButtonConfirm_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 71);
            this.Controls.Add(this.addButtonConfirm);
            this.Controls.Add(this.confirmTextbox);
            this.Name = "Form2";
            this.Text = "Digite uma descrição para o evento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox confirmTextbox;
        private System.Windows.Forms.Button addButtonConfirm;
    }
}