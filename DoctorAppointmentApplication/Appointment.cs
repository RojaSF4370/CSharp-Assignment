using System;

namespace DoctorAppointmentApplication
{
    public class Appointment
    {
        public static int s_appointmentID = 0;
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime Date { get; set; }
        public string Problem { get; set; }
        //Constructor
        public Appointment(int patienId,int  doctorId,DateTime date, string problem)
        {
            AppointmentID=++s_appointmentID;
            PatientID=patienId;
            DoctorID=doctorId;
            Date=date;
            Problem=problem;

        }

    }
}
