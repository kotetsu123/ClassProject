using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Controler : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("PlayAnimation", 3, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
