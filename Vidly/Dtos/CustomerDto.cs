﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.CustomValidation;

namespace Vidly.Dtos {
    public class CustomerDto {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Min18YearIfAMember]
        public DateTime? BirthofDate { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}