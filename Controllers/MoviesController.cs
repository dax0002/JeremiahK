using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;
using FinalProject.Seeding;
using FinalProject.DAL;

public class MoviesController : Controller
{
    private readonly AppDbContext _context;

    public MoviesController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult ExploreMovies()
    {
        // Retrieve movies from the seeded data
        List<Movie> movies = SeedMovies.GetMovies();

        return View("Movies/Index", movies);
    }
}