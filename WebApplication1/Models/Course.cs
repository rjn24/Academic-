using System.ComponentModel.DataAnnotations;

public class Course
{
    [Key]
    public string CourseCode { get; set; }
    public string SubjectName { get; set; }
    public int Semester { get; set; }
    public int Credits { get; set; }
}
