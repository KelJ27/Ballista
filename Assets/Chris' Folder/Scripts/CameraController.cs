using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;

    void Update()
    {
        transform.position = new Vector3(this._player.position.x, this._player.position.y, -10f);
    }
}
