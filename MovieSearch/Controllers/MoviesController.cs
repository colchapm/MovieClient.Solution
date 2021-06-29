using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieSearch.Models;

namespace MovieSearch.Controllers
{
  public class MoviesController : Controller
  {

    public IActionResult Index()
    {
      var allMovies = Movie.GetMovies();

      return View(allMovies);
    }

    public IActionResult Details(int id)
    {
      var movie = Movie.GetDetails(id);
      return View(movie);
    }

    //The route below is actually the edit route, but since it reroutes to the details page it's done in that page.
    [HttpPost]
    public IActionResult Details(int id, Movie movie)
    {
      movie.MovieId = id;
      Movie.Put(movie);
      return RedirectToAction("Details", id);
    }
    //Below is just the get method for the edit 
    public IActionResult Edit(int id)
    {
      var movie = Movie.GetDetails(id);
      return View(movie);
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Movie movie)
    {
      Movie.Post(movie);
      return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
      Movie.Delete(id);
      return RedirectToAction("Index");
    }
  }
}