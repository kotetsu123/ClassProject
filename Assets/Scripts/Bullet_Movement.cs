using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 20.0f;

    // Update is called once per frame
    void Update()
    {
        Movement();
        
    }
    private void Movement()
    {
        transform.Translate(0, Time.deltaTime, 0);
    }
}
