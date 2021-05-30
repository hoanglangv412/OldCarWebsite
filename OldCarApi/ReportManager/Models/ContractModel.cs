using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OldCarApi.Models
{
    public class ContractModel
    {
        public int Contract_id { get; set; }
        public int Contract_customerBuy_id { get; set; }
        public int Contract_customerSell_id { get; set; }
        public ContractModel() { }
        public List<ContractModel> ListContractModels { get; set; }

        public SqlConnection SQL_CONNECTION = new SqlConnection(ConfigurationManager.ConnectionStrings["OldCarApi"].ToString());

        #region Selectalldata
        public DataTable Selectalldata()
        {
            DataTable dt = new DataTable();

            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Contract", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Contract_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Contract_customerBuy_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Contract_customerSell_id", DBNull.Value);
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

        #region selectsellerData
        public DataTable selectsellerData(string ID)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Contract", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Contract_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Contract_customerBuy_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Contract_customerSell_id", ID);
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
        #endregion

        #region InsertData
        public string Insertdata(ContractModel contractModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Contract", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Contract_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Contract_customerBuy_id", contractModel.Contract_customerBuy_id);
                cmd.Parameters.AddWithValue("@Contract_customerSell_id", contractModel.Contract_customerSell_id);
                cmd.Parameters.AddWithValue("@Query", 1);
                SQL_CONNECTION.Open();
                cmd.ExecuteNonQuery();

                return "1-Tạo thành công";
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
        public string Updatedata(ContractModel contractModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Contract", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Contract_id", contractModel.Contract_id);
                cmd.Parameters.AddWithValue("@Contract_customerBuy_id", contractModel.Contract_customerBuy_id);
                cmd.Parameters.AddWithValue("@Contract_customerSell_id", contractModel.Contract_customerSell_id);
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
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Contract", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Contract_id", ID);
                cmd.Parameters.AddWithValue("@Contract_customerBuy_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Contract_customerSell_id", DBNull.Value);
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
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Contract", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Contract_id", ID);
                cmd.Parameters.AddWithValue("@Contract_customerBuy_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Contract_customerSell_id", DBNull.Value);
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