using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AManager : MonoBehaviour
{
    public Audio[] audios;
    public static AManager instance;

    private void Start()
    {
        playSound("Background");
        if(instance == null)
            instance = this;
        
        else
            Destroy(this.gameObject);

        GameObject.DontDestroyOnLoad(instance);

    }

    public void playSound(string name)
    {
        foreach(Audio item in audios)
        {
            if(item.name == name)
            {
                if(item.source == null)
                    item.source = gameObject.AddComponent<AudioSource>();
                item.source.clip = item.clip;
                item.source.volume = item.volume;
                item.source.loop = item.loop;

                item.source.Play();
                break;
                
            }
        }
    }
}
