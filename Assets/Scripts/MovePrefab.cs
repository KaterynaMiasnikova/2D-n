using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePrefab : MonoBehaviour
{
    public HeroScript hs;
    public GameObject prefabToMove, fuelCan, fuelCanTOP, lasers, gun, crate;
    public MovePrefab sensorToActivate;
    public List<GameObject> lights, screensOn, screensOff, covers;
    private float deltaX;

    // Start is called before the first frame update
    void Start()
    {
        deltaX = 76.83f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hs.AddAmountOfPrefabs();
        gameObject.SetActive(false);
        prefabToMove.SetActive(true);
        if (hs.GetAmountOfPrefabs() == 23)
        {
            hs.SetActiveSecretKey();
        }
        if (hs.GetAmountOfPrefabs() == 40)
        {
            hs.GetSecretPrefab().transform.position = new Vector3(prefabToMove.transform.position.x + deltaX, prefabToMove.transform.position.y, prefabToMove.transform.position.z);
            hs.GetSecretPrefab().SetActive(true);
            prefabToMove.SetActive(false);
            hs.sensor0.gameObject.SetActive(true);
            hs.sensor0.SetParameters(sensorToActivate);
        }
        prefabToMove.transform.position = new Vector3(prefabToMove.transform.position.x + deltaX, prefabToMove.transform.position.y, prefabToMove.transform.position.z);

        sensorToActivate.gameObject.SetActive(true);
        Randomise();
    }

    public void Randomise()
    {
        //randomise fuelCan/lasers/gun/crate
        int choice = Random.Range(0, 6); 
        switch (choice)
        {
            case 0:
                fuelCan.SetActive(false);
                lasers.SetActive(false);
                gun.SetActive(true);
                crate.SetActive(false);
                fuelCanTOP.SetActive(false);
                break;
            case 1:
                fuelCan.SetActive(false);
                lasers.SetActive(true);
                gun.SetActive(false);
                crate.SetActive(false);
                fuelCanTOP.SetActive(false);
                break;
            case 2:
                fuelCan.SetActive(true);
                lasers.SetActive(false);
                gun.SetActive(false);
                crate.SetActive(false);
                fuelCanTOP.SetActive(false);
                break;
            case 3:
                fuelCan.SetActive(false);
                lasers.SetActive(false);
                gun.SetActive(false);
                crate.SetActive(true);
                fuelCanTOP.SetActive(false);
                break;
            case 4:
                fuelCan.SetActive(false);
                lasers.SetActive(false);
                gun.SetActive(false);
                crate.SetActive(true);
                fuelCanTOP.SetActive(true);
                break;
            case 5:
                fuelCan.SetActive(false);
                lasers.SetActive(true);
                gun.SetActive(false);
                crate.SetActive(true);
                fuelCanTOP.SetActive(false);
                break;
            default:
                fuelCan.SetActive(false);
                lasers.SetActive(false);
                gun.SetActive(false);
                crate.SetActive(false);
                fuelCanTOP.SetActive(false);
                break;
        }

        //randomise lights
        foreach (GameObject light in lights)
        {
            choice = Random.Range(0, 2);
            switch (choice)
            {
                case 0:
                    light.SetActive(false);
                    break;
                case 1:
                    light.SetActive(true);
                    break;
                default:
                    light.SetActive(false);
                    break;
            }
        }

        //randomise covers
        choice = Random.Range(0, 3);
        switch (choice)
        {
            case 0:
                covers[0].SetActive(false);
                covers[1].SetActive(false);
                covers[2].SetActive(true);
                break;
            case 1:
                covers[0].SetActive(false);
                covers[1].SetActive(true);
                covers[2].SetActive(false);
                break;
            case 2:
                covers[0].SetActive(true);
                covers[1].SetActive(false);
                covers[2].SetActive(false);
                break;
            default:
                covers[0].SetActive(false);
                covers[1].SetActive(false);
                covers[2].SetActive(false);
                break;
        }

        //randomise screens
        for (int j = 0; j < 6; j++)
        {
            choice = Random.Range(0, 3);
            switch (choice)
            {
                case 0:
                    screensOff[j].SetActive(false);
                    screensOn[j].SetActive(true);
                    break;
                case 1:
                    screensOff[j].SetActive(true);
                    screensOn[j].SetActive(false);
                    break;
                default:
                    screensOff[j].SetActive(false);
                    screensOn[j].SetActive(true);
                    break;
            }
        }
    }

    public void SetParameters(MovePrefab mp)
    {
        hs = mp.hs;
        prefabToMove = mp.prefabToMove;
        fuelCan = mp.fuelCan;
        fuelCanTOP = mp.fuelCanTOP;
        lasers = mp.lasers;
        gun = mp.gun;
        crate = mp.crate;
        sensorToActivate = mp.sensorToActivate;
        lights = mp.lights;
        screensOn = mp.screensOn;
        screensOff = mp.screensOff;
        covers = mp.covers;
    }
}