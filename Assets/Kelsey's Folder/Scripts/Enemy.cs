using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyStatsSO enemyStatsSO;
    [SerializeField] private Image healthBar;
    protected float movementSpeed;
    protected float maxHealth;
    protected int atkDamage;

    private SpriteRenderer sr;

    private float currentHealth;

    protected void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (!GameUIController.IsGameActive)
        {
            return;
        }

        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, PlayerController.Player.transform.position, this.movementSpeed * Time.deltaTime);
    }

    private async Task FlashDamageColor()
    {
        this.sr.color = Color.red;
        await UniTask.WaitForSeconds(0.05f);
        this.sr.color = Color.white;

    }

    private void DecreaseHealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    public async void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        await FlashDamageColor();
        DecreaseHealthBar();
        
        if (this.currentHealth <= 0)
        {
            Destroy(gameObject);
            Globals.enemyKills++;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.transform.TryGetComponent(out PlayerController player))
        {
            return;
        }

        target.TakeDamage(this.atkDamage);
    }


}
