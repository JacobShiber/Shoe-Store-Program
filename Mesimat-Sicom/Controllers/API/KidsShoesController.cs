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
    public class KidsShoesController : ApiController
    {
        static string connectionString = "Data Source=DESKTOP-76KPC67;Initial Catalog=ShoeStoreDB;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework";
        KidsShoesDataContext dataContext = new KidsShoesDataContext(connectionString);
        // GET: api/KidsShoes
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new { Massage = "Success", Shoes = dataContext.KidsShoesTables.ToList() });
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

        // GET: api/KidsShoes/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                KidsShoesTable expectedShoe = dataContext.KidsShoesTables.First(shoe => shoe.Id == id);

                return Ok(new { Massage = "Success", expectedShoe });
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

        // POST: api/KidsShoes
        public IHttpActionResult Post([FromBody] KidsShoesTable newShoe)
        {
            try
            {
                dataContext.KidsShoesTables.InsertOnSubmit(newShoe);
                dataContext.SubmitChanges();

                return Ok(new { Massage = "Success, new shoe added" });
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

        // PUT: api/KidsShoes/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] KidsShoesTable editedShoe)
        {
            try
            {
                KidsShoesTable expectedShoe = dataContext.KidsShoesTables.First(shoe => shoe.Id == id);

                expectedShoe.CompanyName = editedShoe.CompanyName;
                expectedShoe.IsInStock = editedShoe.IsInStock;
                expectedShoe.Material = editedShoe.Material;
                expectedShoe.Price = editedShoe.Price;
                expectedShoe.Size = editedShoe.Size;


                dataContext.SubmitChanges();

                return Ok(new { Massage = "Success, shoe edited" });
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

        // DELETE: api/KidsShoes/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                dataContext.KidsShoesTables.DeleteOnSubmit(dataContext.KidsShoesTables.First(shoe => shoe.Id == id));
                dataContext.SubmitChanges();

                return Ok(new { Massage = "Success, shoe deleted" });
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
