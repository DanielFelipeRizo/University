using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.models.dataModels
{
    public class Course: BaseEntity
    {
        [Required, StringLength(100)]
        public string courseName { get; set; } = string.Empty;

        [StringLength(280)]
        public string shortCourseDescription { get; set; } = string.Empty;

        [StringLength(600)]
        public string longCourseDescription { get; set; } = string.Empty;

        [StringLength(100)]
        public string targetPublic { get; set; } = string.Empty;

        [StringLength(100)]
        public string objectives { get; set; } = string.Empty;

        [StringLength(100)]
        public string Requirements { get; set; } = string.Empty;
        public enum level {basic, Intermediate, Advanced};
    }
}
