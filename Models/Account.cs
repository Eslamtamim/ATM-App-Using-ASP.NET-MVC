using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using mvcTest1;
using System.ComponentModel;

namespace mvcTest1.Models
{

    [Table("Account")]
    public class Account
    {

        [Key]
        [Column("id")]
        [Unicode(false)]
        [MaxLength(14 , ErrorMessage ="ID must be 14 numbers") , MinLength(14, ErrorMessage = "ID must be 14 numbers")]
        public string? Id { get; set; }


        [StringLength(50)]
        [Unicode(false)]
        [Required]
        [DataType(DataType.Text)]
        public string? FirstName { get; set; }
        
        
        [StringLength(50)]
        [Unicode(false)]
        [Required]
        [DataType(DataType.Text)]
        public string? LastName { get; set; }


        [NotMapped]
        public string FullName { get{return FirstName +" "+ LastName;}}

        [Required]
        [MaxLength(4, ErrorMessage = "PIN must be 4 numbers"), MinLength(4, ErrorMessage = "PIN must be 4 numbers")]
        [DataType(DataType.Password)]
        public int? Pin { get; set; }
        
        
        [StringLength(50)]
        [Unicode(false)]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        
        
        [StringLength(50)]
        [Unicode(false)]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [DisplayFormat(DataFormatString ="{0:dd-MMM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }


        [StringLength(50)]
        [Unicode(false)]
        [Required]
        [DisplayName("Government")]
        public string? Government { get; set; }
        
        
        [Column(TypeName = "decimal(38, 2)")]
        [Required]
        [DataType(DataType.Currency)]
        [Range(0 , 1000000)]
        public decimal? Balance { get; set; }

        //public Account()
        //{
        //    FullName = this.FirstName + this.LastName; 
        //}

    }
}

