using MainWeb.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MainWeb.Api
{
    public class MontirController : ApiController
    {
        private MontirContext context = new MontirContext();
        // GET: api/Montir
        public IHttpActionResult Get()
        {
            return Ok(context.Get());
        }

        // GET: api/Montir/5
        public IHttpActionResult Get(int id)
        {
            var result = context.GetByIdWithDetail(id);
            return Ok(result.OrderBy(x=>x.TanggalFaktur));
        }

        // POST: api/Montir
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Montir/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Montir/5
        public void Delete(int id)
        {
        }
    }
}
