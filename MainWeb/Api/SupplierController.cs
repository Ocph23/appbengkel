using MainWeb.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MainWeb.Api
{
    public class SupplierController : ApiController
    {

        private SupplierContext context = new SupplierContext();
        // GET: api/Supplier
        public IHttpActionResult Get()
        {
            return Ok(context.Get());
        }

    }
}
