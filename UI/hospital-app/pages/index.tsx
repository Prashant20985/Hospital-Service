import type { NextPage } from 'next'
import Head from 'next/head'
import Navbar from './components/Navbar'
import DoctorsList from './components/DoctorsList'
import AppointmentList from './components/AppointmentList'

const Home: NextPage = () => {
  return (
    <div>
      <Head>
        <title>MAS Project</title>
        <link rel="icon" href="/ITN.jpg" />
      </Head>
      <Navbar/>
      <DoctorsList/>
    </div>
  )
}

export default Home
