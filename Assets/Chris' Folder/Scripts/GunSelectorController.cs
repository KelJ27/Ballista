using System;
using System.Linq;
using UnityEngine;

public class GunSelectorController : MonoBehaviour
{
    [SerializeField] private GunController[] _guns = Array.Empty<GunController>();
    private int _currentGunIndex = 0;

    void Start()
    {
        this.SelectGun(this._currentGunIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.SelectGun(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.SelectGun(1);
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
    }

    private void HideAllGuns()
    {
        foreach (GunController gun in this._guns)
        {
            gun.gameObject.SetActive(false);
        }
    }
}
