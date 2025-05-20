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

    public static KeyCode ToAlphaKeyCode(this int number)
    {
        switch (number)
        {
            case 0: return KeyCode.Alpha0;
            case 1: return KeyCode.Alpha1;
            case 2: return KeyCode.Alpha2;
            case 3: return KeyCode.Alpha3;
            case 4: return KeyCode.Alpha4;
            case 5: return KeyCode.Alpha5;
            case 6: return KeyCode.Alpha6;
            case 7: return KeyCode.Alpha7;
            case 8: return KeyCode.Alpha8;
            case 9: return KeyCode.Alpha9;
            default: return KeyCode.None;
        }
    }

    public static KeyCode ToKeypadKeyCode(this int number)
    {
        switch (number)
        {
            case 0: return KeyCode.Keypad0;
            case 1: return KeyCode.Keypad1;
            case 2: return KeyCode.Keypad2;
            case 3: return KeyCode.Keypad3;
            case 4: return KeyCode.Keypad4;
            case 5: return KeyCode.Keypad5;
            case 6: return KeyCode.Keypad6;
            case 7: return KeyCode.Keypad7;
            case 8: return KeyCode.Keypad8;
            case 9: return KeyCode.Keypad9;
            default: return KeyCode.None;
        }
    }
}
