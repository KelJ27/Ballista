using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Player;
    [SerializeField] float movementSpeed = 5f;

    private void Awake()
    {
        PlayerController.Player = this;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Time.deltaTime * new Vector3(0f, movementSpeed, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Time.deltaTime * new Vector3(movementSpeed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Time.deltaTime * new Vector3(0f, -movementSpeed, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Time.deltaTime * new Vector3(-movementSpeed, 0f, 0f);
        }
    }
}
