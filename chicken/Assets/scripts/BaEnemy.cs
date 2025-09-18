using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BaEnemy : MonoBehaviour
{

    NavMeshAgent agent;

    public int health = 5;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = GameObject.Find("Player").transform.position;

    if (health <= 0)
        {
          Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boolet")
        {
            health -= 1;
        }

        
    }

}