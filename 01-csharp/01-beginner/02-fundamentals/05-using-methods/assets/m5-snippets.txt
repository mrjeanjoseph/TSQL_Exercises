Module 5 Snippets
-----------------
 
Demo 1
------

static int CalculateYearlyWage(int monthlyWage, int numberOfMonthsWorked)
        {
            //Console.WriteLine($"The yearly wage is: {monthlyWage * numberOfMonthsWorked}");
            return monthlyWage * numberOfMonthsWorked;
			
			}
			
		

static int CalculateYearlyWage(int monthlyWage, int numberOfMonthsWorked)
	{
		//Console.WriteLine($"The yearly wage is: {monthlyWage * numberOfMonthsWorked}");
		//return monthlyWage * numberOfMonthsWorked;

		if (numberOfMonthsWorked == 12)//let's add a bonus month
			return monthlyWage * (numberOfMonthsWorked + 1);

		return monthlyWage * numberOfMonthsWorked;
	}
		
		
Demo 2
------



static int CalculateYearlyWage(int monthlyWage, int numberOfMonthsWorked)
{
	//Console.WriteLine($"The yearly wage is: {monthlyWage * numberOfMonthsWorked}");
	//return monthlyWage * numberOfMonthsWorked;

	if (numberOfMonthsWorked == 12)//let's add a bonus month
		return monthlyWage * (numberOfMonthsWorked + 1);

	return monthlyWage * numberOfMonthsWorked;

}
		



Demo 3
------


public static int CalculateYearlyWage(int monthlyWage, int numberOfMonthsWorked, int bonus)
{
	Console.WriteLine($"The yearly wage is: {monthlyWage * numberOfMonthsWorked + bonus}");
	return monthlyWage * numberOfMonthsWorked + bonus;
}


public static double CalculateYearlyWage(double monthlyWage, double numberOfMonthsWorked, double bonus)
{
	Console.WriteLine($"The yearly wage is: {monthlyWage * numberOfMonthsWorked + bonus}");
	return monthlyWage * numberOfMonthsWorked + bonus;
}
	

 
Demo 5
------


public static int CalculateYearlyWageWithOptional(int monthlyWage, int numberOfMonthsWorked, int bonus)
{

	Console.WriteLine($"The yearly wage is: {monthlyWage * numberOfMonthsWorked + bonus}");
	return monthlyWage * numberOfMonthsWorked + bonus;
}


public static void UsingOptionalParameters()
{
	int monthlyWage1 = 1234;
	int months1 = 12;

	int yearlyWageForEmployee1 = CalculateYearlyWageWithOptional(monthlyWage1, months1);
	Console.WriteLine($"Yearly wage for employee 1 (Bethany): {yearlyWageForEmployee1}");
}



public static int CalculateYearlyWageWithNamed(int monthlyWage, int numberOfMonthsWorked, int bonus)
{

	Console.WriteLine($"The yearly wage is: {monthlyWage * numberOfMonthsWorked + bonus}");
	return monthlyWage * numberOfMonthsWorked + bonus;
}



public static void UsingNamedArguments()
{
	int amount = 1234;
	int months = 12;
	int bonus = 500;

	int yearlyWageForEmployee1 = CalculateYearlyWageWithNamed(bonus: bonus, numberOfMonthsWorked: months, monthlyWage: amount);
	Console.WriteLine($"Yearly wage for employee 1 (Bethany): {yearlyWageForEmployee1}");
}



Demo 6
------


public static void UsingExpressionBodiedSyntax()
{
	int amount = 1234;
	int months = 12;
	int bonus = 500;

	int yearlyWageForEmployee1 = CalculateYearlyWageExpressionBodied(monthlyWage, months, bonus);
	Console.WriteLine($"Yearly wage for employee 1 (Bethany): {yearlyWageForEmployee1}");
}


public static int CalculateYearlyWageExpressionBodied(int monthlyWage, int numberOfMonthsWorked, int bonus) => monthlyWage * numberOfMonthsWorked + bonus;


Demo 7
------



