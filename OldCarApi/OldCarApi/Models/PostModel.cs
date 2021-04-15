﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OldCarApi.Models
{
    public class PostModel
    {
        public int Post_id { get; set; }
        public int? Post_customer_id { get; set; }
        public int? Post_car_id { get; set; }
        public string Post_title { get; set; }
        public int? Post_car_price { get; set; }
        public string Post_car_origin { get; set; }
        public string Post_car_incolor { get; set; }
        public string Post_car_outcolor { get; set; }
        public string Post_car_tire { get; set; }
        public string Post_car_plate { get; set; }
        public string Post_car_province { get; set; }
        public int? Post_car_km { get; set; }
        public string Post_car_detail { get; set; }
        public int? Post_car_kpl { get; set; }
        public int? Post_car_cond { get; set; }
        public int? Post_car_civilcare { get; set; }
        public int? Post_car_bodycare {get; set; }
        public string Post_car_anothercare { get; set; }
        public string Post_car_frontpic { get; set; }
        public string Post_car_leftpic { get; set; }
        public string Post_car_rightpic { get; set; }
        public string Post_car_behindpic { get; set; }
        public string Post_car_inpic { get; set; }
        public string Post_car_outpic { get; set; }
        public string Post_car_tirepic { get; set; }
        public string Post_car_enginepic { get; set; }
        public string Post_car_trunkpic { get; set; }
        public string Post_car_replaceditems { get; set; }
        public int? Post_car_like { get; set; }
        public DateTime? Post_car_date { get; set; }
        public PostModel() { }
        public SqlConnection SQL_CONNECTION = new SqlConnection(ConfigurationManager.ConnectionStrings["OldCarApi"].ToString());

        #region Selectalldata
        public DataTable Selectalldata()
        {
            DataTable dt = new DataTable();

            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Post", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Post_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_customer_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_title", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_price", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_origin", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_incolor", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_outcolor", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_tire", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_plate", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_province", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_km", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_detail", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_kpl", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_cond", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_civilcare", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_bodycare", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_anothercare", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_frontpic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_leftpic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_rightpic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_behindpic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_inpic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_outpic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_tirepic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_enginepic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_trunkpic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_replaceditems", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_like", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_date", DBNull.Value);
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
        public string Insertdata(PostModel postModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Post", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Post_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_customer_id", postModel.Post_customer_id);
                cmd.Parameters.AddWithValue("@Post_car_id", postModel.Post_car_id.HasValue ? postModel.Post_car_id : null);
                cmd.Parameters.AddWithValue("@Post_title", String.IsNullOrEmpty(postModel.Post_title) ? null : postModel.Post_title);
                cmd.Parameters.AddWithValue("@Post_car_price", postModel.Post_car_price.HasValue ? postModel.Post_car_price : null);
                cmd.Parameters.AddWithValue("@Post_car_origin", String.IsNullOrEmpty(postModel.Post_car_origin) ? null : postModel.Post_car_origin);
                cmd.Parameters.AddWithValue("@Post_car_incolor", String.IsNullOrEmpty(postModel.Post_car_incolor) ? null : postModel.Post_car_incolor);
                cmd.Parameters.AddWithValue("@Post_car_outcolor", String.IsNullOrEmpty(postModel.Post_car_outcolor) ? null : postModel.Post_car_outcolor);
                cmd.Parameters.AddWithValue("@Post_car_tire", String.IsNullOrEmpty(postModel.Post_car_tire) ? null : postModel.Post_car_tire);
                cmd.Parameters.AddWithValue("@Post_car_plate", String.IsNullOrEmpty(postModel.Post_car_plate) ? null : postModel.Post_car_plate);
                cmd.Parameters.AddWithValue("@Post_car_province", String.IsNullOrEmpty(postModel.Post_car_province) ? null : postModel.Post_car_province);
                cmd.Parameters.AddWithValue("@Post_car_km", postModel.Post_car_km.HasValue ? postModel.Post_car_km : null);
                cmd.Parameters.AddWithValue("@Post_car_detail", String.IsNullOrEmpty(postModel.Post_car_detail) ? null : postModel.Post_car_detail);
                cmd.Parameters.AddWithValue("@Post_car_kpl", postModel.Post_car_kpl.HasValue ? postModel.Post_car_kpl : null);
                cmd.Parameters.AddWithValue("@Post_car_cond", postModel.Post_car_cond.HasValue ? postModel.Post_car_cond : null);
                cmd.Parameters.AddWithValue("@Post_car_civilcare", postModel.Post_car_civilcare.HasValue ? postModel.Post_car_civilcare : null);
                cmd.Parameters.AddWithValue("@Post_car_bodycare", postModel.Post_car_bodycare.HasValue ? postModel.Post_car_bodycare : null);
                cmd.Parameters.AddWithValue("@Post_car_anothercare", String.IsNullOrEmpty(postModel.Post_car_anothercare) ? null : postModel.Post_car_anothercare);
                cmd.Parameters.AddWithValue("@Post_car_frontpic", String.IsNullOrEmpty(postModel.Post_car_frontpic) ? null : postModel.Post_car_frontpic);
                cmd.Parameters.AddWithValue("@Post_car_leftpic", String.IsNullOrEmpty(postModel.Post_car_leftpic) ? null : postModel.Post_car_leftpic);
                cmd.Parameters.AddWithValue("@Post_car_rightpic", String.IsNullOrEmpty(postModel.Post_car_rightpic) ? null : postModel.Post_car_rightpic);
                cmd.Parameters.AddWithValue("@Post_car_behindpic", String.IsNullOrEmpty(postModel.Post_car_behindpic) ? null : postModel.Post_car_behindpic); ;
                cmd.Parameters.AddWithValue("@Post_car_inpic", String.IsNullOrEmpty(postModel.Post_car_inpic) ? null : postModel.Post_car_inpic);
                cmd.Parameters.AddWithValue("@Post_car_outpic", String.IsNullOrEmpty(postModel.Post_car_outpic) ? null : postModel.Post_car_outpic);
                cmd.Parameters.AddWithValue("@Post_car_tirepic", String.IsNullOrEmpty(postModel.Post_car_tirepic) ? null : postModel.Post_car_tirepic);
                cmd.Parameters.AddWithValue("@Post_car_enginepic", String.IsNullOrEmpty(postModel.Post_car_enginepic) ? null : postModel.Post_car_enginepic);
                cmd.Parameters.AddWithValue("@Post_car_trunkpic", String.IsNullOrEmpty(postModel.Post_car_trunkpic) ? null : postModel.Post_car_trunkpic);
                cmd.Parameters.AddWithValue("@Post_car_replaceditems", String.IsNullOrEmpty(postModel.Post_car_replaceditems) ? null : postModel.Post_car_replaceditems);
                cmd.Parameters.AddWithValue("@Post_car_like", postModel.Post_car_like.HasValue ? postModel.Post_car_like : null);
                cmd.Parameters.AddWithValue("@Post_car_date", postModel.Post_car_date.HasValue ? postModel.Post_car_date : null);
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
        public string Updatedata(PostModel postModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Post", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Post_id", postModel.Post_id);
                cmd.Parameters.AddWithValue("@Post_customer_id", postModel.Post_customer_id);
                cmd.Parameters.AddWithValue("@Post_car_id", postModel.Post_car_id.HasValue ? postModel.Post_car_id : null);
                cmd.Parameters.AddWithValue("@Post_title", String.IsNullOrEmpty(postModel.Post_title) ? null : postModel.Post_title);
                cmd.Parameters.AddWithValue("@Post_car_price", postModel.Post_car_price.HasValue ? postModel.Post_car_price : null);
                cmd.Parameters.AddWithValue("@Post_car_origin", String.IsNullOrEmpty(postModel.Post_car_origin) ? null : postModel.Post_car_origin);
                cmd.Parameters.AddWithValue("@Post_car_incolor", String.IsNullOrEmpty(postModel.Post_car_incolor) ? null : postModel.Post_car_incolor);
                cmd.Parameters.AddWithValue("@Post_car_outcolor", String.IsNullOrEmpty(postModel.Post_car_outcolor) ? null : postModel.Post_car_outcolor);
                cmd.Parameters.AddWithValue("@Post_car_tire", String.IsNullOrEmpty(postModel.Post_car_tire) ? null : postModel.Post_car_tire);
                cmd.Parameters.AddWithValue("@Post_car_plate", String.IsNullOrEmpty(postModel.Post_car_plate) ? null : postModel.Post_car_plate);
                cmd.Parameters.AddWithValue("@Post_car_province", String.IsNullOrEmpty(postModel.Post_car_province) ? null : postModel.Post_car_province);
                cmd.Parameters.AddWithValue("@Post_car_km", postModel.Post_car_km.HasValue ? postModel.Post_car_km : null);
                cmd.Parameters.AddWithValue("@Post_car_detail", String.IsNullOrEmpty(postModel.Post_car_detail) ? null : postModel.Post_car_detail);
                cmd.Parameters.AddWithValue("@Post_car_kpl", postModel.Post_car_kpl.HasValue ? postModel.Post_car_kpl : null);
                cmd.Parameters.AddWithValue("@Post_car_cond", postModel.Post_car_cond.HasValue ? postModel.Post_car_cond : null);
                cmd.Parameters.AddWithValue("@Post_car_civilcare", postModel.Post_car_civilcare.HasValue ? postModel.Post_car_civilcare : null);
                cmd.Parameters.AddWithValue("@Post_car_bodycare", postModel.Post_car_bodycare.HasValue ? postModel.Post_car_bodycare : null);
                cmd.Parameters.AddWithValue("@Post_car_anothercare", String.IsNullOrEmpty(postModel.Post_car_anothercare) ? null : postModel.Post_car_anothercare);
                cmd.Parameters.AddWithValue("@Post_car_frontpic", String.IsNullOrEmpty(postModel.Post_car_frontpic) ? null : postModel.Post_car_frontpic);
                cmd.Parameters.AddWithValue("@Post_car_leftpic", String.IsNullOrEmpty(postModel.Post_car_leftpic) ? null : postModel.Post_car_leftpic);
                cmd.Parameters.AddWithValue("@Post_car_rightpic", String.IsNullOrEmpty(postModel.Post_car_rightpic) ? null : postModel.Post_car_rightpic);
                cmd.Parameters.AddWithValue("@Post_car_behindpic", String.IsNullOrEmpty(postModel.Post_car_behindpic) ? null : postModel.Post_car_behindpic); ;
                cmd.Parameters.AddWithValue("@Post_car_inpic", String.IsNullOrEmpty(postModel.Post_car_inpic) ? null : postModel.Post_car_inpic);
                cmd.Parameters.AddWithValue("@Post_car_outpic", String.IsNullOrEmpty(postModel.Post_car_outpic) ? null : postModel.Post_car_outpic);
                cmd.Parameters.AddWithValue("@Post_car_tirepic", String.IsNullOrEmpty(postModel.Post_car_tirepic) ? null : postModel.Post_car_tirepic);
                cmd.Parameters.AddWithValue("@Post_car_enginepic", String.IsNullOrEmpty(postModel.Post_car_enginepic) ? null : postModel.Post_car_enginepic);
                cmd.Parameters.AddWithValue("@Post_car_trunkpic", String.IsNullOrEmpty(postModel.Post_car_trunkpic) ? null : postModel.Post_car_trunkpic);
                cmd.Parameters.AddWithValue("@Post_car_replaceditems", String.IsNullOrEmpty(postModel.Post_car_replaceditems) ? null : postModel.Post_car_replaceditems);
                cmd.Parameters.AddWithValue("@Post_car_like", postModel.Post_car_like.HasValue ? postModel.Post_car_like : null);
                cmd.Parameters.AddWithValue("@Post_car_date", postModel.Post_car_date.HasValue ? postModel.Post_car_date : null);
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
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Post", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Post_id", ID);
                cmd.Parameters.AddWithValue("@Post_customer_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_title", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_price", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_origin", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_incolor", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_outcolor", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_tire", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_plate", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_province", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_km", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_detail", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_kpl", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_cond", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_civilcare", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_bodycare", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_anothercare", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_frontpic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_leftpic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_rightpic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_behindpic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_inpic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_outpic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_tirepic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_enginepic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_trunkpic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_replaceditems", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_like", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_date", DBNull.Value);
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
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Post", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Post_id", ID);
                cmd.Parameters.AddWithValue("@Post_customer_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_title", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_price", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_origin", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_incolor", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_outcolor", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_tire", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_plate", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_province", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_km", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_detail", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_kpl", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_cond", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_civilcare", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_bodycare", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_anothercare", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_frontpic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_leftpic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_rightpic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_behindpic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_inpic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_outpic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_tirepic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_enginepic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_trunkpic", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_replaceditems", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_like", DBNull.Value);
                cmd.Parameters.AddWithValue("@Post_car_date", DBNull.Value);
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