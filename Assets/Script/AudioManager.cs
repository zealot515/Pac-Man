using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips;

    int ThisType;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AudioSource>().clip = audioClips[0];
        this.GetComponent<AudioSource>().Play();
    }
    //Ghost soundclips
    // Update is called once per frame
    void Update()
    {
        if (ThisType == 1)
        {
            if(this.GetComponent<AudioSource>().clip != audioClips[1])
            {
                this.GetComponent<AudioSource>().clip = audioClips[1];
                this.GetComponent<AudioSource>().Play();

            }
           
        }
        if (ThisType ==2)
        {
            if (this.GetComponent<AudioSource>().clip != audioClips[2])
            {
                this.GetComponent<AudioSource>().clip = audioClips[2];
                this.GetComponent<AudioSource>().Play();

            }
        }
        if (ThisType == 3)
        {
            if (this.GetComponent<AudioSource>().clip != audioClips[3])
            {
                this.GetComponent<AudioSource>().clip = audioClips[3];
                this.GetComponent<AudioSource>().Play();

            }
        }
        if (this.GetComponent<AudioSource>().clip== audioClips[0]&& !this.GetComponent<AudioSource>().isPlaying)
        {
           
            this.GetComponent<AudioSource>().loop = true;
           
            ThisType = 1;
            
        }
        int Temp = 0;
        for (int i = 0; i < 4; i++)
        {
            if (this.transform.GetChild(i).GetComponent<Monster>().Die)
            {
                if (this.GetComponent<AudioSource>().clip != audioClips[3])
                {
                    ThisType = 2;

                }
                else
                {
                    Temp++;
                }
               
            }
        }
        if (Temp == 4)
        {
            ThisType = 1;
        }
        if (PlayerMove.GameType == 1&&ThisType!=2)
        {
            if (this.GetComponent<AudioSource>().clip != audioClips[2])
            {
                ThisType = 3;
            }

        }
        if (PlayerMove.GameType == 0 && ThisType == 3)
        {
            if (this.GetComponent<AudioSource>().clip != audioClips[1])
            {
                ThisType = 1;
            }

        }
    }
}
