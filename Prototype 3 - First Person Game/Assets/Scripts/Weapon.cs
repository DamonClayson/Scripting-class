using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // public GameObject bulletPrefab; <- Old code

    public ObjectPool bulletPool; // New code

    public Transform muzzle;

    public int curAmmo;

    public int maxAmmo;

    public bool infiniteAmmo;

    public float bulletSpeed;

    public float shootRate;

    private float lastShootTime;

    private bool isPlayer;

    // Set audio source and sound to play
    public AudioClip shootSFX;
    private AudioSource audioSource;



    void Awake() 
    {
        //Disable cursor
        Cursor.lockState = CursorLockMode.Locked;

        if(GetComponent<PlayerController>())
            isPlayer = true;

        audioSource = GetComponent<AudioSource>();
    }

    public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if(curAmmo > 0 || infiniteAmmo == true)
                return true;
        }

        return false;
    }

    public void Shoot()
    {
        // Cooldown
        lastShootTime = Time.time;
        curAmmo --;

        // Muzzle postion and rotation

        // GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation); (OLD CODE)
        GameObject bullet = bulletPool.GetObject();  // New Code

        bullet.transform.position = muzzle.position;
        bullet.transform.rotation = muzzle.rotation;
        
        // Added velocity to bullet
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;

        if(isPlayer)
        {
            GameUI.instance.UpdateAmmoText(curAmmo, maxAmmo);
        }

    //  Play shoot sound effect
        audioSource.PlayOneShot(shootSFX);
    }
}
