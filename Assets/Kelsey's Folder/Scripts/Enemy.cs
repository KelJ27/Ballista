using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private float maxHealth = 10;
    [SerializeField] private int atk = 2;

    [SerializeField] private Image healthBar;
    private SpriteRenderer sr;

    private PlayerController target = PlayerController.Player;
    private float currentHealth;

    private void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, this.target.transform.position, this.movementSpeed * Time.deltaTime);
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

    public void DamagePlayer()
    {

    }


}
