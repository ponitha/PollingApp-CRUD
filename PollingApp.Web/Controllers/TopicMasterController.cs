using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PollingApp.Models;

namespace PollingApp.Web.Controllers
{
  public class TopicMasterController : Controller
  {
    public string Result { get; set; }
    public class AllJournals
    {
      public IEnumerable<TopicMaster> JournalEntries { get; set; }
    }
    // GET: TopicMaster
    public ActionResult Index()
    {
      //using (var client = new System.Net.Http.HttpClient())
      //{
      //  // HTTP POST
      //  client.BaseAddress = new Uri("http://localhost:57203/api/apitopicmaster/");
      //  //client.DefaultRequestHeaders.Add("Authorization", "Basic dmNhM2VzZ2pqMjA0OTJzMjE4ajdkZjJyNmM2Ym5qNGo0YXNtazF5Zw==");
      //  client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      //  //var response = client.GetAsync("/companies/709c095a-298b-49e8-8e73-07cea548c3d2").Result;
      //  var response = client.GetAsync("/api/apitopicmaster").Result;
      //  using (HttpContent content = response.Content)
      //  {
      //    // ... Read the string.
      //    Task<string> result = content.ReadAsStringAsync();
      //    Result = result.Result;
      //  }
      //}
      //string json = Result;
      //var deserialized = JsonConvert.DeserializeObject<List<TopicMaster>>(json);
      //return View(deserialized);
      return View();
    }

    [HttpPost]
    public ActionResult Index(List<TopicMaster> topicMaster)
    {
      return PartialView("TopicList", topicMaster);
    }

    // GET: TopicMaster/Details/5
    public ActionResult Details(int id)
    {
      using (var client = new System.Net.Http.HttpClient())
      {
        UriBuilder builder = new UriBuilder("http://localhost:57203/api/apitopicmaster/get");
        builder.Query = "id=" + id;
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = client.GetAsync(builder.Uri).Result;
        using (HttpContent content = response.Content)
        {
          Task<string> result = content.ReadAsStringAsync();
          Result = result.Result;
        }
      }
      string json = Result;
      var deserialized = JsonConvert.DeserializeObject<TopicMaster>(json);
      return PartialView(deserialized);
    }

    // GET: TopicMaster/Create
    public ActionResult Create()
    {
      return PartialView();
    }

    // POST: TopicMaster/Create
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

    // GET: TopicMaster/Edit/5
    public ActionResult Edit(int id)
    {
      using (var client = new System.Net.Http.HttpClient())
      {
        UriBuilder builder = new UriBuilder("http://localhost:57203/api/apitopicmaster/get");
        builder.Query = "id=" + id;
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = client.GetAsync(builder.Uri).Result;
        using (HttpContent content = response.Content)
        {
          Task<string> result = content.ReadAsStringAsync();
          Result = result.Result;
        }
      }
      string json = Result;
      var deserialized = JsonConvert.DeserializeObject<TopicMaster>(json);
      return PartialView(deserialized);
    }

    // POST: TopicMaster/Edit/5
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

    // GET: TopicMaster/Delete/5
    public ActionResult Delete(int id)
    {
      using (var client = new System.Net.Http.HttpClient())
      {
        UriBuilder builder = new UriBuilder("http://localhost:57203/api/apitopicmaster/get");
        builder.Query = "id=" + id;
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = client.GetAsync(builder.Uri).Result;
        using (HttpContent content = response.Content)
        {
          Task<string> result = content.ReadAsStringAsync();
          Result = result.Result;
        }
      }
      string json = Result;
      var deserialized = JsonConvert.DeserializeObject<TopicMaster>(json);
      return PartialView(deserialized);
    }

    // POST: TopicMaster/Delete/5
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
