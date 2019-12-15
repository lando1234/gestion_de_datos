namespace FrbaOfertas.CargaDeCredito
{
    partial class RecargarCredito
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
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cantidadACargar = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.tipoPago = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadACargar)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Cantidad a cargar";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(449, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cargar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cargar credito";
            // 
            // cantidadACargar
            // 
            this.cantidadACargar.Location = new System.Drawing.Point(233, 112);
            this.cantidadACargar.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.cantidadACargar.Name = "cantidadACargar";
            this.cantidadACargar.Size = new System.Drawing.Size(126, 20);
            this.cantidadACargar.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tipo de pago";
            // 
            // tipoPago
            // 
            this.tipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoPago.FormattingEnabled = true;
            this.tipoPago.Location = new System.Drawing.Point(233, 166);
            this.tipoPago.Name = "tipoPago";
            this.tipoPago.Size = new System.Drawing.Size(214, 21);
            this.tipoPago.TabIndex = 2;
            // 
            // RecargarCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 262);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tipoPago);
            this.Controls.Add(this.cantidadACargar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "RecargarCredito";
            this.Text = "Cargar credito";
            this.Load += new System.EventHandler(this.RecargarCredito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cantidadACargar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown cantidadACargar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox tipoPago;
    }
}