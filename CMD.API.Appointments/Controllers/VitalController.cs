using CMD.Business.Appointments.Interfaces;
using CMD.DTO.Appointments;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace CMD.API.Appointments.Controllers
{
    public class VitalController : ApiController
    {
        protected IVitalService manager;
        public VitalController(IVitalService manager)
        {
            this.manager = manager;
        }

        [Route("GetAllVitals")]
        [HttpGet]
        [ResponseType(typeof(List<VitalDTO>))]
        public IHttpActionResult Get()
        {
            return Ok(manager.GetAllVitalsDTO());
        }

        [Route("GetAllVitals/{id}")]
        [HttpGet]
        [ResponseType(typeof(VitalDTO))]
        // GET: api/Vital/5
        public IHttpActionResult GetAllVitals(int id)
        {
            return Ok(manager.GetVitalDTOByVitalId(id));
        }

        //Action method for editing
        // PUT: api/Vital/id
        [Route("UpdateVital/{id}")]
        [HttpPut]
        [ResponseType(typeof(VitalDTO))]
        public IHttpActionResult Put(int id, VitalDTO vital)
        {
            if (id != vital.id)
                return BadRequest();

            VitalDTO v = manager.UpdateVital(vital);

            return Ok(v);
        }
    }
}
