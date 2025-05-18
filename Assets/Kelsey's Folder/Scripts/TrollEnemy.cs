using Unity.VisualScripting;
using UnityEngine;

public class TrollEnemy : Enemy
{
    private new void Start()
    {
        this.movementSpeed = this.enemyStatsSO.movementSpeed;
        this.maxHealth = this.enemyStatsSO.maxHealth;
        this.atkDamage = this.enemyStatsSO.atkDamage;

        base.Start();
    }


}
