using EasyNetQ;
using GatewayApi.Background.Messages;
using GatewayApi.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMqService _mqService;
        public ProductController(IMqService mqService)
        {
            _mqService = mqService;
        }
        [HttpGet]
        public async Task<ActionResult<ProductsResponse>> Get()
        {
            return await _mqService.GetProducts();
        }
        [HttpGet("GetProductDetail")]
        public async Task<ActionResult<ProductDetailsResponse>> GetProductDetail(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            if (id.Length < 24 || id.Length > 24)
            {
                return UnprocessableEntity();
            }
            return await _mqService.GetProductDetails(id);
        }
    }
}
