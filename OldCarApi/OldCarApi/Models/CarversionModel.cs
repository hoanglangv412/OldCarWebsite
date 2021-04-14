using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OldCarApi.Models
{
    public class CarversionModel
    {
        public int Carversion_id { get; set; }
        public string Carversion_name { get; set; }
        public string Carversion_date { get; set; }
        public string Carversion_style { get; set; }
        public string Carversion_class { get; set; }
        public string Carversion_option { get; set; }
        public string Carversion_ManufacturerName { get; set; }
        public string Carversion_ManufacturerLogo { get; set; }

        public CarversionModel() { }

        public List<CarversionModel> ListCarversionModels { get; set; }

        public SqlConnection SQL_CONNECTION = new SqlConnection(ConfigurationManager.ConnectionStrings["OldCarApi"].ToString());

        #region Selectalldata
        public DataTable Selectalldata()
        {
            DataTable dt = new DataTable();

            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Carversion", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Carversion_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Carversion_name", DBNull.Value);
                cmd.Parameters.AddWithValue("@Carversion_date", DBNull.Value);
                cmd.Parameters.AddWithValue("@Carversion_style", DBNull.Value);
                cmd.Parameters.AddWithValue("@Carversion_class", DBNull.Value);
                cmd.Parameters.AddWithValue("@Carversion_option", DBNull.Value);
                cmd.Parameters.AddWithValue("@Carversion_ManufacturerName", DBNull.Value);
                cmd.Parameters.AddWithValue("@Carversion_ManufacturerLogo", DBNull.Value);
                cmd.Parameters.AddWithValue("@Query", 4);
                SQL_CONNECTION.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                SQL_CONNECTION.Close();
            }

            return dt;
        }
        #endregion Selectalldata

        #region InsertData
        public string Insertdata(CarversionModel carVersionModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Carversion", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Carversion_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Carversion_name", String.IsNullOrEmpty(carVersionModel.Carversion_name) ? null : carVersionModel.Carversion_name);
                cmd.Parameters.AddWithValue("@Carversion_date", String.IsNullOrEmpty(carVersionModel.Carversion_date) ? null : carVersionModel.Carversion_date);
                cmd.Parameters.AddWithValue("@Carversion_style", String.IsNullOrEmpty(carVersionModel.Carversion_date) ? null : carVersionModel.Carversion_date);
                cmd.Parameters.AddWithValue("@Carversion_class", String.IsNullOrEmpty(carVersionModel.Carversion_class) ? null : carVersionModel.Carversion_class);
                cmd.Parameters.AddWithValue("@Carversion_option", String.IsNullOrEmpty(carVersionModel.Carversion_option) ? null : carVersionModel.Carversion_option);
                cmd.Parameters.AddWithValue("@Carversion_ManufacturerName", String.IsNullOrEmpty(carVersionModel.Carversion_ManufacturerName) ? null : carVersionModel.Carversion_ManufacturerName);
                cmd.Parameters.AddWithValue("@Carversion_ManufacturerLogo", String.IsNullOrEmpty(carVersionModel.Carversion_ManufacturerLogo) ? null : carVersionModel.Carversion_ManufacturerLogo);
                cmd.Parameters.AddWithValue("@Query", 1);
                SQL_CONNECTION.Open();
                cmd.ExecuteNonQuery();

                return "1-Thêm thành công";
            }
            catch (Exception ex)
            {
                return "2-Lỗi khi thêm";
            }
            finally
            {
                SQL_CONNECTION.Close();
            }
        }
        #endregion InsertData

        #region Updatedata
        public string Updatedata(CarversionModel carVersionModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Carversion", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Carversion_id", carVersionModel.Carversion_id);
                cmd.Parameters.AddWithValue("@Carversion_name", String.IsNullOrEmpty(carVersionModel.Carversion_name) ? null : carVersionModel.Carversion_name);
                cmd.Parameters.AddWithValue("@Carversion_date", String.IsNullOrEmpty(carVersionModel.Carversion_date) ? null : carVersionModel.Carversion_date);
                cmd.Parameters.AddWithValue("@Carversion_style", String.IsNullOrEmpty(carVersionModel.Carversion_date) ? null : carVersionModel.Carversion_date);
                cmd.Parameters.AddWithValue("@Carversion_class", String.IsNullOrEmpty(carVersionModel.Carversion_class) ? null : carVersionModel.Carversion_class);
                cmd.Parameters.AddWithValue("@Carversion_option", String.IsNullOrEmpty(carVersionModel.Carversion_option) ? null : carVersionModel.Carversion_option);
                cmd.Parameters.AddWithValue("@Carversion_ManufacturerName", String.IsNullOrEmpty(carVersionModel.Carversion_ManufacturerName) ? null : carVersionModel.Carversion_ManufacturerName);
                cmd.Parameters.AddWithValue("@Carversion_ManufacturerLogo", String.IsNullOrEmpty(carVersionModel.Carversion_ManufacturerLogo) ? null : carVersionModel.Carversion_ManufacturerLogo);
                cmd.Parameters.AddWithValue("@Query", 2);
                SQL_CONNECTION.Open();
                cmd.ExecuteNonQuery();

                return "1-Cập nhật thành công";
            }
            catch (Exception ex)
            {

                return "2-Lỗi khi cập nhật";
            }
            finally
            {
                SQL_CONNECTION.Close();
            }
        }
        #endregion Updatedata

        #region SelectDataById
        public DataTable SelectDataById(string ID)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Carversion", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Carversion_id", ID);
                cmd.Parameters.AddWithValue("@Carversion_name", DBNull.Value);
                cmd.Parameters.AddWithValue("@Carversion_date", DBNull.Value);
                cmd.Parameters.AddWithValue("@Carversion_style", DBNull.Value);
                cmd.Parameters.AddWithValue("@Carversion_class", DBNull.Value);
                cmd.Parameters.AddWithValue("@Carversion_option", DBNull.Value);
                cmd.Parameters.AddWithValue("@Carversion_ManufacturerName", DBNull.Value);
                cmd.Parameters.AddWithValue("@Carversion_ManufacturerLogo", DBNull.Value);
                cmd.Parameters.AddWithValue("@Query", 5);
                SqlDataAdapter da = new SqlDataAdapter();
                SQL_CONNECTION.Open();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SQL_CONNECTION.Close();
            }
        }
        #endregion SelectDataById

        #region DeleteData
        public string DeleteData(string ID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Carversion", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Carversion_id", ID);
                cmd.Parameters.AddWithValue("@Carversion_name", DBNull.Value);
                cmd.Parameters.AddWithValue("@Carversion_date", DBNull.Value);
                cmd.Parameters.AddWithValue("@Carversion_style", DBNull.Value);
                cmd.Parameters.AddWithValue("@Carversion_class", DBNull.Value);
                cmd.Parameters.AddWithValue("@Carversion_option", DBNull.Value);
                cmd.Parameters.AddWithValue("@Carversion_ManufacturerName", DBNull.Value);
                cmd.Parameters.AddWithValue("@Carversion_ManufacturerLogo", DBNull.Value);
                cmd.Parameters.AddWithValue("@Query", 3);
                SQL_CONNECTION.Open();
                cmd.ExecuteNonQuery();

                return "1-Xóa thành công";
            }
            catch (Exception ex)
            {

                return "2-Lỗi khi xóa";
            }
            finally
            {
                SQL_CONNECTION.Close();
            }
        }
        #endregion DeleteData

    }
}