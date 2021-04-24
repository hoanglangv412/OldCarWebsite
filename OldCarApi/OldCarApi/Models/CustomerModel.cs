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
        public string Customer_avatar { get; set; }
        public string Customer_name { get; set; }
        public DateTime? Customer_birth { get; set; }
        public string Customer_email { get; set; }
        public string Customer_address { get; set; }
        public string Customer_phone { get; set; }
        public DateTime? Customer_begindate { get; set; }
        public string Account_name { get; set; }
        public string Account_password { get; set; }
        public int? Account_role { get; set; }
        public DateTime? Account_lastLogin { get; set; }
        public CustomerModel() { }

        public List<CustomerModel> ListCustomerModels { get; set; }

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
                cmd.Parameters.AddWithValue("@Customer_avatar", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_name", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_birth", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_email", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_address", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_phone", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_begindate", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_name", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_password", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_role", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_lastLogin", DBNull.Value);
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
                cmd.Parameters.AddWithValue("@Customer_avatar", String.IsNullOrEmpty(customerModel.Customer_avatar) ? null : customerModel.Customer_avatar);
                cmd.Parameters.AddWithValue("@Customer_name", String.IsNullOrEmpty(customerModel.Customer_name) ? null : customerModel.Customer_name);
                cmd.Parameters.AddWithValue("@Customer_birth", (customerModel.Customer_birth == DateTime.MinValue) ? null : customerModel.Customer_birth);
                cmd.Parameters.AddWithValue("@Customer_email", String.IsNullOrEmpty(customerModel.Customer_email) ? null : customerModel.Customer_email);
                cmd.Parameters.AddWithValue("@Customer_address", String.IsNullOrEmpty(customerModel.Customer_address) ? null : customerModel.Customer_address);
                cmd.Parameters.AddWithValue("@Customer_phone", String.IsNullOrEmpty(customerModel.Customer_phone) ? null : customerModel.Customer_phone);
                cmd.Parameters.AddWithValue("@Customer_begindate", (customerModel.Customer_begindate == DateTime.MinValue) ? null : customerModel.Customer_begindate);
                cmd.Parameters.AddWithValue("@Account_name", String.IsNullOrEmpty(customerModel.Account_name) ? null : customerModel.Account_name);
                cmd.Parameters.AddWithValue("@Account_password", String.IsNullOrEmpty(customerModel.Account_password) ? null : customerModel.Account_password);
                cmd.Parameters.AddWithValue("@Account_role", customerModel.Account_role.HasValue ? customerModel.Account_role : null);
                cmd.Parameters.AddWithValue("@Account_lastLogin", (customerModel.Account_lastLogin == DateTime.MinValue) ? null : customerModel.Account_lastLogin);
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
                cmd.Parameters.AddWithValue("@Customer_avatar", String.IsNullOrEmpty(customerModel.Customer_avatar) ? null : customerModel.Customer_avatar);
                cmd.Parameters.AddWithValue("@Customer_name", String.IsNullOrEmpty(customerModel.Customer_name) ? null : customerModel.Customer_name);
                cmd.Parameters.AddWithValue("@Customer_birth", (customerModel.Customer_birth == DateTime.MinValue) ? null : customerModel.Customer_birth);
                cmd.Parameters.AddWithValue("@Customer_email", String.IsNullOrEmpty(customerModel.Customer_email) ? null : customerModel.Customer_email);
                cmd.Parameters.AddWithValue("@Customer_address", String.IsNullOrEmpty(customerModel.Customer_address) ? null : customerModel.Customer_address);
                cmd.Parameters.AddWithValue("@Customer_phone", String.IsNullOrEmpty(customerModel.Customer_phone) ? null : customerModel.Customer_phone);
                cmd.Parameters.AddWithValue("@Customer_begindate", (customerModel.Customer_begindate == DateTime.MinValue) ? null : customerModel.Customer_begindate);
                cmd.Parameters.AddWithValue("@Account_name", String.IsNullOrEmpty(customerModel.Account_name) ? null : customerModel.Account_name);
                cmd.Parameters.AddWithValue("@Account_password", String.IsNullOrEmpty(customerModel.Account_password) ? null : customerModel.Account_password);
                cmd.Parameters.AddWithValue("@Account_role", customerModel.Account_role.HasValue ? customerModel.Account_role : null);
                cmd.Parameters.AddWithValue("@Account_lastLogin", (customerModel.Account_lastLogin == DateTime.MinValue) ? null : customerModel.Account_lastLogin);
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
                cmd.Parameters.AddWithValue("@Customer_avatar", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_name", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_birth", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_email", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_address", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_phone", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_begindate", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_name", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_password", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_role", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_lastLogin", DBNull.Value);
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
                cmd.Parameters.AddWithValue("@Customer_avatar", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_name", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_birth", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_email", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_address", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_phone", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_begindate", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_name", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_password", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_role", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_lastLogin", DBNull.Value);
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

        #region
        public CustomerModel checkExist(string username, string password)
        {
            try
            {
                CustomerModel returnCustomer = new CustomerModel();
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Customer_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_avatar", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_name", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_birth", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_email", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_address", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_phone", DBNull.Value);
                cmd.Parameters.AddWithValue("@Customer_begindate", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_name", username);
                cmd.Parameters.AddWithValue("@Account_password", password);
                cmd.Parameters.AddWithValue("@Account_role", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_lastLogin", DBNull.Value);
                cmd.Parameters.AddWithValue("@Query", 6);
                SQL_CONNECTION.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    returnCustomer.Customer_id = (int)dr["Customer_id"];
                    returnCustomer.Customer_avatar = (string)dr["Customer_avatar"];
                    returnCustomer.Customer_name = (string)dr["Customer_name"];
                    returnCustomer.Customer_birth = (DateTime)dr["Customer_birth"];
                    returnCustomer.Customer_email = (string)dr["Customer_email"];
                    returnCustomer.Customer_address = (string)dr["Customer_address"];
                    returnCustomer.Customer_phone = (string)dr["Customer_phone"];
                    returnCustomer.Customer_begindate = (DateTime)dr["Customer_begindate"];
                    returnCustomer.Account_name = (string)dr["Account_name"];
                    returnCustomer.Account_password = (string)dr["Account_password"];
                    returnCustomer.Account_role = (int)dr["Account_role"];
                    returnCustomer.Account_lastLogin = (DateTime)dr["Account_lastLogin"];
                }
                return returnCustomer;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {
                SQL_CONNECTION.Close();
            }
        }
        #endregion
    }
}