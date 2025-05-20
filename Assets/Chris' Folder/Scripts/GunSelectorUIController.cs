using UnityEngine;

public class GunSelectorUIController : MonoBehaviour
{
    [SerializeField] private GameObject[] _weaponBorders;

    private void Awake()
    {
        GunSelectorController.OnGunSelected += this.OnGunSelected;
    }

    private void OnDestroy()
    {
        GunSelectorController.OnGunSelected -= this.OnGunSelected;
    }

    private void HideAllWeaponBorders()
    {
        foreach (GameObject weaponBorder in this._weaponBorders)
        {
            weaponBorder.SetActive(false);
        }
    }

    private void ShowWeaponBorder(int index)
    {
        if (index > this._weaponBorders.Length - 1)
        {
            Debug.LogWarning("UI not added for this weapon!");
            return;
        }

        this.HideAllWeaponBorders();
        this._weaponBorders[index].SetActive(true);
    }

    private void OnGunSelected(int gunIndex)
    {
        this.HideAllWeaponBorders();
        this.ShowWeaponBorder(gunIndex);
    }
}
