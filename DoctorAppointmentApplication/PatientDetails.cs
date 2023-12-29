using System;

namespace DoctorAppointmentApplication
{
    //enum
    public enum Gender { Select, Male, Female }
    public class PatientDetails
    {
        //Field
        private static int s_patientId = 0;
        //Properties
        public int PatientID{get;set;}
        public string Password { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        //Constructor
        public PatientDetails(string password, string name, int age, Gender gender)
        {
            PatientID=++s_patientId;
            Password=password;
            Name=name;
            Age=age;
            Gender=gender;

        }
    }
}
