using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.models.dataModels
{
    public class Student : BaseEntity
    {
        [Required]
        public string studentName { get; set; } = string.Empty;
        [Required]
        public string lastNameStudent { get; set; } = string.Empty;
        [Required]
        public DateTime Dob { get; set; }

        public int edad { get; set; }

        //relacion n-m con course
        public ICollection<Course> courses { get; set; } = new List<Course>();

        /*
        public int edadEstudiante()
        {

            try
            {
                int edad = DateTime.Today.AddTicks(-Dob.Ticks).Year - 1;
                return edad;
            }
            catch (Exception)
            {

                return 0;
            }
        }*/
    }
}
