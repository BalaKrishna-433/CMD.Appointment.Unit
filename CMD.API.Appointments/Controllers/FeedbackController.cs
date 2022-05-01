using CMD.Business.Appointments.Interfaces;
using CMD.Model.Appointments;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CMD.API.Appointments.Controllers
{
    public class FeedbackController : ApiController
    {
        protected IFeedbackService manager;

        public FeedbackController(IFeedbackService manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        [Route("GetFeedback/{id}")]
        [ResponseType(typeof(FeedBack))]
        public IHttpActionResult GetFeedback(int id)
        {
            var result = manager.GetFeedback(id);
            if (result == null)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Your feedback ID is not found {0}", id)),
                    ReasonPhrase = "Appointment Id not found"
                };
                throw new HttpResponseException(msg);
            }
            return Ok(result);

        }
    }
}
