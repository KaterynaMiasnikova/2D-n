using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OptionsScript : MonoBehaviour, IPointerClickHandler
{
    public HeroScript hero;
    // add callbacks in the inspector like for buttons
    public UnityEvent onClick;

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
        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        //Debug.Log(name + " Start Button Clicked!", this);
        // invoke your event
        onClick.Invoke();
        foreach (GameObject obj in hero.mainScene)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in hero.startScene)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in hero.finalScene)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in hero.optionsScene)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in hero.helpScene)
        {
            obj.SetActive(false);
        }
    }
}