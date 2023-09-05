using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Monster_Controler : MonoBehaviour
{
    public GameObject[] Monster_Prefabs;//����Ԥ����  bat ghost rabbit slime
    public Transform[] SwapPoint ;//����λ��
    public int MaxNumOfMonster = 10;//����������
    public float RebotTime = 3.0f;//���ɼ��
    public int DestroyTime = 5;//�ݻټ�϶
    public Animation monsterAni=null;
    public string[] monsterAniClips;
    
    public enum MonsterType
    {
        bat,
        ghost,
        rabbit,
        slime
    }
    public MonsterType monsterType;

    //����
    private static Monster_Controler instance;
    public static Monster_Controler Instance { get => instance; set => instance = value; }

    private GameObject Targetcounter;
    private int EnemyCounter = 0;//���������
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        
    }
    void Start()
    {
       /*monsterAni = GetComponent<Animation>();
        foreach(string clipName in monsterAniClips)
        {
            //����AnimationClip��·��
            string clipPath = "Assets/Animation/Animation/" + clipName;
            //����AnimationClip
            AnimationClip animationClip = Resources.Load<AnimationClip>(clipPath);

        }*/
         
        EnemyCounter = 0;
        InvokeRepeating("CreatEnemy", 0.5f, RebotTime);
        /*if (EnemyCounter == MaxNumOfMonster)
        {
            CancelInvoke();
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyCounter >= MaxNumOfMonster)
        {
            CancelInvoke();
        }
    }
    private void CreatEnemy()
    {
        /*Transform customRebotPoint1 = new GameObject("CustomRebotPoint1").transform;
        customRebotPoint1.position = new Vector3(-3, 0.8f, -4);
        Transform customRebotPoint2 = new GameObject("CustomRebotPoint2").transform;
        customRebotPoint2.position = new Vector3(3, 0.8f, -4);
        SwapPoint = new Transform[] { customRebotPoint1, customRebotPoint2 };*/
        if (Monster_Prefabs.Length > 0 && SwapPoint != null&&SwapPoint.Length>0)
        {
            int randomIndex_Monster = Random.Range(0, Monster_Prefabs.Length);//�������
            int randomIndex_SwapPoint = Random.Range(0, SwapPoint.Length);//����ص�
            Transform Selected_SwapPoint=SwapPoint[randomIndex_SwapPoint];
            GameObject SelectedMonster=Monster_Prefabs[randomIndex_Monster];  
            Quaternion rotation = Quaternion.Euler(0, 180f, 0);//�������
            GameObject swapedMonster= Instantiate(SelectedMonster, Selected_SwapPoint.position,rotation);
            EnemyCounter++;

            if (SelectedMonster.name == "Bat_Level_1")//������Ϊ����ʱ y����
            {
                float newY = Selected_SwapPoint.transform.position.y - 0.4f;
                Selected_SwapPoint.position = new Vector3(Selected_SwapPoint.position.x, newY, Selected_SwapPoint.position.z);
            }
            Destroy(swapedMonster,DestroyTime);//�ݻ���Ϸ����


        }
        else
        {
            Debug.LogWarning("bug!");
        }
       
    }
   
}
