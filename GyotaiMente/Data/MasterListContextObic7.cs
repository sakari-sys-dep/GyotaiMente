using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GyotaiMente.Models;

namespace GyotaiMente.Data
{
    public class GyotaiMenteContextObic7 : DbContext
    {
        public GyotaiMenteContextObic7(DbContextOptions<GyotaiMenteContextObic7> options)
    : base(options)
        {
        }

        //public DbSet<倉庫マスタ検索用> 倉庫マスタ検索用 { get; set; } = default!;
        //public DbSet<得意先マスタ_検索用v2> 得意先マスタ_検索用v2 { get; set; } = default!;
        //public DbSet<納品先マスタ_検索用v2> 納品先マスタ_検索用v2 { get; set; } = default!;
    }
}
