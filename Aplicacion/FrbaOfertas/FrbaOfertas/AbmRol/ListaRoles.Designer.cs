namespace FrbaOfertas.AbmRol
{
    partial class ListaRoles
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
            this.dataGridRol1 = new System.Windows.Forms.DataGridView();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.nombreRolBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameRolColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilitadoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetalleButtonGrid = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRol1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridRol1
            // 
            this.dataGridRol1.AllowUserToAddRows = false;
            this.dataGridRol1.AllowUserToDeleteRows = false;
            this.dataGridRol1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRol1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColumn,
            this.nameRolColumn,
            this.habilitadoColumn,
            this.DetalleButtonGrid});
            this.dataGridRol1.Location = new System.Drawing.Point(77, 139);
            this.dataGridRol1.Name = "dataGridRol1";
            this.dataGridRol1.ReadOnly = true;
            this.dataGridRol1.Size = new System.Drawing.Size(470, 235);
            this.dataGridRol1.TabIndex = 7;
            this.dataGridRol1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRol1_CellContentClick);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(399, 89);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscar.TabIndex = 6;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(272, 89);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 5;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nombreRolBuscar
            // 
            this.nombreRolBuscar.Location = new System.Drawing.Point(170, 44);
            this.nombreRolBuscar.Name = "nombreRolBuscar";
            this.nombreRolBuscar.Size = new System.Drawing.Size(258, 20);
            this.nombreRolBuscar.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre";
            // 
            // idColumn
            // 
            this.idColumn.HeaderText = "*";
            this.idColumn.Name = "idColumn";
            this.idColumn.ReadOnly = true;
            // 
            // nameRolColumn
            // 
            this.nameRolColumn.HeaderText = "Rol";
            this.nameRolColumn.Name = "nameRolColumn";
            this.nameRolColumn.ReadOnly = true;
            // 
            // habilitadoColumn
            // 
            this.habilitadoColumn.HeaderText = "Habilitado";
            this.habilitadoColumn.Name = "habilitadoColumn";
            this.habilitadoColumn.ReadOnly = true;
            // 
            // DetalleButtonGrid
            // 
            this.DetalleButtonGrid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DetalleButtonGrid.HeaderText = "Modificar";
            this.DetalleButtonGrid.Name = "DetalleButtonGrid";
            this.DetalleButtonGrid.ReadOnly = true;
            this.DetalleButtonGrid.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DetalleButtonGrid.Text = "Modificar";
            // 
            // ListaRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 408);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nombreRolBuscar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridRol1);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.buttonLimpiar);
            this.Name = "ListaRoles";
            this.Text = "Listar Roles";
            this.Load += new System.EventHandler(this.ListaRoles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRol1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridRol1;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox nombreRolBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameRolColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn habilitadoColumn;
        private System.Windows.Forms.DataGridViewButtonColumn DetalleButtonGrid;
    }
}