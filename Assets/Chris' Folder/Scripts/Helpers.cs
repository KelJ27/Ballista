using UnityEngine;

public static class Helpers
{
    public static Vector3 GetDirectionTowardsCursor(Vector3 position)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return (new Vector3(mousePosition.x, mousePosition.y, 0f) - position).normalized;
    }
}
