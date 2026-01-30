using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
   
    void Start()
    {

    }
    void Update()
    {
      
    }
public void loadLevel(int level)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(level);
    }


    
}