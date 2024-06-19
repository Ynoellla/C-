using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CPT231_Assignment06_LeviNoell_Baba.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Magics",
                columns: table => new
                {
                    MagicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPermanent = table.Column<bool>(type: "bit", nullable: false),
                    ManaCost = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    Toughness = table.Column<int>(type: "int", nullable: false),
                    CardColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magics", x => x.MagicId);
                });

            migrationBuilder.InsertData(
                table: "Magics",
                columns: new[] { "MagicId", "CardColor", "CardName", "CardType", "IsPermanent", "ManaCost", "Power", "Toughness" },
                values: new object[,]
                {
                    { 1, "Colorless", "Roaming Throne", "Artifact Creature - Golem", true, 4, 4, 4 },
                    { 2, "Red", "Hunting Velociraptor", "Creature - Dinosaur", true, 3, 3, 2 },
                    { 3, "Blue", "Tishana's Tidebinder", "Creature - Merfolk Wizard", true, 3, 3, 2 },
                    { 4, "Red, Green", "Owen Grady, Raptor Trainer", "Legenday Creature - Human Soldier Scientist", true, 3, 3, 2 },
                    { 5, "Colorless", "Sunken Citadel", "Land - Cave", true, 0, 0, 0 },
                    { 6, "Colorless", "Reliquary Tower", "Land", true, 0, 0, 0 },
                    { 7, "Colorless", "Myriad Landscape", "Land", true, 0, 0, 0 },
                    { 8, "Colorless", "Evolving Wilds", "Land", true, 0, 0, 0 },
                    { 9, "Colorless", "Hunter's Blowgun", "Artifact - Equipment", true, 1, 0, 0 },
                    { 10, "Green", "Walk with the Ancestors", "Sorcery", false, 5, 0, 0 },
                    { 11, "Red", "Triumphant Chomp", "Sorcery", false, 1, 0, 0 },
                    { 12, "Green", "Twists and Turns", "Enchantment", true, 1, 0, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Magics");
        }
    }
}
