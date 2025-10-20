
using UnityEngine;

public class Game : MonoBehaviour
{
     int health = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boolet")
        {
            health -= 1;
           
        }
        if (other.tag == "Boolet2")
        {
            health -= 1;
            
        }
        if (health <= 0)
            {
                Destroy(gameObject);
            }
    }
}
