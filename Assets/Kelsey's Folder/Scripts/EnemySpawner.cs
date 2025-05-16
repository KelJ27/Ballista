using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform enemyPrefab;
    int x = 0;
    int y = 0;

    void Start()
    {
        Instantiate(enemyPrefab, new Vector3(0,1,0), Quaternion.identity);
        Instantiate(enemyPrefab, new Vector3(0,2,0), Quaternion.identity);
        Instantiate(enemyPrefab, new Vector3(0,3,0), Quaternion.identity);
        Instantiate(enemyPrefab, new Vector3(0,4,0), Quaternion.identity);
        Instantiate(enemyPrefab, new Vector3(0,5,0), Quaternion.identity);
        
    }

    void Update()
    {
        
    }
}
