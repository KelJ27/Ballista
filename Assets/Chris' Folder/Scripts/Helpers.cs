using UnityEngine;

public static class Helpers
{
    public static Vector3 GetDirectionTowardsCursor(Vector3 position)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return (new Vector3(mousePosition.x, mousePosition.y, 0f) - position).normalized;
    }

    public static Vector3 GetDirectionTowardsPosition(Vector3 position1, Vector3 position2)
    {
        return (new Vector3(position2.x, position2.y, 0f) - position1).normalized;
    }
}
