using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace ImageUpload
{
    public partial class Details : System.Web.UI.Page
    {
        #region "Page_Load"
        /// <summary>
        /// Displying the data with grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            #region "Disply Data"
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CompanyDetailsConnectionString"].ConnectionString))
            {
                connection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter("SELECT Id,CompanyName,RegistrationDate,Logo FROM CompanyData", connection);
                DataSet ds = new DataSet();
                sqlAdapter.Fill(ds);
                grdData.DataSource = ds;
                grdData.DataBind();
            }
        }
            #endregion
        #endregion
    }
}