using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Album.Api.Services
{
    public class GreetingService : IGreetingService
    {
        public string Hello(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return("Hello World");
            }
            return($"Hello {name} from {Dns.GetHostName()}");
        }
    }

    public interface IGreetingService
    {
        string Hello(string Name);
 
    }
}