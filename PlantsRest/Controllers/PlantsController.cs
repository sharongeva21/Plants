using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlantsDAL;
using System.Security.Cryptography;

namespace PlantsRest.Controllers
{
    //[RoutePrefix("Api/Plants")]
    public class PlantsController : ApiController
    {

        // GET: api/Plants
        [HttpGet]
        [Route("Api/Plants/allPlants")]
        public IEnumerable<Plant> Get()
        {
            PlantsEntities entities = new PlantsEntities();
            return entities.Plants.ToList();
            
        }

        [HttpGet]
        [Route("Api/Plants/GetPlantDetailsById/{plantID}")]
        public IHttpActionResult GetPlantById(string plantID)
        {
            PlantsEntities entities = new PlantsEntities();
            Plant objEmp = new Plant();
            int ID = Convert.ToInt32(plantID);
            try
            {
                objEmp = entities.Plants.Find(ID);
                if (objEmp == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                throw;
            }

            return Ok(objEmp);
        }

        [HttpGet]
        [Route("Api/Plants/getUserByID/{userID}")]
        public IHttpActionResult getUserByID(string userID)
        {
            PlantsEntities entities = new PlantsEntities();
            user objEmp = new user();
            int ID = Convert.ToInt32(userID);
            try
            {

                objEmp = entities.users.Find(ID);
                if (objEmp == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                throw;
            }

            return Ok(objEmp);
        }

        // POST: api/Plants
        [HttpPost]
        [Route("Api/Plants/registerNewUser")]
        public IHttpActionResult Register([FromBody] user userData)
        {
            PlantsEntities entities = new PlantsEntities();
            user objEmp = new user();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                entities.users.Add(userData);
                entities.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(userData);
        }

        //// PUT: api/Plants/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Plants/5
        //public void Delete(int id)
        //{
        //}
    }
}
