using UnityEngine;
using Newtonsoft.Json;

public class Data : MonoBehaviour
{
    [JsonProperty]
    public int levelindex { get; set; }

    public float posx { get; set; }
    public float posy { get; set; }
    

}
