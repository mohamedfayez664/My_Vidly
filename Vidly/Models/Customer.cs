using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.ValidatorModels;

namespace Vidly.Models
{
    public class Customer

    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        [Display(Name ="Date Of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
        public MembershipType MembershipType { get; set; }
        [Required]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

    }
}