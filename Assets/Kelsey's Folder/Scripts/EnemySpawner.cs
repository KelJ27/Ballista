using Cysharp.Threading.Tasks;
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

    private async void Update()
    {

        SpawnEnemy();
        //await UniTask.WaitForSeconds(10f);
    }

    private void SpawnEnemy()
    {
        int spawnSide = Random.Range(1, 4);
        Vector3 playerPos = GetPlayerPos();


        switch (spawnSide)
        {
            case (int)SpawnSide.Up:
                float playerYPosOutsideCameraView = playerPos.y + cameraBoundsY;
                float playerRandXPosOutsideCameraView = playerPos.x + Random.Range(-cameraBoundsX, cameraBoundsX);
                Instantiate(enemyPrefab, new Vector3(playerRandXPosOutsideCameraView, playerYPosOutsideCameraView, 0), Quaternion.identity, spawner);
                break;
            case (int)SpawnSide.Down:
                playerYPosOutsideCameraView = playerPos.y - cameraBoundsY;
                playerRandXPosOutsideCameraView = playerPos.x + Random.Range(-cameraBoundsX, cameraBoundsX);
                Instantiate(enemyPrefab, new Vector3(playerRandXPosOutsideCameraView, playerYPosOutsideCameraView, 0), Quaternion.identity, spawner);
                break;
            case (int)SpawnSide.Left:
                float playerRandYPosOutsideCameraView = playerPos.y + Random.Range(-cameraBoundsY, cameraBoundsY);
                float playerXPosOutsideCameraView = playerPos.x - cameraBoundsX;
                Instantiate(enemyPrefab, new Vector3(playerXPosOutsideCameraView, playerRandYPosOutsideCameraView, 0), Quaternion.identity, spawner);
                break;
            case (int)SpawnSide.Right:
                playerRandYPosOutsideCameraView = playerPos.y + Random.Range(-cameraBoundsY, cameraBoundsY);
                playerXPosOutsideCameraView = playerPos.x + cameraBoundsX;
                Instantiate(enemyPrefab, new Vector3(playerXPosOutsideCameraView, playerRandYPosOutsideCameraView, 0), Quaternion.identity, spawner);
                break;
            default:
                break;
        }
    }

    private Vector3 GetPlayerPos()
    {
        return player.transform.position;
    }

}
