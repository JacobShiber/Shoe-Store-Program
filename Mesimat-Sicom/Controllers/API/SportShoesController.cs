using Mesimat_Sicom.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mesimat_Sicom.Controllers.API
{
    public class SportShoesController : ApiController
    {
        string connectionString = "Data Source=DESKTOP-76KPC67;Initial Catalog=ShoeStoreDB;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework";
        // GET: api/SportShoes
        public IHttpActionResult Get()
        {
            try
            {
                List<SportShoe> shoeList = new List<SportShoe>();
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM SportShoeTable";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            shoeList.Add(new SportShoe(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetInt32(3), dataReader.GetInt32(4)));
                        }
                    }
                    connection.Close();
                    return Ok(new { Massage = "Success", shoeList });
                }
            }
            catch(SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/SportShoes/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                SportShoe expectedShoe = new SportShoe();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $@"SELECT * FROM SportShoeTable WHERE SportShoeTable.Id = {id}";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            expectedShoe.Id = dataReader.GetInt32(0);
                            expectedShoe.CompanyName = dataReader.GetString(1);
                            expectedShoe.ModelName = dataReader.GetString(2);
                            expectedShoe.Size = dataReader.GetInt32(3);
                            expectedShoe.Price = dataReader.GetInt32(4);
                        }
                    }
                    connection.Close();
                    return Ok(new { Massage = "Success", expectedShoe });
                }
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/SportShoes
        public IHttpActionResult Post([FromBody]SportShoe newShoe)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $@"INSERT INTO SportShoeTable(CompanyName, ModelName, Size, Price) VALUES ('{newShoe.CompanyName}','{newShoe.ModelName}', {newShoe.Size}, {newShoe.Price})";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rows = command.ExecuteNonQuery();
                    connection.Close();
                    if (rows > 0) return Ok(new { Massage = "Success, new shoe added" });
                    else return BadRequest("there was a problem doing this");
                }
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/SportShoes/5
        public IHttpActionResult Put(int id, [FromBody] SportShoe editedShoe)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"UPDATE SportShoeTable SET CompanyName = '{editedShoe.CompanyName}', ModelName = '{editedShoe.ModelName}', Size = {editedShoe.Size}, Price = {editedShoe.Price} WHERE SportShoeTable.Id = {id}";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rows = command.ExecuteNonQuery();
                    connection.Close();
                    if (rows > 0) return Ok(new { Massage = "Success, shoe edited" });
                    else return BadRequest("there was a problem doing this");
                }
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/SportShoes/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"DELETE FROM SportShoeTable WHERE SportShoeTable.Id = {id}";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rows = command.ExecuteNonQuery();
                    connection.Close();
                    if (rows > 0) return Ok(new { Massage = "Success, shoe deleted" });
                    else return BadRequest("there was a problem doing this");
                }
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
