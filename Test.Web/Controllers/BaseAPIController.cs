using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.Model;
using Test.Services;

namespace Test.Web.Controllers
{
    public class BaseAPIController<M, S> : ApiController
          where M : class, IEntity<int>
          where S : class, IService<M>, new()
    {


        public S _Service { get; set; }
        public BaseAPIController()
        {
            _Service = new S();
        }



        public virtual IQueryable<M> Get()
        {
            return _Service.Read().AsQueryable();
        }


        public virtual IHttpActionResult Get(int id)
        {

            var item = _Service.ReadById(id);

            if (item != null)
            {
                return Ok(item);
            } else
            {
                return NotFound();
            }
        }



        public virtual IHttpActionResult Put([FromBody] M item)
        {
            if ((!ModelState.IsValid || item == null) && item.Id != 0)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _Service.Update(item);

                return Content(HttpStatusCode.Accepted, item);

            }

        }

        public virtual IHttpActionResult Delete(int id)
        {
            _Service.Delete(id);

            return Ok();
        }


        public virtual IHttpActionResult Post([FromBody] M item)
        {
            if (!ModelState.IsValid || item == null)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var createdId = _Service.Create(item);
                item.Id = createdId;

                return CreatedAtRoute("DefaultApi", new { id = createdId }, item);

            }

        }

    }

}