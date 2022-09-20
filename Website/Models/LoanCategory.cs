using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website.Models
{
    [Table(name: "LoanCategories")]
    public class LoanCategory
    {
        //---------Loan Id---------//
        [Display(Name = "Loan Category Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanCategoryId { get; set; }



        // -----Loan name ----------//
        [Display(Name = "Loan Category Name")]
        [Required]
        [StringLength(80)]
        public string LoanCategoryName { get; set; }



        //---------Amount------//
        [Display(Name = "Amount")]
        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        public string Amount { get; set; }



        //----- description-----//
        [Display(Name = "Description")]
        [Required]
        [StringLength(350)]
        public string Description { get; set; }



        // -----  Eligibility -----//
        [Display(Name = "Eligibility")]
        [Required]
        [StringLength(350)]
        public string Eligibility { get; set; }


        #region Navigation Properties to the category model

        public int LoanId { get; set; }

        [ForeignKey(nameof(LoanCategory.LoanId))]

        public Loan Loan { get; set; }

        #endregion



        #region Navigation Properties to the Item Model

        public ICollection<Customer> Customers { get; set; }

        #endregion

    }
}
