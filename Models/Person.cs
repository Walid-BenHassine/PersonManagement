using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PersonManager.Api.Models
{
    [Table("Persons")]
    public class Person
    {
        [Column("PersonID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage ="Person ID is required")]
        [Display(Name = "Person ID")]
        public int PersonID { get; set; }

        [Column("FirstName")]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(20,ErrorMessage ="First Name must be less than 20 characters")]
        public string FirstName { get; set; }

        [Column("LastName")]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage ="Last Name is required")]
        [StringLength(20,ErrorMessage ="Last Name must be less than 20 characters")]
        public string LastName { get; set; }

        [Column("BirthDate")]
        [Display(Name = "Birth Date")]
        [Required(ErrorMessage ="Birth Date is required")]
        public DateTime BirthDate { get; set; }

        [Column("StartDate")]
        [Display(Name = "Start Date")]
        [Required(ErrorMessage ="Start Date is required")]
        public DateTime StartDate { get; set; }

        [Column("EndDate")]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Column("Position")]
        [Display(Name = "Position")]
        [StringLength(20,ErrorMessage ="Position must be less than 20 characters")]
        public string Position { get; set; }
    }
}
