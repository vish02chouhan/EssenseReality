using AutoMapper;
using EssenceRealty.Repository.IRepositories;
using EssenceRealty.Domain.ViewModels;
using EssenceRealty.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EssenceRealty.Web.API.Model;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Web;

namespace EssenceRealty.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UrlExecuteController : ControllerBase
    {
        private readonly ILogger<UrlExecuteController> logger;
        private readonly HttpClient httpClient;

        public UrlExecuteController(ILogger<UrlExecuteController> logger, HttpClient httpClient)
        {
            this.logger = logger;
            this.httpClient = httpClient;
        }


        [HttpGet("{url}")]
        public async Task<string> Get(string url)
        {
            url = HttpUtility.UrlDecode(url);

            httpClient.BaseAddress = new Uri(url);
            using var httpResponse = await httpClient.GetAsync("", HttpCompletionOption.ResponseHeadersRead);

            httpResponse.EnsureSuccessStatusCode(); // throws if not 200-299

            try
            {
                return await httpResponse.Content.ReadAsStringAsync();
            }
            catch // Could be ArgumentNullException or UnsupportedMediaTypeException
            {
                Console.WriteLine("HTTP Response was invalid or could not be deserialised.");
            }

            return null;
        }
    }
  
}
