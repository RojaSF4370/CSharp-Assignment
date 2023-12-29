using System;

namespace DoctorAppointmentApplication
{
    public class Doctor
    {
        //Field
        private static int s_doctorId = 0;
        //property
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string DepartmentName { get; set; }
        //Constructor
        public Doctor(string name, string departmentName)
        {
            DoctorID = ++s_doctorId;
            DoctorName = name;
            DepartmentName = departmentName;
        }

    }
}
