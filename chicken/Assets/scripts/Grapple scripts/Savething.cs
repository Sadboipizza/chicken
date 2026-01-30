using System.IO;
using UnityEngine;
using Newtonsoft.Json;
    
public class Savething : MonoBehaviour
{



    private readonly JsonSerializerSettings _settings = new();
        
           public void Initialize()
        {
            _settings.Formatting = Formatting.Indented;
        }

        public void Save<T>(T objecttosave,string destination)
        {
            string json = JsonConvert.SerializeObject(objecttosave, _settings);
            File.WriteAllText(destination, json);
        }

        public T load<T>(string destination)
        {
          
           string json = File.ReadAllText(destination);
            var obj = JsonConvert.DeserializeObject<T>(json);
            return obj;


        }
    
}


