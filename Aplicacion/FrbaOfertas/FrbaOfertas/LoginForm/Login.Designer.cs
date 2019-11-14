namespace FrbaOfertas
{
    partial class LoginForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelBienvenida = new System.Windows.Forms.Label();
            this.textBoxLoginUser = new System.Windows.Forms.TextBox();
            this.labelIniciarSesion = new System.Windows.Forms.Label();
            this.labelLoginUser = new System.Windows.Forms.Label();
            this.labelLoginPassword = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxLoginPassword = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelBienvenida
            // 
            this.labelBienvenida.AutoSize = true;
            this.labelBienvenida.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBienvenida.Location = new System.Drawing.Point(3, 9);
            this.labelBienvenida.Name = "labelBienvenida";
            this.labelBienvenida.Size = new System.Drawing.Size(317, 25);
            this.labelBienvenida.TabIndex = 2;
            this.labelBienvenida.Text = "Bienvenido a Ofertas FRBA";
            // 
            // textBoxLoginUser
            // 
            this.textBoxLoginUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxLoginUser.Location = new System.Drawing.Point(133, 120);
            this.textBoxLoginUser.Name = "textBoxLoginUser";
            this.textBoxLoginUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxLoginUser.Size = new System.Drawing.Size(200, 20);
            this.textBoxLoginUser.TabIndex = 1;
            // 
            // labelIniciarSesion
            // 
            this.labelIniciarSesion.AutoSize = true;
            this.labelIniciarSesion.Location = new System.Drawing.Point(130, 70);
            this.labelIniciarSesion.Name = "labelIniciarSesion";
            this.labelIniciarSesion.Size = new System.Drawing.Size(70, 13);
            this.labelIniciarSesion.TabIndex = 0;
            this.labelIniciarSesion.Text = "Iniciar Sesion";
            this.labelIniciarSesion.Click += new System.EventHandler(this.labelIniciarSesion_Click);
            // 
            // labelLoginUser
            // 
            this.labelLoginUser.AutoSize = true;
            this.labelLoginUser.Location = new System.Drawing.Point(130, 104);
            this.labelLoginUser.Name = "labelLoginUser";
            this.labelLoginUser.Size = new System.Drawing.Size(43, 13);
            this.labelLoginUser.TabIndex = 11;
            this.labelLoginUser.Text = "Usuario";
            // 
            // labelLoginPassword
            // 
            this.labelLoginPassword.AutoSize = true;
            this.labelLoginPassword.Location = new System.Drawing.Point(130, 142);
            this.labelLoginPassword.Name = "labelLoginPassword";
            this.labelLoginPassword.Size = new System.Drawing.Size(53, 13);
            this.labelLoginPassword.TabIndex = 12;
            this.labelLoginPassword.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Bienvenido a FRBA Ofertas";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(182, 184);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 3;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxLoginPassword
            // 
            this.textBoxLoginPassword.Location = new System.Drawing.Point(133, 158);
            this.textBoxLoginPassword.Name = "textBoxLoginPassword";
            this.textBoxLoginPassword.PasswordChar = '*';
            this.textBoxLoginPassword.Size = new System.Drawing.Size(200, 20);
            this.textBoxLoginPassword.TabIndex = 2;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(14, 240);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(60, 13);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Registrarse";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 262);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.textBoxLoginPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelLoginPassword);
            this.Controls.Add(this.labelLoginUser);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.labelIniciarSesion);
            this.Controls.Add(this.textBoxLoginUser);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelBienvenida;
        private System.Windows.Forms.TextBox textBoxLoginUser;
        private System.Windows.Forms.Label labelIniciarSesion;
        private System.Windows.Forms.Label labelLoginUser;
        private System.Windows.Forms.Label labelLoginPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textBoxLoginPassword;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

