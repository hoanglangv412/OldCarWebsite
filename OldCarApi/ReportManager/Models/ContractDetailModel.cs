using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OldCarApi.Models
{
    public class ContractDetailModel
    {
        public int Contractdetail_contract_id { get; set; }
        public int Contractdetail_post_id { get; set; }
        public DateTime? Contractdetail_date { get; set; }
        public List<ContractDetailModel> ListContractdetailModels { get; set; }

        public SqlConnection SQL_CONNECTION = new SqlConnection(ConfigurationManager.ConnectionStrings["OldCarApi"].ToString());
        #region Selectalldata
        public DataTable Selectalldata()
        {
            DataTable dt = new DataTable();

            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Contractdetail", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Contractdetail_contract_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Contractdetail_post_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Contractdetail_date", DBNull.Value);
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
        public string Insertdata(ContractDetailModel contractdetailModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Contractdetail", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Contractdetail_contract_id", contractdetailModel.Contractdetail_contract_id);
                cmd.Parameters.AddWithValue("@Contractdetail_post_id", contractdetailModel.Contractdetail_post_id);
                cmd.Parameters.AddWithValue("@Contractdetail_date", DBNull.Value);
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

        #region SelectDataById
        public DataTable SelectDataById(string contract_id, string post_id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Contractdetail", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Contractdetail_contract_id", contract_id);
                cmd.Parameters.AddWithValue("@Contractdetail_post_id", post_id);
                cmd.Parameters.AddWithValue("@Contractdetail_date", DBNull.Value);
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
        public string DeleteData(string contract_id, string post_id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Contractdetail", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Contractdetail_contract_id", contract_id);
                cmd.Parameters.AddWithValue("@Contractdetail_post_id", post_id);
                cmd.Parameters.AddWithValue("@Contractdetail_date", DBNull.Value);
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