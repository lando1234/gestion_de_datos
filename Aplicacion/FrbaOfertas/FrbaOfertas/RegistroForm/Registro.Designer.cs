namespace FrbaOfertas.RegistroForm
{
    partial class Registro
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.textUsuario = new System.Windows.Forms.TextBox();
            this.textPass1 = new System.Windows.Forms.TextBox();
            this.textPass2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.siguienteRegistro = new System.Windows.Forms.Button();
            this.funcionesProveedorBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.funcionesProveedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.funcionesProveedorBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionesProveedorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registrar usuario";
            // 
            // textUsuario
            // 
            this.textUsuario.Location = new System.Drawing.Point(204, 61);
            this.textUsuario.Name = "textUsuario";
            this.textUsuario.Size = new System.Drawing.Size(171, 20);
            this.textUsuario.TabIndex = 1;
            // 
            // textPass1
            // 
            this.textPass1.Location = new System.Drawing.Point(204, 85);
            this.textPass1.Name = "textPass1";
            this.textPass1.PasswordChar = '*';
            this.textPass1.Size = new System.Drawing.Size(171, 20);
            this.textPass1.TabIndex = 2;
            // 
            // textPass2
            // 
            this.textPass2.Location = new System.Drawing.Point(204, 110);
            this.textPass2.Name = "textPass2";
            this.textPass2.PasswordChar = '*';
            this.textPass2.Size = new System.Drawing.Size(171, 20);
            this.textPass2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Tipo usuario:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Repita Contraseña:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(100, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Contraseña:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(98, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Nombre de Usuario:";
            // 
            // comboTipo
            // 
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Items.AddRange(new object[] {
            "Cliente",
            "Proveedor"});
            this.comboTipo.Location = new System.Drawing.Point(204, 137);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(171, 21);
            this.comboTipo.TabIndex = 27;
            this.comboTipo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.botonCancelar);
            // 
            // siguienteRegistro
            // 
            this.siguienteRegistro.Location = new System.Drawing.Point(300, 199);
            this.siguienteRegistro.Name = "siguienteRegistro";
            this.siguienteRegistro.Size = new System.Drawing.Size(75, 23);
            this.siguienteRegistro.TabIndex = 29;
            this.siguienteRegistro.Text = "Siguiente";
            this.siguienteRegistro.UseVisualStyleBackColor = true;
            this.siguienteRegistro.Click += new System.EventHandler(this.button2_Click);
            // 

            // Registro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 262);
            this.Controls.Add(this.siguienteRegistro);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboTipo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textPass2);
            this.Controls.Add(this.textPass1);
            this.Controls.Add(this.textUsuario);
            this.Controls.Add(this.label1);
            this.Name = "Registro";
            this.Text = "Registro";
            ((System.ComponentModel.ISupportInitialize)(this.funcionesProveedorBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionesProveedorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textUsuario;
        private System.Windows.Forms.TextBox textPass1;
        private System.Windows.Forms.TextBox textPass2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboTipo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button siguienteRegistro;
        private System.Windows.Forms.BindingSource funcionesProveedorBindingSource;
        private System.Windows.Forms.BindingSource funcionesProveedorBindingSource1;
    }
}