using System.ComponentModel.DataAnnotations;

namespace UniversitySystem.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }
    }
}
