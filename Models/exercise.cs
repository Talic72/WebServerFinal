using System.ComponentModel.DataAnnotations;

namespace LiftingApp.Models
{
    public class Exercise
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }        // Bench Press
        [Required]
        public string MuscleGroup { get; set; } // Chest, Legs, etc.
        public string Difficulty { get; set; } // Label how difficult it was
        public string Description { get; set; } // What it does
    }
}