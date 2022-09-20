﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website.Models
{
    [Table(name: "Customers")]
    public class Customer
    {
        //---------Customer Id---------//
        [Display(Name = "Customer Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }


        //-------Full Name----------//
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "{0} cannot be empty!")]
        [RegularExpression(@"(^[a-zA-Z''-'\s]{1,40}$)", ErrorMessage = "Wrong Name")]
        [StringLength(50)]
        public string FullName { get; set; }


        //------- Customer Address-------//
        [Display(Name = "Customer Address")]
        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(50)]
        public string Address { get; set; }

        //------Phone Number--------//
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "{0} Cannot be Empty")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        public string Phonenumber { get; set; }


        //---- Email------//
        [Display(Name = " Email")]
        [Required(ErrorMessage = "{0} cannot be empty!")]
        [EmailAddress(ErrorMessage = "{0} is not valid.")]
        public string Email { get; set; }


        [Display(Name = "Age")]
        [Required(ErrorMessage = "{0} cannot be empty!")]
        public decimal Age { get; set; }


        //------ Gender------------//
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "{0} cannot be empty!")]
        [DefaultValue("Female,Male,Other")]
        public string Gender { get; set; }


        //----- State ------//
        [Display(Name = "State")]
        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(50)]
        public string State { get; set; }


        //--- Birth Date -------//
        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "{0} cannot be empty!")]
        public DateTime BirthDate { get; set; }



        #region Navigation Properties to the Loan model

        public int LoanCategoryId { get; set; }

        [ForeignKey(nameof(Customer.LoanCategoryId))]

        public LoanCategory LoanCategory { get; set; }

        #endregion


    }
}
