using PollingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PollingApp.Web.Controllers
{

  public class AppRoleController : Controller
  {
    private readonly IAppRoleRepo _appRoleRepo;
    public AppRoleController(IAppRoleRepo appRoleRepo)
    {
      _appRoleRepo = appRoleRepo;
    }
    // GET: AppRole
    public ActionResult Index()
    {
      return View();
    }

    // GET: AppRole/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: AppRole/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: AppRole/Create
    [HttpPost]
    public ActionResult Create(FormCollection collection)
    {
      try
      {
        // TODO: Add insert logic here

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }

    // GET: AppRole/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: AppRole/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, FormCollection collection)
    {
      try
      {
        // TODO: Add update logic here

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }

    // GET: AppRole/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: AppRole/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, FormCollection collection)
    {
      try
      {
        // TODO: Add delete logic here

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }
  }
}
