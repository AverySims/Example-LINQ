namespace StudentManager
{
	public class Student
	{
		public int Age { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public List<double> Grades { get; set; }
		
		public Student(int age, string nameFirst, string nameLast, List<double> grades)
		{
			Age = age;
			FirstName = nameFirst;
			LastName = nameLast;
			Grades = grades;
		}
        
		public string FullName
		{
			get { return $"{FirstName} {LastName}"; }
		}
		
		public double AverageGrade
		{
			// If there are no grades, return 0
			// Otherwise, return the average of the grades
			get { return Grades.Count == 0 ? 0 : Grades.Average(); }
		}

		public char LetterGrade
		{
			get
			{
				double average = AverageGrade;
				if (average >= 90) { return 'A'; }
				if (average >= 80) { return 'B'; }
				if (average >= 70) { return 'C'; }
				if (average >= 60)
				{
					return 'D';
				}
				else
				{
					return 'F';
				}
			}
		}
	}
}