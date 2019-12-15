namespace FrbaOfertas.CrearOferta
{
    partial class CrearOfertaAdministrativo
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
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePickerVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerOferta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.Detalles = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_descripcion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.precioOferta = new System.Windows.Forms.NumericUpDown();
            this.precioLista = new System.Windows.Forms.NumericUpDown();
            this.maxCliente = new System.Windows.Forms.NumericUpDown();
            this.cantidad = new System.Windows.Forms.NumericUpDown();
            this.Detalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.precioOferta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.precioLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(526, 379);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Guardar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(303, 379);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 29;
            this.button2.Text = "Limpiar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 379);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerVencimiento
            // 
            this.dateTimePickerVencimiento.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerVencimiento.Location = new System.Drawing.Point(244, 103);
            this.dateTimePickerVencimiento.Name = "dateTimePickerVencimiento";
            this.dateTimePickerVencimiento.Size = new System.Drawing.Size(314, 20);
            this.dateTimePickerVencimiento.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(103, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Fecha De Vencimiento";
            // 
            // dateTimePickerOferta
            // 
            this.dateTimePickerOferta.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerOferta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerOferta.Location = new System.Drawing.Point(244, 62);
            this.dateTimePickerOferta.Name = "dateTimePickerOferta";
            this.dateTimePickerOferta.Size = new System.Drawing.Size(314, 20);
            this.dateTimePickerOferta.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Fecha De Oferta";
            // 
            // Detalles
            // 
            this.Detalles.Controls.Add(this.cantidad);
            this.Detalles.Controls.Add(this.maxCliente);
            this.Detalles.Controls.Add(this.precioLista);
            this.Detalles.Controls.Add(this.precioOferta);
            this.Detalles.Controls.Add(this.label11);
            this.Detalles.Controls.Add(this.txt_codigo);
            this.Detalles.Controls.Add(this.label6);
            this.Detalles.Controls.Add(this.comboBox1);
            this.Detalles.Controls.Add(this.label9);
            this.Detalles.Controls.Add(this.txt_descripcion);
            this.Detalles.Controls.Add(this.label10);
            this.Detalles.Controls.Add(this.label3);
            this.Detalles.Controls.Add(this.label5);
            this.Detalles.Controls.Add(this.label8);
            this.Detalles.Controls.Add(this.label2);
            this.Detalles.Controls.Add(this.label4);
            this.Detalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Detalles.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Detalles.Location = new System.Drawing.Point(87, 29);
            this.Detalles.Name = "Detalles";
            this.Detalles.Size = new System.Drawing.Size(514, 344);
            this.Detalles.TabIndex = 27;
            this.Detalles.TabStop = false;
            this.Detalles.Text = "Detalle de Oferta";
            this.Detalles.Enter += new System.EventHandler(this.Detalles_Enter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(17, 318);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Cantidad";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // txt_codigo
            // 
            this.txt_codigo.ForeColor = System.Drawing.SystemColors.Window;
            this.txt_codigo.Location = new System.Drawing.Point(71, 289);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(402, 20);
            this.txt_codigo.TabIndex = 8;
            this.txt_codigo.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(19, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Codigo";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(157, 256);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(314, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Proveedor a asignar";
            // 
            // txt_descripcion
            // 
            this.txt_descripcion.Location = new System.Drawing.Point(157, 111);
            this.txt_descripcion.Name = "txt_descripcion";
            this.txt_descripcion.Size = new System.Drawing.Size(314, 20);
            this.txt_descripcion.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(18, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Descripción de Oferta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "$";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(283, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "$";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(18, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(189, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Máximo de Unidades por Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(18, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Precio de Oferta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(18, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Precio de Lista";
            // 
            // precioOferta
            // 
            this.precioOferta.Location = new System.Drawing.Point(157, 148);
            this.precioOferta.Name = "precioOferta";
            this.precioOferta.Size = new System.Drawing.Size(120, 20);
            this.precioOferta.TabIndex = 4;
            // 
            // precioLista
            // 
            this.precioLista.Location = new System.Drawing.Point(157, 184);
            this.precioLista.Name = "precioLista";
            this.precioLista.Size = new System.Drawing.Size(120, 20);
            this.precioLista.TabIndex = 5;
            // 
            // maxCliente
            // 
            this.maxCliente.Location = new System.Drawing.Point(216, 223);
            this.maxCliente.Name = "maxCliente";
            this.maxCliente.Size = new System.Drawing.Size(120, 20);
            this.maxCliente.TabIndex = 6;
            // 
            // cantidad
            // 
            this.cantidad.Location = new System.Drawing.Point(81, 316);
            this.cantidad.Name = "cantidad";
            this.cantidad.Size = new System.Drawing.Size(120, 20);
            this.cantidad.TabIndex = 9;
            // 
            // CrearOfertaAdministrativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 414);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePickerVencimiento);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePickerOferta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Detalles);
            this.Name = "CrearOfertaAdministrativo";
            this.Text = "Form1";
            this.Detalles.ResumeLayout(false);
            this.Detalles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.precioOferta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.precioLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePickerVencimiento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerOferta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Detalles;
        private System.Windows.Forms.TextBox txt_descripcion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_codigo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown cantidad;
        private System.Windows.Forms.NumericUpDown maxCliente;
        private System.Windows.Forms.NumericUpDown precioLista;
        private System.Windows.Forms.NumericUpDown precioOferta;
    }
}