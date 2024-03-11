using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCan : MonoBehaviour
{
    public HeroScript hs;
    public AudioClip fuelAudio;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hs.GetHealth() < 100)
        {
            gameObject.SetActive(false);
            hs.IncreaseHealth();
            if (hs.AreSoundsOn())
            {
                hs.heroAudioSourse.PlayOneShot(fuelAudio);
            }
        }
    }
}
