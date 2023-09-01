using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 20.0f;
    /*public float playerScore;
    public Text scoreText ;*/
    

    

    // Update is called once per frame
    void Update()
    {
        Movement();
        //PlayerSocre();
        //Debug.Log(playerScore);
        
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
            //playerScore++;
            Pistol_Controler.Instance.playerSocre++;
            Debug.Log(Pistol_Controler.Instance.playerSocre);
            
        }
        else if (other.CompareTag("BackGround"))
        {
            Destroy(gameObject);
        }
        
    }
   /* private void PlayerSocre()
    {
        scoreText.text = "Score:" + playerScore;
    }*/
}
