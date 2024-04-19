using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject EnemySpawner;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void StartGame()
    {
        EnemySpawner.SetActive(true);
        var _spawnBehaviour = EnemySpawner.GetComponent<EnemySpawnerBehaviour>();
        StartCoroutine(_spawnBehaviour.SpawnEnemy(10));
    }

    public void EndGame()
    {
        EnemySpawner.SetActive(false);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
