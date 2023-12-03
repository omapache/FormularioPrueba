using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Data;

namespace FormularioPrueba.Pages
{
    public partial class Crud : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string sID = "-1";
        public static string sOpc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //obtener el id
            if(!Page.IsPostBack)
            {
                if (Request.QueryString["id"]!=null)
                {
                    sID = Request.QueryString["id"].ToString();
                    CargarDatos();
                }

                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();

                    switch(sOpc)
                    {
                        case "C":
                            this.Lbtitulo.Text = "Ingresar nuevo usuario";
                            this.BtnCreate.Visible = true;
                            break;

                        case "R":
                            this.Lbtitulo.Text = "Consulta de usuario";
                            break;

                        case "U":
                            this.Lbtitulo.Text = "Modificar Usuario";
                            this.BtnUpdate.Visible = true;
                            break;

                        case "D":
                            this.Lbtitulo.Text = "Eliminar Usuario";
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }

        void CargarDatos()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_read", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            tbNombres.Text = row[1].ToString();
            tbApellidos.Text = row[2].ToString();
            tbTelefono.Text = row[3].ToString();
            tbCiudad.Text = row[4].ToString();
            tbMes.Text = row[5].ToString();
            tbVentaMes.Text = row[6].ToString();
            con.Close();
        }
         
        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_created", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = tbNombres.Text;
            cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = tbApellidos.Text;
            cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = tbTelefono.Text;
            cmd.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = tbCiudad.Text;
            cmd.Parameters.Add("@Mes", SqlDbType.Int).Value = Convert.ToInt32(tbMes.Text);
            cmd.Parameters.Add("@VentaMes", SqlDbType.Decimal).Value = tbVentaMes.Text;
            if (string.IsNullOrEmpty(tbNombres.Text) ||
               string.IsNullOrEmpty(tbApellidos.Text) ||
               string.IsNullOrEmpty(tbTelefono.Text) ||
               string.IsNullOrEmpty(tbCiudad.Text) ||
               string.IsNullOrEmpty(tbMes.Text) ||
               string.IsNullOrEmpty(tbVentaMes.Text))
            {
                string mensaje = "Por favor, completa todos los campos.";
                string script = $"alert('{mensaje}');";
                ClientScript.RegisterStartupScript(this.GetType(), "Alerta", script, true);
                return;
            }
            foreach (char caracter in tbTelefono.Text)
            {
                if (!char.IsDigit(caracter))
                {
                    string mensaje = "El campo telefono solo acepta numeros";
                    string script = $"alert('{mensaje}');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Alerta", script, true);
                    return;
                }
            }
            foreach (char caracter in tbVentaMes.Text)
            {
                if (!char.IsDigit(caracter))
                {
                    string mensaje = "El campo ventaMes solo acepta numeros";
                    string script = $"alert('{mensaje}');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Alerta", script, true);
                    return;
                }
            }
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_update", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id",SqlDbType.Int).Value = sID;
            cmd.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = tbNombres.Text;
            cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = tbApellidos.Text;
            cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = tbTelefono.Text;
            cmd.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = tbCiudad.Text;
            cmd.Parameters.Add("@Mes", SqlDbType.Int).Value = Convert.ToInt32(tbMes.Text);
            cmd.Parameters.Add("@VentaMes", SqlDbType.Decimal).Value = tbVentaMes.Text;
            if (string.IsNullOrEmpty(tbNombres.Text) ||
                           string.IsNullOrEmpty(tbApellidos.Text) ||
                           string.IsNullOrEmpty(tbTelefono.Text) ||
                           string.IsNullOrEmpty(tbCiudad.Text) ||
                           string.IsNullOrEmpty(tbMes.Text) ||
                           string.IsNullOrEmpty(tbVentaMes.Text))
            {
                string mensaje = "Por favor, completa todos los campos.";
                string script = $"alert('{mensaje}');";
                ClientScript.RegisterStartupScript(this.GetType(), "Alerta", script, true);
                return;
            }
            foreach (char caracter in tbTelefono.Text)
            {
                if (!char.IsDigit(caracter))
                {
                    string mensaje = "El campo telefono solo acepta numeros";
                    string script = $"alert('{mensaje}');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Alerta", script, true);
                    return;
                }
            }
            foreach (char caracter in tbVentaMes.Text)
            {
                if (!char.IsDigit(caracter))
                {
                    string mensaje = "El campo ventaMes solo acepta numeros";
                    string script = $"alert('{mensaje}');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Alerta", script, true);
                    return;
                }
            }
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}