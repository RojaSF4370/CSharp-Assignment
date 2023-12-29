using System;
using System.Collections.Generic;


namespace DoctorAppointmentApplication
{
    public class AppointmentManager
    {
        public static List<Doctor> doctorList;
        public static List<PatientDetails> patientList;
        public static List<Appointment> appointmentList;
        public AppointmentManager()
        {
            doctorList = new List<Doctor>();
            patientList = new List<PatientDetails>();
            appointmentList = new List<Appointment>();

        }

    }
}
