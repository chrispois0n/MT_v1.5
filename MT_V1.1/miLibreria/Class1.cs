using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace miLibreria
{
    public class Utilidades
    {
        public static DataSet Ejecutar(string cmd)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-6DH3H6C\\SQLSERVER;Initial Catalog=MT;Integrated Security=True");
            con.Open();

            DataSet DS = new DataSet();
            SqlDataAdapter DP = new SqlDataAdapter(cmd,con);

            DP.Fill(DS);

            con.Close();

            return DS;
        }

        public string FormatoFecha (DateTimePicker dtp)
        {
            string fecha = "";
            fecha += (dtp.Value.Year).ToString() + "-";
            if(dtp.Value.Month < 10)
            {
                fecha += "0" + dtp.Value.Month.ToString() + "-";
            }
            else
            {
                fecha += dtp.Value.Month.ToString() + "-";
            }

            if (dtp.Value.Day < 10 )
            {
                fecha += "0" + dtp.Value.Day.ToString();
            }
            else
            {
                fecha += dtp.Value.Day.ToString();
            }
            return fecha;
        }

        public static Boolean ValidarFormulario(Control Objeto, ErrorProvider ErrorProvider)
        {
            Boolean hayErrores = false;

            foreach(Control Item in Objeto.Controls)
            {
                if (Item is errorTxtBox)
                {
                    errorTxtBox Obj = (errorTxtBox)Item;

                    if (Obj.Validar == true)
                    {
                        if (string.IsNullOrEmpty(Obj.Text.Trim()))//Si esta vacio o nulo activa el error provider
                        {
                            ErrorProvider.SetError(Obj, "este campo no puede estar vacio!");
                            hayErrores = true;
                        }
                    }else
                    {
                        ErrorProvider.SetError(Obj, "");
                    }

                }
            }
            return hayErrores;



        }



    }
}
