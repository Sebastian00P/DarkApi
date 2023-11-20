using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkAPI.ApplicationServices
{
    public interface IMargonemService
    {
        List<string> ReadAddressesFromFile();
        bool AddUserIdToList(string userId);
        bool RemoveUserIdFromList(string userId);
    }
}
