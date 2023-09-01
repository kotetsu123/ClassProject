using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controler : MonoBehaviour
{
    public GameObject bulletPrefab;

    private float timeVal=3;//¼ÆÊ±Æ÷
    

    private void Update()
    {
        if (timeVal >= 4)
        {
            Shoot();
        }
        else
        {
            timeVal += Time.deltaTime;
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            //timeVal = 0;
        }
    }
}
