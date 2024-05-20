namespace Personalregister {
    internal class Program {
        static void Main(string[] args) {
            Employee e = new Employee("Bob", 25000);
            Console.WriteLine(e.Name + "-" + e.Salary);
        }
    }

    public class Employee {
        private string _name;
        private int _salary;

        public Employee(string name, int salary) {
            _name = name;
            _salary = salary;
        }

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        public int Salary {
            get { return _salary; }
            set { _salary = value; }
        }
    }
}
