import { Disclosure } from "@headlessui/react";
import { ChevronUpIcon } from "@heroicons/react/solid";
import AppointmentList from "./AppointmentList";
import React from "react";

const Doctor = ({ doctor }) => {
  return (
    <Disclosure>
      {({ open }) => (
        <>
          <Disclosure.Button className="flex w-full justify-between bg-gray-700 px-4 py-2 text-left text-sm font-medium text-purple-900 hover:bg-gray-600 focus:outline-none focus-visible:ring focus-visible:ring-purple-500 focus-visible:ring-opacity-75">
            <tr key={doctor.DoctorId} className="flex flex-row justify-center">
              <td className="text-left px-6 py-4 whitespace-nowrap">
                <div className="text-white text-lg">
                  Name: {doctor.firstName} {doctor.lastName}
                </div>
                <div className="text-lg text-white">Age: {doctor.age}</div>
              </td>
              <td className="text-left px-6 py-4 whitespace-nowrap">
                <div className="text-lg text-white">
                  Gender: {doctor.gender}
                </div>
                <div className="text-lg text-white">
                  Specialization: {doctor.specializations}
                </div>
              </td>
            </tr>
            <ChevronUpIcon
              className={`${
                open ? "rotate-180 transform" : ""
              } h-5 w-5 text-purple-500`}
            />
          </Disclosure.Button>
          <Disclosure.Panel className="px-4 pt-4 pb-2 text-sm text-gray-500">
            <AppointmentList doctorId={doctor.doctorId} />
          </Disclosure.Panel>
        </>
      )}
    </Disclosure>
  );
};

export default Doctor;
