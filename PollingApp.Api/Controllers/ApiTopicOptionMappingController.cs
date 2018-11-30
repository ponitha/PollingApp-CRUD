using PollingApp.Models;
using PollingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PollingApp.Api.Controllers
{
  public class ApiTopicOptionMappingController : ApiController
  {
    // GET api/<controller>
    private readonly ITopicOptionMappingRepo _topicOptionMappingRepo;

    public ApiTopicOptionMappingController(ITopicOptionMappingRepo topicOptionMappingRepo)
    {
      _topicOptionMappingRepo = topicOptionMappingRepo;
    }
    public IEnumerable<TopicOptionMapping> Get()
    {
      return _topicOptionMappingRepo.GetAll();
    }

    // GET api/<controller>/5
    public TopicOptionMapping Get(int id)
    {
      return _topicOptionMappingRepo.Get(id);
    }

    // POST api/<controller>
    public HttpResponseMessage Post([FromBody]TopicOptionMapping topicoptionmapping)
    {
      topicoptionmapping.CreatedDate = DateTime.Now;
      if (ModelState.IsValid)
      {
        _topicOptionMappingRepo.Add(ref topicoptionmapping);
      }
      if (topicoptionmapping.TopicOptionMappingId > 0)
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

    // PUT api/<controller>/5
    [HttpPut]
    public HttpResponseMessage Put( [FromBody]TopicOptionMapping topicoptionmapping)
    {
      topicoptionmapping.LastModifiedDate = DateTime.Now;
      if (ModelState.IsValid)
      {
        _topicOptionMappingRepo.Update(topicoptionmapping);
      }
      if (topicoptionmapping.TopicOptionMappingId > 0)
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

    // DELETE api/<controller>/5
    [HttpDelete]
    public HttpResponseMessage Delete(int id)
    {
      try
      {
        _topicOptionMappingRepo.Delete(id);
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