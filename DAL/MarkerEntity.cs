using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using weLab_9.Models;

namespace weLab_9.DAL
{
    public class MarkerEntity
    {
        public MarkerEntity()
        {
            sqlConnection = new SqlConnection(connection);
        }
        private string connection = @"Persist Security Info=False;User ID=sa;Initial Catalog=SqlProjectdb;Data Source=DESKTOP-7GUB027\SQLEXPRESS; integrated security = SSPI";
        private SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;
        private string query;
        private SqlDataReader sqlDataReader = null;
        private int rowsAffected = 0;
        public List<Marker> GetMarkers(string id)
        {
            int itId = Convert.ToInt32(id);
            List<Marker> list = new List<Marker>();
            if (id != null)
            {
                query = $"SELECT * FROM Markers WHERE mrk_id = '{itId}'";
            }
            else
            {
                query = "SELECT * FROM Markers";
            }
            
            sqlConnection.Open();
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                list.Add(new Marker
                {
                    Id = Convert.ToInt32(sqlDataReader[0].ToString()),
                    Manufacturer = sqlDataReader[1].ToString(),
                    Color = sqlDataReader[2].ToString(),
                    Type = sqlDataReader[3].ToString(),
                    Price = Convert.ToInt32(sqlDataReader[4].ToString()),
                    PrdDate = Convert.ToDateTime(sqlDataReader[5]),
                    PrdDateShort = Convert.ToDateTime(sqlDataReader[5]).ToShortDateString(),
                });
            }
            sqlConnection.Close();
            return list;
        }
        public int AddMarker(Marker marker)
        {
            try
            {
                query = "INSERT INTO Markers(mrk_manufacturer, mrk_color, mrk_type, mrk_price, prd_date) " +
                    "Values('" + marker.Manufacturer + "', '" + marker.Color + "', '" + marker.Type + "'," +
                    "'" + marker.Price + "','" + marker.PrdDate + "')";
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                rowsAffected = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return rowsAffected;
            }
            sqlConnection.Close();

            return rowsAffected;
        }
        public Marker GetMarkerById(int id)
        {
            Marker marker = new Marker();
            query = $"SELECT * FROM Markers WHERE mrk_id = '{id}'";
            sqlConnection.Open();
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while(sqlDataReader.Read())
            {
                marker.Id = Convert.ToInt32(sqlDataReader["mrk_id"].ToString());
                marker.Manufacturer = sqlDataReader[1].ToString();
                marker.Color = sqlDataReader[2].ToString();
             
                marker.Type = sqlDataReader[3].ToString();
                marker.Price = Convert.ToInt32(sqlDataReader[4].ToString());
                marker.PrdDate = Convert.ToDateTime(sqlDataReader[5]);
            }
            sqlConnection.Close ();
            return marker;
        }
        public int Update(Marker marker)
        {
            query = $"UPDATE Markers " +
                $"SET " +
                $"mrk_manufacturer = '{marker.Manufacturer}' " +
                $"mrk_color = '{marker.Color}' " +
                $"mrk_type = '{marker.Type}' " +
                $"mrk_price = '{marker.Price}' " +
                $"prd_date = '{marker.PrdDate}' " +
                $"WHERE mrk_id = {marker.Id}";
            sqlConnection.Open();
            sqlCommand = new SqlCommand(query, sqlConnection);
            try
            {
                rowsAffected = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                rowsAffected = 0;
            }
            sqlConnection.Close();
            return rowsAffected;
        }
        public int Delete(int id)
        {
            query = $"DELETE FROM Markers WHERE mrk_id = {id}";
            sqlConnection.Open();
            sqlCommand = new SqlCommand(query,sqlConnection);
            try
            {
                rowsAffected = sqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                rowsAffected= 0;
            }
            sqlConnection.Close();
            return rowsAffected;
        }

    }
}