﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OldCarApi.Models
{
    public class CarModel
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
        public string Car_loadweight { get; set; }
        public int? Car_doors { get; set; }
        public string Car_drivetype { get; set; }
        public string Car_totaldimens { get; set; }
        public int? Car_baselength { get; set; }
        public int? Car_turnradius { get; set; }
        public int? Car_height { get; set; }
        public string Car_cylcapacity { get; set; }
        public string Car_brakesystem { get; set; }
        public int? Car_airnums { get; set; }
        public string Car_acceleration { get; set; }
        public string Car_handbrake { get; set; }
        public string Car_cityfuelconsump { get; set; }
        public string Car_highwayfuelconsump { get; set; }
        public string Car_adder { get; set; }
        public CarModel(){}
        public List<CarModel> ListCarModels { get; set; }

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
                cmd.Parameters.AddWithValue("@Car_airnums", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_acceleration", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_handbrake", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_cityfuelconsump", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_highwayfuelconsump", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_adder", DBNull.Value);
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

        #region Selectlastdata
        public DataTable Selectlastdata()
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
                cmd.Parameters.AddWithValue("@Car_airnums", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_acceleration", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_handbrake", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_cityfuelconsump", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_highwayfuelconsump", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_adder", DBNull.Value);
                cmd.Parameters.AddWithValue("@Query", 8);
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
        #endregion Selectlastdata

        #region SelectalldataFORCOMBOBOX
        public DataTable Selectalldataforcombobox()
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
                cmd.Parameters.AddWithValue("@Car_airnums", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_acceleration", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_handbrake", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_cityfuelconsump", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_highwayfuelconsump", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_adder", DBNull.Value);
                cmd.Parameters.AddWithValue("@Query", 7);
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
        public string Insertdata(CarModel carModel)
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
                cmd.Parameters.AddWithValue("@Car_seats", !carModel.Car_seats.HasValue ? null : carModel.Car_seats);
                cmd.Parameters.AddWithValue("@Car_maxmomen", String.IsNullOrEmpty(carModel.Car_maxmomen) ? null : carModel.Car_maxmomen);
                cmd.Parameters.AddWithValue("@Car_maxspeed", !carModel.Car_maxspeed.HasValue ? null : carModel.Car_maxspeed);
                cmd.Parameters.AddWithValue("@Car_maxpower", String.IsNullOrEmpty(carModel.Car_maxpower) ? null : carModel.Car_maxpower);
                cmd.Parameters.AddWithValue("@Car_loadweight", String.IsNullOrEmpty(carModel.Car_loadweight) ? null : carModel.Car_loadweight);
                cmd.Parameters.AddWithValue("@Car_doors", !carModel.Car_doors.HasValue ? null : carModel.Car_doors);
                cmd.Parameters.AddWithValue("@Car_drivetype", String.IsNullOrEmpty(carModel.Car_drivetype) ? null : carModel.Car_drivetype);
                cmd.Parameters.AddWithValue("@Car_totaldimens", String.IsNullOrEmpty(carModel.Car_totaldimens) ? null : carModel.Car_totaldimens);
                cmd.Parameters.AddWithValue("@Car_baselength", !carModel.Car_baselength.HasValue ? null : carModel.Car_baselength);
                cmd.Parameters.AddWithValue("@Car_turnradius", !carModel.Car_turnradius.HasValue ? null : carModel.Car_turnradius);
                cmd.Parameters.AddWithValue("@Car_height", !carModel.Car_height.HasValue ? null : carModel.Car_height);
                cmd.Parameters.AddWithValue("@Car_cylcapacity", String.IsNullOrEmpty(carModel.Car_cylcapacity) ? null : carModel.Car_cylcapacity);
                cmd.Parameters.AddWithValue("@Car_brakesystem", String.IsNullOrEmpty(carModel.Car_brakesystem) ? null : carModel.Car_brakesystem);
                cmd.Parameters.AddWithValue("@Car_airnums", !carModel.Car_airnums.HasValue ? null : carModel.Car_airnums);
                cmd.Parameters.AddWithValue("@Car_acceleration", String.IsNullOrEmpty(carModel.Car_acceleration) ? null : carModel.Car_acceleration);
                cmd.Parameters.AddWithValue("@Car_handbrake", String.IsNullOrEmpty(carModel.Car_handbrake) ? null : carModel.Car_handbrake);
                cmd.Parameters.AddWithValue("@Car_cityfuelconsump", String.IsNullOrEmpty(carModel.Car_cityfuelconsump) ? null : carModel.Car_cityfuelconsump);
                cmd.Parameters.AddWithValue("@Car_highwayfuelconsump", String.IsNullOrEmpty(carModel.Car_highwayfuelconsump) ? null : carModel.Car_highwayfuelconsump);
                cmd.Parameters.AddWithValue("@Car_adder", String.IsNullOrEmpty(carModel.Car_adder) ? null : carModel.Car_adder);
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
        public string Updatedata(CarModel carModel)
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
                cmd.Parameters.AddWithValue("@Car_seats", !carModel.Car_seats.HasValue ? null : carModel.Car_seats);
                cmd.Parameters.AddWithValue("@Car_maxmomen", String.IsNullOrEmpty(carModel.Car_maxmomen) ? null : carModel.Car_maxmomen);
                cmd.Parameters.AddWithValue("@Car_maxspeed", !carModel.Car_maxspeed.HasValue ? null : carModel.Car_maxspeed);
                cmd.Parameters.AddWithValue("@Car_maxpower", String.IsNullOrEmpty(carModel.Car_maxpower) ? null : carModel.Car_maxpower);
                cmd.Parameters.AddWithValue("@Car_loadweight", String.IsNullOrEmpty(carModel.Car_loadweight) ? null : carModel.Car_loadweight);
                cmd.Parameters.AddWithValue("@Car_doors", !carModel.Car_doors.HasValue ? null : carModel.Car_doors);
                cmd.Parameters.AddWithValue("@Car_drivetype", String.IsNullOrEmpty(carModel.Car_drivetype) ? null : carModel.Car_drivetype);
                cmd.Parameters.AddWithValue("@Car_totaldimens", String.IsNullOrEmpty(carModel.Car_totaldimens) ? null : carModel.Car_totaldimens);
                cmd.Parameters.AddWithValue("@Car_baselength", !carModel.Car_baselength.HasValue ? null : carModel.Car_baselength);
                cmd.Parameters.AddWithValue("@Car_turnradius", !carModel.Car_turnradius.HasValue ? null : carModel.Car_turnradius);
                cmd.Parameters.AddWithValue("@Car_height", !carModel.Car_height.HasValue ? null : carModel.Car_height);
                cmd.Parameters.AddWithValue("@Car_cylcapacity", String.IsNullOrEmpty(carModel.Car_cylcapacity) ? null : carModel.Car_cylcapacity);
                cmd.Parameters.AddWithValue("@Car_brakesystem", String.IsNullOrEmpty(carModel.Car_brakesystem) ? null : carModel.Car_brakesystem);
                cmd.Parameters.AddWithValue("@Car_airnums", !carModel.Car_airnums.HasValue ? null : carModel.Car_airnums);
                cmd.Parameters.AddWithValue("@Car_acceleration", String.IsNullOrEmpty(carModel.Car_acceleration) ? null : carModel.Car_acceleration);
                cmd.Parameters.AddWithValue("@Car_handbrake", String.IsNullOrEmpty(carModel.Car_handbrake) ? null : carModel.Car_handbrake);
                cmd.Parameters.AddWithValue("@Car_cityfuelconsump", String.IsNullOrEmpty(carModel.Car_cityfuelconsump) ? null : carModel.Car_cityfuelconsump);
                cmd.Parameters.AddWithValue("@Car_highwayfuelconsump", String.IsNullOrEmpty(carModel.Car_highwayfuelconsump) ? null : carModel.Car_highwayfuelconsump);
                cmd.Parameters.AddWithValue("@Car_adder", String.IsNullOrEmpty(carModel.Car_adder) ? null : carModel.Car_adder);
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
                cmd.Parameters.AddWithValue("@Car_airnums", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_acceleration", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_handbrake", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_cityfuelconsump", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_highwayfuelconsump", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_adder", DBNull.Value);
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

        #region SelectNameById
        public DataTable SelectNameById(string ID)
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
                cmd.Parameters.AddWithValue("@Car_airnums", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_acceleration", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_handbrake", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_cityfuelconsump", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_highwayfuelconsump", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_adder", DBNull.Value);
                cmd.Parameters.AddWithValue("@Query", 6);
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
                cmd.Parameters.AddWithValue("@Car_airnums", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_acceleration", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_handbrake", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_cityfuelconsump", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_highwayfuelconsump", DBNull.Value);
                cmd.Parameters.AddWithValue("@Car_adder", DBNull.Value);
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