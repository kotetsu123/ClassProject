using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 20.0f;
    public float playerScore;
    

    

    // Update is called once per frame
    void Update()
    {
        Movement();
        
    }
    private void Movement()
    {
        transform.Translate(transform.up*moveSpeed* Time.deltaTime,Space.World);
        
    }
    /*private void OnColliderEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Monster":
                {
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                }break;
            case "BackGround":
                {
                    Destroy(gameObject);
                }break;
            default:
                break;

        }
        
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            playerScore++;
            Debug.Log(playerScore);
        }
        else if (other.CompareTag("BackGround"))
        {
            Destroy(gameObject);
        }
        
    }
}
