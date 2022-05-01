using CMD.Business.Appointments.Interfaces;
using CMD.DTO.Appointments;
using CMD.Model.Appointments;
using CMD.Repository.Appointments.Implementations;
using CMD.Repository.Appointments.Interfaces;
using System;
using System.Collections.Generic;

namespace CMD.Business.Appointments.Implementations
{
    public class PrescriptionService : IPrescriptionService
    {
        private IPrescriptionRepository repo;
        public PrescriptionService()
        {
            repo = new PrescriptionRepository();
        }

        public bool DeletePrescription(int appointmentId, int PrescriptionId)
        {
            return repo.DeletePrescription(appointmentId, PrescriptionId);
        }

        public ICollection<PrescriptionDTO> GetPrescriptions(int appointmentId)
        {
            ICollection<Prescription> prescriptions = repo.GetPrescriptions(appointmentId);
            ICollection<PrescriptionDTO> prescriptionDTOs = new List<PrescriptionDTO>();
            foreach (Prescription p in prescriptions)
            {
                PrescriptionDTO temp = new PrescriptionDTO()
                {
                    Id = p.Id,
                    Medicine = p.Medicine.Name,
                    Intake = p.Intake == Intake.BEFOREFOOD,
                    Span = p.Span,
                    TimeOfDay = p.TimeOfDay,
                    AdditionalComment = p.AdditionalComment
                };
                prescriptionDTOs.Add(temp);

            }
            return prescriptionDTOs;
        }

        //Add and View Prescription

        public PrescriptionDTO AddPrescription(int appointmentId, PrescriptionDTO prescriptionDto)
        {
            Prescription prescriptions = new Prescription
            {
                Medicine = repo.GetMedicine(prescriptionDto.Medicine),
                Span = prescriptionDto.Span,
                Intake = prescriptionDto.Intake ? Intake.AFTERFOOD : Intake.BEFOREFOOD,
                AdditionalComment = prescriptionDto.AdditionalComment,
                TimeOfDay = prescriptionDto.TimeOfDay,

            };

            try
            {
                var pre = repo.AddPrescription(appointmentId, prescriptions);
                return new PrescriptionDTO
                {
                    Id = pre.Id,
                    Span = pre.Span,
                    TimeOfDay = pre.TimeOfDay,
                    AdditionalComment = pre.AdditionalComment,
                    Intake = pre.Intake == Intake.BEFOREFOOD,
                    Medicine = pre.Medicine.Name,
                };

            }
            catch (Exception)
            {

                throw new Exception("Medicine record not found");
            }
        }

        public PrescriptionDTO UpdatePrescription(PrescriptionDTO prescriptionDto)
        {
            Prescription prescriptions = new Prescription
            {
                Id = prescriptionDto.Id,
                Medicine = repo.GetMedicine(prescriptionDto.Medicine),
                Span = prescriptionDto.Span,
                Intake = prescriptionDto.Intake ? Intake.AFTERFOOD : Intake.BEFOREFOOD,
                AdditionalComment = prescriptionDto.AdditionalComment,
                TimeOfDay = prescriptionDto.TimeOfDay,

            };
            var pre = repo.UpdatePrescription(prescriptions);
            return new PrescriptionDTO
            {
                Id = pre.Id,
                Span = pre.Span,
                TimeOfDay = pre.TimeOfDay,
                AdditionalComment = pre.AdditionalComment,
                Intake = pre.Intake == Intake.BEFOREFOOD,
                Medicine = pre.Medicine.Name,
            };
        }

        public ICollection<MedicineDTO> GetAllMedicine()
        {
            var med = repo.GetAllMedicine();

            ICollection<MedicineDTO> result = new List<MedicineDTO>();

            foreach (var m in med)
            {
                result.Add(new MedicineDTO
                {
                    Id = m.Id,
                    Name = m.Name,
                });
            }
            return result;
        }
    }
}
