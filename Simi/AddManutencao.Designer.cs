namespace Simi
{
    partial class AddManutencao
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
            this.label1 = new System.Windows.Forms.Label();
            this.problemare = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.data_serial = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Problema Relatado:";
            // 
            // problemare
            // 
            this.problemare.Location = new System.Drawing.Point(13, 47);
            this.problemare.Multiline = true;
            this.problemare.Name = "problemare";
            this.problemare.Size = new System.Drawing.Size(324, 203);
            this.problemare.TabIndex = 1;
            this.problemare.KeyDown += new System.Windows.Forms.KeyEventHandler(this.problemare_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 48);
            this.button1.TabIndex = 2;
            this.button1.Text = "Adicionar a Fila de Manutenção";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(175, 256);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 48);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // data_serial
            // 
            this.data_serial.AutoSize = true;
            this.data_serial.Location = new System.Drawing.Point(15, 14);
            this.data_serial.Name = "data_serial";
            this.data_serial.Size = new System.Drawing.Size(39, 13);
            this.data_serial.TabIndex = 4;
            this.data_serial.Text = "SERIE";
            // 
            // AddManutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 309);
            this.Controls.Add(this.data_serial);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.problemare);
            this.Controls.Add(this.label1);
            this.Name = "AddManutencao";
            this.Text = "Adicionar a Fila de Manutenção";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox problemare;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label data_serial;
    }
}