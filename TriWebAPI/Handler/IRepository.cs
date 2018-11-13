using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriWebAPI.Models;

namespace TriWebAPI.Handler
{
    public interface IRepository
    {
        Response<Triathlon> AddTri(Triathlon u);
        Response<IEnumerable<Triathlon>> GetAllTri();
        Response<bool> DeleteTri(string Id);
        Response<IEnumerable<Triathlon>> GetTriById(string Id, string year, string monthS, string monthE, string place);
        Response<bool> UpdateTri(string Id, Triathlon tri);
    }
}
