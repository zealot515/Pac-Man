using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public GameObject [] LevelAsset;
  
    //float OCx = 10f;
    //float OCy = 20f;
    // Start is called before the first frame update
    void Start()
    {
        int[,] levelmap =
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
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
        };

        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                if (levelmap[i, j] == 0)
                {
                    
                  Instantiate(LevelAsset[1], new Vector3(20f,25f,200f), Quaternion.identity);
                   


                }
                //else if (levelmap[i, j] == 2)
                //{
                   // Instantiate(OutsideWall, new Vector3(20, 30, 0), Quaternion.identity);


               // }



            }

           
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
