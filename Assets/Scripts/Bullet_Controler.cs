using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controler : MonoBehaviour
{
    public GameObject bulletPrefab;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}