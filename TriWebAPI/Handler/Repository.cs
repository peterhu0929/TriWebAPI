using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriWebAPI.Models;

namespace TriWebAPI.Handler
{
    public class Repository : IRepository
    {
        private readonly DataAccess _db;
        public Repository(DataAccess db)
        {
            _db = db;
        }

        public Response<Triathlon> AddTri(Triathlon tri)
        {
            var result = new Response<Triathlon>();
            result.IsSuccess = true;
            try
            {
                result.Data = _db.CreateTri(tri);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public Response<bool> DeleteTri(string Id)
        {
            var result = new Response<bool>();
            result.IsSuccess = true;
            try
            {
                var objId = new ObjectId(Id);
                result.Data = _db.RemoveTri(objId);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public Response<IEnumerable<Triathlon>> GetAllTri()
        {
            var result = new Response<IEnumerable<Triathlon>>();
            result.IsSuccess = true;
            try
            {
                result.Data = _db.GetTris();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public Response<IEnumerable<Triathlon>> GetTriById(string Id, string year, string monthS, string monthE, string place)
        {
            var result = new Response<IEnumerable<Triathlon>>();
            result.IsSuccess = true;
            try
            {
                result.Data = _db.GetTri(Id, year, monthS, monthE, place);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public Response<bool> UpdateTri(string Id, Triathlon tri)
        {
            var result = new Response<bool>();
            result.IsSuccess = true;
            try
            {
                var objId = new ObjectId(Id);
                result.Data = _db.UpdateTri(objId, tri);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
