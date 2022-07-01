import {React, useState, useEffect, Fragment} from 'react'
import { Dialog, Transition } from '@headlessui/react'

const EditAppointment = ({appointmentId, setResponseAppointment}) => {
    const APPOINTMENT_API_BASE_URL = "https://localhost:44350/appointment";
    const APPOINTMENT_UPDATE_API_BASE_URL = "https://localhost:44350/appointmentUpdate";

    const [isOpen, setIsOpen] = useState(false);
    const [appointment, setAppointment] = useState({
        startTime:"",
        endTime:"",
        roomNumber:"",
        status:"",
        procedureTitle:""
    })

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch(APPOINTMENT_API_BASE_URL + "/" + appointmentId, {
                    method:"GET",
                    headers:{
                        "Content-Type":"application/json",
                    },
                });
                const appointment = await response.json();
                console.log(appointment);
                setAppointment(appointment);
                setIsOpen(true);
            } catch (error) {
                console.log(error);
            }
        }
        if(appointmentId){
            fetchData();
        }
    }, [appointmentId])

    function closeModel(){
        setIsOpen(false)
    }

    function openModel(){
        setIsOpen(true)
    }

    const handleChange = (event) => {
        const value = event.target.value;
        setAppointment({...appointment, [event.target.name]: value})
    }

    const reset = (e) => {
        e.preventDefault();
        setIsOpen(false)
    };

    const updateAppoinment = async (e) => {
        e.preventDefault();
        const response = await fetch(APPOINTMENT_UPDATE_API_BASE_URL + "/" + appointmentId, {
            method: "PUT",
            headers: {
                "Content-Type" : "application/json"
            },
            body: JSON.stringify(appointment)
        })
        if(!response.ok){
            throw new Error("Something went wrong");
        }
        const _appointment = await response.json();
        setResponseAppointment(_appointment);
        reset(e);
    }

  return (
    <Transition appear show={isOpen} as={Fragment}>
    <Dialog as="div" 
    className="fixed inset-0 z-10 overflow-y-auto"
    onClose = {closeModel}
    >
        <div className="min-h-screen px-4 text-center">
            <Transition.Child
            as={Fragment}
            enter="ease-out duration-300"
            enterFrom="opacity-0 scale-95"
            enterTo="opacity-100 scale-100"
            leave="ease-in duration-200"
            leaveFrom="opacity-100 scale-100"
            leaveTo="opacity-0 scale-95"
            >
                <div className="inline-block w-full max-w-md p-6 my-8 overflow-hidden text-left align-middle transition-all transform bg-white shadow-xl rounded">
                    <Dialog.Title as="h3" className="text-lg font-medium leading-6 text-gray-900">Add new User
                    </Dialog.Title>
                    <div className="flex max-w-md max-auto">
                        <div className="py-2">
                            <div className="h-14 my-4">
                                <label className="block text-gray-600 text-sm font-normal">Start Time</label>
                                <input type="text" name="startTime" 
                                value={appointment.startTime}
                                onChange={(e) => handleChange(e)}
                                className="h-10 w-96 border mt-2 px-2"></input>
                            </div>
                            <div className="h-14 my-4">
                                <label className="block text-gray-600 text-sm font-normal">End Time</label>
                                <input type="text" name="endTime" 
                                value={appointment.endTime}
                                onChange={(e) => handleChange(e)}
                                className="h-10 w-96 border mt-2 px-2"></input>
                            </div>
                            <div className="h-14 my-4">
                                <label className="block text-gray-600 text-sm font-normal">Room Number</label>
                                <input type="text" name="roomNumber" 
                                value={appointment.roomNumber}
                                onChange={(e) => handleChange(e)}
                                className="h-10 w-96 border mt-2 px-2"></input>
                            </div>
                            <div className="h-14 my-4">
                                <label className="block text-gray-600 text-sm font-normal">Status</label>
                                <input type="text" name="status" 
                                value={appointment.status}
                                onChange={(e) => handleChange(e)}
                                className="h-10 w-96 border mt-2 px-2"></input>
                            </div>
                            <div className="h-14 my-4 space-x-4 pt-4">
                                <button 
                                onClick={updateAppoinment}
                                className="rounded text-white font-semibold bg-green-400 hover:bg-green-700 py-2 px-6">Update</button>
                                <button 
                                onClick={reset}
                                className="rounded text-white font-semibold bg-red-400 hover:bg-red-700 py-2 px-6">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </Transition.Child>
        </div>
    </Dialog>
</Transition>
  )
}

export default EditAppointment