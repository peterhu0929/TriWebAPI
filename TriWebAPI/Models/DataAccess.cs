using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace TriWebAPI.Models
{
    public class DataAccess
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        MongoClient _clientAzure;
        MongoServer _serverAzure;
        MongoDatabase _dbAzure;

        string connectionString =
  @"mongodb://angular-tri:BgoQgavrKYsD34H1009QjoSXA2ETiqgvZBWKnp0MqtNurKOnKGmqHAWHiK8sThwX3BKuQffl5m1uWC0tbWDB5A==@angular-tri.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";

        string defaultDBstring = "mongodb://localhost:27017";

        public DataAccess()
        {
            _client = new MongoClient(defaultDBstring);
            _server = _client.GetServer();
            //_db = _server.GetDatabase("TriDB");

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            _clientAzure = new MongoClient(settings);
            _serverAzure = _clientAzure.GetServer();
            _db = _serverAzure.GetDatabase("TriDB");
        }

        public IEnumerable<Triathlon> GetTris()
        {
            //return _dbAzure.GetCollection<User>("Users").FindAll();
            return _db.GetCollection<Triathlon>("Triathlon").FindAll();
        }

        public IEnumerable<Triathlon> GetTri(string id, string year, string monthS,string monthE, string place)
        {
            int i = 0;
            var qc = new IMongoQuery[5];
            if (id != "") qc[i++] = Query<Triathlon>.EQ(p => p.Id, new ObjectId(id));
            if (year != "") qc[i++] = Query<Triathlon>.Matches(p => p.year, year);
            var S = Query<Triathlon>.GTE(p => p.month, monthS);
            var E = Query<Triathlon>.LTE(p => p.month, monthE);
            if (monthS != "") qc[i++] =S;
            if (monthE != "") qc[i++] =E;
            if (monthE != ""&& monthE != "") qc[i++] = Query.And(S, E);
            if (place != "") qc[i++] = Query<Triathlon>.Matches(p => p.place, place);
            qc = qc.Where(c => c != null).ToArray();
            if (qc.Length > 0)
                return _db.GetCollection<Triathlon>("Triathlon").Find(Query.And(qc));
            else
                return _db.GetCollection<Triathlon>("Triathlon").FindAll();
        }

        public Triathlon CreateTri(Triathlon tri)
        {
            tri.in_date = DateTime.Now;
            tri.up_date = DateTime.Now;
            _db.GetCollection<Triathlon>("Triathlon").Save(tri);
            return tri;
        }

        public bool UpdateTri(ObjectId id, Triathlon tri)
        {
            tri.Id = id;
            tri.up_date = DateTime.Now; 
            var res = Query<Triathlon>.EQ(u => u.Id, id);
            var operation = Update<Triathlon>.Replace(tri);
            var result = _db.GetCollection<Triathlon>("Triathlon").Update(res, operation);
            return !result.HasLastErrorMessage;
        }
        public bool RemoveTri(ObjectId id)
        {
            var res = Query<Triathlon>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Triathlon>("Triathlon").Remove(res);
            return !operation.HasLastErrorMessage;
        }
    }
}