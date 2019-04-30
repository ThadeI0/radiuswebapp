using System;
using System.Data;
using System.IO;
using System.Web;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;


namespace testformbase
{
        
    public partial class WebForm1 : System.Web.UI.Page
    {
        private dynamic jsonfile = JsonConvert.DeserializeObject(File.ReadAllText(HttpContext.Current.Server.MapPath(".") + @"\\" + "appconfig.json"));

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Server: ";
            if (Request.QueryString["ip"] != null && Request.QueryString["ip"] != "") TextBox1.Text = Request.QueryString["ip"].Trim();
            if (Request.QueryString["vendor"] == "eltex") ddlVendor.Items[1].Selected = true;
            else ddlVendor.Items[0].Selected = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox1.Text == "") throw new Exception("ip cannot be blank or null");
                MySqlCommand command = new MySqlCommand();
                string connectionString, commandString;
                connectionString = string.Format(@"Data source={0};UserId={1};Password={2};database={3};Connect Timeout={4}", jsonfile["host"].ToString(),
                                                 jsonfile["user"].ToString(), jsonfile["password"].ToString(), jsonfile["database"].ToString(), jsonfile["timeout"].ToString()
                                                );
                MySqlConnection connection = new MySqlConnection(connectionString);
                if (ddlVendor.Text == "dlink")
                {
                    commandString = string.Format(jsonfile["dlink"].ToString(), TextBox1.Text);
                }
                else
                {
                    commandString = string.Format(jsonfile["eltex"], TextBox1.Text);
                }
                command.CommandText = commandString;
                command.Connection = connection;
                MySqlDataReader reader;
                Stopwatch sw = new Stopwatch();
                try
                {
                    
                    sw.Start();
                    command.Connection.Open();
                    reader = command.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                    reader.Close();
                }
                catch (MySqlException ex)
                {
                    
                    Label1.Text += ex.Message.ToString();
                }
                finally
                {
                    sw.Stop();
                    Label1.Text += sw.Elapsed.ToString();
                    command.Connection.Close();
                     
                }
            }
            catch(Exception ex)
            {
                Label1.Text += ex.Message.ToString();
            }
            
        }

    }
}