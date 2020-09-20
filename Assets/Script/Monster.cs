using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Monster : MonoBehaviour
{
    public Vector2 vector2Next;
    public Vector2 vector2This;
    public  int ThisType;
    public int MoveVec;
    float MoveRange;
    public bool Move { get; private set; }


    GameObject ThisPlayer;

    float TypeTime;
    float TypeTime1;

    public bool Die;

    bool Hit;
    // Start is called before the first frame update
    void Start()
    {
        Hit = false;
        ThisType = 1;
        ThisPlayer = GameObject.FindGameObjectWithTag("Player");
        vector2This = new Vector2(14, 15);
        vector2Next = new Vector2(14, 15);
        MoveVec = Random.Range(1, 5);
        this.transform.position = new Vector3(-14 * 0.57f * 0.6f + vector2This.y * 0.57f * 0.6f, 17 * 0.57f * 0.6f - vector2This.x * 0.57f * 0.6f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (ThisType == 1)//鬼移动
        {
            MoveRange += Time.deltaTime;
            if (MoveVec==1&& !Move)
            {
                int temp = LevelGenerator.LevelMap4[(int)vector2This.x, (int)vector2This.y - 1];
                if (temp == 5 || temp == 6 || temp == 0 || temp == 8)
                {
                    vector2Next = new Vector2((int)vector2This.x, (int)vector2This.y - 1);
                    Move = true;
                    this.transform.localEulerAngles = new Vector3(0, 0, -270);
                }
                else
                {
                    int temp1 = MoveVec;
                    while (MoveVec == temp1)
                    {
                        MoveVec = Random.Range(1, 5);
                    }

                }

               
            }
            if (MoveVec == 2 && !Move)
            {
                int temp = LevelGenerator.LevelMap4[(int)vector2This.x, (int)vector2This.y + 1];
                if (temp == 5 || temp == 6 || temp == 0 || temp == 8)
                {
                    vector2Next = new Vector2((int)vector2This.x, (int)vector2This.y + 1);
                    Move = true;
                    this.transform.localEulerAngles = new Vector3(0, 0, -90);
                }
                else
                {
                    int temp1 = MoveVec;
                    while (MoveVec == temp1)
                    {
                        MoveVec = Random.Range(1, 5);
                    }

                }

            }
            if (MoveVec ==3 && !Move)
            {
                int temp = LevelGenerator.LevelMap4[(int)vector2This.x - 1, (int)vector2This.y];
                if (temp == 5 || temp == 6 || temp == 0 || temp == 8)
                {
                    vector2Next = new Vector2((int)vector2This.x - 1, (int)vector2This.y);
                    Move = true;
                    this.transform.localEulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    int temp1 = MoveVec;
                    while (MoveVec == temp1)
                    {
                        MoveVec = Random.Range(1, 5);
                    }

                }

            }
            if (MoveVec == 4 && !Move)
            {
                int temp = LevelGenerator.LevelMap4[(int)vector2This.x + 1, (int)vector2This.y];
                if (temp == 5 || temp == 6 || temp == 0 || temp == 8)
                {
                    vector2Next = new Vector2((int)vector2This.x + 1, (int)vector2This.y);
                    Move = true;
                    this.transform.localEulerAngles = new Vector3(0, 0, -180);
                }
                else
                {
                    int temp1 = MoveVec;
                    while (MoveVec == temp1)
                    {
                        MoveVec = Random.Range(1, 5);
                    }

                }

            }
            Vector3 vector3temp = new Vector3(-14 * 0.57f * 0.6f + vector2Next.y * 0.57f * 0.6f, 17 * 0.57f * 0.6f - vector2Next.x * 0.57f * 0.6f, 0);
            this.transform.position = Vector2.Lerp(this.transform.position, vector3temp, Time.deltaTime * 3);
            if (Vector2.Distance(this.transform.position, vector3temp) <= 0.05f)
            {

                vector2This = vector2Next;
                Move = false;
                if (MoveRange >= 5)
                {
                    MoveRange = 0;
                    MoveVec = Random.Range(1, 5);
                }

            }
        }
        if (PlayerMove.GameType == 1)//鬼恐惧
        {
            this.GetComponent<Animator>().SetInteger("State", 1);
            ThisType = 2;
        }
        if (ThisType == 2)//鬼恐惧计时
        {
            TypeTime += Time.deltaTime;
            if (TypeTime >= 4)
            {
                this.GetComponent<Animator>().SetInteger("State", 0);
                TypeTime = 0;
                ThisType = 1;
                PlayerMove.GameType =0;
            }
        }
        if (ThisType ==4)//鬼死亡
        {
          
            Die = true;
            TypeTime1 += Time.deltaTime;
            if (TypeTime1 >= 4)
            {
                this.GetComponent<Animator>().SetInteger("State", 0);
                TypeTime1 = 0;
                ThisType = 1;
                vector2This = new Vector2(14, 15);
                vector2Next = new Vector2(14, 15);
                this.transform.position = new Vector3(-14 * 0.57f * 0.6f + vector2This.y * 0.57f * 0.6f, 17 * 0.57f * 0.6f - vector2This.x * 0.57f * 0.6f, 0);
                Die = false;
            }
        }
        if (Vector2.Distance(this.transform.position, ThisPlayer.transform.position) <= 0.2f)//鬼碰撞判断
        {
            if (ThisType == 1&&!Hit)
            {
                Time.timeScale = 0;
                PlayerMove.GameType = 0;
                PlayerMove.HP -= 1;
                if (PlayerMove.HP <= 0)
                {
                    PlayerMove.HP = 3;
                 
                }
                SceneManager.LoadScene(0);
                Hit = true;

            }
            if (ThisType ==2)
            {
                this.GetComponent<Animator>().SetInteger("State", 2);
                ThisType = 4;
            }


        }

    }
   
}
