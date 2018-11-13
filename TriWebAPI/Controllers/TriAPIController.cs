using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TriWebAPI.Handler;
using TriWebAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriWebAPI.Controllers
{
    [Route("api/Triathlon/[action]/")]
    public class TriAPIController : Controller
    {
        private readonly IRepository _repository;

        public TriAPIController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        public Response<IEnumerable<Triathlon>> GetAllTri()
        {
            return _repository.GetAllTri();
        }

        // GET api/<controller>/5
        [HttpGet]
        public Response<IEnumerable<Triathlon>> GetTriById(string Id="", string year = "",string monthS="",string monthE = "",string place="")
        {
            var response = _repository.GetTriById(Id, year,monthS, monthE, place);
            return response;
        }

        // POST api/<controller>
        [HttpPost]
        public Response<Triathlon> AddTri([FromBody]Triathlon tri)
        {
            var response = _repository.AddTri(tri);
            return response;
        }

        [HttpPut]
        public Response<bool> UpdateTri(string Id, [FromBody] Triathlon tri)
        {
            var response = _repository.UpdateTri(Id, tri);
            return response;
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public Response<bool> DeleteTri(string Id)
        {
            var response = _repository.DeleteTri(Id);
            return response;
        }
    }
}