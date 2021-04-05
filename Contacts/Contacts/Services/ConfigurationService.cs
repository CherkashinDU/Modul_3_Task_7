using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Contacts
{
    public class ConfigurationService
    {
        public ContactSettings GetContactSettings()
        {
            var filePath = "Configs\\contactSettings.json";
            var content = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<ContactSettings>(content);
        }
    }
}
