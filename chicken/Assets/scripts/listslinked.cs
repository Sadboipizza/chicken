


using UnityEngine;


// used to make the spawner of enemies maybe better idk
public class listslinked : MonoBehaviour
{
   
  
    public class node
    {
        public Transform yes;
        public node after;
        public node(Transform y)
        {
            yes = y;
            after = null;
        }
    }
    public class dalist
    {
               public node head;
        public dalist()
        {
            head = null;
        }
        public void add(Transform y)
        {
            node newnode = new node(y);
            if (head == null)
            {
                head = newnode;
            }
            else
            {
                node current = head;
                while (current.after != null)
                {
                    current = current.after;
                }
                current.after = newnode;
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

    public void Spawnys(System.Action<Transform> action)
    {
        node current = new node(null);
      while (current != null)
        {
            action(current.yes);
            current = current.after;
        }
    }
}
