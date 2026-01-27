using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class spawner : MonoBehaviour
{

    public Transform[] points;
    public GameObject[] enigmaPrefabs;
    public bool spawnEnemy = true;
    public int waveNumber = 1;
    TextMeshProUGUI score;
    public GameObject health;
    public GameObject refil;
    
    public listslinked.dalist enemiesList = new listslinked.dalist();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject enemy in enigmaPrefabs)
        {
            enemiesList.add(enemy.transform);
        }

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
            listslinked.node current = enemiesList.head;
            while (current != null)
            {
                Transform enemyTransform = current.yes;
                int randomPointIndex = Random.Range(0, points.Length);
                Transform spawnPoint = points[randomPointIndex];
                Instantiate(enemyTransform.gameObject, spawnPoint.position, spawnPoint.rotation);
                current = current.after;
            }

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