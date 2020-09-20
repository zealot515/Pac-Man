using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject gameMap;
    int[,] LevelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {1,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {2,0,0,0,0,0,5,0,0,0,4,0,0,0},             
    };

  public static  int[,] LevelMap4 = new int[29, 28];
    // Start is called before the first frame update
    void Start()// Map Instantiate
    {
        int[,] LevelMap1=new int[14,14];
        for (int i = 0; i < 14; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                LevelMap1[i,j] = LevelMap[13 - i,j];
            }
        }
        int[,] LevelMap2 = new int[29, 14];
        for (int i = 0; i < 29; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                if (i < 15)
                    LevelMap2[i, j] = LevelMap[i, j];
                else
                {
                    LevelMap2[i, j] = LevelMap1[i-15, j];
                }
            }
        }
        int[,] LevelMap3 = new int[29, 14];
        for (int i = 0; i < 29; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                LevelMap3[i, j] = LevelMap2[i, 13-j];
            }
        }
       

        for (int i = 0; i < 29; i++)
        {
            for (int j = 0; j < 28; j++)
            {
                if (j < 14)
                    LevelMap4[i, j] = LevelMap2[i, j];
                else
                {
                    LevelMap4[i, j] = LevelMap3[i , j-14];
                }
            }
        }
        for (int i = 0; i < 29; i++)
        {
            for (int j = 0; j <28; j++)
            {
                bool BTrue = false;
                GameObject gameObject1 = GameObject.Instantiate(gameMap);
                gameObject1.transform.SetParent(this.transform);
                if (LevelMap4[i, j] == 0)
                {

                }
                else
                {
                    gameObject1.GetComponent<SpriteRenderer>().sprite = sprites[LevelMap4[i, j] - 1];
                }
               
                gameObject1.transform.position = new Vector3(-14*0.57f*0.6f+j * 0.57f*0.6f, 17 * 0.57f*0.6f - i * 0.57f*0.6f, 0);
                if (LevelMap4[i, j] == 1)
                {
                    if(i-1>=0)
                    {
                        if (LevelMap4[i-1, j] == 2|| LevelMap4[i - 1, j] == 1)
                        {
                            if (j - 1 >= 0)
                            {
                                if (LevelMap4[i, j - 1] == 2 || LevelMap4[i , j-1] == 1)
                                {
                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 180);

                                }
                            }
                            if (j + 1 <= 27)
                            {
                                if (LevelMap4[i, j + 1] == 2 || LevelMap4[i , j+1] == 1)
                                {
                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);
                                  
                                }
                            }
                            
                           
                        }
                    }
                    if (i + 1 <= 28)
                    {
                        if (LevelMap4[i + 1, j] == 2 || LevelMap4[i + 1, j] == 1)
                        {
                            if (j - 1 >= 0)
                            {
                                if (LevelMap4[i, j - 1] == 2 || LevelMap4[i, j-1] == 1)
                                {
                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 270);
                                  
                                }
                            }
                            if (j + 1 <= 27)
                            {
                                if (LevelMap4[i, j + 1] == 2 || LevelMap4[i , j+1] == 1)
                                {
                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);
                                  
                                }
                            }

                        }
                    }
                }
                if (LevelMap4[i, j] == 2)
                {
                    if (i - 1 >= 0)
                    {
                        if (LevelMap4[i - 1, j] == 2|| LevelMap4[i - 1, j] == 1|| LevelMap4[i - 1, j] == 7)
                        {
                          
                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);
                          
                           


                        }
                    }
                    if (j - 1 >= 0)
                    {
                        if (LevelMap4[i, j-1] == 2 || LevelMap4[i, j-1] == 1|| LevelMap4[i, j - 1] ==7)
                        {
                           
                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);
                          



                        }
                    }
                }
                if (LevelMap4[i, j] == 3)
                {
                    if (i - 1 >= 0)
                    {
                        if (LevelMap4[i - 1, j] == 4|| LevelMap4[i - 1, j] ==3)
                        {
                            if (j - 1 >= 0)
                            {
                                if (LevelMap4[i, j - 1] == 4 || LevelMap4[i, j-1] == 3)
                                {
                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 180);
                                    if (LevelMap4[i - 1, j] == 4 && LevelMap4[i, j - 1] == 4)
                                    {
                                        BTrue = true;
                                    }
                                }
                            }
                            if (j + 1 <= 27)
                            {
                                if (LevelMap4[i, j + 1] == 4 || LevelMap4[i , j+1] == 3)
                                {
                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);
                                    if (LevelMap4[i - 1, j] == 4 && LevelMap4[i, j+ 1] == 4)
                                    {
                                        BTrue = true;
                                    }

                                }
                            }
                           


                        }
                    }
                    if (j + 1 <= 27 && j - 1 >= 0 && i - 1 >= 0 && i + 1 <= 28)
                    {
                        if (LevelMap4[i - 1, j] == 4 || LevelMap4[i - 1, j] == 3)
                        {
                            if (LevelMap4[i + 1, j] == 4 || LevelMap4[i + 1, j] == 3)
                            {
                                if (LevelMap4[i, j - 1] == 4 || LevelMap4[i, j - 1] == 3)
                                {
                                    if (LevelMap4[i, j + 1] == 4 || LevelMap4[i, j + 1] == 3)
                                    {
                                        if (LevelMap4[i - 1, j] == 4&& LevelMap4[i, j - 1] == 4)
                                        {
                                            if (LevelMap4[i - 2, j] == 4 && LevelMap4[i, j - 2] == 4)
                                            {
                                                gameObject1.transform.localEulerAngles = new Vector3(0, 0, 180);
                                                BTrue = true;
                                            }
                                        }
                                         if (LevelMap4[i - 1, j] == 4 && LevelMap4[i, j + 1] == 4)
                                        {
                                            if (LevelMap4[i - 2, j] == 4 && LevelMap4[i, j + 2] == 4)
                                            {
                                                gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);
                                                BTrue = true;
                                            }
                                        }
                                         if (LevelMap4[i + 1, j] == 4 && LevelMap4[i, j + 1] == 4)
                                        {
                                            if (LevelMap4[i + 2, j] == 4 && LevelMap4[i, j + 2] == 4)
                                            {
                                                gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);
                                                BTrue = true;
                                            }
                                        }
                                         if (LevelMap4[i + 1, j] == 4 && LevelMap4[i, j - 1] == 4)
                                        {
                                            if (LevelMap4[i + 2, j] == 4 && LevelMap4[i, j - 2] == 4)
                                            {
                                                gameObject1.transform.localEulerAngles = new Vector3(0, 0, 270);
                                                BTrue = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (i + 1 <= 28&& !BTrue)
                    {
                        if (LevelMap4[i + 1, j] == 4 || LevelMap4[i + 1, j] == 3)
                        {
                            if (j - 1 >= 0)
                            {
                                if (LevelMap4[i, j - 1] == 4 || LevelMap4[i , j-1] == 3)
                                {
                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 270);
                                   
                                }
                            }
                            if (j + 1 <= 27)
                            {
                                if (LevelMap4[i, j + 1] == 4 || LevelMap4[i, j+1] == 3)
                                {
                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);
                                  
                                }
                            }

                        }
                    }
                    
                }
                if (LevelMap4[i, j] == 4)
                {
                   
                    if (j - 1 >= 0)
                    {
                        if (LevelMap4[i, j - 1] == 3 || LevelMap4[i, j - 1] == 4 || LevelMap4[i, j - 1] == 7)
                        {


                            gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);

                        }
                    }
                    if (j + 1 <= 27)
                    {
                        if (LevelMap4[i, j + 1] == 4 || LevelMap4[i, j + 1] == 3 || LevelMap4[i, j + 1] == 7)
                        {
                            gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);
                        }
                    }
                    if (i - 1 >= 0)
                    {
                        if (LevelMap4[i - 1, j] == 3 || LevelMap4[i - 1, j] == 4 || LevelMap4[i - 1, j] == 7)
                        {
                            if (i + 1 <= 28)
                            {
                                if (LevelMap4[i + 1, j] == 3 || LevelMap4[i + 1, j] == 4 || LevelMap4[i + 1, j] == 7)
                                {
                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);
                                }
                            }



                        }
                    }
                }
                if (LevelMap4[i, j] == 7)
                {
                    if (i - 1 >= 0)
                    {
                        if (LevelMap4[i - 1, j] == 3 || LevelMap4[i - 1, j] == 4)
                        {
                            gameObject1.transform.localEulerAngles = new Vector3(0, 0, 180);
                        }
                    }
                    if (i + 1 <= 27)
                    {
                        if (LevelMap4[i + 1, j] == 3 || LevelMap4[i + 1, j] == 4)
                        {
                            gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);
                        }
                    }
                    if (j - 1 >= 0)
                    {
                        if (LevelMap4[i, j-1] == 3 || LevelMap4[i , j-1] == 4)
                        {
                            gameObject1.transform.localEulerAngles = new Vector3(0, 0, 270);
                        }
                    }
                    if (j + 1 <= 27)
                    {
                        if (LevelMap4[i , j+1] == 3 || LevelMap4[i , j+1] == 4)
                        {
                            gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);
                        }
                    }

                }
                if (LevelMap4[i, j] == 6)
                {
                    gameObject1.GetComponent<Item>().enabled = true;
                    gameObject1.GetComponent<Item>().ThisItem = 6;
                    gameObject1.GetComponent<Animator>().enabled = true;
                }
                if (LevelMap4[i, j] == 5)
                {
                    gameObject1.GetComponent<Item>().enabled = true;
                    gameObject1.GetComponent<Item>().ThisItem = 5;
                   
                }
                if (LevelMap4[i, j] == 8)
                {
                    gameObject1.GetComponent<Item>().enabled = true;
                    gameObject1.GetComponent<Item>().ThisItem = 8;

                }
            }
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
