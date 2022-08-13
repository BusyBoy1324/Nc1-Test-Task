namespace TestProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int Age { get; set; }
        public char Gender { get; set; }
        public int DepartmentId { get; set; }
        public int ProgramingLanguageId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string ProgramingLanguageName { get; set; } = string.Empty;
    }
}
