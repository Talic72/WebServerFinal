using LiftingApp.Data;
using Microsoft.AspNetCore.Mvc;
using LiftingApp.Models;

namespace LiftingApp.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly AppDbContext _context;
        public WorkoutController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search)
        {
            var workouts = _context.Exercises.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                workouts = workouts.Where(w =>
                    w.Name.Contains(search) ||
                    w.MuscleGroup.Contains(search));
            }

            return View(workouts.ToList());
        }

        public IActionResult Stats()
        {
            var workouts = _context.Exercises.ToList();

            var totalWorkouts = workouts.Count;

            var muscleGroups = workouts
                .GroupBy(w => w.MuscleGroup)
                .Select(g => new
                {
                    Muscle = g.Key,
                    Count = g.Count()
                })
                .ToList();

            ViewBag.TotalWorkouts = totalWorkouts;
            ViewBag.MuscleGroups = muscleGroups;

            return View();
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // GET: Workout/Edit/5
        public IActionResult Edit(int id)
        {
            var workout = _context.Exercises.Find(id);

            if (workout == null)
            {
                return NotFound();
            }

            return View(workout);
        }

        // GET: Workout/Delete/5
        public IActionResult Delete(int id)
        {
            var workout = _context.Exercises.Find(id);

            if (workout == null)
            {
                return NotFound();
            }

            return View(workout);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Exercise excercises)
        {
            if (ModelState.IsValid)
            {
                _context.Exercises.Add(excercises);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(excercises);
        }

        // POST: Workout/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Exercise workout)
        {
            if (ModelState.IsValid)
            {
                _context.Exercises.Update(workout);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workout);
        }

        // POST: Workout/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var workout = _context.Exercises.Find(id);

            if (workout != null)
            {
                _context.Exercises.Remove(workout);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}