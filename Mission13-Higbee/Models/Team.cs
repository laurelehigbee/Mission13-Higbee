using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13_Higbee.Models
{
    public class Team
    {
        [Key] //sets the team id as the primary key
        [Required] //sets the variable as required
        public int TeamID { get; set; } //sets the team id variable
        public string TeamName { get; set; } //sets the team name variable
    }
}
