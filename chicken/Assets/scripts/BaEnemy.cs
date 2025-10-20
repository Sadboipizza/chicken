
using UnityEngine;
using UnityEngine.AI;


public class BaEnemy : MonoBehaviour
{

    NavMeshAgent agent;
    public bool isFallowing = false;


    public int health = 5;
    Animator anim;

    public int maxE = 10;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = GameObject.Find("Player").transform.position;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else
                if (isFallowing)
        {
            agent.isStopped = false;
            agent.destination = GameObject.Find("Player").transform.position;
            anim.SetBool("isattackuing", true);
        }
        else
        {
            agent.isStopped = true;
            anim.SetBool("isattackung", false);
        }


        


    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boolet")
        {
            health -= 10;
        }
        if(other.tag == "GameJournalist")
        {
           health = 0;
        }
        if (other.tag == "Boolet2")
        {
            health -= 50;

        }

    }

}