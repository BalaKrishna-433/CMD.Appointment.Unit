using CMD.Business.Appointments.Interfaces;
using CMD.DTO.Appointments;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CMD.API.Appointments.Controllers
{
    public class AppointmentController : ApiController
    {
        protected IAppointmentService manager;

        public AppointmentController(IAppointmentService manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Creates an appointment
        /// </summary>
        /// <param name="jsonData"></param>
        /// <returns>IHttpActionResult</returns>
        [HttpPost]
        [Route("api/appointment/create")]
        [ResponseType(typeof(ConfirmedAppointmentDTO))]
        public IHttpActionResult AddAppointment(AppointmentFormDTO jsonData)
        {
            AppointmentFormDTO appointmentForm = jsonData;

            var result = manager.CreateAppointment(appointmentForm);

            return Created($"api/appointment/{result.AppointmentId}", result);
        }



        /// <summary>
        /// Changes status from open to either closed or confirmed
        /// </summary>
        /// <param name="appointmentStatusDTO"></param>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("api/appointment/changestatus/doctorId/{doctorId}")]
        public IHttpActionResult ChangeStatus([FromBody] AppointmentStatusDTO appointmentStatusDTO, int doctorId)
        {
            var result = manager.ChangeAppointmentStatus(appointmentStatusDTO, doctorId);
            var response = Request.CreateResponse(result ? HttpStatusCode.NoContent : HttpStatusCode.PreconditionFailed);
            return ResponseMessage(response);
        }



        /// <summary>
        /// Closes a appointment and create a feeback form
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("api/appointment/close")]
        public IHttpActionResult CloseAppointment(int appointmentId)
        {
            var res = manager.CloseAppointment(appointmentId);
            if (!res)
            {
                return BadRequest();
            }
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }


        /// <summary>
        /// Gets appointment data(paginated)
        /// </summary>
        /// <param name="doctorId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/appointment/allappointments/{doctorId}")]
        [ResponseType(typeof(AppointmentBasicInfoDTO))]
        public IHttpActionResult GetAllAppointment(int doctorId, [FromUri] PaginationParams parameters)
        {
            ICollection<AppointmentBasicInfoDTO> appointments = manager.GetAllAppointment(doctorId, parameters);

            if (appointments.Count() == 0)
            {
                return Ok("No appointment");
            }

            var totalAppointmentCount = manager.GetAppointmentCount(doctorId);

            var paginationMetaData = new PaginationMetaData(totalAppointmentCount, parameters.Page, parameters.ItemsPerPage, appointments);

            var response = Request.CreateResponse(HttpStatusCode.OK, paginationMetaData);
            return ResponseMessage(response);
        }


        /// <summary>
        /// Gets appointments data with a particular status
        /// </summary>
        /// <param name="doctorId"></param>
        /// <param name="status"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/appointment/allappointments/{status}/{doctorId}")]
        [ResponseType(typeof(AppointmentBasicInfoDTO))]
        public IHttpActionResult GetAllAppointmentBasedOnStatus(int doctorId, string status, [FromUri] PaginationParams parameters)
        {
            ICollection<AppointmentBasicInfoDTO> appointments = manager.GetAllAppointmentFiltered(doctorId, status, parameters);

            if (appointments.Count() == 0)
            {
                return Ok("No appointment");
            }

            var totalAppointmentCount = manager.GetAppointmentCountBasedOnStatus(doctorId, status);

            var paginationMetaData = new PaginationMetaData(totalAppointmentCount, parameters.Page, parameters.ItemsPerPage, appointments);

            var response = Request.CreateResponse(HttpStatusCode.OK, paginationMetaData);
            return ResponseMessage(response);
        }


        /// <summary>
        /// Gets all the IDs associated with a appointment
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/appointment/getids/{appointmentId}")]
        [ResponseType(typeof(IdsListViewDetailsDTO))]
        public IHttpActionResult GetIdsAssociatedWithAppointment(int appointmentId)
        {
            return Ok(manager.GetIdsAssociatedWithAppointment(appointmentId));
        }



        /// <summary>
        /// Get appointment comment
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/comment/{appointmentId}")]
        [ResponseType(typeof(AppointmentCommentDTO))]
        public IHttpActionResult GetComment(int appointmentId)
        {
            var a = manager.GetAppointmentComment(appointmentId);
            return Ok(a);
        }


        /// <summary>
        /// Edit appointment comment
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        // PUT: api/appointment/comment/{appointmentId}
        [HttpPut]
        [Route("api/comment/{appointmentId}")]
        [ResponseType(typeof(AppointmentCommentDTO))]
        public IHttpActionResult EditComment(int appointmentId, AppointmentCommentDTO comment)
        {
            var a = manager.UpdateAppointmentComment(appointmentId, comment);
            if (!a)
            {
                return BadRequest();
            }
            return Ok(comment);
        }

        /// <summary>
        /// Throws System.Exception. (Elmah Testing)
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        [HttpGet]
        [Route("api/throwexception/elmah")]
        public IHttpActionResult Throw()
        {
            throw new System.Exception();
        }

    }
}
