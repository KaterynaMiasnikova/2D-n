using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowHero : MonoBehaviour
{
    public HeroScript hs;
    public GameObject eastWall, westWall;
    public List<GameObject> gunHandles, guns, bullets;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hs.getCurrentHeroPosition() > hs.getMaxHeroPosition())
        {
            hs.IncreaseMeters();
            hs.setMaxHeroPosition(hs.getCurrentHeroPosition());
        }
        if (hs.getCurrentHeroPosition() > transform.position.x)
        {
            transform.position = new Vector3(hs.getCurrentHeroPosition(), transform.position.y, transform.position.z);
        }

        int i = 0;
        foreach (GameObject gunHandle in gunHandles)
        {
            if (gunHandle.activeSelf)
            {
                if (gunHandle.transform.position.x - 2 < westWall.transform.position.x || gunHandle.transform.position.x > eastWall.transform.position.x)
                {
                    bullets[i].SetActive(false);
                    guns[i].SetActive(false);
                }
                if (gunHandle.transform.position.x - 2 >= westWall.transform.position.x && gunHandle.transform.position.x <= eastWall.transform.position.x)
                {
                    bullets[i].SetActive(true);
                    guns[i].SetActive(true);
                }
            }
            i++;
        }
    }
}