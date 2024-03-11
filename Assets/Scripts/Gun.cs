using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Bullet bullet;
    public HeroScript hs;
    private Animator anim;
    public AudioSource audioSourse;
    public AudioClip fireGunAudio;
    private bool isInCamera;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("NoBullet", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("GunChargeAnimation") && hs.isGameOn())
        {
            bullet.gameObject.SetActive(true);
        }
        /*if (anim.GetCurrentAnimatorStateInfo(0).IsName("GunFireAnimation"))
        {
            bullet.gameObject.SetActive(false);
        }/*/
        
    }

    public void LoadGun()
    {
        bullet.gameObject.SetActive(false);
        anim.SetBool("NoBullet", true);
        bullet.MoveBullet();
        bullet.gameObject.SetActive(true);
        if (hs.AreSoundsOn())
        {
            audioSourse.PlayOneShot(fireGunAudio);
        }
    }

    public bool IsGunInCamera()
    {
        return isInCamera;
    }
}