using DeviceManager.Helpers;
using DeviceManager.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviceManager.Controllers
{
    public class DeviceController : Controller
    {
        // GET: DeviceController
        public async Task<ActionResult> IndexAsync()
        {
            ServiceHelper serviceHelper = new ServiceHelper();
            List<Device> devices = await serviceHelper.GetAllDevicesAsync();

            // Pass the devices list to view
            return View(devices);
        }

        // GET: DeviceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeviceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> CreateAsync(IFormCollection collection)
        {
            bool success = false;

            try
            {
                Device newDevice = new Device();
                newDevice.id = -1;
                newDevice.location = collection["location"];
                newDevice.type = collection["type"];
                newDevice.device_health = collection["device_health"];
                newDevice.last_used = Convert.ToDateTime(collection["last_used"]);
                newDevice.price = Convert.ToDouble(collection["price"]);
                newDevice.color = collection["color"];

                ServiceHelper serviceHelper = new ServiceHelper();
                success = await serviceHelper.CreateDeviceAsync(newDevice);
            }
            catch
            {
                // Log the exception
            }

            return Json(success);
        }

        // GET: DeviceController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            ServiceHelper serviceHelper = new ServiceHelper();
            Device device = await serviceHelper.GetDeviceAsync(id);

            return View(device);
        }

        // POST: DeviceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Edit(IFormCollection collection)
        {
            bool success = false;

            try
            {
                Device newDevice = new Device();
                newDevice.id = Convert.ToInt32(collection["id"]);
                newDevice.location = collection["location"];
                newDevice.type = collection["type"];
                newDevice.device_health = collection["device_health"];
                newDevice.last_used = Convert.ToDateTime(collection["last_used"]);
                newDevice.price = Convert.ToDouble(collection["price"]);
                newDevice.color = collection["color"];

                ServiceHelper serviceHelper = new ServiceHelper();
                success = await serviceHelper.UpdateDeviceAsync(newDevice);
            }
            catch
            {
                // Log the exception
            }

            return Json(success);
        }

        //DELETE: DeviceController/Delete/5
        public async Task<JsonResult> Delete(int id)
        {
            bool success = false;

            try
            {
                ServiceHelper serviceHelper = new ServiceHelper();
                success = await serviceHelper.DeleteDeviceAsync(id);
            }
            catch
            {
                // Log the exception
            }

            return Json(success);
        }
    }
}
