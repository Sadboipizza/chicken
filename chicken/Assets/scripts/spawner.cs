using UnityEngine;

public class spawner : MonoBehaviour
{

    private float spawnRangeX = 0;
    private float spawnPosZ = 44.46f;
    public GameObject[] enigmaPrefabs;
    public bool spawnEnemy = true;
    public int spawnLimit;
    public int spawnEnime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnEnemy == true)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            int randomIndex = Random.Range(0, enigmaPrefabs.Length);
            Instantiate(enigmaPrefabs[randomIndex], spawnPos, enigmaPrefabs[randomIndex].transform.rotation);

            spawnEnime++;
        }
        
        if(spawnLimit == spawnEnime)
        {
            spawnEnemy = false;
          
        }
       
        if (spawnEnime == 0)
        {
            spawnEnemy = true;
        }
    }
    void SpawnEemy()
    {
      
    }
}
