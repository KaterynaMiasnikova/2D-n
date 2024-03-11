using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretKey : MonoBehaviour
{
    public HeroScript hs;
    public GameObject lasers;
    public List<GameObject> fuelCans;
    public AudioClip secretKeyAudio;

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
        gameObject.SetActive(false);
        hs.SecretKeyAchieved();
        if (hs.AreSoundsOn())
        {
            hs.heroAudioSourse.PlayOneShot(secretKeyAudio);
        }

        lasers.SetActive(false);
        foreach (GameObject can in fuelCans)
        {
            can.SetActive(true);
        }
        
    }
}