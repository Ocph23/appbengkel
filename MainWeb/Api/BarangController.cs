using MainWeb.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MainWeb.Api
{
    public class BarangController : ApiController
    {
        // GET: api/Barang
        private BarangContext context = new BarangContext();
        public IHttpActionResult Get()
        {
            return Ok(context.Get());
        }

        // GET: api/Barang/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Barang
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Barang/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Barang/5
        public void Delete(int id)
        {
        }
    }
}
