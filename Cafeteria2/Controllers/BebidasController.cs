using Cafeteria2.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cafeteria2.Controllers
{
    public class BebidasController : ApiController
    {

        private BebidasModel _bebidasModel;

        public BebidasController()
        {
            _bebidasModel = new BebidasModel(new CafeteriaConexionDataContext());
        }

        public BebidasController(BebidasModel bebidasModel)
        {
            _bebidasModel = bebidasModel;
        }

        // GET: api/Bebidas
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_bebidasModel.GetAll());
            }
            catch (Exception ex)
            {

                return InternalServerError();
            }
        }

        // GET: api/Bebidas/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok( _bebidasModel.GetById(id) );
            }
            catch (Exception ex)
            {

                return InternalServerError();
            }
        }

        // POST: api/Bebidas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Bebidas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bebidas/5
        public void Delete(int id)
        {
        }
    }
}
