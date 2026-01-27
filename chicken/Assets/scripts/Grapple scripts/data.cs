using UnityEngine;

public class data : MonoBehaviour
{

    public class playerData
    {
        public int health = 1;
        public float[] position;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public playerData CapturePlayer (Player player)
    {
        playerData data = new playerData();
        data.health = player.health;
        data.position = new float[2];
        data.position[0] = player.transform.position.x;
        data.position[1] = player.transform.position.y;

        return data;
    }
}
