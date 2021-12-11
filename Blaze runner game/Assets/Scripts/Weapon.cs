using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform muzzle;

    public GameObject bulletPrefab;

    // Update is called once per frame
    // Shooting input (Fire1 is set to space)
    void Update()
    {
                if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    // Create bullet prefab at muzzle position
    void Shoot()
    {
        Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
    }
}
