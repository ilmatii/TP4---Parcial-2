using System;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace TP4___Desempeño_2
{
    public partial class Formulario2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Recuperar el nombre de usuario de la sesión
                string nombreUsuario = Session["Username"] as string;

                if (!string.IsNullOrEmpty(nombreUsuario))
                {
                    // Mostrar el mensaje de bienvenida en la Label
                    BienvenidoLabel.Text = $"Bienvenido, {nombreUsuario}!";
                }
                else
                {
                    BienvenidoLabel.Text = "";
                }

                if (nombreUsuario != null)
                {
                    // Obtener o crear la carpeta del usuario
                    string userFolderPath = Server.MapPath($"./{nombreUsuario}");
                    if (!Directory.Exists(userFolderPath))
                    {
                        Directory.CreateDirectory(userFolderPath);
                    }

                    // Cargar archivos en el GridView
                    LoadFilesToGridView(userFolderPath);
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            // Recuperar el nombre de usuario de la sesión
            string nombreUsuario = Session["Username"] as string;

            if (nombreUsuario != null)
            {
                // Obtener la carpeta del usuario
                string userFolderPath = Server.MapPath($"./{nombreUsuario}");

                // Subir el archivo al servidor
                if (fileUpload.PostedFile != null && fileUpload.PostedFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(fileUpload.PostedFile.FileName);
                    string filePath = Path.Combine(userFolderPath, fileName);
                    fileUpload.PostedFile.SaveAs(filePath);
                }

                // Recargar archivos en el GridView
                LoadFilesToGridView(userFolderPath);
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DownloadFile")
            {
                string filePath = e.CommandArgument.ToString();
                Descargar(filePath);
            }
        }

        private void LoadFilesToGridView(string folderPath)
        {
            // Obtener la lista de archivos en la carpeta
            string[] files = Directory.GetFiles(folderPath);

            // Crear una DataTable para almacenar información de archivos
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable.Columns.Add("FileName", typeof(string));
            dataTable.Columns.Add("FilePath", typeof(string));

            // Agregar info de archivos a la DataTable
            foreach (string filePath in files)
            {
                string fileName = Path.GetFileName(filePath);
                dataTable.Rows.Add(fileName, filePath);
            }

            // Enlazar la DataTable al GridView
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }

        private void Descargar(string filePath)
        {
            // Configurar la respuesta HTTP para la descarga del archivo
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", $"attachment; filename={Path.GetFileName(filePath)}");
            Response.TransmitFile(filePath);
            Response.End();
        }
    }
}
