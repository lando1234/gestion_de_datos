﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Modelo.Roles;
using FrbaOfertas.Modelo;
using FrbaOfertas.Utils;

namespace FrbaOfertas.AbmProveedor
{
    public partial class AltaProveedor : Form
    {
        Usuario usuario;
        public AltaProveedor(Usuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }

        public AltaProveedor()
        {
            InitializeComponent();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                Proveedor proveedor = new Proveedor(
                0,//no se usa
                txt_razonsocial.Text,
                txt_cuit.Text,
                txt_mail.Text,
                Convert.ToDecimal(txt_tel.Text),
                new Direccion(null, txt_ciudad.Text, txt_calle.Text, Convert.ToDecimal(txt_codpostal.Text)),
                (Rubro)comboRubro.SelectedItem,
                txt_nombreContacto.Text,
                true
                );
                ConectorDB.FuncionesProveedor.altaUsuarioProveedor(proveedor, usuario);
                if (this.usuario != null)
                {
                    new LoginConRegistro().Show();
                } 
            }
            catch (System.ArgumentException ex)
            {

                MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void validar()
        {
            if (!Validador.isNumeric(txt_codpostal.Text))
            {
                throw new System.ArgumentException("Codigo postal debe ser númerico", "original");

            }
            else if (!Validador.IsValidEmail(txt_mail.Text))
            {
                throw new System.ArgumentException("el mail debe ser válido", "original");
            }
            else if (!Validador.isNumeric(txt_tel.Text))
            {
                throw new System.ArgumentException("el telefono debe ser númerico", "original");
            }
            else if (!Validador.isNumeric(txt_cuit.Text))
            {
                throw new System.ArgumentException("el CUIT debe ser númerico", "original");
            }
            else if (Validador.isEmpty(txt_razonsocial.Text) || Validador.isEmpty(txt_cuit.Text) || Validador.isEmpty(txt_tel.Text) ||
               Validador.isEmpty(txt_nombreContacto.Text) || Validador.isEmpty(txt_mail.Text) || Validador.isEmpty(txt_ciudad.Text) || Validador.isEmpty(txt_calle.Text)
               || Validador.isEmpty(txt_codpostal.Text) || comboRubro.SelectedItem == null)
            {

                   throw new System.ArgumentException("No puede haber campos vacios", "original");
            }
        }
        

        private void AltaProveedor_Load(object sender, EventArgs e)
        {
            List<Rubro> rubros = ConectorDB.FuncionesRubro.getRubros();
           
            foreach (Rubro rubro in rubros)
            {
                comboRubro.Items.Add(rubro);
            }
            
        }
    }
}
