using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OldCarApi.Models
{
    public class CarInfoModel
    {
        public int Car_id { get; set; }
        public int Car_carversion_id { get; set; }
        public string Car_trans { get; set; }
        public string Car_fuel { get; set; }
        public string Car_engine { get; set; }
        public int? Car_seats { get; set; }
        public string Car_maxmomen{get;set;}
        public int? Car_maxspeed { get; set; }
        public string Car_maxpower { get; set; }
        public int? Car_loadweight { get; set; }
        public int? Car_doors { get; set; }
        public string Car_drivetype { get; set; }
        public string Car_totaldimens { get; set; }
        public int? Car_baselength { get; set; }
        public int? Car_turnradius { get; set; }
        public int? Car_height { get; set; }
        public int? Car_cylcapacity { get; set; }
        public string Car_brakesystem { get; set; }
        public string Car_fuelsystem { get; set; }
        public int? Car_airnums { get; set; }
        public int? Car_gps { get; set; }
        public int? Car_touchscreen { get; set; }
        public string Car_camera { get; set; }
        public string Car_doortype { get; set; }
        public string Car_mirror { get; set; }
        public string Car_balance { get; set; }
        public string Car_seattype { get; set; }
        public string Car_sound { get; set; }
        public int? Car_skyview { get; set; }
        public int? Car_electrunk { get; set; }
        public CarInfoModel(){}
        public List<CarInfoModel> ListCarModels { get; set; }

        public SqlConnection SQL_CONNECTION = new SqlConnection(ConfigurationManager.ConnectionStrings["OldCarApi"].ToString());

        #region Selectalldata
        public DataTable Selectalldata()
        {
            DataTable dt = new DataTable();

            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Car", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Car_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_carversion_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_trans", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_fuel", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_engine", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_seats", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_maxmomen", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_maxspeed", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_maxpower", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_loadweight", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_doors", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_drivetype", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_totaldimens", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_baselength", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_turnradius", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_height", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_cylcapacity", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_brakesystem", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_fuelsystem", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_airnums", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_gps", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_touchscreen", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_camera", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_doortype", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_mirror", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_balance", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_seattype", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_sound", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_skyview", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_electrunk", DBNull.Value);
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
        public string Insertdata(CarInfoModel carModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Car", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Car_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_carversion_id", carModel.Car_carversion_id);
                cmd.Parameters.AddWithValue("@Car_trans", String.IsNullOrEmpty(carModel.Car_trans) ? null : carModel.Car_trans);
                cmd.Parameters.AddWithValue("@Car_fuel", String.IsNullOrEmpty(carModel.Car_fuel) ? null : carModel.Car_fuel);
                cmd.Parameters.AddWithValue("@Car_engine", String.IsNullOrEmpty(carModel.Car_engine) ? null : carModel.Car_engine);
                cmd.Parameters.AddWithValue("@Car_seats", carModel.Car_seats.HasValue ? null : carModel.Car_seats);
                cmd.Parameters.AddWithValue("@Car_maxmomen", String.IsNullOrEmpty(carModel.Car_maxmomen) ? null : carModel.Car_maxmomen);
                cmd.Parameters.AddWithValue("@Car_maxspeed", carModel.Car_maxspeed.HasValue ? null : carModel.Car_maxspeed);
                cmd.Parameters.AddWithValue("@Car_maxpower", String.IsNullOrEmpty(carModel.Car_maxpower) ? null : carModel.Car_maxpower);
                cmd.Parameters.AddWithValue("@Car_loadweight", carModel.Car_loadweight.HasValue ? null : carModel.Car_loadweight);
                cmd.Parameters.AddWithValue("@Car_doors", carModel.Car_doors.HasValue ? null : carModel.Car_doors);
                cmd.Parameters.AddWithValue("@Car_drivetype", String.IsNullOrEmpty(carModel.Car_drivetype) ? null : carModel.Car_drivetype);
                cmd.Parameters.AddWithValue("@Car_totaldimens", String.IsNullOrEmpty(carModel.Car_totaldimens) ? null : carModel.Car_totaldimens);
                cmd.Parameters.AddWithValue("@Car_baselength", carModel.Car_baselength.HasValue ? null : carModel.Car_baselength);
                cmd.Parameters.AddWithValue("@Car_turnradius", carModel.Car_turnradius.HasValue ? null : carModel.Car_turnradius);
                cmd.Parameters.AddWithValue("@Car_height", carModel.Car_height.HasValue ? null : carModel.Car_height);
                cmd.Parameters.AddWithValue("@Car_cylcapacity", carModel.Car_cylcapacity.HasValue ? null : carModel.Car_cylcapacity);
                cmd.Parameters.AddWithValue("@Car_brakesystem", String.IsNullOrEmpty(carModel.Car_brakesystem) ? null : carModel.Car_brakesystem);
                cmd.Parameters.AddWithValue("@Car_fuelsystem", String.IsNullOrEmpty(carModel.Car_fuelsystem) ? null : carModel.Car_fuelsystem);
                cmd.Parameters.AddWithValue("@Car_airnums", carModel.Car_airnums.HasValue ? null : carModel.Car_airnums);
                cmd.Parameters.AddWithValue("@Car_gps", carModel.Car_gps.HasValue ? null : carModel.Car_gps);
                cmd.Parameters.AddWithValue("@Car_touchscreen", carModel.Car_touchscreen.HasValue ? null : carModel.Car_touchscreen);
                cmd.Parameters.AddWithValue("@Car_camera", String.IsNullOrEmpty(carModel.Car_camera) ? null : carModel.Car_camera);
                cmd.Parameters.AddWithValue("@Car_doortype", String.IsNullOrEmpty(carModel.Car_doortype) ? null : carModel.Car_doortype);
                cmd.Parameters.AddWithValue("@Car_mirror", String.IsNullOrEmpty(carModel.Car_mirror) ? null : carModel.Car_mirror);
                cmd.Parameters.AddWithValue("@Car_balance", String.IsNullOrEmpty(carModel.Car_balance) ? null : carModel.Car_balance);
                cmd.Parameters.AddWithValue("@Car_seattype", String.IsNullOrEmpty(carModel.Car_seattype) ? null : carModel.Car_seattype);
                cmd.Parameters.AddWithValue("@Car_sound", String.IsNullOrEmpty(carModel.Car_sound) ? null : carModel.Car_sound);
                cmd.Parameters.AddWithValue("@Car_skyview", carModel.Car_skyview.HasValue ? null : carModel.Car_skyview);
                cmd.Parameters.AddWithValue("@Car_electrunk", carModel.Car_electrunk.HasValue ? null : carModel.Car_electrunk);
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
        public string Updatedata(CarInfoModel carModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Car", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Car_id", carModel.Car_id);
                cmd.Parameters.AddWithValue("@Car_carversion_id", carModel.Car_carversion_id);
                cmd.Parameters.AddWithValue("@Car_trans", String.IsNullOrEmpty(carModel.Car_trans) ? null : carModel.Car_trans);
                cmd.Parameters.AddWithValue("@Car_fuel", String.IsNullOrEmpty(carModel.Car_fuel) ? null : carModel.Car_fuel);
                cmd.Parameters.AddWithValue("@Car_engine", String.IsNullOrEmpty(carModel.Car_engine) ? null : carModel.Car_engine);
                cmd.Parameters.AddWithValue("@Car_seats", carModel.Car_seats.HasValue ? null : carModel.Car_seats);
                cmd.Parameters.AddWithValue("@Car_maxmomen", String.IsNullOrEmpty(carModel.Car_maxmomen) ? null : carModel.Car_maxmomen);
                cmd.Parameters.AddWithValue("@Car_maxspeed", carModel.Car_maxspeed.HasValue ? null : carModel.Car_maxspeed);
                cmd.Parameters.AddWithValue("@Car_maxpower", String.IsNullOrEmpty(carModel.Car_maxpower) ? null : carModel.Car_maxpower);
                cmd.Parameters.AddWithValue("@Car_loadweight", carModel.Car_loadweight.HasValue ? null : carModel.Car_loadweight);
                cmd.Parameters.AddWithValue("@Car_doors", carModel.Car_doors.HasValue ? null : carModel.Car_doors);
                cmd.Parameters.AddWithValue("@Car_drivetype", String.IsNullOrEmpty(carModel.Car_drivetype) ? null : carModel.Car_drivetype);
                cmd.Parameters.AddWithValue("@Car_totaldimens", String.IsNullOrEmpty(carModel.Car_totaldimens) ? null : carModel.Car_totaldimens);
                cmd.Parameters.AddWithValue("@Car_baselength", carModel.Car_baselength.HasValue ? null : carModel.Car_baselength);
                cmd.Parameters.AddWithValue("@Car_turnradius", carModel.Car_turnradius.HasValue ? null : carModel.Car_turnradius);
                cmd.Parameters.AddWithValue("@Car_height", carModel.Car_height.HasValue ? null : carModel.Car_height);
                cmd.Parameters.AddWithValue("@Car_cylcapacity", carModel.Car_cylcapacity.HasValue ? null : carModel.Car_cylcapacity);
                cmd.Parameters.AddWithValue("@Car_brakesystem", String.IsNullOrEmpty(carModel.Car_brakesystem) ? null : carModel.Car_brakesystem);
                cmd.Parameters.AddWithValue("@Car_fuelsystem", String.IsNullOrEmpty(carModel.Car_fuelsystem) ? null : carModel.Car_fuelsystem);
                cmd.Parameters.AddWithValue("@Car_airnums", carModel.Car_airnums.HasValue ? null : carModel.Car_airnums);
                cmd.Parameters.AddWithValue("@Car_gps", carModel.Car_gps.HasValue ? null : carModel.Car_gps);
                cmd.Parameters.AddWithValue("@Car_touchscreen", carModel.Car_touchscreen.HasValue ? null : carModel.Car_touchscreen);
                cmd.Parameters.AddWithValue("@Car_camera", String.IsNullOrEmpty(carModel.Car_camera) ? null : carModel.Car_camera);
                cmd.Parameters.AddWithValue("@Car_doortype", String.IsNullOrEmpty(carModel.Car_doortype) ? null : carModel.Car_doortype);
                cmd.Parameters.AddWithValue("@Car_mirror", String.IsNullOrEmpty(carModel.Car_mirror) ? null : carModel.Car_mirror);
                cmd.Parameters.AddWithValue("@Car_balance", String.IsNullOrEmpty(carModel.Car_balance) ? null : carModel.Car_balance);
                cmd.Parameters.AddWithValue("@Car_seattype", String.IsNullOrEmpty(carModel.Car_seattype) ? null : carModel.Car_seattype);
                cmd.Parameters.AddWithValue("@Car_sound", String.IsNullOrEmpty(carModel.Car_sound) ? null : carModel.Car_sound);
                cmd.Parameters.AddWithValue("@Car_skyview", carModel.Car_skyview.HasValue ? null : carModel.Car_skyview);
                cmd.Parameters.AddWithValue("@Car_electrunk", carModel.Car_electrunk.HasValue ? null : carModel.Car_electrunk);
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
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Car", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Car_id", ID);
                cmd.Parameters.AddWithValue("@Car_carversion_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_trans", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_fuel", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_engine", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_seats", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_maxmomen", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_maxspeed", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_maxpower", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_loadweight", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_doors", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_drivetype", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_totaldimens", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_baselength", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_turnradius", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_height", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_cylcapacity", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_brakesystem", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_fuelsystem", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_airnums", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_gps", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_touchscreen", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_camera", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_doortype", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_mirror", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_balance", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_seattype", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_sound", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_skyview", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_electrunk", DBNull.Value);
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
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Car", SQL_CONNECTION);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Car_id", ID);
                cmd.Parameters.AddWithValue("@Car_carversion_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_trans", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_fuel", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_engine", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_seats", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_maxmomen", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_maxspeed", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_maxpower", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_loadweight", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_doors", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_drivetype", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_totaldimens", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_baselength", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_turnradius", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_height", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_cylcapacity", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_brakesystem", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_fuelsystem", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_airnums", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_gps", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_touchscreen", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_camera", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_doortype", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_mirror", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_balance", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_seattype", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_sound", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_skyview", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_electrunk", DBNull.Value);
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