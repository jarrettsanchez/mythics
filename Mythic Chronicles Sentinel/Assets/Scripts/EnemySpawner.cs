using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private int [] enemyOrder;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 5;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 10f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private int currentEnemyIndex = 0;
    private int currentWave = 1;
    private int enemiesAlive;
    private int enemiesSlain;
    private int enemiesLeftToSpawn;
    private float timeSinceLastSpawn;
    private bool isSpawning = false;

    public ProgressBar progressBar;

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
        StartCoroutine(StartWave());
        progressBar.SetMaxHealth(13);
        progressBar.SetHealth(0);
    }

    private void Update()
    {
        if (!isSpawning)
        {
            return;
        }

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }

        // after 2 waves, load into next stage
        if (enemiesSlain == 13)
        {
            PlayerPrefs.SetInt("Stage", 2);
            SceneManager.LoadScene("Stage Title");
        }
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
        enemiesSlain++;
        progressBar.SetHealth(enemiesSlain);
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWave());
    }

    private void SpawnEnemy()
    {
        int prefabIndex = enemyOrder[currentEnemyIndex];
        if (prefabIndex >= 0 && prefabIndex < enemyPrefabs.Length && enemyOrder.Length == baseEnemies)
        {
            GameObject prefabToSpawn = enemyPrefabs[prefabIndex];
            Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
        }
        currentEnemyIndex = (currentEnemyIndex + 1) % enemyOrder.Length;
    }


    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }
}
