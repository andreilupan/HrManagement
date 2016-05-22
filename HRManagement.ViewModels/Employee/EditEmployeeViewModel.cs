using HRManagement.DataAccess.Models.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.ViewModels.Employee
{
    public class EditEmployeeViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50,ErrorMessage ="First Name cannot exceed 50 characters")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(50, ErrorMessage = "Middle Name cannot exceed 50 characters")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        public int PositionId { get; set; }
        public int ProjectId { get; set; }
        public List<Position> Positions { get; set; }
        public List<Project> Projects { get; set; }
    }
}
