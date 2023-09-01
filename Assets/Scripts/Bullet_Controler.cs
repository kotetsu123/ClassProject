using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controler : MonoBehaviour
{
    public GameObject bulletPrefab;


    private float timeVal=3;//¼ÆÊ±Æ÷
    /*private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }*/


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

    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //animator.SetTrigger("Fire");
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            Pistol_Controler.Instance.pistolAni.Play("Grip|Fire");
            //timeVal = 0;
        }
    }
}
