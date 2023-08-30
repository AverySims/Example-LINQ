namespace StudentManager
{
	public class Student
	{
		public Student(int age, string name, List<double> grades)
		{
			Age = age;
			Name = name;
			Grades = grades;
		}
		
		public int Age { get; set; }
		public string Name { get; set; }
		public List<double> Grades { get; set; }
	}
}