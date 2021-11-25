using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlayer : MonoBehaviour
{

    public List<Weapon> weapons;

    private int _weaponId;

    private bool _canShoot;

    Weapon _currentWeapon;

    private void Start()
    {
        _canShoot = true;
        _weaponId = 0;
        _currentWeapon = weapons[_weaponId];
    }

    private void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (_weaponId < weapons.Count - 1)
            {
                _weaponId++;
                _currentWeapon = weapons[_weaponId];
            }
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (_weaponId > 0)
            {
                _weaponId--;
                _currentWeapon = weapons[_weaponId];
            }
        }

        if (Input.GetMouseButton(0) && _canShoot)
        {
            _currentWeapon.Shoot();
            StartCoroutine(WaitShootFireRate());
        }
    }

    IEnumerator WaitShootFireRate()
    {
        _canShoot = false;
        yield return new WaitForSeconds(_currentWeapon.fireRate);
        _canShoot = true;
    }
}
