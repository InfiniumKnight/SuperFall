using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

public float bulletSpeed;
public float fireRate;
public Transform bulletSpawnTransform;
    public GameObject bulletPrefab;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

if (timer > 0)
{
    timer -= Time.deltaTime / fireRate;
}

        if (Input.GetMouseButton(0) && timer <= 0) {

            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bulletObject = Instantiate(bulletPrefab, bulletSpawnTransform.position, bulletSpawnTransform.rotation);
        bulletObject.GetComponent<Rigidbody>().AddForce(bulletSpawnTransform.forward * bulletSpeed, ForceMode.Impulse);

        timer = 1;
    }
}
