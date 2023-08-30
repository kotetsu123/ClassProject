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
        Vector3 mousePosition = Input.mousePosition;//��ȡ��������
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z - Camera.main.transform.position.z));//�����λ�ô���Ļ����ת��Ϊ��������
        //��������ָ�����λ�õ�ָ��
        Vector3 lookDirection = mousePosition - transform.position;
        float angle=Mathf.Atan2(lookDirection.y,lookDirection.x)*Mathf.Rad2Deg;
        //Ӧ�ó���Ƕ�
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
