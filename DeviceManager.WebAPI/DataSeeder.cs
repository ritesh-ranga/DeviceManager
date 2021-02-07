using DeviceManager.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DeviceManager.WebAPI
{
    /// <summary>
    /// Class to seed the database with initial data
    /// </summary>
    public class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            List<Device> devicesFromJson =  LoadJson();

            if (devicesFromJson.Count > 0)
            {
                try
                {
                    using (var context = new DeviceContext(serviceProvider.GetRequiredService<DbContextOptions<DeviceContext>>()))
                    {
                        // Look for any device
                        if (context.DeviceItems.Any())
                        {
                            return;   // Data was already seeded
                        }

                        context.DeviceItems.AddRange(devicesFromJson);

                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception
                }
            }
        }

        /// <summary>
        /// Loads the Json file, parses it and extracts the devices
        /// </summary>
        /// <returns>List of devices</returns>
        public static List<Device> LoadJson()
        {
            List<Device> items = new List<Device>();

            try
            {
                string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"Data\data.json");

                if (File.Exists(jsonFilePath))
                {
                    using (StreamReader r = new StreamReader(jsonFilePath))
                    {
                        string json = r.ReadToEnd();
                        items = JsonConvert.DeserializeObject<List<Device>>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
            }

            return items;
        }
    }
}
