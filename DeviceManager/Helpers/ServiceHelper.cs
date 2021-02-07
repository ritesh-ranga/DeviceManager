using DeviceManager.Shared;
using DeviceManager.Shared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager.Helpers
{
    /// <summary>
    /// A helper class that facilitates communicating with the back-end WebAPI
    /// </summary>
    public class ServiceHelper
    {
        /// <summary>
        /// Method to call WebAPI and fetch all devices
        /// </summary>
        /// <returns>A list of devices</returns>
        public async Task<List<Device>> GetAllDevicesAsync()
        {
            List<Device> devices = new List<Device>();

            try
            {
                using (var client = new HttpClient())
                {
                    // Passing service base url  
                    client.BaseAddress = new Uri(Globals.WebAPIBaseURL);
                    client.DefaultRequestHeaders.Clear();

                    // Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Sending request to find web api REST service resource using HttpClient
                    HttpResponseMessage Res = await client.GetAsync("Devices");

                    // Checking if the response is successful or not
                    if (Res.IsSuccessStatusCode)
                    {
                        // Storing the response details recieved from web api   
                        var response = Res.Content.ReadAsStringAsync().Result;

                        // Deserializing the response recieved from web api and storing into the Employee list  
                        devices = JsonConvert.DeserializeObject<List<Device>>(response);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError($"{nameof(ServiceHelper)} : {nameof(GetAllDevicesAsync)}", ex);
            }

            return devices;
        }

        /// <summary>
        /// Method to call WebAPI and fetch a particular device
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <returns>A device</returns>
        public async Task<Device> GetDeviceAsync(int DeviceID)
        {
            Device device = new Device();

            try
            {
                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(DeviceID);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    // Passing service base url  
                    client.BaseAddress = new Uri(Globals.WebAPIBaseURL);
                    client.DefaultRequestHeaders.Clear();

                    // Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Sending request to find web api REST service resource using HttpClient
                    HttpResponseMessage Res = await client.GetAsync($"Devices/{DeviceID}");

                    // Checking if the response is successful or not
                    if (Res.IsSuccessStatusCode)
                    {
                        // Storing the response details recieved from web api   
                        var response = Res.Content.ReadAsStringAsync().Result;

                        // Deserializing the response recieved from web api and storing into the Employee list  
                        device = JsonConvert.DeserializeObject<Device>(response);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError($"{nameof(ServiceHelper)} : {nameof(GetDeviceAsync)}", ex);
            }

            return device;
        }

        /// <summary>
        /// Method to call WebAPI and create a new device
        /// </summary>
        /// <param name="DeviceToBeAdded"></param>
        /// <returns>A boolean flag that signifies success or failure</returns>
        public async Task<bool> CreateDeviceAsync(Device DeviceToBeAdded)
        {
            bool success = false;

            try
            {
                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(DeviceToBeAdded);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    // Passing service base url  
                    client.BaseAddress = new Uri(Globals.WebAPIBaseURL);
                    client.DefaultRequestHeaders.Clear();

                    // Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Sending request to find web api REST service resource using HttpClient
                    HttpResponseMessage Res = await client.PostAsync("Devices", data);

                    // Checking if the response is successful or not
                    if (Res.IsSuccessStatusCode)
                    {
                        // Storing the response details recieved from web api   
                        var response = Res.Content.ReadAsStringAsync().Result;

                        // Deserializing the response recieved from web api and storing into the Employee list  
                        success = JsonConvert.DeserializeObject<bool>(response);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError($"{nameof(ServiceHelper)} : {nameof(CreateDeviceAsync)}", ex);
            }

            return success;
        }

        /// <summary>
        /// Method to call WebAPI and delete a device
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <returns>A boolean flag that signifies success or failure</returns>
        public async Task<bool> DeleteDeviceAsync(int DeviceID)
        {
            bool success = false;

            try
            {
                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(DeviceID);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    // Passing service base url  
                    client.BaseAddress = new Uri(Globals.WebAPIBaseURL);
                    client.DefaultRequestHeaders.Clear();

                    // Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Sending request to find web api REST service resource using HttpClient
                    HttpResponseMessage Res = await client.DeleteAsync($"Devices/{DeviceID}");

                    // Checking if the response is successful or not
                    if (Res.IsSuccessStatusCode)
                    {
                        // Storing the response details recieved from web api   
                        var response = Res.Content.ReadAsStringAsync().Result;

                        // Deserializing the response recieved from web api and storing into the Employee list  
                        success = JsonConvert.DeserializeObject<bool>(response);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError($"{nameof(ServiceHelper)} : {nameof(DeleteDeviceAsync)}", ex);
            }

            return success;
        }

        /// <summary>
        /// Method to call WebAPI and update a device's details
        /// </summary>
        /// <param name="DeviceToBeUpdated"></param>
        /// <returns>A boolean flag that signifies success or failure</returns>
        public async Task<bool> UpdateDeviceAsync(Device DeviceToBeUpdated)
        {
            bool success = false;

            try
            {
                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(DeviceToBeUpdated);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    // Passing service base url  
                    client.BaseAddress = new Uri(Globals.WebAPIBaseURL);
                    client.DefaultRequestHeaders.Clear();

                    // Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Sending request to find web api REST service resource using HttpClient
                    HttpResponseMessage Res = await client.PutAsync($"Devices/{DeviceToBeUpdated.id}", data);

                    // Checking if the response is successful or not
                    if (Res.IsSuccessStatusCode)
                    {
                        // Storing the response details recieved from web api   
                        var response = Res.Content.ReadAsStringAsync().Result;

                        // Deserializing the response recieved from web api and storing into the Employee list  
                        success = JsonConvert.DeserializeObject<bool>(response);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError($"{nameof(ServiceHelper)} : {nameof(UpdateDeviceAsync)}", ex);
            }

            return success;
        }
    }
}
