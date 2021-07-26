using GatewayApi.Background.Interfaces;
using GatewayApi.Background.Messages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace GatewayApi.Background.Factories
{
    public class ProductFactory
    {
        private readonly IProductService _service;
        public ProductFactory(IProductService service)
        {
            _service = service;
        }
        public ProductDetailsResponse GetProductDetails(ProductDetailsRequest request)
        {
            var response = new ProductDetailsResponse
            {
                Product = new Product()
            };
            var reductionRate = _service.GetReducionRate((int)DateTime.Now.DayOfWeek);
            var result = _service.Get(new MongoDB.Bson.ObjectId(request.ProductId));
            if (result != null)
            {
                response.Product = new Product
                {
                    Id = result.Id.ToString(),
                    Name = result.ProductName,
                    EntryDate = result.EntryDate,
                    PriceWithReduction = reductionRate != 0 ? result.Price * reductionRate : result.Price
                };
            }
            return response;
        }
        public ProductsResponse GetProduct(ProductsRequest request)
        {
            var response = new ProductsResponse();
            response.ProductList = new List<Product>();
            var reductionRate = _service.GetReducionRate((int)DateTime.Now.DayOfWeek);
            var products = _service.Get();
            foreach (var i in products)
            {
                var p = new Product
                {
                    Id = i.Id.ToString(),
                    Name = i.ProductName,
                    EntryDate = i.EntryDate,
                    PriceWithReduction = reductionRate != 0 ? i.Price * reductionRate : i.Price
                };
                response.ProductList.Add(p);
            }
            return response;
        }
    }
}
