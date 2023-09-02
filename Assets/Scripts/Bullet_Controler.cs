using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controler : MonoBehaviour
{
    public GameObject bulletPrefab;


    private float timeVal=3;//¼ÆÊ±Æ÷
    private float bulletValue = 6;
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
        Reload();
        UpdateAmmoText();
    }

    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)&&bulletValue>0)
        {
            //animator.SetTrigger("Fire");
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            Pistol_Controler.Instance.pistolAni.Play("Grip|Fire");
            //timeVal = 0;
            bulletValue--;
        }
         
    }
    private void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            bulletValue = 6;
            Pistol_Controler.Instance.pistolAni.Play("Grip|Reload");
        }
    }
    private void UpdateAmmoText()
    {
        AmmoUi ammoui=FindObjectOfType<AmmoUi>();
        if (ammoui != null)
        {
            ammoui.ammoText.text = "Ammo:" + bulletValue.ToString();
        }
        if (bulletValue == 0)
        {
            ammoui.ammoText.text = "You Need Reload!!";
        }
       
    }
}
