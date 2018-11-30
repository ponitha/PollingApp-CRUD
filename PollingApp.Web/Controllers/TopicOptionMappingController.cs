using Newtonsoft.Json;
using PollingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PollingApp.Web.Controllers
{
  public class TopicOptionMappingController : Controller
  {
    // GET: TopicOptionMapping
    public string Result { get; set; }
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Index(List<TopicOptionMapping> topicoptionmapping)
    {
      return PartialView("TopicOptionMappingList", topicoptionmapping);
    }
    public ActionResult Details(int id)
    {
      using (var client = new System.Net.Http.HttpClient())
      {
        UriBuilder builder = new UriBuilder("http://localhost:8080/api/apitopicoptionmapping/get");
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
      var deserialized = JsonConvert.DeserializeObject<TopicOptionMapping>(json);
      return PartialView(deserialized);
    }
    public ActionResult Create()
    {
      var lstTopics = GetTopicMasters().OrderBy(o => o.TopicName).ToList();

      ViewBag.TopicNameList = new SelectList(lstTopics, "TopicId", "TopicName");
      var lstOptions = GetOptionMasters().OrderBy(o => o.OptionName).ToList();
      ViewBag.OptionNameList = new SelectList(lstOptions, "OptionId", "OptionName");
      return PartialView();
    }
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
    public ActionResult Edit(int id)
    {
      using (var client = new System.Net.Http.HttpClient())
      {
        UriBuilder builder = new UriBuilder("http://localhost:8080/api/apitopicoptionmapping/get");
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
      var deserialized = JsonConvert.DeserializeObject<TopicOptionMapping>(json);
      var lstTopics = GetTopicMasters().OrderBy(o => o.TopicName).ToList();
      ViewBag.TopicNameList = new SelectList(lstTopics, "TopicId", "TopicName", deserialized.TopicId);
      var lstOptions = GetOptionMasters().OrderBy(o => o.OptionName).ToList();
      ViewBag.OptionNameList = new SelectList(lstOptions, "OptionId", "OptionName", deserialized.OptionId);
      return PartialView(deserialized);
    }

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


    public ActionResult Delete(int id)
    {
      using (var client = new System.Net.Http.HttpClient())
      {
        UriBuilder builder = new UriBuilder("http://localhost:8080/api/apitopicoptionmapping/get");
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
      var deserialized = JsonConvert.DeserializeObject<TopicOptionMapping>(json);
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


    public List<TopicMaster> GetTopicMasters()
    {
      using (var client = new System.Net.Http.HttpClient())
      {
        UriBuilder builder = new UriBuilder("http://localhost:8080/api/apitopicmaster");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = client.GetAsync(builder.Uri).Result;
        using (HttpContent content = response.Content)
        {
          Task<string> result = content.ReadAsStringAsync();
          Result = result.Result;
        }
      }
      string json = Result;
      var deserialized = JsonConvert.DeserializeObject<List<TopicMaster>>(json);
      return deserialized;
    }
    public List<OptionMaster> GetOptionMasters()
    {
      using (var client = new System.Net.Http.HttpClient())
      {
        UriBuilder builder = new UriBuilder("http://localhost:8080/api/apioptionmaster");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = client.GetAsync(builder.Uri).Result;
        using (HttpContent content = response.Content)
        {
          Task<string> result = content.ReadAsStringAsync();
          Result = result.Result;
        }
      }
      string json = Result;
      var deserialized = JsonConvert.DeserializeObject<List<OptionMaster>>(json);
      return deserialized;
    }
  }
}