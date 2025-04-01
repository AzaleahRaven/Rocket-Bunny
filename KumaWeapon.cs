using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KumaWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public AudioClip shootingSound;

    public AudioSource shootingSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootLaser();
        }
    }

    public void ShootLaser()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        shootingSource.PlayOneShot(shootingSound);
    }
}
