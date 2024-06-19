//Levi Noell-Baba
//CPT 231-W17
//Assignment 06
//February 25, 2024
using System.ComponentModel.DataAnnotations;

namespace CPT231_Assignment06_LeviNoell_Baba.Models
{
    public class Magic
    {
        public int MagicId { get; set; } //setting a unique identifier for each magic card
        [Required(ErrorMessage = "You must enter the card's name!")] //making the card name a required field and generating an error message if not filled.
        public string CardName { get; set; }//Setting the card name
        [Required(ErrorMessage = "You must enter a Card Type!")]//making the card type a required field and generating an error message if not filled.
        public string CardType { get; set; }//Setting the card type
        [Required(ErrorMessage = "You must Select whether the card is a permanent!")]//making the isPermanent a required field and generating an error message if not filled.
        public bool IsPermanent { get; set; }//Setting whether the card is a permanent or not
        [Required(ErrorMessage = "You must enter the ManaCost!")]//making the ManaCost a required field and generating an error message if not filled.
        public int ManaCost { get; set; }//Setting the card's mana cost
        [Required(ErrorMessage = "You must enter the card's Power!")]//making the Power a required field and generating an error message if not filled.
        public int Power {  get; set; }//Setting the card's power
        [Required(ErrorMessage = "You must enter the card's Toughness!")]//making the Toughness a required field and generating an error message if not filled.
        public int Toughness { get; set; }//Setting the card's toughness
        [Required(ErrorMessage = "You must enter the card's Color/Colors!")]//making the Card color a required field and generating an error message if not filled.
        public string CardColor { get; set; }//Setting the card's color
    }
}

