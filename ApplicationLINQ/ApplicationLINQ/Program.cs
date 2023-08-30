using System.Linq;
using StudentManager;
using CustomConsole;
using GenericParse;

namespace ApplicationLINQ
{
	internal class Program
	{
		private static List<Student> _students = new List<Student>()
		{
			new Student(22, "Olivia", "Brown", new List<double>() { 72.5, 89.2, 61.8, 95.3, 76.1 } ),
			new Student(18, "Emily", "Johnson", new List<double>() { 63.7, 83.4, 97.0, 67.9, 74.6 } ),
			new Student(19, "Noah", "Davis", new List<double>() { 79.2, 66.8, 91.5, 62.3, 88.7 } ),
			new Student(20, "Liam", "Smith", new List<double>() { 71.9, 98.6, 65.4, 82.1, 69.0 } ),
			new Student(19, "William", "Anderson", new List<double>() { 80.3, 94.7, 68.2, 77.8, 86.6 } )
		};

		private static string[] menu1 = { "Find students with specific letter grade", "Group students by letter grade"};
		private static string[] menu2 = { "Sort by age", "Sort by last name", "Sort by average grade" };
		
		static void Main(string[] args)
		{
			string[][] menus = { menu1, menu2 };
			Console.WriteLine("Welcome to LINQ Student Manager");
			ConsoleHelper.PrintMenu(menus);
			
			ConsoleHelper.UserEndProgram();
		}
		
		
		
		
	}
}