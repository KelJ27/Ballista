using System;
using System.Linq;
using UnityEngine;

public class GunSelectorController : MonoBehaviour
{
    [SerializeField] private GunController[] _guns = Array.Empty<GunController>();
    private int[] _keyboardNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    private int _currentGunIndex = 0;

    public static Action<int> OnGunSelected;

    void Start()
    {
        this.SelectGun(this._currentGunIndex);
    }

    void Update()
    {
        CheckSwapWeaponUserInputs();
    }

    private void CheckSwapWeaponUserInputs()
    {
        foreach (int keyboardNum in this._keyboardNumbers)
        {
            if (Input.GetKeyDown(keyboardNum.ToAlphaKeyCode()) || Input.GetKeyDown(keyboardNum.ToKeypadKeyCode()))
            {
                this.SelectGun(keyboardNum - 1);
            }
        }
    }

    private void SelectGun(int gunIndex)
    {
        if (gunIndex > this._guns.Count() - 1)
        {
            return;
        }

        this.HideAllGuns();
        this._guns[gunIndex].gameObject.SetActive(true);
        this._currentGunIndex = gunIndex;
        GunSelectorController.OnGunSelected?.Invoke(gunIndex);
    }

    private void HideAllGuns()
    {
        foreach (GunController gun in this._guns)
        {
            gun.gameObject.SetActive(false);
        }
    }
}
