using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol_Controler : MonoBehaviour
{
    public Camera customCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pistolMovement();
        //pistolRayMovement();
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
    private void pistolRayMovement()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            Vector3 targetPosition = hit.point;
            transform.LookAt(targetPosition);
        }
        
    }
}
