using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Vector3 _aimDirection;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _damage = 1f;
    [SerializeField] private float _maxLifeTimeSeconds = 2f;
    [SerializeField] private bool _shouldDestroyAfterHittingTarget = true;
    private float _timeSinceSpawn = 0;

    private void Update()
    {
        this._timeSinceSpawn += Time.deltaTime;
        this.transform.position += this._aimDirection * this._movementSpeed * Time.deltaTime;

        if (this._timeSinceSpawn >= this._maxLifeTimeSeconds)
        {
            Destroy(gameObject);
        }
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        this._aimDirection = aimDirection;
    }

    public void LookAtShootPoint(Vector3 gunPoint, Vector3 shootPoint)
    {
        Vector3 direction = Helpers.GetDirectionTowardsPosition(gunPoint, shootPoint);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.transform.TryGetComponent(out Enemy enemy))
        {
            return;
        }

        enemy.TakeDamage(this._damage);

        if (this._shouldDestroyAfterHittingTarget)
        {
            Destroy(gameObject);
        }
    }
}
