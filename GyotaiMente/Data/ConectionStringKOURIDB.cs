using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GyotaiMente.Models;

namespace GyotaiMente.Data
{
    public class ConectionStringKOURIDB : DbContext
    {
        public ConectionStringKOURIDB(DbContextOptions<ConectionStringKOURIDB> options)
            : base(options)
        {
        }

        //public DbSet<GyotaiMente.Models.Shouhin>? Shouhin { get; set; }

        public DbSet<大業態マスタ> ms01d_big { get; set; } = default!;
        public DbSet<小業態マスタ> ms01d_small { get; set; } = default!;
    }

}
