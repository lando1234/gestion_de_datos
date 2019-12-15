namespace FrbaOfertas.MenuPrincipal
{
    partial class Menu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.abmCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.altaCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.ListarCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.abmProveedor = new System.Windows.Forms.ToolStripMenuItem();
            this.altaProveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarProveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abmRol = new System.Windows.Forms.ToolStripMenuItem();
            this.altaRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CargaCredito = new System.Windows.Forms.ToolStripMenuItem();
            this.recargaCreditoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Ofertas = new System.Windows.Forms.ToolStripMenuItem();
            this.ComprarOferta = new System.Windows.Forms.ToolStripMenuItem();
            this.crearOfertaAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearOfertaProv = new System.Windows.Forms.ToolStripMenuItem();
            this.facturacion = new System.Windows.Forms.ToolStripMenuItem();
            this.facturarAProveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadisticas = new System.Windows.Forms.ToolStripMenuItem();
            this.top5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abmCliente,
            this.abmProveedor,
            this.abmRol,
            this.CargaCredito,
            this.Ofertas,
            this.facturacion,
            this.estadisticas});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(748, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // abmCliente
            // 
            this.abmCliente.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaCliente,
            this.ListarCliente});
            this.abmCliente.Name = "abmCliente";
            this.abmCliente.Size = new System.Drawing.Size(82, 20);
            this.abmCliente.Text = "AbmCliente";
            this.abmCliente.Click += new System.EventHandler(this.abmRolToolStripMenuItem_Click);
            // 
            // altaCliente
            // 
            this.altaCliente.Name = "altaCliente";
            this.altaCliente.Size = new System.Drawing.Size(152, 22);
            this.altaCliente.Text = "AltaCliente";
            this.altaCliente.Click += new System.EventHandler(this.altaClienteToolStripMenuItem_Click);
            // 
            // ListarCliente
            // 
            this.ListarCliente.Name = "ListarCliente";
            this.ListarCliente.Size = new System.Drawing.Size(152, 22);
            this.ListarCliente.Text = "ListarClientes";
            this.ListarCliente.Click += new System.EventHandler(this.listarClientesToolStripMenuItem_Click);
            // 
            // abmProveedor
            // 
            this.abmProveedor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaProveedorToolStripMenuItem,
            this.listarProveedoresToolStripMenuItem});
            this.abmProveedor.Name = "abmProveedor";
            this.abmProveedor.Size = new System.Drawing.Size(99, 20);
            this.abmProveedor.Text = "AbmProveedor";
            // 
            // altaProveedorToolStripMenuItem
            // 
            this.altaProveedorToolStripMenuItem.Name = "altaProveedorToolStripMenuItem";
            this.altaProveedorToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.altaProveedorToolStripMenuItem.Text = "AltaProveedor";
            this.altaProveedorToolStripMenuItem.Click += new System.EventHandler(this.altaProveedorToolStripMenuItem_Click);
            // 
            // listarProveedoresToolStripMenuItem
            // 
            this.listarProveedoresToolStripMenuItem.Name = "listarProveedoresToolStripMenuItem";
            this.listarProveedoresToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.listarProveedoresToolStripMenuItem.Text = "ListarProveedores";
            this.listarProveedoresToolStripMenuItem.Click += new System.EventHandler(this.listarProveedoresToolStripMenuItem_Click);
            // 
            // abmRol
            // 
            this.abmRol.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaRolToolStripMenuItem,
            this.listarRolToolStripMenuItem});
            this.abmRol.Name = "abmRol";
            this.abmRol.Size = new System.Drawing.Size(62, 20);
            this.abmRol.Text = "AbmRol";
            // 
            // altaRolToolStripMenuItem
            // 
            this.altaRolToolStripMenuItem.Name = "altaRolToolStripMenuItem";
            this.altaRolToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.altaRolToolStripMenuItem.Text = "AltaRol";
            this.altaRolToolStripMenuItem.Click += new System.EventHandler(this.altaRolToolStripMenuItem_Click);
            // 
            // listarRolToolStripMenuItem
            // 
            this.listarRolToolStripMenuItem.Name = "listarRolToolStripMenuItem";
            this.listarRolToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.listarRolToolStripMenuItem.Text = "ListarRol";
            this.listarRolToolStripMenuItem.Click += new System.EventHandler(this.listarRolToolStripMenuItem_Click);
            // 
            // CargaCredito
            // 
            this.CargaCredito.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recargaCreditoToolStripMenuItem});
            this.CargaCredito.Name = "CargaCredito";
            this.CargaCredito.Size = new System.Drawing.Size(89, 20);
            this.CargaCredito.Text = "CargaCredito";
            // 
            // recargaCreditoToolStripMenuItem
            // 
            this.recargaCreditoToolStripMenuItem.Name = "recargaCreditoToolStripMenuItem";
            this.recargaCreditoToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.recargaCreditoToolStripMenuItem.Text = "RecargaCredito";
            this.recargaCreditoToolStripMenuItem.Click += new System.EventHandler(this.recargaCreditoToolStripMenuItem_Click);
            // 
            // Ofertas
            // 
            this.Ofertas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ComprarOferta,
            this.crearOfertaAdminToolStripMenuItem,
            this.crearOfertaProv});
            this.Ofertas.Name = "Ofertas";
            this.Ofertas.Size = new System.Drawing.Size(57, 20);
            this.Ofertas.Text = "Ofertas";
            this.Ofertas.Click += new System.EventHandler(this.Ofertas_Click);
            // 
            // ComprarOferta
            // 
            this.ComprarOferta.Name = "ComprarOferta";
            this.ComprarOferta.Size = new System.Drawing.Size(189, 22);
            this.ComprarOferta.Text = "Comprar";
            this.ComprarOferta.Click += new System.EventHandler(this.comprarToolStripMenuItem1_Click);
            // 
            // crearOfertaAdminToolStripMenuItem
            // 
            this.crearOfertaAdminToolStripMenuItem.Name = "crearOfertaAdminToolStripMenuItem";
            this.crearOfertaAdminToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.crearOfertaAdminToolStripMenuItem.Text = "CrearOfertaAdmin";
            this.crearOfertaAdminToolStripMenuItem.Click += new System.EventHandler(this.crearOfertaAdminToolStripMenuItem_Click);
            // 
            // crearOfertaProv
            // 
            this.crearOfertaProv.Name = "crearOfertaProv";
            this.crearOfertaProv.Size = new System.Drawing.Size(189, 22);
            this.crearOfertaProv.Text = "CrearOfertaProveedor";
            this.crearOfertaProv.Click += new System.EventHandler(this.crearOfertaProveedorToolStripMenuItem_Click);
            // 
            // facturacion
            // 
            this.facturacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facturarAProveedorToolStripMenuItem});
            this.facturacion.Name = "facturacion";
            this.facturacion.Size = new System.Drawing.Size(81, 20);
            this.facturacion.Text = "Facturacion";
            // 
            // facturarAProveedorToolStripMenuItem
            // 
            this.facturarAProveedorToolStripMenuItem.Name = "facturarAProveedorToolStripMenuItem";
            this.facturarAProveedorToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.facturarAProveedorToolStripMenuItem.Text = "Facturar a Proveedor";
            this.facturarAProveedorToolStripMenuItem.Click += new System.EventHandler(this.facturarAProveedorToolStripMenuItem_Click);
            // 
            // estadisticas
            // 
            this.estadisticas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.top5ToolStripMenuItem});
            this.estadisticas.Name = "estadisticas";
            this.estadisticas.Size = new System.Drawing.Size(79, 20);
            this.estadisticas.Text = "Estadisticas";
            // 
            // top5ToolStripMenuItem
            // 
            this.top5ToolStripMenuItem.Name = "top5ToolStripMenuItem";
            this.top5ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.top5ToolStripMenuItem.Text = "Top 5";
            this.top5ToolStripMenuItem.Click += new System.EventHandler(this.top5ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(210, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "BIENVENIDO A FRBA OFERTAS";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 109);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Menu";
            this.Text = "Menu principal";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem abmCliente;
        private System.Windows.Forms.ToolStripMenuItem abmProveedor;
        private System.Windows.Forms.ToolStripMenuItem altaCliente;
        private System.Windows.Forms.ToolStripMenuItem ListarCliente;
        private System.Windows.Forms.ToolStripMenuItem altaProveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarProveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abmRol;
        private System.Windows.Forms.ToolStripMenuItem CargaCredito;
        private System.Windows.Forms.ToolStripMenuItem recargaCreditoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Ofertas;
        private System.Windows.Forms.ToolStripMenuItem ComprarOferta;
        private System.Windows.Forms.ToolStripMenuItem crearOfertaAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearOfertaProv;
        private System.Windows.Forms.ToolStripMenuItem facturacion;
        private System.Windows.Forms.ToolStripMenuItem estadisticas;
        private System.Windows.Forms.ToolStripMenuItem top5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarRolToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem facturarAProveedorToolStripMenuItem;
    }
}