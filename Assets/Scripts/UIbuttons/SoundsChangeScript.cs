using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SoundsChangeScript : MonoBehaviour, IPointerClickHandler
{
    // add callbacks in the inspector like for buttons
    public UnityEvent onClick;
    public Text volumeText;

    public HeroScript hs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Output to console the clicked GameObject's name and the following message.
        //Debug.Log(name + " Start Button Clicked!", this);
        // invoke your event
        onClick.Invoke();

        if (hs.AreSoundsOn())
        {
            hs.ChangeSounds(false);
            volumeText.text = "off";
        }
        else
        {
            hs.ChangeSounds(true);
            volumeText.text = "on";
        }
    }
}
