using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroScript : MonoBehaviour
{
    public MovePrefab mp1, mp2, mp3;
    public List<GameObject> startScene, mainScene, finalScene, finalHideScene, helpScene, optionsScene;
    public GameObject cam, sensor1, sensor2, sensor3;
    public Text healthText, finalFuelCansText, metersText, finalMetersText;
    public FollowHero fh;
    public PauseScript pauseScr;
    public AudioSource heroAudioSourse, finalAudioSourse;
    public AudioClip heroRespawnAudio, heroJumpAudio;

    public GameObject secretPrefab, secretKey;
    public MovePrefab sensor0;

    private List<Vector3> firstPositions; //first positions of MainScene to know where to return everything on "start again"
    private Vector3 firstPositionCamera;

    private float jumpForce = 7.2f;
    private float speed = 10f;
    private float flashDuration = 0.05f;
    private bool onGround = false;      // Whether or not the player is on ground.
    private bool sounds = true;
    private bool gameOn = true;
    private bool secretKeyBool = false;
    private int amountOfPrefabs = 3;

    private Animator anim;
    private int health, fuelCans;
    private float meters; 
    private float maxPosition; //max position where hero was to count only meters of the scene and not all back and forth meters

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Blink());
        //Vector3 movement = new Vector3(horizontalInput * moveSpeed * SpeedingUp * speedMultiplier * Time.deltaTime, 0, 0);
        anim = GetComponent<Animator>();
        health = 90;
        healthText.text = "" + health;
        anim.SetInteger("Trans", 1); //first animation is standing animation
        firstPositions = new List<Vector3>(); //first positions to know where to return everything on "start again"
        foreach (GameObject obj in mainScene)  
        {
            firstPositions.Add(obj.transform.position);
        }
        firstPositionCamera = cam.transform.position;
        maxPosition = transform.position.x;
        secretKeyBool = false;

        /*mp1.Randomise();
        mp2.Randomise();
        mp3.Randomise();*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up") && onGround && gameOn)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            // Add a vertical force to the player.
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            //We trigger the Jump animation state
            anim.SetInteger("Trans", 3); //ju,p animation
            onGround = false;
            if (sounds)
            {
                heroAudioSourse.PlayOneShot(heroJumpAudio);
            }
        }

        if (Input.GetKey("right") && Time.timeScale == 1 && gameOn)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.fixedDeltaTime, transform.position.y, transform.position.z);
            transform.localScale = new Vector3(1f, 1f, 1f);
            if (onGround == true)
            {
                anim.SetInteger("Trans", 2); //run animation
            }
        }

        if (Input.GetKey("left" ) && Time.timeScale == 1 && gameOn)
        {

            transform.position = new Vector3(transform.position.x - speed * Time.fixedDeltaTime, transform.position.y, transform.position.z);
            transform.localScale = new Vector3(-1f, 1f, 1f);
            if (onGround == true)
            {
                anim.SetInteger("Trans", 2); //run animation
            }
        }

        // When no key is pressed
        if ((Input.GetKeyUp("left") || Input.GetKeyUp("right")) && onGround == true && gameOn)// || Input.GetKeyUp("up"))
        {
            anim.SetInteger("Trans", 1); //stand animation
        }
    }

    //when hero is on the ground after jump start stand animation
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (!onGround)
        {
            onGround = true;
            //print("Hero has landed on ground");
            anim.SetInteger("Trans", 1); //stand animation
            if (sounds)
            {
                heroAudioSourse.Play();
            }
        }
    }

    public float getCurrentHeroPosition()
    {
        return transform.position.x;
    }
    public float getMaxHeroPosition()
    {
        return maxPosition;
    }
    public void setMaxHeroPosition(float position)
    {
        maxPosition = position;
    }

    public void IncreaseMeters()
    {
        meters += 0.05f;
        metersText.text = "" + ((int)meters);
    }

    public int GetHealth()
    {
        return health;
    }
    public void IncreaseHealth()
    {
        fuelCans++;
        health += 10;
        if (health > 100)
            health = 100;
        healthText.text = "" + health;
        //Debug.Log("Health is " + health);
    }
    public void DecreaseHealth()
    {
        health--;
        if (health <= 0)
        {
            gameOn = false;
            anim.SetInteger("Trans", 4); //dead animation
            //Debug.Log("You died!!!");
            StartCoroutine(Blink());
            //Time.timeScale = 0;
            foreach (GameObject obj in finalScene)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in finalHideScene)
            {
                obj.SetActive(false);
            }
            /*foreach (GameObject obj in mainScene)
            {
                obj.SetActive(false);
            }*/
            finalFuelCansText.text = "" + fuelCans;
            finalMetersText.text = "" + ((int)meters);
            if (sounds)
            {
                finalAudioSourse.Play();
            }
            //ReturnEverythingOnStart();
        }
        else
        {
            StartCoroutine(Blink());
            healthText.text = "" + health;
            //Debug.Log("Health is " + health);
        }
    }
    public void DecreaseHealth(int healths)
    {
        health -= healths;
        DecreaseHealth();
    }

    public void ReturnEverythingOnStart()
    {
        StartCoroutine(Blink());
        anim.SetInteger("Trans", 1); //first animation is standing animation
        gameOn = true;
        Time.timeScale = 1;
        secretKeyBool = false;
        secretKey.SetActive(false);
        health = 100;
        healthText.text = "" + health;
        amountOfPrefabs = 3;
        meters = 0;
        metersText.text = "" + ((int)meters);

        int i = 0;
        foreach (GameObject obj in mainScene)
        {
            obj.transform.position = firstPositions[i++];
        }
        cam.transform.position = firstPositionCamera;
        maxPosition = transform.position.x;
        transform.localScale = new Vector3(1f, 1f, 1f);
        sensor1.SetActive(false);
        sensor2.SetActive(true);
        sensor3.SetActive(true);
        mp1.Randomise();
        mp2.Randomise();
        mp3.Randomise();
        pauseScr.StopPause();
    }

    public bool AreSoundsOn()
    {
        return sounds;
    }
    public void ChangeSounds(bool newSound)
    {
        sounds = newSound;
        //Debug.Log("New value of sounds is " + sounds);
    }

    private IEnumerator Blink()
    {
        if (sounds)
        {
            heroAudioSourse.PlayOneShot(heroRespawnAudio);
        }
        int flashCount = 0;
        while (flashCount < 3) 
        {
            GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(flashDuration);
            GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(flashDuration);
            flashCount++;
        }
    }

    public bool isGameOn()
    {
        return gameOn;
    }

    public GameObject GetSecretPrefab()
    {
        return secretPrefab;
    }
    public MovePrefab GetSecretSensor()
    {
        return sensor0;
    }
    public void SetActiveSecretKey()
    {
        secretKey.SetActive(true);
        Debug.Log("Secret Key Set Active!!!");
        secretKeyBool = true;
    }
    public void SecretKeyAchieved()
    {
        secretKeyBool = true;
    }
    public bool isSecretKey()
    {
        return secretKeyBool;
    }
    public int GetAmountOfPrefabs()
    {
        return amountOfPrefabs;
    }
    public void AddAmountOfPrefabs()
    {
        amountOfPrefabs++;
        Debug.Log("AmountOfPrefabs is " + amountOfPrefabs);
    }

}