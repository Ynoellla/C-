using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CPT231_Assignment06_LeviNoell_Baba.Models
{
    public class NoellBabaContext : IdentityDbContext<User> //setting NoellBabaContext to represent the Identity database context
    {
        public NoellBabaContext(DbContextOptions<NoellBabaContext> options) : base(options) //constructor that takes DbContextOptions as a parameter
        {
            
        }

        public DbSet<Magic> Magics { get; set; } = null!; //DbSet that represents the entity in the database

        protected override void OnModelCreating(ModelBuilder modelBuilder)//method to to build the database when the context is being created
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Magic>().HasData(//initial data for the magic cards being used for the database.
                new Magic
                {
                    MagicId = 1,
                    CardName = "Roaming Throne",
                    CardType = "Artifact Creature - Golem",
                    IsPermanent = true,
                    ManaCost = 4,
                    Power = 4,
                    Toughness = 4,
                    CardColor = "Colorless"
                },
                new Magic
                {
                    MagicId = 2,
                    CardName = "Hunting Velociraptor",
                    CardType = "Creature - Dinosaur",
                    IsPermanent = true,
                    ManaCost = 3,
                    Power = 3,
                    Toughness = 2,
                    CardColor = "Red"
                },
                new Magic
                {
                    MagicId = 3,
                    CardName = "Tishana's Tidebinder",
                    CardType = "Creature - Merfolk Wizard",
                    IsPermanent = true,
                    ManaCost = 3,
                    Power = 3,
                    Toughness = 2,
                    CardColor = "Blue"
                },
                new Magic
                {
                    MagicId = 4,
                    CardName = "Owen Grady, Raptor Trainer",
                    CardType = "Legenday Creature - Human Soldier Scientist",
                    IsPermanent = true,
                    ManaCost = 3,
                    Power = 3,
                    Toughness = 2,
                    CardColor = "Red, Green"
                },
                new Magic
                {
                    MagicId = 5,
                    CardName = "Sunken Citadel",
                    CardType = "Land - Cave",
                    IsPermanent = true,
                    ManaCost = 0,
                    Power = 0,
                    Toughness = 0,
                    CardColor = "Colorless"
                },
                new Magic
                {
                    MagicId = 6,
                    CardName = "Reliquary Tower",
                    CardType = "Land",
                    IsPermanent = true,
                    ManaCost = 0,
                    Power = 0,
                    Toughness = 0,
                    CardColor = "Colorless"
                },
                new Magic
                {
                    MagicId = 7,
                    CardName = "Myriad Landscape",
                    CardType = "Land",
                    IsPermanent = true,
                    ManaCost = 0,
                    Power = 0,
                    Toughness = 0,
                    CardColor = "Colorless"
                },
                new Magic
                {
                    MagicId = 8,
                    CardName = "Evolving Wilds",
                    CardType = "Land",
                    IsPermanent = true,
                    ManaCost = 0,
                    Power = 0,
                    Toughness = 0,
                    CardColor = "Colorless"
                },
                new Magic
                {
                    MagicId = 9,
                    CardName = "Hunter's Blowgun",
                    CardType = "Artifact - Equipment",
                    IsPermanent = true,
                    ManaCost = 1,
                    Power = 0,
                    Toughness = 0,
                    CardColor = "Colorless"
                },
                new Magic
                {
                    MagicId = 10,
                    CardName = "Walk with the Ancestors",
                    CardType = "Sorcery",
                    IsPermanent = false,
                    ManaCost = 5,
                    Power = 0,
                    Toughness = 0,
                    CardColor = "Green"
                },
                new Magic
                {
                    MagicId = 11,
                    CardName = "Triumphant Chomp",
                    CardType = "Sorcery",
                    IsPermanent = false,
                    ManaCost = 1,
                    Power = 0,
                    Toughness = 0,
                    CardColor = "Red"
                },
                new Magic
                {
                    MagicId = 12,
                    CardName = "Twists and Turns",
                    CardType = "Enchantment",
                    IsPermanent = true,
                    ManaCost = 1,
                    Power = 0,
                    Toughness = 0,
                    CardColor = "Green"
                }
                );
        }
    }
}
