using HomeHealthCareModelClass.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HomeHealthCareAPI.Controllers
{
    public class PatientController : ApiController
    {
        private HomeHealthCareEntities entities;

        public PatientController()
        {
            this.entities = new HomeHealthCareEntities();
        }
        [Route("api/patient/Getspecialist")]
        [HttpGet]
        public IHttpActionResult Getspecialist()
        {
            List<SpecialistList_Result> specialistRecords = new List<SpecialistList_Result>();
            specialistRecords = entities.SpecialistList().ToList();
            return Json(entities.SpecialistList().Select(specialistt => new
                { 
                DID=specialistt.DID,
                specialist=specialistt.Specialist
            }).ToList());

        }
        [Route("api/patient/Getdoctornamelist")]
        [HttpGet]
        public IHttpActionResult Getdoctornamelist()
        {
            List<DoctorNameList_Result> doctornamelist = new List<DoctorNameList_Result>();
            doctornamelist = entities.DoctorNameList().ToList();
            return Json(doctornamelist);
        }
        [Route("api/patient/AddAppointment")]
        [HttpPost]
        public IHttpActionResult AddAppointment(Appointment model)
        {
            int DID = Convert.ToInt32(model.Specialist);
            int ID = Convert.ToInt32(model.DoctorName);
            var specialist = entities.Specialists.FirstOrDefault(p => p.DID == DID);
            var doctorName = entities.doctorNames.FirstOrDefault(p => p.ID == ID);
            entities.Getappointment(doctorName.DoctorName1, specialist.Specialist1, model.AppointmentDate);
            entities.SaveChanges();
            return Ok();
        }
    }
}
