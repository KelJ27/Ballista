using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Player;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _health = 100f;

    public Action<float> OnHealthChange;
    public static Action OnPlayerDies;

    private void Awake()
    {
        PlayerController.Player = this;
    }

    private void Start()
    {
        this._health = this._maxHealth;
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

    public void TakeDamage(float damage)
    {
        this._health -= damage;
        this.OnHealthChange?.Invoke(this._health);

        if (this._health <= 0f)
        {
            PlayerController.OnPlayerDies?.Invoke();
            Destroy(gameObject);
        }
    }
}
