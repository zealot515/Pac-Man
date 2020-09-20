using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3[] vector3s = new Vector3[4];
    int ThisCount;

    public AudioClip[] audioClips;

    public   int Score;
   // public Text text;

    public static int GameType;

    public Vector2 vector2Next;
    public Vector2 vector2This;

    bool Move;

    public static  int HP =3;
    public Text HpUi;
    public Text ScoreUi;
    void Start()
    {
        Time.timeScale = 1;
       
        vector2This = new Vector2(1, 1);
        vector2Next= new Vector2(1, 1);
        GameType = 0;
        ThisCount = 0;
        vector3s[0] = new Vector3(-14 * 0.57f * 0.6f + 6 * 0.57f * 0.6f, 17 * 0.57f * 0.6f - 1 * 0.57f * 0.6f, 0);
        vector3s[1] = new Vector3(-14 * 0.57f * 0.6f + 6 * 0.57f * 0.6f, 17 * 0.57f * 0.6f - 5 * 0.57f * 0.6f, 0);
        vector3s[2] = new Vector3(-14 * 0.57f * 0.6f + 1 * 0.57f * 0.6f, 17 * 0.57f * 0.6f - 5 * 0.57f * 0.6f, 0);
        vector3s[3] = new Vector3(-14 * 0.57f * 0.6f + 1 * 0.57f * 0.6f, 17 * 0.57f * 0.6f - 1 * 0.57f * 0.6f, 0);
    }

    // Update is called once per frame
    void Update()//主角循环移动
    {
       HpUi.text = HP.ToString();
       ScoreUi.text = Score.ToString();
       // if (Input.GetKeyDown(KeyCode.Escape))
       // {
       //     Application.Quit();
      //  }

       // Debug.Log(ThisCount);
       // this.transform.position = Vector2.Lerp(this.transform.position, vector3s[ThisCount], Time.deltaTime);
       // this.transform.localEulerAngles = new Vector3(0, 0, -90 * (ThisCount + 1));

      //  if (Vector2.Distance(this.transform.position, vector3s[ThisCount]) <= 0.05f)
       // {
        //    ThisCount++;
       //     if (ThisCount > 3)
       //     {
       //         ThisCount = 0;
       //     }
      //  }

        //text.text = Score.ToString();

        InputMove();

    }
    public void InputMove()//主角按键移动
    {
        if (Input.GetKeyDown(KeyCode.A)&&!Move)
        {
            int temp = LevelGenerator.LevelMap4[(int)vector2This.x , (int)vector2This.y-1];
            if (temp==5|| temp==6||temp== 0 || temp == 8)
            {
                vector2Next = new Vector2((int)vector2This.x , (int)vector2This.y-1);
                Move = true;
                this.transform.localEulerAngles = new Vector3(0, 0, -270 );
            }
            else
            {
                Playaudio2();
            }
        }
        if (Input.GetKeyDown(KeyCode.D) && !Move)
        {
            int temp = LevelGenerator.LevelMap4[(int)vector2This.x, (int)vector2This.y+1];
            if (temp == 5 || temp == 6 || temp == 0 || temp == 8)
            {
                vector2Next = new Vector2((int)vector2This.x , (int)vector2This.y+1);
                Move = true;
                this.transform.localEulerAngles = new Vector3(0, 0, -90);
            }
            else
            {
                Playaudio2();
            }
        }
        if (Input.GetKeyDown(KeyCode.W) && !Move)
        {
            int temp = LevelGenerator.LevelMap4[(int)vector2This.x-1 , (int)vector2This.y];
            if (temp == 5 || temp == 6 || temp == 0 || temp == 8)
            {
                vector2Next = new Vector2((int)vector2This.x-1 , (int)vector2This.y);
                Move = true;
                this.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                Playaudio2();
            }
        }
        if (Input.GetKeyDown(KeyCode.S) && !Move)
        {
            int temp = LevelGenerator.LevelMap4[(int)vector2This.x+1, (int)vector2This.y];
            if (temp == 5 || temp == 6 || temp == 0 || temp == 8)
            {
                vector2Next = new Vector2((int)vector2This.x + 1, (int)vector2This.y);
                Move = true;
                this.transform.localEulerAngles = new Vector3(0, 0, -180);
            }
            else
            {
                Playaudio2();
            }
        }
        Vector3 vector3temp = new Vector3(-14 * 0.57f * 0.6f + vector2Next.y * 0.57f * 0.6f, 17 * 0.57f * 0.6f - vector2Next.x * 0.57f * 0.6f, 0);
        this.transform.position = Vector2.Lerp(this.transform.position, vector3temp, Time.deltaTime*3);
        if (Vector2.Distance(this.transform.position, vector3temp) <= 0.05f)
        {
           
            vector2This = vector2Next;
            Move = false;
           

        }
       
    }

    public void Playaudio()//主角音效控制
    {
        Score += 1;
        this.GetComponent<AudioSource>().PlayOneShot(audioClips[0]);
    }
    public void Playaudio1()//主角音效控制
    {
        Score += 1;
        GameType = 1;
        this.GetComponent<AudioSource>().PlayOneShot(audioClips[0]);
    }
    public void Playaudio2()//主角音效控制
    {
        this.GetComponent<AudioSource>().PlayOneShot(audioClips[1]);
    }
    public void Playaudio3()//主角音效控制
    {
        Score += 10;
        this.GetComponent<AudioSource>().PlayOneShot(audioClips[0]);
    }



}
