import React from 'react'
import { PencilAltIcon } from "@heroicons/react/outline";

const Appointment = ({appointment, editAppointment}) => {
  return (
    <tr key={appointment.appointmentId}>
      <td className="text-left px-6 py-4 whitespace-nowrap">
        <div className="text-sm text-gray-500">{appointment.startTime}</div>
      </td>
      <td className="text-left px-6 py-4 whitespace-nowrap">
        <div className="text-sm text-gray-500">{appointment.endTime}</div>
      </td>
      <td className="text-left px-6 py-4 whitespace-nowrap">
        <div className="text-sm text-gray-500">{appointment.roomNumber}</div>
      </td>
      <td className="text-left px-6 py-4 whitespace-nowrap">
        <div className="text-sm text-gray-500">{appointment.status}</div>
      </td>
      <td className="text-left px-6 py-4 whitespace-nowrap">
        <div className="text-sm text-gray-500">{appointment.procedureTitle}</div>
      </td>
      <td className="text-right px-6 py-4 whitespace-nowrap">
        <a
          onClick={(e, appointmentId) => editAppointment(e, appointment.appointmentId)}
          className="text-indigo-600 hover:text-indigo-800 hover:cursor-pointer px-4"
        >
          <PencilAltIcon className="flex justify-center h-6 w-6 "/>
        </a>
      </td>
    </tr>
  )
}

export default Appointment