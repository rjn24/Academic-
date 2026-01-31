using System.ComponentModel.DataAnnotations;

public class Class
{
    [Key]
    public string ClassID { get; set; }
    public string Program { get; set; }
    public string Year { get; set; }
    public string Section { get; set; }
    public int Semester { get; set; }
}
