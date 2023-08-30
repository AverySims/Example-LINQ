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

		private static string[] menu1 = { "Get students by age", "Get students by letter grade" };
		private static string[] menu2 = { "Sort by age", "Sort by first name", "Sort by last name", "Sort by letter grade", "Sort by average grade" };
		private static string[] menu3 = { "Exit program" };

		private static bool _loopMain = true;
		
		static void Main(string[] args)
		{
			while (_loopMain)
			{
				PrintMenu();
				
				//ConsoleHelper.PrintBlank();
				//PrintStudents(_students);
				
				SelectMenuOption();
			}
		}

		static void PrintMenu()
		{
			string[][] menus = { menu1, menu2, menu3 };
			Console.WriteLine("Welcome to LINQ Student Manager");
			ConsoleHelper.PrintStrings(menus);
		}
		
		static void SelectMenuOption()
		{
			while (true)
			{
				ConsoleHelper.PrintBlank();
				Console.Write("Select option: ");

				if (!SwitchOnMenuSelection(GenericReadLine.TryReadLine<int>()))
				{
					break;
				}
			}
		}

		static bool SwitchOnMenuSelection(int selection)
		{
			bool tempReturnValue = true;
			
			// clearing console and printing menu again to prevent clutter
			Console.Clear();
			PrintMenu();
			
			ConsoleHelper.PrintBlank();
			switch (selection)
			{
				case 1: // Get students by age
					Console.WriteLine("Get students by age");
					PrintStudents(_students.Where(student => student.Age == 19).ToList());
					break;
				case 2: // Get students by letter grade
					Console.Write("Get students by letter grade: ");
					
					var tempGrade = Console.ReadLine().ToUpper().ToCharArray()[0];
					
					Console.WriteLine(tempGrade);
					PrintStudents(GetStudentsWithGrade('c'));
					break;
					var tempStudents = GetStudentsWithGrade(tempGrade);
					
					
					if (ConsoleHelper.ListEmpty(tempStudents))
					{
						PrintNoStudentResults();
						break;
					}
					PrintStudents(GetStudentsWithGrade('c'));
					break;
				case 3: // Sort by age
					Console.WriteLine("Sort by age");
					PrintStudents(SortByAge());
					break;
				case 4: // Sort by first name
					Console.WriteLine("Sort by first name");
					PrintStudents(SortByFirstName());
					break;
				case 5: // Sort by last name
					Console.WriteLine("Sort by last name");
					PrintStudents(SortByLastName());
					break;
				case 6: // Sort by letter grade
					Console.WriteLine("Sort by letter grade");
					break;
				case 7: // Sort by average grade
					Console.WriteLine("Sort by average grade");
					break;
				case 8: // Exit program
					tempReturnValue = false;
					_loopMain = false;
					break;
				default: // Invalid selection
					ConsoleHelper.PrintInvalidSelection();
					break;
			}
			return tempReturnValue;
		}
		
		static void PrintStudents(List<Student> students)
		{
			foreach (Student student in students)
			{
				Console.WriteLine($"{student.FullName}, Age: {student.Age}, Grade: {student.LetterGrade} - {student.AverageGrade:F1}");
			}
		}
		
		static List<Student> GetStudentsWithGrade(char grade)
		{
			// forcing uppercase to make sure we get a match
			char tempGrade = grade.ToString().ToUpper().ToCharArray()[0];
			
			return _students.Where(student => student.LetterGrade == tempGrade).ToList();
		}
		
		static List<Student> GetStudentsWithAge(int age)
		{
			return _students.Where(student => student.Age == age).ToList();
		}
		
		static List<Student> SortByAge()
		{
			return _students.OrderByDescending(student => student.Age).ToList();
		}
		
		static List<Student> SortByFirstName()
		{
			return _students.OrderBy(student => student.FirstName).ToList();
		}
		
		static List<Student> SortByLastName()
		{
			return _students.OrderBy(student => student.LastName).ToList();
		}

		static void PrintNoStudentResults()
		{
			Console.WriteLine("No students found that match the specified parameters.");
		}
		
	}
}