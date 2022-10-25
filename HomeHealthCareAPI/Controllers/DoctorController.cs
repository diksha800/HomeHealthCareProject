using HomeHealthCareModelClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HomeHealthCareAPI.Controllers
{
    public class DoctorController : ApiController
    {
        private HomeHealthCareEntities entities;

        public DoctorController()
        {
            this.entities = new HomeHealthCareEntities();
        }
        [Route("api/doctor/AppointmentRecord")]
        [HttpGet]
        public IHttpActionResult AppointmentRecord()
        {
            List<AppointmentRecords_Result> appointmentRecords = new List<AppointmentRecords_Result>();
            appointmentRecords = entities.AppointmentRecords().ToList();
            return Json(appointmentRecords);
        }
    }
}
