

//DEMO 1
//Employee bethany = new Employee("Bethany", "Smith", "bethany@snowball.be", new DateTime(1979, 1, 16), 25, EmployeeType.Manager);
//Employee george = new("George", "Jones", "george@snowball.be", new DateTime(1984, 3, 28), 30, EmployeeType.Research);

//bethany.DisplayEmployeeDetails();
//bethany.PerformWork(8);
//bethany.PerformWork();
//bethany.PerformWork(3);
//bethany.ReceiveWage();

////bethany.firstName = "John";
//bethany.FirstName = "John";
//bethany.DisplayEmployeeDetails();

////bethany.Wage = 300;

//DEMO 2
//Employee bethany = new Employee("Bethany", "Smith", "bethany@snowball.be", new DateTime(1979, 1, 16), 25);
//Manager mary = new Manager("Mary", "Jones", "mary@snowball.be", new DateTime(1965, 1, 16), 30);
//JuniorResearcher bobJunior = new JuniorResearcher("Bob", "Spencer", "bob@snowball.be", new DateTime(1988, 1, 23), 17);

//bethany.DisplayEmployeeDetails();
//bethany.PerformWork();
//bethany.PerformWork(5);
//bethany.PerformWork();
//bethany.ReceiveWage();

//mary.DisplayEmployeeDetails();
//mary.PerformWork();
//mary.PerformWork(11);
//mary.PerformWork();
//mary.ReceiveWage();


//mary.AttendManagementMeeting();
//bobJunior.ResearchNewPieTastes(5);
//bobJunior.ResearchNewPieTastes(5);


//DEMO 3
//Employee bethany = new Employee("Bethany", "Smith", "bethany@snowball.be", new DateTime(1979, 1, 16), 25);
//Employee mary = new Manager("Mary", "Jones", "mary@snowball.be", new DateTime(1965, 1, 16), 30);
////JuniorResearcher bobJunior = new JuniorResearcher("Bob", "Spencer", "bob@snowball.be", new DateTime(1988, 1, 23), 17);
//JuniorResearcher bobJunior = new JuniorResearcher("Bob", "Spencer", "bob@snowball.be", new DateTime(1988, 1, 23), 17);

//bethany.DisplayEmployeeDetails();
//bethany.PerformWork();
//bethany.PerformWork(5);
//bethany.PerformWork();
//bethany.ReceiveWage();

//mary.DisplayEmployeeDetails();
//mary.PerformWork();
//mary.PerformWork(11);
//mary.PerformWork();
//mary.ReceiveWage();


////mary.AttendManagementMeeting();
//bobJunior.ResearchNewPieTastes(5);
//bobJunior.ResearchNewPieTastes(5);
//Employee kevin = new StoreManager("Kevin", "Marks", "kevin@snowball.be", new DateTime(1953, 12, 12), 10);
//Employee kate = new StoreManager("Kate", "Greggs", "kate@snowball.be", new DateTime(1993, 8, 8), 10);

//DEMO 4
//Employee jake = new Employee("Jake", "Nicols", "jake@snowball.be", new DateTime(1995, 8, 16), 25, "New street", "123", "123456", "Pie Ville");
//string streetName = jake.Address.Street;
//Console.WriteLine($"{jake.FirstName} lives on {jake.Address.Street}");

//Address newAddress = new Address("Another street", "444", "999999", "Donut town");
//jake.Address = newAddress;
//Console.WriteLine($"{jake.FirstName} moved to {jake.Address.Street} in {jake.Address.City}");


//Employee mary = new Employee("Mary", "Jones", "mary@snowball.be", new DateTime(1965, 1, 16), 30, EmployeeType.Manager);
//Employee bobJunior = new Employee("Bob", "Spencer", "bob@snowball.be", new DateTime(1988, 1, 23), 17, EmployeeType.Research);
//Employee kevin = new Employee("Kevin", "Marks", "kevin@snowball.be", new DateTime(1953, 12, 12), 10, EmployeeType.StoreManager);
//Employee kate = new Employee("Kate", "Greggs", "kate@snowball.be", new DateTime(1993, 8, 8), 10, EmployeeType.StoreManager);
//Employee kim = new Employee("Kim", "Jacobs", "kim@snowball.be", new DateTime(1975, 5, 14), 22, EmployeeType.StoreManager);

//Employee[] employees = new Employee[7];
//employees[0] = bethany;
//employees[1] = george;
//employees[2] = mary;
//employees[3] = bobJunior;
//employees[4] = kevin;
//employees[5] = kate;    
//employees[6] = kim;

//foreach (var employee in employees)
//{
//    employee.DisplayEmployeeDetails();
//    var numberOfHoursWorked = new Random().Next(25);
//    employee.PerformWork(numberOfHoursWorked);
//    employee.ReceiveWage();
//}



using BethanysPieShopHRM.HR;

IEmployee bethany = new StoreManager("Bethany", "Smith", "bethany@snowball.be", new DateTime(1979, 1, 16), 25);
IEmployee mary = new Manager("Mary", "Jones", "mary@snowball.be", new DateTime(1965, 1, 16), 30);
JuniorResearcher bobJunior = new JuniorResearcher("Bob", "Spencer", "bob@snowball.be", new DateTime(1988, 1, 23), 17);
IEmployee kevin = new StoreManager("Kevin", "Marks", "kevin@snowball.be", new DateTime(1953, 12, 12), 10);
IEmployee kate = new StoreManager("Kate", "Greggs", "kate@snowball.be", new DateTime(1993, 8, 8), 10);

//bethany.DisplayEmployeeDetails();
//bethany.PerformWork();
//bethany.PerformWork(10);
//bethany.PerformWork();
//bethany.ReceiveWage();

//mary.DisplayEmployeeDetails();
//mary.PerformWork();
//mary.PerformWork(3);
//mary.PerformWork();
////mary.AttendManagementMeeting();
//mary.ReceiveWage();

//bobJunior.ResearchNewPieTastes(5);
//bobJunior.ReceiveWage();

List<IEmployee> employees = new List<IEmployee>();
employees.Add(bethany);
employees.Add(mary);
employees.Add(bobJunior);
employees.Add(kevin);
employees.Add(kate);

foreach (var employee in employees)
{
    employee.PerformWork();
    employee.ReceiveWage();
    employee.DisplayEmployeeDetails();
    employee.GiveBonus();
    //employee.AttendManagementMeeting();
}

Console.ReadLine();