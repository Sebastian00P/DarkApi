using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DarkAPI.ApplicationServices
{
    public class MargonemService : IMargonemService
    {
        public string FilePath = "";
        private readonly IConfiguration _services;
        public MargonemService(IConfiguration services)
        {
            _services = services;
            FilePath = _services.GetValue<string>("AddressesFilePath");
        }
        public List<string> ReadAddressesFromFile()
        {
            string filePath = FilePath;
            List<string> addresses = new List<string>();

            try
            {            
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        addresses.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Wystąpił błąd podczas czytania pliku: " + e.Message);
            }

            return addresses;
        }
    }
}
