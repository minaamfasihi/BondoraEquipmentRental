using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Experimental.System.Messaging;
using Frontend.Models;
using System.IO;
using System.Text;
using Frontend.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Frontend.Helpers;
using Microsoft.Extensions.Logging;

namespace Frontend.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IMemoryCache _cache;
        public IEquipmentRepository repository;
        public EquipmentController(IEquipmentRepository equipmentRepository, IMemoryCache memoryCache)
        {
            repository = equipmentRepository;
            _cache = memoryCache;
        }
        public IActionResult Index(string returnUrl)
        {
            List<Equipment> equipments;
            if (!_cache.TryGetValue(CacheKeys.Entry, out equipments))
            {
                Parser parser = new Parser();
                equipments = parser.parseEquipments(new Reader().ReadFile("inventory.txt"));

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(3600));

                _cache.Set(CacheKeys.Entry, equipments, cacheEntryOptions);
            }
            return View(equipments);
        }
    }
}
