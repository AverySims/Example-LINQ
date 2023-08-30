namespace StudentManager
{
	public class Student
	{
		public Student(int age, string nameFirst, string nameLast, List<double> grades)
		{
			Age = age;
			FirstName = nameFirst;
			LastName = nameLast;
			Grades = grades;
		}
		
		public int Age { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public List<double> Grades { get; set; }
		
		public string GetFullName()
		{
			return $"{FirstName} {LastName}";
		}
	}
}