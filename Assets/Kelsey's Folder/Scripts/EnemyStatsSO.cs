using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Stats", menuName = "Scriptable Objects/Enemy/EnemyStats")]
public class EnemyStatsSO : ScriptableObject
{
    public float movementSpeed;
    public float maxHealth;
    public int atkDamage;
}
