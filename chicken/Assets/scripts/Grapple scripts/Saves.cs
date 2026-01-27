using UnityEngine;

using System.IO;

public class Saves : MonoBehaviour
{
    public class playerData
    {
        public int health = 1;
        public float[] position;
    }
    public class SaveSystem
    {
      public void SavePlayer()
      {
          playerData data = new playerData();
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/player.fun", json);
        }
        public static playerData LoadPlayer()
        {
            string path = Application.persistentDataPath + "/player.fun";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                playerData data = JsonUtility.FromJson<playerData>(json);
                return data;
            }
            else
            {
                Debug.LogError("Save file not found in " + path);
                return null;
            }
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }
 
}
