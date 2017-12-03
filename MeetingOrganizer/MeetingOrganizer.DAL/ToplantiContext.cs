using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingOrganizer.DAL
{
   public class ToplantiContext:DbContext
    {
        public ToplantiContext():base("MeetORGCon")
        {

        }
        public DbSet<Toplanti> Toplantilar { get; set; }
        public DbSet<Katilimci> Katilimcilar { get; set; }
    }
}
