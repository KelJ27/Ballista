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
    [SerializeField] Transform player;
    private const float cameraBoundsX = 10f;
    private const float cameraBoundsY = 6f;

    private void Start()
    {
        SpawnEnemy();
    }

    private void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        int spawnSide = Random.Range(1, 4);
        switch (spawnSide)
        {
            case (int)SpawnSide.Up:
                Instantiate(enemyPrefab, new Vector3(Random.Range(-15f, 15f), cameraBoundsY, 0), Quaternion.identity, spawner);
                break;
            case (int)SpawnSide.Down:
                Instantiate(enemyPrefab, new Vector3(Random.Range(-15f, 15f), -cameraBoundsY, 0), Quaternion.identity, spawner);
                break;
            case (int)SpawnSide.Left:
                Instantiate(enemyPrefab, new Vector3(-cameraBoundsX, Random.Range(-15f, 15f), 0), Quaternion.identity, spawner);
                break;
            case (int)SpawnSide.Right:
                Instantiate(enemyPrefab, new Vector3(cameraBoundsX, Random.Range(-15f, 15f), 0), Quaternion.identity, spawner);
                break;
            default:
                break;
        }
    }

}
