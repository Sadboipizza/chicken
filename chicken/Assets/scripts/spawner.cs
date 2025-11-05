using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class spawner : MonoBehaviour
{

    private float spawnRangeX = 0;
    private float spawnPosZ = 44.46f;
    public GameObject[] enigmaPrefabs;
    public bool spawnEnemy = true;
    public int waveNumber = 1;
    TextMeshProUGUI score;
    public GameObject health;
    public GameObject refil;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        if (SceneManager.GetActiveScene().buildIndex >= 1)
        {
            score = GameObject.FindGameObjectWithTag("UI_Score").GetComponent<TextMeshProUGUI>();
        }

            
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && GameObject.FindGameObjectsWithTag("Enemy2").Length == 0)
        {
            waveNumber+=1;
            SpawnEnemyWave(waveNumber);
            score.text = "Score: " + waveNumber ;
        }

        SpawnHealthRefil();

    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            int randomIndex = Random.Range(0, enigmaPrefabs.Length);
            Instantiate(enigmaPrefabs[randomIndex], spawnPos, enigmaPrefabs[randomIndex].transform.rotation);
        }

    }

    void SpawnHealthRefil()
    {
        if (waveNumber == 10)
        {
            health.SetActive(true);
            refil.SetActive(true);
        }
        if (waveNumber == 20)
        {
            health.SetActive(true);
            refil.SetActive(true);
        }
        if (waveNumber == 30)
        {
            health.SetActive(true);
            refil.SetActive(true);
        }
        if (waveNumber == 40)
        {
            health.SetActive(true);
            refil.SetActive(true);
        }
        if (waveNumber == 50)
        {
            health.SetActive(true);
            refil.SetActive(true);
        }
        if (waveNumber == 60)
        {
            health.SetActive(true);
            refil.SetActive(true);
        }
        if (waveNumber == 70)
        {
            health.SetActive(true);
            refil.SetActive(true);
        }
        if (waveNumber == 80)
        {
            health.SetActive(true);
            refil.SetActive(true);
        }
        if (waveNumber == 90)
        {
            health.SetActive(true);
            refil.SetActive(true);
        }
        if (waveNumber == 100)
        {
            health.SetActive(true);
            refil.SetActive(true);
        }

    }

}