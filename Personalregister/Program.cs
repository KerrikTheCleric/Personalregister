namespace Personalregister {
    internal class Program {
        static void Main(string[] args) {
            Employee e1 = new Employee("Bob", "Jones", 25000);
            Employee e2 = new Employee("Jerry", "James", 24500);
            StaffRegister sRegister = new StaffRegister();

            Console.WriteLine(e1.FullName + "-" + e1.Salary);
            Console.WriteLine(e2.FullName + "-" + e2.Salary);

            sRegister.addStaffMember(e1);
            sRegister.addStaffMember(e2);

            sRegister.printStaffRegister();

            if (sRegister.removeStaffMember(e2)) {
                Console.WriteLine("Removed staff member {0}", e2.FullName);
            }
            else {
                Console.WriteLine("Staff member {0} was not removed", e2.FullName);
            }

            sRegister.printStaffRegister();

            if (sRegister.removeStaffMember(e2)) {
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
