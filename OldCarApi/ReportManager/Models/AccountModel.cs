using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OldCarApi.Models
{
    public class AccountModel
    {
        public AccountModel(int account_id, string account_name, string account_password, int account_role)
        {
            Account_id = account_id;
            Account_name = account_name;
            Account_password = account_password;
            Account_role = account_role;
        }
        public AccountModel()
        {
        }
        public int Account_id { get; set; }
        public string Account_name { get; set; }
        public string Account_password { get; set; }
        public int Account_role { get; set; }
        public List<AccountModel> ListAccountModels { get; set; }

        public SqlConnection SQL_CONNECTION = new SqlConnection(ConfigurationManager.ConnectionStrings["OldCarApi"].ToString());

        #region Selectalldata
        public DataTable Selectalldata()
        {
            DataTable dt = new DataTable();

            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Account", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Account_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_name", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_password", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_role", DBNull.Value);
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
        public string Insertdata(AccountModel accountModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Account", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Account_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_name", accountModel.Account_name);
                cmd.Parameters.AddWithValue("@Account_password", accountModel.Account_password);
                cmd.Parameters.AddWithValue("@Account_role", accountModel.Account_role);
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
        public string Updatedata(AccountModel accountModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Account", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Account_id", accountModel.Account_id);
                cmd.Parameters.AddWithValue("@Account_name", accountModel.Account_name);
                cmd.Parameters.AddWithValue("@Account_password", accountModel.Account_password);
                cmd.Parameters.AddWithValue("@Account_role", accountModel.Account_role);
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
        public DataTable SelectDataById(string accountId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Account", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Account_id", accountId);
                cmd.Parameters.AddWithValue("@Account_name", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_password", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_role", DBNull.Value);
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

        #region SearchDataByName
        /// <summary>
        /// Tim blog theo ten
        /// </summary>
        /// <param name="BlogName" value="string"></param>
        /// <returns name="listFoundBlog" value="List<Blog>"></returns>
        public DataTable SearchDataByName(string accountName)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Account", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Account_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_name", accountName);
                cmd.Parameters.AddWithValue("@Account_password", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_role", DBNull.Value);
                cmd.Parameters.AddWithValue("@Query", 6);
                SQL_CONNECTION.Open();
                SqlDataAdapter da = new SqlDataAdapter();
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
        #endregion SearchDataByName

        #region DeleteData
        public string DeleteData(string ID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Account", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Account_id", ID);
                cmd.Parameters.AddWithValue("@Account_name", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_password", DBNull.Value);
                cmd.Parameters.AddWithValue("@Account_role", DBNull.Value);
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