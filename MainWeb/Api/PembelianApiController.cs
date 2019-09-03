using MainWeb.DataAccess.Contexts;
using MainWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace MainWeb.Api
{
    public class PembelianApiController : ApiController
    {
        private PembelianContext pembelianContext = new PembelianContext();
        // GET: api/PembelianApi
        public IHttpActionResult Get()
        {
            return Ok(pembelianContext.Get());
        }

        // GET: api/PembelianApi/5
        public IHttpActionResult Get(int id)
        {
            return Ok(pembelianContext.GetById(id));
        }

        // POST: api/PembelianApi
        public IHttpActionResult Post([FromBody]Pembelian value)
        {
            try
            {
                value.UserId = User.Identity.GetUserId();
                if(value != null && value.Items !=null && value.Items.Count>0)
                {
                    var result = new PembelianContext().Insert(value);
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
