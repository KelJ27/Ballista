using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private float _distanceFromPlayer = 0.75f;
    [SerializeField] private Transform _bulletPrefab;
    [SerializeField] private Transform _shootPoint;

    private void Update()
    {
        LookAtCursor();
        RotateAroundPlayerTowardsCursor();

        if (Input.GetMouseButton(0))
        {
            this.Shoot();
        }
    }

    private void Shoot()
    {
        BulletController bullet = Instantiate(this._bulletPrefab, this._shootPoint.position, Quaternion.identity).GetComponent<BulletController>();
        bullet.SetAimDirection(Helpers.GetDirectionTowardsCursor(transform.position));
    }

    private void LookAtCursor()
    {
        Vector3 direction = Helpers.GetDirectionTowardsCursor(transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void RotateAroundPlayerTowardsCursor()
    {
        Vector3 direction = Helpers.GetDirectionTowardsCursor(transform.position);
        transform.localPosition = direction * this._distanceFromPlayer;
    }
}
