import React, { useState, useEffect } from 'react'
import Doctor from './Doctor';

const DoctorsList = () => {

    const HOSPITAL_API_BASE_URL = "https://localhost:44350/doctors"
    const [doctors, setDoctors] = useState(null);
    const [doctorId, setDoctorId] = useState(null)
    const [loading, setLoading] = useState(true)

    useEffect(() => {
      const fetchData = async () => {
          setLoading(true);
          try{
              const response = await fetch(HOSPITAL_API_BASE_URL, {
                  method: "GET",
                  headers:{
                    "Content-Type": "application/json"
                  },
              });
              const doctors = await response.json();
              console.log(doctors)
              setDoctors(doctors);
          }
          catch (error) {
            console.log(error)
        }
        setLoading(false);
    }
    fetchData();
    }, [])
    
  return (
    <>
    <div className="container mx-auto my-8">
        <div className="flex shadow">
          <table className="min-w-full">
            {!loading && (
              <tbody className="bg-[#385E72]">
                {doctors?.map((doctor) => (
                  <Doctor
                    doctor={doctor}
                    key={doctor.DoctorId}
                  />
                ))}
              </tbody>
            )}
          </table>
        </div>
      </div>
    </>
  )
}

export default DoctorsList
