using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
    public float bulletSpeed;
    public float fireRate;
    public Transform bulletSpawnTransform;
    public GameObject bulletPrefab;
    
    // Assign an AudioSource component (with your shooting audio clip) in the Inspector.
    public AudioSource shootAudio; 
    
    private float timer;

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime / fireRate;
        }

        if (Input.GetMouseButton(0) && timer <= 0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        
        // Play the shooting audio if assigned.
        if (shootAudio != null)
        {
            shootAudio.Play();
        }
        
        GameObject bulletObject = Instantiate(bulletPrefab, bulletSpawnTransform.position, bulletSpawnTransform.rotation);
        bulletObject.GetComponent<Rigidbody>().AddForce(bulletSpawnTransform.forward * bulletSpeed, ForceMode.Impulse);

        timer = 1;
    }
}
