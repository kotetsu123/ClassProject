using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol_Controler : MonoBehaviour
{
    public Camera customCamera;
    public float rotationSpeed = 2.0f;
    public float moveSpeed = 5.0f;
    public Transform target;
    public float playerSocre = 0;
    public Animation pistolAni;
    public AudioClip pistolAudio;


    //单例
    private static Pistol_Controler instance;
    public static Pistol_Controler Instance { get => instance; set => instance = value; }

    private Bullet_Controler bulletcontrol;
    

    private void Awake()
    {
        Instance = this;
        pistolAni = GetComponent<Animation>();
        bulletcontrol = GetComponent<Bullet_Controler>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //pistolMovement();
        PistolRayMovement();
        /*if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            pistolAni.Play("Grip|Fire");
            bulletcontrol.Shoot();
        }*/
    }
    private void pistolMovement()
    {
        Vector3 mousePosition = Input.mousePosition;//获取鼠标的坐标
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z - Camera.main.transform.position.z));//把鼠标位置从屏幕坐标转换为世界坐标
        //计算物体指向鼠标位置的指向
        Vector3 lookDirection = mousePosition - transform.position;
        float angle=Mathf.Atan2(lookDirection.y,lookDirection.x)*Mathf.Rad2Deg;
        //应用朝向角度
        transform.rotation = Quaternion.Euler(0,angle ,0);

    }
    private void PistolRayMovement()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        if (Physics.Raycast(ray, out hit))//需要碰撞体！也就是说只有面对怪物的时候武器才会转动。
        {
            Vector3 targetDirection = hit.point - target.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
    public void PlayFireAudio()
    {
        AudioSource.PlayClipAtPoint(pistolAudio, transform.position);
    }
}
