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
  public class ApiAppRoleController : ApiController
  {
    private readonly IAppRoleRepo _appRoleRepo;
    public ApiAppRoleController(IAppRoleRepo appRoleRepo)
    {
      _appRoleRepo = appRoleRepo;
    }
    // GET: api/AppRole
    public IEnumerable<AppRole> Get()
    {
      return _appRoleRepo.GetAll();
    }

    // GET: api/AppRole/5
    public string Get(int id)
    {
      return "value";
    }

    // POST: api/AppRole
    public void Post([FromBody]string value)
    {
    }

    // PUT: api/AppRole/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/AppRole/5
    public void Delete(int id)
    {
    }
  }
}
