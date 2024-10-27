using BethanysPieShopHRM.HR;


//Employee bethany = new Employee("Bethany", "Smith", "bethany@snowball.be", new DateTime(1979, 1, 16), 25, EmployeeType.Manager);
//Employee george = new("George", "Jones", "george@snowball.be", new DateTime(1984, 3, 28), 30, EmployeeType.Research);
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

//int[] sampleArray1 = new int[5];


//int[] sampleArray2 = new int[] { 1, 2, 3, 4, 5 };

////int[] sampleArray3 = new int[6] { 1, 2, 3, 4, 5 };


//Console.WriteLine("How many employees IDs do you want to register?");

//int length = int.Parse(Console.ReadLine());

//int[] employeeIds = new int[length];

////var testId = employeeIds[0];
////Console.WriteLine(testId);

//for (int i = 0; i < length; i++)
//{
//    Console.Write("Enter the employee ID: ");
//    int id = int.Parse(Console.ReadLine());//let's assume here that the user will always enter an int value
//    employeeIds[i] = id;
//}

//for (int i = 0; i < employeeIds.Length; i++)
//{
//    Console.WriteLine($"ID {i + 1}: \t{employeeIds[i]}");
//}

//Array.Sort(employeeIds);

//Console.WriteLine("After sorting");
//for (int i = 0; i < employeeIds.Length; i++)
//{
//    Console.WriteLine($"ID {i + 1}: \t{employeeIds[i]}");
//}


//int[] employeeIdsCopy = new int[length];

//employeeIds.CopyTo(employeeIdsCopy, 0);

//Array.Reverse(employeeIds);

//Console.WriteLine("After reversing original array");

//for (int i = 0; i < employeeIds.Length; i++)
//{
//    Console.WriteLine($"ID {i + 1}: \t{employeeIds[i]}");
//}

//Console.WriteLine("Copy of array");

//for (int i = 0; i < employeeIdsCopy.Length; i++)
//{
//    Console.WriteLine($"ID {i + 1}: \t{employeeIdsCopy[i]}");
//}


//List<int> employeeIds = new List<int>();
//employeeIds.Add(55);
//employeeIds.Add(1);
//employeeIds.Add(943);
//employeeIds.Add(78);
//employeeIds.Add(78);

////employeeIds.Add("test");

//if (employeeIds.Contains(78))
//{
//    Console.WriteLine("78 is found!");
//}



//int currentAmountOfEmployees = employeeIds.Count;

//var employeeIdsArray = employeeIds.ToArray();


//employeeIds.Clear();


//Console.WriteLine("How many employees IDs do you want to register?");

//int length = int.Parse(Console.ReadLine());

//for (int i = 0; i < length; i++)
//{
//    Console.Write("Enter the employee ID: ");
//    int id = int.Parse(Console.ReadLine());//let's assume here that the user will always enter an int value
//    employeeIds.Add(id);
//}

Employee bethany = new Employee("Bethany", "Smith", "bethany@snowball.be", new DateTime(1979, 1, 16), 25, EmployeeType.Manager);
Employee george = new("George", "Jones", "george@snowball.be", new DateTime(1984, 3, 28), 30, EmployeeType.Research);
Employee mary = new Employee("Mary", "Jones", "mary@snowball.be", new DateTime(1965, 1, 16), 30, EmployeeType.Manager);
Employee bobJunior = new Employee("Bob", "Spencer", "bob@snowball.be", new DateTime(1988, 1, 23), 17, EmployeeType.Research);
Employee kevin = new Employee("Kevin", "Marks", "kevin@snowball.be", new DateTime(1953, 12, 12), 10, EmployeeType.StoreManager);
Employee kate = new Employee("Kate", "Greggs", "kate@snowball.be", new DateTime(1993, 8, 8), 10, EmployeeType.StoreManager);
Employee kim = new Employee("Kim", "Jacobs", "kim@snowball.be", new DateTime(1975, 5, 14), 22, EmployeeType.StoreManager);

List<Employee> employees = new List<Employee>(); 
employees.Add(george);
employees.Insert(0, bethany);
employees.Add(mary);

employees.Add(bobJunior);

employees.Add(kevin);
employees.Add(kate);
employees.Add(kim);
//employees.Add(kim);

foreach (var employee in employees)
{
    employee.DisplayEmployeeDetails();
}

Console.ReadLine();