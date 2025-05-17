using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Vector3 _aimDirection;
    [SerializeField] private float _movementSpeed;

    private void Start()
    {
        this.LookAtCursor();
    }

    private void Update()
    {
        this.transform.position += this._aimDirection * this._movementSpeed * Time.deltaTime;
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        this._aimDirection = aimDirection;
    }

    private void LookAtCursor()
    {
        Vector3 direction = Helpers.GetDirectionTowardsCursor(transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }
}
