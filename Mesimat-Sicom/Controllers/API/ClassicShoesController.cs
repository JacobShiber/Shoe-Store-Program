using Mesimat_Sicom.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Mesimat_Sicom.Controllers.API
{
    public class ClassicShoesController : ApiController
    {
        ShoeStoreContext dataContext = new ShoeStoreContext();
        // GET: api/ClassicShoes
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new { Massage = "Success", Shoes = dataContext.ClassicShoesTable.ToList() });
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

        // GET: api/ClassicShoes/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                ClassicShoe expectedShoe = await dataContext.ClassicShoesTable.FindAsync(id);
                if (expectedShoe.CompanyName != null) return Ok(new { Massage = "Success", Shoe = expectedShoe });
                else return NotFound();
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

        // POST: api/ClassicShoes
        public async Task<IHttpActionResult> Post([FromBody] ClassicShoe newShoe)
        {
            try
            {
                dataContext.ClassicShoesTable.Add(newShoe);
                await dataContext.SaveChangesAsync();

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

        // PUT: api/ClassicShoes/5
        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] ClassicShoe editedShoe)
        {
            try
            {
                ClassicShoe expectedShoe = await dataContext.ClassicShoesTable.FindAsync(id);
                if (expectedShoe.CompanyName != null)
                {
                    expectedShoe.CompanyName = editedShoe.CompanyName;
                    expectedShoe.Gender = editedShoe.Gender;
                    expectedShoe.HasHeel = editedShoe.HasHeel;
                    expectedShoe.IsInStock = editedShoe.IsInStock;
                    expectedShoe.Price = editedShoe.Price;
                    expectedShoe.Size = editedShoe.Size;

                    await dataContext.SaveChangesAsync();

                    return Ok(new { Massage = "Success, shoe been edited" });
                }
                else return NotFound();
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

        // DELETE: api/ClassicShoes/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                ClassicShoe expectedShoe = await dataContext.ClassicShoesTable.FindAsync(id);
                if (expectedShoe.CompanyName != null)
                {
                    dataContext.ClassicShoesTable.Remove(expectedShoe);
                    await dataContext.SaveChangesAsync();

                    return Ok(new { Massage = "Success, shoe deleted" });
                }
                else return NotFound();
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
