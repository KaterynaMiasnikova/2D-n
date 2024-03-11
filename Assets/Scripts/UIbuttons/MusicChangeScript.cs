using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MusicChangeScript : MonoBehaviour, IPointerClickHandler
{
    public AudioSource cam;
    // add callbacks in the inspector like for buttons
    public UnityEvent onClick;
    bool isMusicPlaying;
    float normalVolume;
    public Text volumeText;

    // Start is called before the first frame update
    void Start() 
    {
        isMusicPlaying = true;
        normalVolume = cam.volume;
    }

    // Update is called once per frame
    void Update() { }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Output to console the clicked GameObject's name and the following message.
        //Debug.Log(name + " Start Button Clicked!", this);
        // invoke your event
        onClick.Invoke();

        if (isMusicPlaying)
        {
            isMusicPlaying = false;
            cam.volume = 0;
            volumeText.text = "off";
        }
        else
        {
            isMusicPlaying = true;
            cam.volume = normalVolume;
            volumeText.text = "on";
        }
    }
}
