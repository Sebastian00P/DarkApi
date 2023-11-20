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
        public bool GetUserToken(string userId)
        {          
            var addresses = _margonemService.ReadAddressesFromFile();
            if (addresses.Contains(userId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpPost]
        [Route("AddUserIdToList")]
        public bool AddUserId(string userId)
        {
            return _margonemService.AddUserIdToList(userId);
        }
        [HttpDelete]
        [Route("RemoveUserIdToList")]
        public bool RemoveUserId(string userId)
        {
            return _margonemService.RemoveUserIdFromList(userId);
        }
        [HttpGet]
        [Route("GetAllUserIds")]
        public List<string> GetAllUserIds()
        {
            return _margonemService.ReadAddressesFromFile();         
        }
    }
}
