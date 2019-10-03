using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using ImageUpload.Model;

namespace ImageUpload
{
    public partial class CompanyDetails : System.Web.UI.Page
    {
        #region "Page_Load"
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region "Save details button"
        /// <summary>
        /// Saving details fromuser input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveDetails_Click(object sender, EventArgs e)
        {
            bool isSave = false;
            fileUpload.SaveAs(Server.MapPath("~/ImagePath/") + Path.GetFileName(fileUpload.FileName));
            String link = "ImagePath/" + Path.GetFileName(fileUpload.FileName);
            CompanyData compnayData = new CompanyData
            {
                CompanyName = txtCompnayName.Text.Trim(),
                RegistrationDate = txtDateOfRegistration.Text.Trim(),
                Logo = link
            };

            isSave = SaveCompanyDetails(compnayData);
        }
        #endregion

        #region "Save Company Detail function"
        /// <summary>
        /// Inserting data into database
        /// </summary>
        /// <param name="compnayData"></param>
        /// <returns></returns>
        public bool SaveCompanyDetails(CompanyData compnayData)
        {
            
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CompanyDetailsConnectionString"].ConnectionString))
            {
                connection.Open();
                string sqlInsert = "INSERT INTO CompanyData (CompanyName,RegistrationDate,Logo)values(@CompanyName,@RegistrationDate,@Logo)";
                using (SqlCommand cmd = new SqlCommand(sqlInsert, connection))
                {
                    cmd.Parameters.AddWithValue("@CompanyName",compnayData.CompanyName);
                    cmd.Parameters.AddWithValue("@RegistrationDate", compnayData.RegistrationDate);
                    cmd.Parameters.AddWithValue("@Logo", compnayData.Logo);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }
        #endregion
    }
}