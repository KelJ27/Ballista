using UnityEngine;

public class CameraController : MonoBehaviour
{
    void Update()
    {
        if (!GameUIController.IsGameActive)
        {
            return;
        }

        transform.position = new Vector3(PlayerController.Player.transform.position.x, PlayerController.Player.transform.position.y, -10f);
    }
}
