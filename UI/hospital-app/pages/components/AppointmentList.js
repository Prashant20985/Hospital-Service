import { React, useState, useEffect } from "react";
import Appointment from "./Appointment";
import EditAppointment from "./EditAppointment";

const AppointmentList = ({ doctorId }) => {
  const APPOINTMENTS_API_BASE_URL = "https://localhost:44350/appointments";
  const DOCTOR_API_BASE_URL = "https://localhost:44350/doctor";
  const [appointments, setAppointments] = useState(null);
  const [individualDoctor, setIndividualDoctor] = useState(null);
  const [appointmentId, setAppointmentId] = useState(null);
  const [responseAppointment, setResponseAppointment] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchData = async () => {
      setLoading(true);
      try {
        const response = await fetch(
          APPOINTMENTS_API_BASE_URL + "/" + doctorId,
          {
            method: "GET",
            headers: {
              "Content-Type": "application/json",
            },
          }
        );
        const appointments = await response.json();
        console.log(appointments);
        setAppointments(appointments);
      } catch (error) {
        console.log(error);
      }
      setLoading(false);
    };
    fetchData();
  }, [doctorId, responseAppointment]);

  useEffect(() => {
    const fetchData = async () => {
      setLoading(true);
      try {
        const response = await fetch(DOCTOR_API_BASE_URL + "/" + doctorId, {
          method: "GET",
          headers: {
            "Content-Type": "application/json",
          },
        });
        const doctor = await response.json();
        console.log(doctor);
        setIndividualDoctor(doctor);
      } catch (error) {
        console.log(error);
      }
      setLoading(false);
    };
    fetchData();
  }, [doctorId]);

  const editAppointment = (e, appointmentId) => {
    e.preventDefault();
    setAppointmentId(appointmentId);
  };

  return (
    <>
      {individualDoctor && (
        <>
          <>
            <div className="container mx-auto my-8">
              <div className="flex shadow border-b">
                <table className="min-w-full">
                  <thead className="bg-gray-300">
                    <tr>
                      <th className="text-left font-medium text-gray-500 uppercase tracking-wide py-3 px-6">
                        Start Time
                      </th>
                      <th className="text-left font-medium text-gray-500 uppercase tracking-wide py-3 px-6">
                        End Time
                      </th>
                      <th className="text-left font-medium text-gray-500 uppercase tracking-wide py-3 px-6">
                        Room Number
                      </th>
                      <th className="text-right font-medium text-gray-500 uppercase tracking-wide py-3 px-6">
                        Status
                      </th>
                      <th className="text-right font-medium text-gray-500 uppercase tracking-wide py-3 px-6">
                        Procedure
                      </th>
                      <th className="text-right font-medium text-gray-500 uppercase tracking-wide py-3 px-6">
                        Action
                      </th>
                    </tr>
                  </thead>
                  {!loading && (
                    <tbody className="bg-white">
                      {appointments?.map((appointment) => (
                        <Appointment
                          appointment={appointment}
                          key={appointment.appointmentId}
                          editAppointment={editAppointment}
                        />
                      ))}
                    </tbody>
                  )}
                </table>
              </div>
            </div>
          </>
          <EditAppointment
            appointmentId={appointmentId}
            setResponseAppointment={setResponseAppointment}
          />
        </>
      )}
    </>
  );
};

export default AppointmentList;
