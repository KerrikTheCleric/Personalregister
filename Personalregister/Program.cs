namespace Personalregister {
    internal class Program {


        /*
         Uppgift 1: Det bör finnas klasser för att lagra personer och personalregister.

         Uppgift 2: Man bör kunna nå och ändra på namn och lön på personer och kunna lägga till och ta bort personer från personalregistret.
         */



        static void Main(string[] args) {
            StaffRegister sRegister = new StaffRegister();
            bool displayMenu = true;

            while (displayMenu) {
                displayMenu = MainMenu(sRegister);
            }

        }

        private static bool MainMenu(StaffRegister staffRegister) {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Print Staff Register");
            Console.WriteLine("2) Add Staff Member");
            Console.WriteLine("3) Remove Staff Member");
            Console.WriteLine("4) Run Tests");
            Console.WriteLine("5) Exit");

            int parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : 999;

            switch (parsedResult) {

                case 1:
                    staffRegister.printStaffRegister();
                    return true;

                case 2:

                    addToList(staffRegister);
                    return true;

                case 3:
                    Console.WriteLine("Functionality to be added :(");
                    return true;

                case 4:
                    testCases();
                    return true;

                case 5:  
                    return false;

                default:
                    Console.WriteLine("Only options 1-5 are valid");
                    return true;
            }
            
        }

        private static void addToList(StaffRegister staffRegister) {
            Console.WriteLine("Input first name of staff member:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Input last name of staff member:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Input salary of staff member in SEK:");

            int salary = int.TryParse(Console.ReadLine(), out salary) ? salary : 0;

            if (salary == 0) {
                Console.WriteLine("Invalid salary, returning to main menu.");
                return;
            }

            Employee e = new Employee(firstName, lastName, salary);
            staffRegister.addStaffMember(e);
            Console.WriteLine("Staff member {0} with salary {1:C} added to register", e.FullName, e.Salary);
        }

        private static void testCases() {
            Employee e1 = new Employee("Bob", "Jones", 25000);
            Employee e2 = new Employee("Jerry", "James", 24500);
            StaffRegister testStaffRegister = new StaffRegister();

            Console.WriteLine("Created staff member " + e1.FullName + "-" + e1.Salary);
            Console.WriteLine("Created staff member " + e2.FullName + "-" + e2.Salary);

            testStaffRegister.addStaffMember(e1);
            testStaffRegister.addStaffMember(e2);

            testStaffRegister.printStaffRegister();

            if (testStaffRegister.removeStaffMember(e2)) {
                Console.WriteLine("Removed staff member {0}", e2.FullName);
            }
            else {
                Console.WriteLine("Staff member {0} was not removed", e2.FullName);
            }

            testStaffRegister.printStaffRegister();

            if (testStaffRegister.removeStaffMember(e2)) {
                Console.WriteLine("Removed staff member {0}", e2.FullName);
            }
            else {
                Console.WriteLine("Staff member {0} could not be found and was not removed", e2.FullName);
            }
        }
    }

    public class Employee {
        private string _firstName;
        private string _lastName;
        private int _salary;

        public Employee(string firstName, string lastName, int salary) {
            _firstName = firstName;
            _lastName = lastName;
            _salary = salary;
        }

        public string FullName {
            get { return _firstName + " " + _lastName; }
        }

        public string FirstName {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public int Salary {
            get { return _salary; }
            set { _salary = value; }
        }
    }

    public class StaffRegister {
        private List<Employee> _staffList; 

        public StaffRegister() {
            _staffList = new List<Employee>();
        }

        public void addStaffMember(Employee e) {
            _staffList.Add(e);
        }

        public bool removeStaffMember(Employee e) {
            return _staffList.Remove(e);
        }

        public void printStaffRegister() {

            Console.WriteLine("======STAFF LIST======");

            foreach (Employee e in _staffList) {
                Console.WriteLine("{0} - {1:C}", e.FullName, e.Salary);
            }

            Console.WriteLine("======END OF LIST======");
        }
    }
}
