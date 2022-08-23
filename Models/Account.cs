using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using mvcTest1;

namespace mvcTest1.Models
{

    [Table("Account")]
    public class Account
    {
        

        [Column("id")]
        [StringLength(50)]
        [Unicode(false)]
        [Required]
        public string? Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        [Required]
        public string? FirstName { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        [Required]
        public string? LastName { get; set; }
        [Required]
        public int? Pin { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? PhoneNumber { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        [Required]
        public string? Email { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? City { get; set; }
        [Column(TypeName = "decimal(38, 2)")]
        public decimal? Balance { get; set; }




    }
}

