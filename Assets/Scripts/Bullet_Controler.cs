using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controler : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Pistol_Controler pistolcontroler;
    public  float bulletValue = 6;




    private float timeVal=3;//¼ÆÊ±Æ÷
   
    private static Bullet_Controler instance;
    public static Bullet_Controler Instance { get => instance; set => instance = value; }


    /*private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }*/
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
       
    }
    private void Update()
    {
        if (timeVal >=1.35f)
        {
            Shoot();
        }
        else
        {
            timeVal += Time.deltaTime;
        }
        Reload();
        UpdateAmmoText();
        UpdateScoreText();
    }

    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)&&bulletValue>0)
        {
            //animator.SetTrigger("Fire");
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            Pistol_Controler.Instance.pistolAni.Play("Grip|Fire");
            Pistol_Controler.Instance.PlayFireAudio();
            timeVal = 0;
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
        AmmoUi ammoui = FindObjectOfType<AmmoUi>();
        
        if (ammoui != null)
        {
            ammoui.ammoText.text = "Ammo:" + bulletValue.ToString();
            
        }
        if (bulletValue == 0)
        {
            ammoui.ammoText.text = "You Need Reload!!";
        }
       
    }
    private void UpdateScoreText()
    {
        scoreUI scoreUi=FindObjectOfType<scoreUI>();
       
        if (scoreUi != null)
        {
            scoreUi.scoreText.text = "Score:" + Pistol_Controler.Instance.playerSocre.ToString();
        }
        else
        {
            Debug.Log("Error!");
        }
    }
    
}
