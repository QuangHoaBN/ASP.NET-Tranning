﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstExample.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter Customer's name")]
        [StringLength(500)]
        public string Name { get; set; }
        public Boolean IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name ="Membership Types")]
        public byte MembershipTypeId { get; set; }
        [Display(Name ="Date Of Birth")]
        [Min18YearsIfAMember]
        public DateTime? DOB { get; set; }

    }
}