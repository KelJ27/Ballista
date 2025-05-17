using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] Transform target;

    private void Start()
    {
        
    }

    private void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, this.target.position, this.movementSpeed * Time.deltaTime);
    }
}
