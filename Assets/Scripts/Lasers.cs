using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour
{
    public HeroScript hs;
    public AudioSource lasersAudioSourse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (hs.isGameOn())
        {
            hs.DecreaseHealth();
        }
        if (hs.AreSoundsOn())
        {
            lasersAudioSourse.Play();
        }
    }
}
