using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13_Higbee.Models
{
    public class BowlingDbContext:DbContext //inherits from DbContext
    {
        public BowlingDbContext(DbContextOptions<BowlingDbContext> options) : base (options)
        {

        }

        public DbSet<Bowler>Bowlers { get; set; } //gets information about each of the individual bowlers
        public DbSet<Team> Teams { get; set; } //gets information about each team
    }
}
