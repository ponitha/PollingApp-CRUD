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
  public class ApiOptionMasterController : ApiController
  {
    // GET api/<controller>
    private readonly IOptionMasterRepo _optionMasterRepo;
    public ApiOptionMasterController(IOptionMasterRepo optionMasterRepo)
    {
      _optionMasterRepo = optionMasterRepo;
    }
    public IEnumerable<OptionMaster> Get()
    {
      return _optionMasterRepo.GetAll();
    }

    // GET api/<controller>/5
    public OptionMaster Get(int id)
    {
      return _optionMasterRepo.Get(id);
    }

    // POST api/<controller>
    public HttpResponseMessage Post([FromBody]OptionMaster optionMaster)
    {
      optionMaster.CreatedDate = DateTime.Now;
      if (ModelState.IsValid)
      {
        _optionMasterRepo.Add(ref optionMaster);
      }
      if (optionMaster.OptionId > 0)
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
    [HttpPost]
    public HttpResponseMessage Put([FromBody]OptionMaster optionMaster)
    {
      optionMaster.LastModifiedDate = DateTime.Now;
      if (ModelState.IsValid)
      {
        _optionMasterRepo.Update(optionMaster);
      }
      if (optionMaster.OptionId > 0)
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
    [HttpPost]
    public HttpResponseMessage DeleteTopic(int id)
    {
      try
      {
        _optionMasterRepo.Delete(id);
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