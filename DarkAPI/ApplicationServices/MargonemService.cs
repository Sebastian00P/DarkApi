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
        public bool AddUserIdToList(string userId)
        {
            try
            {
                List<string> userIds = File.ReadAllLines(FilePath).ToList();
                if (userIds.Contains(userId))
                {
                    return false;
                }
                using (StreamWriter sw = File.AppendText(FilePath))
                {
                    sw.WriteLine(userId);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool RemoveUserIdFromList(string userId)
        {
            try
            {
                string[] lines = File.ReadAllLines(FilePath);
                List<string> updatedLines = new List<string>();

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] != userId)
                    {
                        updatedLines.Add(lines[i]);
                    }
                }

                File.WriteAllLines(FilePath, updatedLines.ToArray());

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
