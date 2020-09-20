using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ThisItem;
    public GameObject ThisPlayer;
    // Start is called before the first frame update
    void Start()
    {
        ThisPlayer = GameObject.FindGameObjectWithTag("Player");
    }
    //吃豆子判断
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(this.transform.position, ThisPlayer.transform.position) <= 0.15f)
        {
            if (ThisItem == 5)
            {
                ThisPlayer.GetComponent<PlayerMove>().Playaudio();
                Destroy(this.gameObject);
            }
            if (ThisItem == 6)
            {
                ThisPlayer.GetComponent<PlayerMove>().Playaudio1();
                Destroy(this.gameObject);
            }
            if (ThisItem == 8)
            {
                ThisPlayer.GetComponent<PlayerMove>().Playaudio3();
                Destroy(this.gameObject);
            }


        }
    }
}
