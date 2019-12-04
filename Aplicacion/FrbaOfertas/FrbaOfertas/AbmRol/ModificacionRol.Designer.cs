namespace FrbaOfertas.AbmRol
{
    partial class ModificacionRol
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
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelFuncionalidad = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.checkBoxHabilitado = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBoxFuncionalidades = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(547, 267);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 3;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(305, 267);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 4;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxFuncionalidades);
            this.groupBox1.Controls.Add(this.labelFuncionalidad);
            this.groupBox1.Controls.Add(this.labelNombre);
            this.groupBox1.Controls.Add(this.textNombre);
            this.groupBox1.Location = new System.Drawing.Point(70, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(433, 224);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Campos Rol";
            // 
            // labelFuncionalidad
            // 
            this.labelFuncionalidad.AutoSize = true;
            this.labelFuncionalidad.Location = new System.Drawing.Point(17, 72);
            this.labelFuncionalidad.Name = "labelFuncionalidad";
            this.labelFuncionalidad.Size = new System.Drawing.Size(84, 13);
            this.labelFuncionalidad.TabIndex = 5;
            this.labelFuncionalidad.Text = "Funcionalidades";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(17, 35);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 3;
            this.labelNombre.Text = "Nombre";
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(175, 32);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(185, 20);
            this.textNombre.TabIndex = 1;
            // 
            // checkBoxHabilitado
            // 
            this.checkBoxHabilitado.AutoSize = true;
            this.checkBoxHabilitado.Checked = true;
            this.checkBoxHabilitado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHabilitado.Location = new System.Drawing.Point(549, 114);
            this.checkBoxHabilitado.Name = "checkBoxHabilitado";
            this.checkBoxHabilitado.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxHabilitado.Size = new System.Drawing.Size(73, 17);
            this.checkBoxHabilitado.TabIndex = 6;
            this.checkBoxHabilitado.Text = "Habilitado";
            this.checkBoxHabilitado.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(70, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listBoxFuncionalidades
            // 
            this.listBoxFuncionalidades.CheckOnClick = true;
            this.listBoxFuncionalidades.FormattingEnabled = true;
            this.listBoxFuncionalidades.Location = new System.Drawing.Point(175, 72);
            this.listBoxFuncionalidades.Name = "listBoxFuncionalidades";
            this.listBoxFuncionalidades.Size = new System.Drawing.Size(185, 94);
            this.listBoxFuncionalidades.TabIndex = 6;
            // 
            // ModificacionRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 340);
            this.Controls.Add(this.checkBoxHabilitado);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModificacionRol";
            this.Text = "Modificacion Rol";
            this.Load += new System.EventHandler(this.ModificacionRol_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxHabilitado;
        private System.Windows.Forms.Label labelFuncionalidad;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox listBoxFuncionalidades;
    }
}