using PollingApp.Models;
using PollingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PollingApp.Api.Controllers
{
  public class ApiTopicMasterController : ApiController
  {
    private readonly ITopicMasterRepo _topicMasterRepo;
    public ApiTopicMasterController(ITopicMasterRepo topicMasterRepo)
    {
      _topicMasterRepo = topicMasterRepo;
    }
    // GET: api/ApiTopicMaster
    public IEnumerable<TopicMaster> Get()
    {
      return _topicMasterRepo.GetAll();
    }

    // GET: api/ApiTopicMaster/5
    public TopicMaster Get(int id)
    {
      return _topicMasterRepo.Get(id);
    }

    // POST: api/ApiTopicMaster
    public HttpResponseMessage Post([FromBody]TopicMaster topicMaster)
    {
      topicMaster.CreatedDate = DateTime.Now;
      if (ModelState.IsValid)
      {
        _topicMasterRepo.Add(ref topicMaster);
      }
      if (topicMaster.TopicId > 0)
      {
        var response = Request.CreateResponse(HttpStatusCode.OK, "Inserted Successfully");
        return response;
      }
      else
      {
        var response = Request.CreateResponse(HttpStatusCode.NotAcceptable, "Error Occured", Configuration.Formatters.JsonFormatter);
        return response;
      }
    }

    // PUT: api/ApiTopicMaster/5
    [HttpPut]
    public HttpResponseMessage Put([FromBody]TopicMaster topicMaster)
    {
      topicMaster.LastModifieddate = DateTime.Now;
      if (ModelState.IsValid)
      {
        _topicMasterRepo.Update(topicMaster);
      }
      if (topicMaster.TopicId > 0)
      {
        var response = Request.CreateResponse(HttpStatusCode.OK, "Updated Successfully");
        return response;
      }
      else
      {
        var response = Request.CreateResponse(HttpStatusCode.NotAcceptable, "Error Occured", Configuration.Formatters.JsonFormatter);
        return response;
      }
    }

    // DELETE: api/ApiTopicMaster/5
    [HttpPost]
    public HttpResponseMessage DeleteTopic(int id)
    {
      try
      {
        _topicMasterRepo.Delete(id);
        var response = Request.CreateResponse(HttpStatusCode.OK, "Deleted Successfully");
        return response;
      }
      catch (Exception)
      {
        var response = Request.CreateResponse(HttpStatusCode.NotAcceptable, "Error Occured", Configuration.Formatters.JsonFormatter);
        return response;
      }
    }

  }
}

