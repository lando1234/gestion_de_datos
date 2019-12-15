namespace FrbaOfertas.ComprarOferta
{
    partial class CompraDeOferta
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
            this.historial = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblmontoactual = new System.Windows.Forms.Label();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.buscador = new System.Windows.Forms.Label();
            this.dataGridCompraOfertas = new System.Windows.Forms.DataGridView();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maximo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comprar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCompraOfertas)).BeginInit();
            this.SuspendLayout();
            // 
            // historial
            // 
            this.historial.Location = new System.Drawing.Point(552, 12);
            this.historial.Name = "historial";
            this.historial.Size = new System.Drawing.Size(80, 37);
            this.historial.TabIndex = 14;
            this.historial.Text = "Historial";
            this.historial.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(451, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 37);
            this.button2.TabIndex = 13;
            this.button2.Text = "Volver";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(647, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 37);
            this.button1.TabIndex = 12;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblmontoactual
            // 
            this.lblmontoactual.AutoSize = true;
            this.lblmontoactual.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmontoactual.Location = new System.Drawing.Point(136, 9);
            this.lblmontoactual.Name = "lblmontoactual";
            this.lblmontoactual.Size = new System.Drawing.Size(109, 26);
            this.lblmontoactual.TabIndex = 11;
            this.lblmontoactual.Text = "Su monto:";
            // 
            // txtBuscador
            // 
            this.txtBuscador.Location = new System.Drawing.Point(327, 67);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(418, 20);
            this.txtBuscador.TabIndex = 10;
            // 
            // buscador
            // 
            this.buscador.AutoSize = true;
            this.buscador.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscador.Location = new System.Drawing.Point(24, 61);
            this.buscador.Name = "buscador";
            this.buscador.Size = new System.Drawing.Size(288, 26);
            this.buscador.TabIndex = 9;
            this.buscador.Text = "Buscar Por nombre de oferta";
            // 
            // dataGridCompraOfertas
            // 
            this.dataGridCompraOfertas.AllowDrop = true;
            this.dataGridCompraOfertas.AllowUserToDeleteRows = false;
            this.dataGridCompraOfertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCompraOfertas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Proveedor,
            this.Detalle,
            this.Precio,
            this.Stock,
            this.maximo,
            this.Comprar,
            this.codigo});
            this.dataGridCompraOfertas.Location = new System.Drawing.Point(12, 104);
            this.dataGridCompraOfertas.Name = "dataGridCompraOfertas";
            this.dataGridCompraOfertas.ReadOnly = true;
            this.dataGridCompraOfertas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridCompraOfertas.Size = new System.Drawing.Size(862, 345);
            this.dataGridCompraOfertas.TabIndex = 8;
            // 
            // Proveedor
            // 
            this.Proveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.ReadOnly = true;
            // 
            // Detalle
            // 
            this.Detalle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Detalle.HeaderText = "Detalle";
            this.Detalle.Name = "Detalle";
            this.Detalle.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Stock
            // 
            this.Stock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            // 
            // maximo
            // 
            this.maximo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.maximo.HeaderText = "Unidades que puede comprar";
            this.maximo.Name = "maximo";
            this.maximo.ReadOnly = true;
            // 
            // Comprar
            // 
            this.Comprar.HeaderText = "Comprar";
            this.Comprar.Name = "Comprar";
            this.Comprar.ReadOnly = true;
            this.Comprar.Width = 150;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "OfeID";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Visible = false;
            // 
            // CompraDeOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 476);
            this.Controls.Add(this.historial);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblmontoactual);
            this.Controls.Add(this.txtBuscador);
            this.Controls.Add(this.buscador);
            this.Controls.Add(this.dataGridCompraOfertas);
            this.Name = "CompraDeOferta";
            this.Text = "Comprar oferta";
            this.Load += new System.EventHandler(this.CompraDeOferta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCompraOfertas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button historial;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblmontoactual;
        private System.Windows.Forms.TextBox txtBuscador;
        private System.Windows.Forms.Label buscador;
        private System.Windows.Forms.DataGridView dataGridCompraOfertas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn maximo;
        private System.Windows.Forms.DataGridViewButtonColumn Comprar;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
    }
}