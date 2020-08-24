using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PierresTreats.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PierresTreats.Controllers
{
  public class FlavorsController : Controller
  {
    private readonly PierresTreatsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public FlavorsController(PierresTreatsContext db, UserManager<ApplicationUser> userManager)
    {
      _db = db;
      _userManager = userManager;
    }

    public ActionResult Index()
    {
      List<Flavor> model = _db.Flavors.ToList();
      return View(model);
    }

    public ActionResult Details(int id)
    {
      var thisFlavor = _db.Flavors
        .Include(flavor => flavor.Treats)
        .ThenInclude(join => join.Treat)
        .FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }

    [Authorize]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Flavor flavor)
    {
      _db.Flavors.Add(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize]
    public ActionResult Edit(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Entry(flavor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = flavor.FlavorId });
    }

    [Authorize]
    public ActionResult Delete(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      _db.Flavors.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize]
    public ActionResult AddTreat(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreatName");
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult AddTreat(Flavor flavor, int TreatId)
    {
      IQueryable<TreatFlavor> treatFlavors = _db.TreatFlavors.Where(entry => entry.FlavorId == flavor.FlavorId);
      foreach (TreatFlavor entry in treatFlavors)
      {
        if (entry.TreatId == TreatId)
        {
          return RedirectToAction("Details", new { id = flavor.FlavorId });
        }
      }
      if (TreatId != 0)
      {
        _db.TreatFlavors.Add(new TreatFlavor() { TreatId = TreatId, FlavorId = flavor.FlavorId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = flavor.FlavorId });
    }
      

    [Authorize]
    public ActionResult DeleteTreat(int id)
    {
      var joinEntry = _db.TreatFlavors.FirstOrDefault(entry => entry.TreatFlavorId == id);
      ViewBag.Flavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == joinEntry.FlavorId);
      ViewBag.Treat = _db.Treats.FirstOrDefault(treat => treat.TreatId == joinEntry.TreatId);
      return View(joinEntry);
    }

    [HttpPost, ActionName("DeleteTreat")]
    public ActionResult DeleteTreatConfirmed(int id)
    {
      var joinEntry = _db.TreatFlavors.FirstOrDefault(entry => entry.TreatFlavorId == id);
      _db.TreatFlavors.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = joinEntry.TreatId });
    }
  }
}