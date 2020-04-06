using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models {
    public class MembershipType {
        public byte Id { get; set; }

        [Display(Name = "Membership Type")]
        public string Name { get; set; }

        [Display(Name = "SignUp Fee")]
        public short SignUpFee { get; set; }

        [Display(Name = "Duration In Months")]
        public byte DurationInMonths { get; set; }

        [Display(Name = "Discount Rate")]
        public byte DiscountRate { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 0;
    }
}