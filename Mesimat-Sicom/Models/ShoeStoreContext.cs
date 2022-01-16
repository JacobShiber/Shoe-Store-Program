using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Mesimat_Sicom.Models
{
    public partial class ShoeStoreContext : DbContext
    {
        public ShoeStoreContext()
            : base("name=ShoeStoreContext")
        {
        }

        public DbSet<ClassicShoe> ClassicShoesTable { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
