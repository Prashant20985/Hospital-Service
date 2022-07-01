
using MAS_PROJECT.Data;
using MAS_PROJECT.DTOs;
using MAS_PROJECT.Models.enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAS_PROJECT.Services
{
    public interface IHospitalServices
    {
        Task<List<DoctorDTO>> GetDoctors();
        Task<DoctorDTO> GetDoctor(int DoctorId);
        Task<List<AppointmentDTO>> GetAppointments(int DoctorId);
        Task<AppointmentDTO> GetAppointment(int DoctorId);
        Task<AppointmentDTO> UpdateAppointment(int AppointmentId, AppointmentDTO appointment);
    }
    public class HospitalServices : IHospitalServices
    {
        private readonly ApplicationDbContext _context;

        public HospitalServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AppointmentDTO>> GetAppointments(int DoctorId)
        {
            var result = await _context.Procedures.Where(x => x.Appointment.DoctorId == DoctorId)
                .Select(y => new AppointmentDTO
                {
                    AppointmentId = y.Appointment.AppointmentId,
                    StartTime = y.Appointment.StartTime,
                    EndTime = y.Appointment.EndTime,
                    RoomNumber = y.Appointment.Room.RoomNumber,
                    Status = y.Appointment.Status.ToString(),
                    ProcedureTitle = y.ProcedureType.Title
                }).ToListAsync();

            return result;
        }

        public async Task<DoctorDTO> GetDoctor(int DoctorId)
        {
            var result = await _context.Doctors
                .Where(y => y.PersonId == DoctorId)
                .Select(x => new DoctorDTO
                {
                    DoctorId = x.PersonId,
                    FirstName = x.MedicalStaff.Person.FirstName,
                    LastName = x.MedicalStaff.Person.LastName,
                    DateOfBirth = x.MedicalStaff.Person.DateOfBirth.Date,
                    Age = DateTime.Now.Year - x.MedicalStaff.Person.DateOfBirth.Year,
                    Gender = x.MedicalStaff.Person.Gender.ToString(),
                    Specializations = x.Specialization.Title
                })
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<DoctorDTO>> GetDoctors()
        {
            var result = await _context.Doctors
                .Select(x => new DoctorDTO
                {
                    DoctorId = x.PersonId,
                    FirstName = x.MedicalStaff.Person.FirstName,
                    LastName = x.MedicalStaff.Person.LastName,
                    DateOfBirth = x.MedicalStaff.Person.DateOfBirth.Date,
                    Age = DateTime.Now.Year - x.MedicalStaff.Person.DateOfBirth.Year,
                    Gender = x.MedicalStaff.Person.Gender.ToString(),
                    Specializations = x.Specialization.Title
                })
                .ToListAsync();
            return result;
        }

        public async Task<AppointmentDTO> GetAppointment(int AppointmentId)
        {
            var result = await _context.Procedures.Where(x => x.Appointment.AppointmentId == AppointmentId)
                .Select(y => new AppointmentDTO
                {
                    AppointmentId = y.Appointment.AppointmentId,
                    StartTime = y.Appointment.StartTime,
                    EndTime = y.Appointment.EndTime,
                    RoomNumber = y.Appointment.Room.RoomNumber,
                    Status = y.Appointment.Status.ToString(),
                    ProcedureTitle = y.ProcedureType.Title
                }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<AppointmentDTO> UpdateAppointment(int AppointmentId, AppointmentDTO appointmentDto)
        {
            var appointment = await _context.Appointments.Where(x => x.AppointmentId == AppointmentId).FirstOrDefaultAsync();
            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.RoomNumber == appointmentDto.RoomNumber);
            var procedure = await _context.Procedures.FirstOrDefaultAsync(x => x.AppointmentId == AppointmentId);
            Status status = (Status)Enum.Parse(typeof(Status), appointmentDto.Status);

            appointment.StartTime = appointmentDto.StartTime;
            appointment.EndTime = appointmentDto.EndTime;
            appointment.Status = status;
            appointment.RoomId = room.RoomId;

            await _context.SaveChangesAsync();

            return appointmentDto;
        }

    }
}
