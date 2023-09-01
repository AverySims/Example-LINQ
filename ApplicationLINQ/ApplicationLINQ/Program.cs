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
			new Student(22, "Olivia", "Brown", new List<double>() { 90.5, 89.2, 96.8, 95.3, 98.1 } ),
			new Student(18, "Emily", "Johnson", new List<double>() { 63.7, 83.4, 97.0, 67.9, 74.6 } ),
			new Student(19, "Noah", "Davis", new List<double>() { 79.2, 66.8, 91.5, 62.3, 88.7 } ),
			new Student(20, "Liam", "Smith", new List<double>() { 71.9, 98.6, 65.4, 82.1, 69.0 } ),
			new Student(19, "William", "Anderson", new List<double>() { 80.3, 94.7, 68.2, 77.8, 86.6 } )
		};

		private static readonly string[] Menu1 = { "View unfiltered student list", "Get students by age", "Get students by letter grade", "Sort by age", "Sort by first name", "Sort by last name", "Group by letter grade", "Sort by average grade" };
		private static readonly string[] Menu2 = { "Exit program" };

		private static bool _loopMain = true;
		
		static void Main(string[] args)
		{
			while (_loopMain)
			{
				PrintMenu();
				
				SelectMenuOption();
			}
		}

		static void PrintMenu()
		{
			string[][] menus = { Menu1, Menu2};
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
				case 1: // View unfiltered student list
					PrintStudents(_students);
					break;
				case 2: // Get students by age
					Console.Write("Enter age to find: ");
					PrintStudents(GetStudentsWithAge(GenericReadLine.TryReadLine<int>()));
					break;
				case 3: // Get students by letter grade
					Console.Write("Get students by letter grade: ");
					PrintStudents(GetStudentsWithGrade(Console.ReadLine().ToUpper().ToCharArray()[0]));
					break;
				case 4: // Sort by age
					Console.WriteLine("Sorted by age (oldest to youngest)");
					PrintStudents(SortByAge());
					break;
				case 5: // Sort by first name
					Console.WriteLine("Alphabetically sorted by first name");
					PrintStudents(SortByFirstName());
					break;
				case 6: // Sort by last name
					Console.WriteLine("Alphabetically sorted by last name");
					PrintStudents(SortByLastName());
					break;
				case 7: // Group by letter grade
					Console.WriteLine("Grouped by letter grade");
					PrintLetterGradeGroup();
					break;
				case 8: // Sort by average grade
					Console.WriteLine("Sorted by average grade");
					PrintStudents(SortByAverageGrade());
					break;
				case 9: // Exit program
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
			if (students.Count < 1)
			{
				PrintNoStudentResults();
			}
			else
			{
				foreach (Student student in students)
				{
					PrintStudent(student);
				}
			}
		}

		static void PrintStudent(Student student)
		{
			Console.WriteLine($"{student.FullName} | Age: {student.Age} | Grade: {student.LetterGrade} {student.AverageGrade:F1}");
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
		
		static List<Student> SortByAverageGrade()
		{
			return _students.OrderByDescending(student => student.AverageGrade).ToList();
		}
		
		static void PrintLetterGradeGroup()
		{
			// Grouping students by letter grade
			var studentsGroupedByGrade = _students.GroupBy(student => student.LetterGrade).ToList();
			
			// Sorting groups with custom grade order and students within each group from high to low
			var studentsSortedInGroup = studentsGroupedByGrade
				.OrderBy(gradeGroup => Student.GradeOrder.IndexOf(gradeGroup.Key))
				.Select(gradeGroup => gradeGroup.OrderByDescending(student => student.AverageGrade))
				.ToList();
			
			// Iterating through each group and its items
			foreach (var gradeGroup in studentsSortedInGroup)
			{
				// Since the group is already sorted, we can just grab the first item.
				Console.WriteLine($"Letter Grade: {gradeGroup.FirstOrDefault().LetterGrade}");
				foreach (var student in gradeGroup)
				{
					PrintStudent(student);
				}
				// Adding a blank line between each group
				ConsoleHelper.PrintBlank();
			}
		}
		
		static void PrintNoStudentResults()
		{
			Console.WriteLine("No students found that match the specified parameters.");
		}
	}
}