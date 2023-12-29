using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
namespace DoctorAppointmentApplication
{

    class Program
    {
        public static PatientDetails currentPatients;
        public static void Main(string[] args)
        {
            DefaultInfo();
            bool checkmenu = true;

            do
            {
                Console.WriteLine("Welcome to Doctor Appointment page");
                Console.WriteLine("Please Select one option from menu\n1.Login\n2.Register\n3.Exit");
                int menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        {
                            //Login
                            Login();
                            break;
                        }
                    case 2:
                        {
                            //Registration
                            Registration();
                            break;
                        }
                    case 3:
                        {
                            //Exit
                            checkmenu = false;
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("Invalid Input");
                            break;
                        }
                }

            } while (checkmenu);
        }

        public static void Registration()
        {
            //Get the user Details
            Console.WriteLine("you are in Registration page\n please enter the below details\n Enter your name");
            string name = Console.ReadLine();
            System.Console.WriteLine("Please enter your password");
            string password = Console.ReadLine();
            System.Console.WriteLine("Enter your age");
            int age = int.Parse(Console.ReadLine());
            Gender gender = Enum.Parse<Gender>(Console.ReadLine());
            PatientDetails patient = new PatientDetails(password, name, age, gender);
            AppointmentManager.patientList.Add(patient);
            System.Console.WriteLine($"You have registered succesfully your RegistrationId {patient.PatientID}");

        }
        /// <summary>
        /// Login Page 
        /// verify the user login and redirect to submenu
        /// </summary>
        /// <returns>
        /// void 
        /// </returns>
        public static void Login()
        {
            bool checklog = false;
            Console.WriteLine("You are in Logi page\n please enter your login id");
            int loginId = int.Parse(Console.ReadLine());
            foreach (PatientDetails patients in AppointmentManager.patientList)
            {
                if (loginId == patients.PatientID)
                {
                    currentPatients = patients;
                    checklog = true;
                    SubMenu();
                    checklog = true;

                }
            }
            if (!checklog)
            {
                System.Console.WriteLine("Invalid Id");
            }

        }
         /// <summary>
        /// submenu
        ///Display the menu details
        /// <c>user will select the option to take the event</c>
        /// </summary>
        /// <returns>
        /// void 
        /// </returns>
        public static void SubMenu()
        {
            bool checksub = true;
            do
            {
                Console.WriteLine("Please select one option from below submenu");
                int sub = int.Parse(Console.ReadLine());
                switch (sub)
                {
                    case 1:
                        {
                            //Bookappointment
                            BookAppointment();
                            break;

                        }
                    case 2:
                        {
                            //Viewappointmets
                            ViewAppointmentDetails();
                            break;

                        }
                    case 3:
                        {
                            //Editmyprofile
                            EditMyProfile();
                            break;

                        }
                    case 4:
                        {
                            checksub = false;
                            break;

                        }
                    default:
                        {
                            System.Console.WriteLine("Invalid input");
                            break;

                        }

                }

            } while (checksub);

        }
         /// <summary>
        /// book appointments
        /// </summary>
        /// <returns>
        /// void 
        /// </returns>
        public static void BookAppointment()
        {
            // If the user chooses option a, get the Department that patient wants to have an appointment by displaying all the departments
            bool checklog = false;
            //show the doctordetails
            foreach (Doctor doctors in AppointmentManager.doctorList)
            {
                Console.WriteLine($" {doctors.DepartmentName}");
            }
            int count = 0;
            Console.WriteLine("Please select the department name from above list to book appointment");
            string department = Console.ReadLine();
            Console.WriteLine("Please enter your health problem");
            string problem = Console.ReadLine();
            foreach (Doctor doctors in AppointmentManager.doctorList)
            {
                if (department.ToLower() == doctors.DepartmentName.ToLower())
                {
                    foreach (Appointment app in AppointmentManager.appointmentList)
                    {
                        if (doctors.DoctorID == app.DoctorID && DateTime.Now == app.Date)
                        {
                            count++;
                        }
                    }
                    checklog = true;
                    break;
                }
            }
            if (checklog)
            {
                if (count < 2)
                {
                    Console.WriteLine($"Appointment is confirmed for the date {DateTime.Now}To book press “Y”, to cancel press “N”.");
                    char answer = char.Parse(Console.ReadLine());
                    if (answer == 'Y')
                    {
                        foreach (Doctor doctors in AppointmentManager.doctorList)
                        {
                            if (department.ToLower() == doctors.DepartmentName.ToLower())
                            {
                                Appointment appointmets = new Appointment(currentPatients.PatientID, doctors.DoctorID, DateTime.Now, problem);
                            }
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("No allotment is avaliable for booking");
                }
            }

        }
        public static void ViewAppointmentDetails()
        {
            // If the user chooses option b, you should display all the appointment details of the patient.
            bool checkappointments = false;
            Console.WriteLine("Appointment Details");
            Console.WriteLine("AppointmentId".PadRight(10) + "PatientId".PadRight(10) + "DoctorID".PadRight(10) + "Date".PadRight(15) + "Problem".PadRight(20));
            foreach (Appointment appointments in AppointmentManager.appointmentList)
            {
                Console.WriteLine($"{appointments.AppointmentID,10}|{appointments.PatientID,10}|{appointments.DoctorID,10}|{appointments.Date.ToString("MM/dd/yyyy", null)}|{appointments.Problem,20}");
                checkappointments = true;
            }
            if (!checkappointments)
            {
                Console.WriteLine("No data avaliable");
            }


        }
        public static void EditMyProfile()
        {
            Console.WriteLine("Please enter the name to modify");
            currentPatients.Name = Console.ReadLine();
            Console.WriteLine("Please enter the password to modify");
            currentPatients.Password = Console.ReadLine();
            Console.WriteLine("Please enter the age to modify");
            currentPatients.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the Genderto modify\n1.Male\n2.Female\nenter the option");
            currentPatients.Gender = Enum.Parse<Gender>(Console.ReadLine());


        }
        public static void DefaultInfo()
        {
            Doctor doctor1 = new Doctor("Nancy", "	Anaesthesiology");
            Doctor doctor2 = new Doctor(" Andrew", "Cardiology");
            Doctor doctor3 = new Doctor("Janet ", "Diabetology");
            Doctor doctor4 = new Doctor(" Margaret", "Neonatology");
            Doctor doctor5 = new Doctor("  Steven", "Nephrology");

            AppointmentManager appointment = new AppointmentManager();
            AppointmentManager.doctorList.Add(doctor1);
            AppointmentManager.doctorList.Add(doctor2);
            AppointmentManager.doctorList.Add(doctor3);
            AppointmentManager.doctorList.Add(doctor4);
            AppointmentManager.doctorList.Add(doctor5);
            Appointment appointment1 = new Appointment(1, 2, new DateTime(2012, 8, 3), "Heart problem");
            Appointment appointment2 = new Appointment(1, 5, new DateTime(2012, 8, 3), "Spinal cord injury");
            Appointment appointment3 = new Appointment(2, 2, new DateTime(2012, 8, 3), "Heart attack");
            AppointmentManager.appointmentList.Add(appointment1);
            AppointmentManager.appointmentList.Add(appointment2);
            AppointmentManager.appointmentList.Add(appointment3);
            PatientDetails patient1 = new PatientDetails("welcome", " Robert", 40, Gender.Male);
            PatientDetails patient2 = new PatientDetails("welcome", "  Laura", 36, Gender.Female);
            PatientDetails patient3 = new PatientDetails("welcome  ", "Anne", 42, Gender.Female);
            AppointmentManager.patientList.Add(patient1);
            AppointmentManager.patientList.Add(patient2);
            AppointmentManager.patientList.Add(patient3);





        }
    }
}