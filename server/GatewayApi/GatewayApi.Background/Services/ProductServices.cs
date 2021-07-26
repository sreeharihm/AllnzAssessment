using GatewayApi.Background.Entites;
using GatewayApi.Background.Extensions;
using GatewayApi.Background.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace GatewayApi.Background.Services
{
    public class ProductServices : IProductService
    { 
       private IConfiguration _configuration;
        public ProductServices(IConfiguration configuration)
        {
            _configuration = configuration;
            var client = new MongoClient(_configuration.GetConnectionString("mongoDb"));
            var database = client.GetDatabase(_configuration["db"]);
            database.CreateCollecitonIfNotExist();
            Products = database.GetCollection<Product>("Product");
            PriceReductions = database.GetCollection<PriceReduction>("PriceReduction");
            ContextSeeding.SeedData(Products);
            ContextSeeding.SeedData(PriceReductions);
        }

        public List<Product> Get() => Products.Find(p => true).ToList();

        public Product Get(ObjectId id) =>
            Products.Find<Product>(p => p.Id == id).FirstOrDefault();

        public Product Create(Product product)
        {
            product.Id = ObjectId.GenerateNewId();
            Products.InsertOne(product);
            return product;
        }

        public double GetReducionRate(int DayOfWeek)
        {
            return PriceReductions.Find(p => p.DayOfWeek == DayOfWeek).Project(x => x.Reduction).FirstOrDefault();
        }

        private IMongoCollection<Product> Products { get; }

        private IMongoCollection<PriceReduction> PriceReductions { get; }
    }
}
