using FrbaOfertas.BaseDeDatos;
using FrbaOfertas.Modelo.Roles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.ConectorDB
{
    class FuncionesCargaCredito
    {
        public static void cargaCredito(Credito credito)
        {
            SqlConnection con = new SqlConnection(Conexion.getStringConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand("CARGAR_CREDITO", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = credito.fecha;
            cmd.Parameters.Add("@USUARIO_ID", SqlDbType.Int).Value = credito.usuario_id;
            cmd.Parameters.Add("@TIPO_PAGO_ID", SqlDbType.VarChar).Value = credito.tipo_pago_id;
            cmd.Parameters.Add("@MONTO", SqlDbType.Float).Value = credito.monto;
            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = credito.nombre;
            cmd.Parameters.Add("@FECHA_VENCIMIENTO", SqlDbType.VarChar).Value = credito.fecha_vencimiento;
            cmd.Parameters.Add("@NUMERO", SqlDbType.VarChar).Value = credito.numero_tarjeta;


            var returnParameter = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;


            cmd.ExecuteNonQuery();

           
            int returnValue = (int)returnParameter.Value;

            if (returnValue == -1)
            {
                MessageBox.Show("Usuario esta bloquead", "USER IS BLOCKED", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            con.Close();

        }

    }
}
