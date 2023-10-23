using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GyotaiMente.Models;

namespace GyotaiMente.Data
{
    public class GyotaiMenteContext : DbContext
    {
        public GyotaiMenteContext(DbContextOptions<GyotaiMenteContext> options)
            : base(options)
        {
        }

        //public DbSet<GyotaiMente.Models.Shouhin>? Shouhin { get; set; }

        //public DbSet<法人マスタ> 法人マスタ { get; set; } = default!;
        //public DbSet<得意先マスタ_検索> 得意先マスタ_検索v2 { get; set; } = default!;
    }

}
