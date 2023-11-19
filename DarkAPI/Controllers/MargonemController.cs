using DarkAPI.ApplicationServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MargonemController : ControllerBase
    {
        private readonly IMargonemService _margonemService;
        public MargonemController(IMargonemService margonemService)
        {
            _margonemService = margonemService;
        }
        [HttpGet]
        [Route("GetToken")]
        public bool GetUserToken()
        {
            var userIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            var addresses = _margonemService.ReadAddressesFromFile();
            if (addresses.Contains(userIpAddress))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
