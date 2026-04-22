namespace LiftingApp.Models
{
    public class Exercise
    {
        public int Id { get; set; }

        public string Name { get; set; }        // Bench Press
        public string MuscleGroup { get; set; } // Chest, Legs, etc.
        public string Description { get; set; } // What it does
    }
}