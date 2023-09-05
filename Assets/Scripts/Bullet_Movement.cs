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
            MonsterType monsterType = other.GetComponent<MonsterType>();
            if (monsterType != null)
            {
                Animation monsterAni = other.gameObject.GetComponent<Animation>();
                if (monsterAni != null)
                {
                    switch (monsterType.monstertype)//Monster_Controler.Instance.monsterType)
                    {

                        case Monster_Controler.MonsterType.bat:
                            // Monster_Controler.Instance.monsterAni = Monster_Controler.Instance.Monster_Prefabs[0].GetComponent<Animation>();
                            monsterAni.Play("bat_die");
                            // Monster_Controler.Instance.monsterAni.Play("bat_die");
                            //   Monster_Controler.Instance.monsterAni = null;
                            Debug.Log(Monster_Controler.Instance.monsterType);
                            break;
                        case Monster_Controler.MonsterType.ghost:
                            //Monster_Controler.Instance.monsterAni.Play("ghost_die");
                            monsterAni.Play("ghost_die");
                            Debug.Log(Monster_Controler.Instance.monsterType);
                            break;
                        case Monster_Controler.MonsterType.rabbit:
                            //Monster_Controler.Instance.monsterAni.Play("rabbit_die");
                            monsterAni.Play("rabbit_die");
                            Debug.Log(Monster_Controler.Instance.monsterType);
                            break;
                        case Monster_Controler.MonsterType.slime:
                            // Monster_Controler.Instance.monsterAni.Play("slime_die");
                            monsterAni.Play("slime_die");
                            Debug.Log(Monster_Controler.Instance.monsterType);
                            break;

                    }
                }
                
               
            }
           
            Destroy(gameObject);
            
            Destroy(other.gameObject,1.0f);
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
