using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    
    PlayerController target = PlayerController.Player;

    private void Start()
    {

    }

    private void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, this.target.transform.position, this.movementSpeed * Time.deltaTime);
    }
}
