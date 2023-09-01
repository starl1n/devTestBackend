using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using Valego_Consulting.Models;
using Valego_Consulting.DataServices;

namespace Valego_Consulting
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DataService dataService = new DataService();

            List<Announcement> announcements = await dataService.FetchBitMexAnnouncements();

            if (announcements != null)
            {
                await dataService.StoreAnnouncements(announcements);
                Console.WriteLine("Anuncios almacenados en la base de datos.");
            }
            else
            {
                Console.WriteLine("No se pudieron obtener anuncios.");
            }
        }
    }
}

