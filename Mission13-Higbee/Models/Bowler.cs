﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13_Higbee.Models
{
    public class Bowler //all information for each bowler
    {
        [Key]
        [Required]
        public int BowlerID { get; set; } //bowler id is primary key
        public string BowlerFirstName { get; set; }
        public string BowlerMiddleInit { get; set; }
        public string BowlerLastName { get; set; }
        public string BowlerAddress { get; set; }
        public string BowlerCity { get; set; }
        public string BowlerState { get; set; }
        public string BowlerZip { get; set; }
        public string BowlerPhoneNumber { get; set; }
        [Required]
        public int TeamID { get; set; } //sets foreign key relationship with Team
        public Team Team { get; set; }
    }
}
