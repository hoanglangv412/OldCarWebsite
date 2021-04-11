using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OldCarApi.Models
{
    public class CustomerModel
    {
        public int Customer_id { get; set; }
        public int Customer_account_id { get; set; }
        public string Customer_avatar { get; set; }
        public string Customer_name { get; set; }
        public DateTime Customer_birth { get; set; }
        public string Customer_email { get; set; }
        public string Customer_address { get; set; }
        public string Customer_phone { get; set; }
        public DateTime Customer_begindate { get; set; }

        public CustomerModel() { }

        public List<AccountModel> ListAccountModels { get; set; }

        public SqlConnection SQL_CONNECTION = new SqlConnection(ConfigurationManager.ConnectionStrings["OldCarApi"].ToString());

        #region Selectalldata
        public DataTable Selectalldata()
        {
            DataTable dt = new DataTable();

            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Customer_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_account_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_avatar", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_name", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_birth", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_email", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_address", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_phone", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_begindate", DBNull.Value);
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
        public string Insertdata(CustomerModel customerModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Customer_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_account_id", customerModel.Customer_account_id);
                cmd.Parameters.AddWithValue("@Customer_avatar", customerModel.Customer_avatar);
                cmd.Parameters.AddWithValue("@Customer_name", customerModel.Customer_name);
                cmd.Parameters.AddWithValue("@Customer_birth", customerModel.Customer_birth);
                cmd.Parameters.AddWithValue("@Customer_email", customerModel.Customer_email);
                cmd.Parameters.AddWithValue("@Customer_address", customerModel.Customer_address);
                cmd.Parameters.AddWithValue("@Customer_phone", customerModel.Customer_phone);
                cmd.Parameters.AddWithValue("@Customer_begindate", customerModel.Customer_begindate);
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
        public string Updatedata(CustomerModel customerModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Customer_id", customerModel.Customer_id);
                cmd.Parameters.AddWithValue("@Customer_account_id", customerModel.Customer_account_id);
                cmd.Parameters.AddWithValue("@Customer_avatar", customerModel.Customer_avatar);
                cmd.Parameters.AddWithValue("@Customer_name", customerModel.Customer_name);
                cmd.Parameters.AddWithValue("@Customer_birth", customerModel.Customer_birth);
                cmd.Parameters.AddWithValue("@Customer_email", customerModel.Customer_email);
                cmd.Parameters.AddWithValue("@Customer_address", customerModel.Customer_address);
                cmd.Parameters.AddWithValue("@Customer_phone", customerModel.Customer_phone);
                cmd.Parameters.AddWithValue("@Customer_begindate", customerModel.Customer_begindate);
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
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Customer_id", ID);
                cmd.Parameters.AddWithValue("@Customer_account_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_avatar", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_name", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_birth", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_email", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_address", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_phone", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_begindate", DBNull.Value);
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
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Customer_id", ID);
                cmd.Parameters.AddWithValue("@Customer_account_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_avatar", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_name", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_birth", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_email", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_address", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_phone", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_begindate", DBNull.Value);
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