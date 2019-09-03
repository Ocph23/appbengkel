using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MainWeb.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using global::MainWeb.DataAccess.Contexts;
    using global::MainWeb.Models;
    using Microsoft.AspNet.Identity;

    namespace MainWeb.Api
    {
        public class PenjualanApiController : ApiController
        {
            private PenjualanContext context = new PenjualanContext();
            // GET: api/PembelianApi
            public IHttpActionResult Get()
            {
                return Ok(context.Get());
            }

            // GET: api/PembelianApi/5
            public IHttpActionResult Get(int id)
            {
                return Ok(context.GetById(id));
            }

            // POST: api/PembelianApi
            public IHttpActionResult Post([FromBody]Penjualan value)
            {
                try
                {
                    value.UserId = User.Identity.GetUserId();
                    if (value != null)
                    {
                        var result = context.Insert(value);
                        if (result != null)
                        {
                            return Ok(result);
                        }
                        throw new SystemException("Data Tidak Tersimpan");
                    }
                    throw new SystemException("Data Tidak Valid, Lengkapi Data Anda");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            // PUT: api/PembelianApi/5
            public void Put(int id, [FromBody]string value)
            {
            }

            // DELETE: api/PembelianApi/5
            public void Delete(int id)
            {
            }
        }
    }

}
