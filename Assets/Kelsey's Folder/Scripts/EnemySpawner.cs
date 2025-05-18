using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private enum SpawnSide
    {
        Up = 1,
        Down = 2,
        Left = 3,
        Right = 4
    }

    [SerializeField] Transform spawner;
    [SerializeField] Transform enemyPrefab;
    private const float cameraBoundsX = 10f;
    private const float cameraBoundsY = 6f;

    private float spawnTimeMs = 100f;
    private float timeSinceLastSpawn = 0f;

    private List<Transform> spawnedEnemies = new List<Transform>();

    private void Awake()
    {
        PlayerController.OnPlayerDies += this.DestroyAllSpawnedEnemies;
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (!GameUIController.IsGameActive)
        {
            return;
        }

        timeSinceLastSpawn += Time.deltaTime * 1000;
        Debug.Log(timeSinceLastSpawn);
        if (timeSinceLastSpawn >= spawnTimeMs)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0;
        }
    }

    private void SpawnEnemy()
    {
        int spawnSide = Random.Range(1, 5);
        Vector3 playerPos = GetPlayerPos();

        switch (spawnSide)
        {
            case (int)SpawnSide.Up:
                float playerYPosOutsideCameraView = playerPos.y + cameraBoundsY;
                float playerRandXPosOutsideCameraView = playerPos.x + Random.Range(-cameraBoundsX, cameraBoundsX);
                spawnedEnemies.Add(Instantiate(enemyPrefab, new Vector3(playerRandXPosOutsideCameraView, playerYPosOutsideCameraView, 0), Quaternion.identity, spawner));
                break;
            case (int)SpawnSide.Down:
                playerYPosOutsideCameraView = playerPos.y - cameraBoundsY;
                playerRandXPosOutsideCameraView = playerPos.x + Random.Range(-cameraBoundsX, cameraBoundsX);
                spawnedEnemies.Add(Instantiate(enemyPrefab, new Vector3(playerRandXPosOutsideCameraView, playerYPosOutsideCameraView, 0), Quaternion.identity, spawner));
                break;
            case (int)SpawnSide.Left:
                float playerRandYPosOutsideCameraView = playerPos.y + Random.Range(-cameraBoundsY, cameraBoundsY);
                float playerXPosOutsideCameraView = playerPos.x - cameraBoundsX;
                spawnedEnemies.Add(Instantiate(enemyPrefab, new Vector3(playerXPosOutsideCameraView, playerRandYPosOutsideCameraView, 0), Quaternion.identity, spawner));
                break;
            case (int)SpawnSide.Right:
                playerRandYPosOutsideCameraView = playerPos.y + Random.Range(-cameraBoundsY, cameraBoundsY);
                playerXPosOutsideCameraView = playerPos.x + cameraBoundsX;
                spawnedEnemies.Add(Instantiate(enemyPrefab, new Vector3(playerXPosOutsideCameraView, playerRandYPosOutsideCameraView, 0), Quaternion.identity, spawner));
                break;
            default:
                break;
        }
    }

    private Vector3 GetPlayerPos()
    {
        return PlayerController.Player.transform.position;
    }

    private void DestroyAllSpawnedEnemies()
    {
        foreach (var enemy in spawnedEnemies)
        {
            if (enemy == null)
            {
                continue;
            }

            Destroy(enemy.gameObject);
        }
        spawnedEnemies.Clear();
    }
}
