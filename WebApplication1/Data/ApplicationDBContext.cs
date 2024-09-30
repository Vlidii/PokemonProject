using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
        }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<OwnedPokemon> OwnedPokemons { get; set; }

        public DbSet<PokemonTeam> PokemonTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PokemonTeam>()
                .HasOne(u => u.AppUser)
                .WithMany(u => u.PokemonTeams)
                .HasForeignKey(p => p.AppUserId);

            builder.Entity<PokemonTeam>()
                .HasOne(op => op.OwnedPokemon1)
                .WithMany()
                .HasForeignKey(p => p.OwnedPokemonId1);

            builder.Entity<PokemonTeam>()
               .HasOne(op => op.OwnedPokemon2)
               .WithMany()
               .HasForeignKey(p => p.OwnedPokemonId2);

            builder.Entity<PokemonTeam>()
               .HasOne(op => op.OwnedPokemon3)
               .WithMany()
               .HasForeignKey(p => p.OwnedPokemonId3);

            builder.Entity<PokemonTeam>()
               .HasOne(op => op.OwnedPokemon4)
               .WithMany()
               .HasForeignKey(p => p.OwnedPokemonId4);

            builder.Entity<PokemonTeam>()
               .HasOne(op => op.OwnedPokemon5)
               .WithMany()
               .HasForeignKey(p => p.OwnedPokemonId5);

            builder.Entity<PokemonTeam>()
               .HasOne(op => op.OwnedPokemon6)
               .WithMany()
               .HasForeignKey(p => p.OwnedPokemonId6);



            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
