using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private float _distanceFromPlayer = 0.75f;

    private void Update()
    {
        LookAtCursor();
        RotateAroundPlayerTowardsCursor();
    }

    private void LookAtCursor()
    {
        Vector3 direction = this.GetDirectionTowardsCursor();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void RotateAroundPlayerTowardsCursor()
    {
        Vector3 direction = this.GetDirectionTowardsCursor();
        transform.localPosition = direction * this._distanceFromPlayer;
    }

    private Vector3 GetDirectionTowardsCursor()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return (new Vector3(mousePosition.x, mousePosition.y, 0f) - transform.position).normalized;
    }
}
