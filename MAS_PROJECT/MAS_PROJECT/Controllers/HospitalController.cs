using MAS_PROJECT.DTOs;
using MAS_PROJECT.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MAS_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalServices _hospitalServices;
        private readonly ILogger<HospitalController> _logger;

        public HospitalController(IHospitalServices hospitalServices)
        {
            _hospitalServices = hospitalServices;
        }

        [HttpGet]
        [Route("/doctors")]
        public async Task<IActionResult> GetDoctors()
        {
            try
            {
                var result = await _hospitalServices.GetDoctors();
                if(result == null)
                {
                    _logger.LogWarning("Docors are Not Present in the Database");
                    return StatusCode(StatusCodes.Status404NotFound, "Docors are Not Present in the Database");
                }
                return Ok(result);
                
            }
            catch (Exception)
            {
                _logger.LogError($"GetDoctors Threw An Exception");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Getting the Data");
            }
        }

        [HttpGet]
        [Route("/doctor/{DoctorId:int}")]
        public async Task<IActionResult> GetDoctor(int DoctorId)
        {
            try
            {
                var result = await _hospitalServices.GetDoctor(DoctorId);
                if (result == null)
                {
                    _logger.LogWarning($"Doctor with given Id: {DoctorId} is not Present in the Database");
                    return StatusCode(StatusCodes.Status404NotFound,
                        $"Doctor with given Id: {DoctorId} is not Present in the Database");
                }
                return Ok(result);

            }
            catch (Exception)
            {
                _logger.LogError($"GetDoctor Threw An Exception");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Getting the Data");
            }
        }

        [HttpGet]
        [Route("/appointments/{DoctorId:int}")]
        public async Task<IActionResult> GetAppointments(int DoctorId)
        {
            try
            {
                var result = await _hospitalServices.GetAppointments(DoctorId);
                if (result == null)
                {
                    _logger.LogWarning($"Doctor with given Id: {DoctorId} is not Present in the Database");
                    return StatusCode(StatusCodes.Status404NotFound,
                        $"Doctor with given Id: {DoctorId} is not Present in the Database");
                }
                return Ok(result);

            }
            catch (Exception)
            {
                _logger.LogError($"GetAppointments Threw An Exception");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Getting the Data");
            }
        }

        [HttpGet]
        [Route("/appointment/{AppointmentId:int}")]
        public async Task<IActionResult> GetAppointment(int AppointmentId)
        {
            try
            {
                var result = await _hospitalServices.GetAppointment(AppointmentId);
                if (result == null)
                {
                    _logger.LogWarning($"Appointment with given Id: {AppointmentId} is not Present in the Database");
                    return StatusCode(StatusCodes.Status404NotFound,
                        $"Appointment with given Id: {AppointmentId} is not Present in the Database");
                }
                return Ok(result);

            }
            catch (Exception)
            {
                _logger.LogError($"GetAppointment Threw An Exception");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Getting the Data");
            }
        }

        [HttpPut]
        [Route("/appointmentUpdate/{AppointmentId:int}")]
        public async Task<IActionResult> UpdateAppointment(int AppointmentId, AppointmentDTO appointmentDTO)
        {
            try
            {
                var result = await _hospitalServices.UpdateAppointment(AppointmentId, appointmentDTO);
                if (result == null)
                {
                    _logger.LogWarning($"Doctor with given Id: {AppointmentId} is not Present in the Database");
                    return StatusCode(StatusCodes.Status404NotFound,
                        $"Appintment with given Id: {AppointmentId} is not Present in the Database");
                }
                return Ok(result);

            }
            catch (Exception)
            {
                _logger.LogError($"UpdateAppointment Threw An Exception");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Getting the Data");
            }
        }

    }
}
