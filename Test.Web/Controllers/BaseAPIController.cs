//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//namespace Test.Web.Controllers
//{
//    [APIException]
//    public class BaseAPIController<T, TVM, S> : ApiController
//          where T : class, IEntity<int>
//          where TVM : class, IViewModel<int>
//          where S : class, IGenericService<T, TVM>, new()
//    {


//        public S _Service { get; set; }
//        public BaseAPIController()
//        {
//            _Service = new S();
//        }



//        [EnableQuery]
//        public virtual IQueryable<TVM> Get()
//        {
//            return _Service.Get().AsQueryable();
//        }


//        public virtual IHttpActionResult Get(int id)
//        {

//            var item = _Service.GetById(id);

//            if (item.IsNull())
//            {
//                return NotFound();
//            }
//            else
//            {
//                return Ok(item);
//            }


//        }



//        public virtual IHttpActionResult Put([FromBody] TVM item)
//        {
//            if ((!ModelState.IsValid || item == null) && item.Id != 0)
//            {
//                return BadRequest(ModelState);
//            }
//            else
//            {
//                _Service.Update(item);

//                return Content(HttpStatusCode.Accepted, item);

//            }

//        }

//        public virtual IHttpActionResult Delete(int id)
//        {
//            _Service.Delete(id);

//            return Ok();
//        }


//        public virtual IHttpActionResult Post([FromBody] TVM item)
//        {
//            if (!ModelState.IsValid || item == null)
//            {
//                return BadRequest(ModelState);
//            }
//            else
//            {
//                var createdId = _Service.Create(item);
//                item.Id = createdId;

//                return CreatedAtRoute("DefaultApi", new { id = createdId }, item);

//            }

//        }

//    }

//}