using Frontend.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Frontend.Helpers
{
    public static class SessionExtensions
    {
        public static void Set(this ISession session, string key, Cart cart)
        {
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new LowercaseContractResolver();
            string json = JsonConvert.SerializeObject(cart, Formatting.Indented, settings);
            session.SetString(key, json);
        }

        public static Cart Get(this ISession session, string key)
        {
            var value = session.GetString(key);
            if (value != null)
            {
                Cart cart = JsonConvert.DeserializeObject<Cart>(value);
                return cart;
            }
            return default;
        }

        public static String GetRawJSON(this ISession session, string key)
        {
            return session.GetString(key);
        }
    }
}
