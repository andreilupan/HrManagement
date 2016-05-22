using HRManagement.DataAccess.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.ViewModels.Employee
{
   public class CreateEmployeeViewModel
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(50, ErrorMessage = "Middle Name cannot exceed 50 characters")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public Language Languages { get; set; }
        [Display(Name = "National identification number")]
        [Required]
        public string NationalIdentificationNumber { get; set; }
        [Display(Name = "Photo")]
        public int PositionId { get; set; }
        public int ProjectId { get; set; }
        [Required]
        public List<Position> Positions { get; set; }
        [Required]
        public List<Project> Projects { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string WorkPhone { get; set; }
        public string PrivatePhone { get; set; }
        public string WorkEmail { get; set; }
        public string PrivateEmail { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}
