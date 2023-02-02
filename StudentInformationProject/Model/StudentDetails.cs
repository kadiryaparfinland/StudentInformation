using System.ComponentModel.DataAnnotations;

namespace StudentInformationProject.Model
{
    public class StudentDetails
    {
        [Key]
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? StudentSurname { get; set; }
        public int? StudentSsn { get; set; }
        public string? StudentEmail { get; set; }
        public string? StudentAddress { get; set; }
        public DateTime StudentRegistrationDate { get; set; }
    }
}
