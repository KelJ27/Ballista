using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform spawner;
    [SerializeField] Transform enemyPrefab;
    [SerializeField] Transform player;
    int x = 0;
    int y = 0;

    private void Start()
    {
        SpawnEnemy();
    }

    private void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, new Vector3(Random.Range(-3f, 3f),Random.Range(-3f, 3f),0), Quaternion.identity, spawner);
        Instantiate(enemyPrefab, new Vector3(Random.Range(-3f, 3f),Random.Range(-3f, 3f),0), Quaternion.identity, spawner);
        Instantiate(enemyPrefab, new Vector3(Random.Range(-3f, 3f),Random.Range(-3f, 3f),0), Quaternion.identity, spawner);
        Instantiate(enemyPrefab, new Vector3(Random.Range(-3f, 3f),Random.Range(-3f, 3f),0), Quaternion.identity, spawner);

    }
}
