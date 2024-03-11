using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public HeroScript hs;
    public Gun gun;
    Vector3 startPosition;
    public AudioSource audioSourse;
    public AudioClip bulletHeroAudio, bulletFloorAudio;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = gun.transform.position;
        MoveBullet();
    }

    // Update is called once per frame
    void Update()
    {
        if (startPosition != gun.transform.position)
            startPosition = gun.transform.position;

        transform.position = new Vector3(transform.position.x - 0.03f, transform.position.y - 0.02f, transform.position.z);
        if (transform.position.y <= -5)
        {
            if (hs.AreSoundsOn())
            {
                audioSourse.PlayOneShot(bulletFloorAudio);
            }
            LoadBulletAndGun();
        }
        if (!hs.isGameOn())
        {
            gameObject.SetActive(false);
        }
        if (hs.isGameOn())
        {
            gameObject.SetActive(true);
        }
    } 

    //when hero is on the ground after jump start stand animation
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hs.AreSoundsOn())
        {
            audioSourse.PlayOneShot(bulletHeroAudio);
        }
        //print("Successful collision with " + hit.gameObject + " 0 " + hit.otherCollider + " 1 " + hit);
        hs.DecreaseHealth(14);
        LoadBulletAndGun();
    }

    public void LoadBulletAndGun()
    {
        gun.LoadGun();
        gameObject.SetActive(false);
        MoveBullet();
    }

    public void MoveBullet()
    {
        transform.position = startPosition;
    }
}
