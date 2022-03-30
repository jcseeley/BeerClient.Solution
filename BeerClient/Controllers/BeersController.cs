using Microsoft.AspNetCore.Mvc;
using BeerClient.Models;

namespace BeerClient.Controllers
{
  public class BeersController : Controller
  {
    public IActionResult Index()
    {
      var allBeer = Beer.GetBeers();
      return View(allBeer);
    }

    [HttpPost]
    public IActionResult Index(Beer beer)
    {
      Beer.Post(beer);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var beer = Beer.GetDetails(id);
      return View(beer);
    }

    public IActionResult Edit(int id)
    {
      var beer = Beer.GetDetails(id);
      return View(beer);
    }

    [HttpPost]
    public IActionResult Details(int id, Beer beer)
    {
      beer.BeerId = id;
      Beer.Put(beer);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Beer.Delete(id);
      return RedirectToAction("Index");
    }
    public IActionResult Random()
    {
      var randomBeer = Beer.Random();
      return View(randomBeer);
    }
  }
}