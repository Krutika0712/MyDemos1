using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website.Models
{
    [Table(name: "Loans")]
    public class Loan
    {
        // ---- Loan Id -----//
        [Display(Name = "Loan Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanId { get; set; }


        // ---- Loan Name----//
        [Display(Name = "Loan Name")]
        [Required]
        [StringLength(100)]
        public string LoanName { get; set; }


        #region Navigation Properties to the Item Model
        public ICollection<LoanCategory> LoanCategories { get; set; }

        #endregion
    }
}
