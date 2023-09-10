using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Monster_Controler : MonoBehaviour
{
    public GameObject[] Monster_Prefabs;//怪物预制体  bat ghost rabbit slime
    public Transform[] SwapPoint ;//生成位置
    public int MaxNumOfMonster = 10;//最大怪物数量
    public float RebotTime = 3.0f;//生成间隔
    public int DestroyTime = 5;//摧毁间隙
    public AudioClip monsterDieAudio;
    //public Animation monsterAni=null;
    //public string[] monsterAniClips;
    
    public enum MonsterType
    {
        bat,
        ghost,
        rabbit,
        slime,
        none
    }
    public MonsterType monsterType;

    //单例
    private static Monster_Controler instance;
    public static Monster_Controler Instance { get => instance; set => instance = value; }

    private GameObject Targetcounter;
    private int EnemyCounter = 0;//怪物计数器
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
            //构建AnimationClip的路径
            string clipPath = "Assets/Animation/Animation/" + clipName;
            //加载AnimationClip
            AnimationClip animationClip = Resources.Load<AnimationClip>(clipPath);

        }*/
         
        EnemyCounter = 0;
        StartCoroutine(creatEnemy());
       // InvokeRepeating("CreatEnemy", 0.5f, RebotTime);//延迟调用该方法，直至通过CancelInvoke()的方法.
        /*if (EnemyCounter == MaxNumOfMonster)
        {
            CancelInvoke();
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        /*if (EnemyCounter >= MaxNumOfMonster)
        {
            CancelInvoke();
        }*/
    }
    /*private void CreatEnemy()
    {
        *//*Transform customRebotPoint1 = new GameObject("CustomRebotPoint1").transform;
        customRebotPoint1.position = new Vector3(-3, 0.8f, -4);
        Transform customRebotPoint2 = new GameObject("CustomRebotPoint2").transform;
        customRebotPoint2.position = new Vector3(3, 0.8f, -4);
        SwapPoint = new Transform[] { customRebotPoint1, customRebotPoint2 };*//*
                                                                                * 
        if (Monster_Prefabs.Length > 0 && SwapPoint != null&&SwapPoint.Length>0)
        {
            int randomIndex_Monster = Random.Range(0, Monster_Prefabs.Length);//随机怪物
            int randomIndex_SwapPoint = Random.Range(0, SwapPoint.Length);//随机地点
            Transform Selected_SwapPoint=SwapPoint[randomIndex_SwapPoint];
            GameObject SelectedMonster=Monster_Prefabs[randomIndex_Monster];  
            Quaternion rotation = Quaternion.Euler(0, 180f, 0);//方向调整
            Vector3 originalPosition = Selected_SwapPoint.position;//存储原始位置
            
            EnemyCounter++;

            if (SelectedMonster.name == "Bat_Level_1")//当怪物为蝙蝠时 y减少
            {
                float newY = Selected_SwapPoint.transform.position.y - 0.4f;
                Selected_SwapPoint.position = new Vector3(Selected_SwapPoint.position.x, newY, Selected_SwapPoint.position.z);
            }
            GameObject swapedMonster = Instantiate(SelectedMonster, Selected_SwapPoint.position, rotation);
            Selected_SwapPoint.position = originalPosition;//恢复初始位置
            Destroy(swapedMonster,DestroyTime);//摧毁游戏对象


        }
        else
        {
            Debug.LogWarning("bug!");
        }
       
    }*/
    private IEnumerator creatEnemy()
    {
        while (EnemyCounter <= MaxNumOfMonster)
        {
            yield return new WaitForSeconds(RebotTime);
            if (Monster_Prefabs.Length > 0 && SwapPoint != null && SwapPoint.Length > 0)
            {
                int randomIndex_Monster = Random.Range(0, Monster_Prefabs.Length);//随机怪物
                int randomIndex_SwapPoint = Random.Range(0, SwapPoint.Length);//随机位置
                Transform selected_SwapPoint = SwapPoint[randomIndex_SwapPoint];//生成的位置为随机的位置
                GameObject selectedMonster = Monster_Prefabs[randomIndex_Monster];//生成选中的随机怪物
                Quaternion rotation=Quaternion.Euler(0, 180f, 0);//旋转生成的怪物的面向
                Vector3 originalPosition=selected_SwapPoint.position;//存储怪物的生成点

                EnemyCounter++;

                if (selectedMonster.name == "Bat_Level_1")//生成的怪物为蝙蝠时y轴下降0.4f点
                {
                    float newY = selected_SwapPoint.transform.position.y - 0.4f;
                    selected_SwapPoint.position=new Vector3(selected_SwapPoint.position.x, newY, selected_SwapPoint.position.z);
                }

                GameObject swapedMonster = Instantiate(selectedMonster, selected_SwapPoint.position,rotation);//实例化新的游戏对象
                selected_SwapPoint.position = originalPosition;//将原先的坐标重新赋值给selected_SwapPoint 上
                Destroy(swapedMonster, DestroyTime);//时间到了就销毁物体

            }
        }
    }
        
    public void monsterDead()
    {
        AudioSource.PlayClipAtPoint(monsterDieAudio, transform.position);
    }
   
}
