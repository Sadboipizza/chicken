using Unity.Hierarchy;
using UnityEngine;

public class reappear : MonoBehaviour
{

    public GameObject[] respawn;
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
        if (other.tag == "health")
        {

        }
        if (other.tag == "AmmoPack")
        {

        }
    }
}
