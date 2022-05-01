using CMD.Business.Appointments.Interfaces;
using CMD.DTO.Appointments;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace CMD.API.Appointments.Controllers
{
    public class PrescriptionController : ApiController
    {
        protected IPrescriptionService manager;

        public PrescriptionController(IPrescriptionService manager)
        {
            this.manager = manager;
        }

        [Route("appointment/{appointmentId}")]
        [HttpGet]
        [ResponseType(typeof(ICollection<PrescriptionDTO>))]
        public IHttpActionResult GetPrescription(int appointmentId)
        {
            ICollection<PrescriptionDTO> prescriptionsDTO = manager.GetPrescriptions(appointmentId);
            if (prescriptionsDTO == null)
            {
                return NotFound();
            }
            return Ok(prescriptionsDTO);
        }


        [Route("appointmentId/{appointmentId}/PrescriptionId/{PrescriptionId}")]
        [HttpDelete]
        public IHttpActionResult DeletePrescription(int appointmentId, int PrescriptionId)
        {
            manager.DeletePrescription(appointmentId, PrescriptionId);
            return Ok();
            //int count = Prescription.DeletePrescription(PatientDetailId);
        }



        // POST and PUT methods And Get



        [HttpGet]
        [Route("appointment/medicine")]
        [ResponseType(typeof(ICollection<MedicineDTO>))]
        public IHttpActionResult GetAllMedicines()
        {
            ICollection<MedicineDTO> medicines = manager.GetAllMedicine();
            return Ok(medicines);
        }



        [HttpPost]
        [Route("AddPrescription/{appointmentId}")]
        [ResponseType(typeof(PrescriptionDTO))]
        public IHttpActionResult AddPrescription(int appointmentId, PrescriptionDTO prescriptionDto)
        {



            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }




            var p = manager.AddPrescription(appointmentId, prescriptionDto);

            return Ok(p);
        }



        [HttpPut]
        [Route("PrescriptionEdit/{id}")]
        [ResponseType(typeof(PrescriptionDTO))]
        public IHttpActionResult Edit(int id, PrescriptionDTO prescriptionDto)
        {
            if (id != prescriptionDto.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Input");
            }
            var p = manager.UpdatePrescription(prescriptionDto);



            return Ok(p);
        }
    }
}
