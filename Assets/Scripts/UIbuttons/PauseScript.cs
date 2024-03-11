using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PauseScript : MonoBehaviour, IPointerClickHandler
{
    // add callbacks in the inspector like for buttons
    public UnityEvent onClick;
    public GameObject pauseIcon, playIcon;
    private bool paused = false;
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
        //Debug.Log(name + " Button Clicked!", this);
        // invoke your event
        onClick.Invoke();
        if (!paused)
        {
            Time.timeScale = 0;
            pauseIcon.SetActive(false);
            playIcon.SetActive(true);
            paused = true;
        } 
        else
        {
            StopPause();
        }

    }
    public void StopPause()
    {
        Time.timeScale = 1;
        pauseIcon.SetActive(true);
        playIcon.SetActive(false);
        paused = false;
    }
    
}
