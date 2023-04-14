using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerPlaneScript : MonoBehaviour
{
    private float maximumX;
    private float maximumY;
    private float minimumX;
    private float minimumY;
    private Vector3 direction;
    private float current_laserAttackedCountL;
    private float current_laserAttackedCountR;
    private bool canLaserAttackL;
    private bool canLaserAttackR;
    private float planeSpeed;
    public bool isPlayerDestroyed;
    public PolygonCollider2D isColliding;
    [HideInInspector] public int playerLives=3;
    [SerializeField] private GameObject playerLaser;
    [SerializeField] private Transform laserSpawner1;
    [SerializeField] private Transform laserSpawner2;
    [SerializeField] private GameObject playerExplosion;
    [SerializeField] private float laserAttackedCountL;
    [SerializeField] private float laserAttackedCountR;
    [SerializeField] private AudioSource SoundSource;
    [SerializeField] private AudioClip laserSFX;
    [SerializeField] protected Animator playerAnimation;
    [SerializeField] private AudioClip explosionSCLP;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private GameObject respawnFX;
    [SerializeField] private togglePlayerPlaneScript togglePlayer;
    [SerializeField] private Text lifeCounter;
    [SerializeField] private GameObject gameOverTExt;
    [SerializeField] private GameOverButtonScripts GameOverObject;
    [SerializeField] private levelComplete campaignBool;
    // Getters and Setters
    // Speed
    void Awake()
    {
        float speed;
        float MaxValX;
        float MaxValY;
        float MinValX;
        float MinValY;
        this.setPlaneSpeed(speed = 0b111);
        this.setMaximumX(MaxValX = 7.822473f);
        this.setMaximumY(MaxValY = 0b100);
        this.setMinimumX(MinValX = -1 * (7.822473f));
        this.setMinimumY(MinValY = -1 * ((int)0b100));
        playerSprite = GetComponent<SpriteRenderer>();
        isPlayerDestroyed = false;
        isColliding.enabled = true;
        playerSprite.enabled = true;
        GameOverObject = FindObjectOfType<GameOverButtonScripts>().GetComponent<GameOverButtonScripts>();
        LifeCounter();
        if (togglePlayer!=null)
        {
            togglePlayer = FindObjectOfType<togglePlayerPlaneScript>().GetComponent<togglePlayerPlaneScript>();
        }
    }
    void Start()
    {
        current_laserAttackedCountL = laserAttackedCountL;
        current_laserAttackedCountR = laserAttackedCountR;
        LifeCounter();
        StartCoroutine(activatePlane());
    }
    void FixedUpdate()
    {
        LifeCounter();
        planeController();
        Attack();
    }
    /////////////////////////////////////////////////////////////////////
    public void setPlaneSpeed(float planeSpeedInFloat)
    {
        if (planeSpeedInFloat!=0x000)
        {
            this.planeSpeed= planeSpeedInFloat;
        }
        else
        {
            Debug.LogError("planeSpeedInFloat is <= 0");
        }
    }
    public float getPlaneSpeed()
    {
        return this.planeSpeed;
    }
    // X
    IEnumerator activatePlane()
    {
        yield return new WaitForSeconds(5.3f);
        playerAnimation.Play("activateAircraft");
    }
    IEnumerator respawnAnimation()
    {
        playerAnimation.Play("respawnAnimation");
        yield return new WaitForSeconds(7.3f);
        playerAnimation.Play("respawnedPlane");
    }
    public void setMinimumX(float minX)
    {
        if (minX != 0x000)
        {
            this.minimumX = minX;
        }
        else
        {
            Debug.LogError("minimumX is <= 0");
        }
    }
    public float getMinimumX()
    {
        return this.minimumX;
    }
    public void setMaximumX(float maxX)
    {
        if (maxX != 0x000)
        {
            this.maximumX = maxX;
        }
        else
        {
            Debug.LogError("maximumX is <= 0");
        }
    }
    public float getMaximumX()
    {
        return this.maximumX;
    }
        // Y
    public void setMinimumY(float minY)
    {
        if (minY != 0x000)
        {
            this.minimumY = minY;
        }
        else
        {
            Debug.LogError("minimumY is <= 0");
        }
    }
    public float getMinimumY()
    {
        return this.minimumY;
    }
    public void setMaximumY(float maxY)
    {
        if (maxY != 0x000)
        {
            this.maximumY = maxY;
        }
        else
        {
            Debug.LogError("maximumY is <= 0");
        }
    }
    public float getMaximumY()
    {
        return this.maximumY;
    }
    /////////////////////////////////////////////////////////////////////
    // Controllers
    void planeController()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            direction = transform.position;
            direction.x = direction.x + this.getPlaneSpeed() * Time.deltaTime;
            if (direction.x > getMaximumX())
            {
                direction.x = getMaximumX();
            }
            transform.position = direction;
        }
        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            direction = transform.position;
            direction.x = direction.x - this.getPlaneSpeed() * Time.deltaTime;
            if (direction.x < getMinimumX())
            {
                direction.x = getMinimumX();
            }
            transform.position = direction;
        }
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            direction = transform.position;
            direction.y = direction.y + this.getPlaneSpeed() * Time.deltaTime;
            if (direction.y > getMaximumY())
            {
                direction.y = getMaximumY();
            }
            transform.position = direction;
        }
        if (Input.GetAxisRaw("Vertical") < 0f)
        {
            direction = transform.position;
            direction.y = direction.y - this.getPlaneSpeed() * Time.deltaTime;
            if (direction.y < getMinimumY())
            {
                direction.y = getMinimumY();
            }
            transform.position = direction;
        }
    }
    void Attack()
    {
        laserAttackedCountL += Time.deltaTime;
        if (laserAttackedCountL>current_laserAttackedCountL)
        {
            canLaserAttackL = true;
        }
        laserAttackedCountR += Time.deltaTime;
        if (laserAttackedCountR > current_laserAttackedCountR)
        {
            canLaserAttackR = true;
        }
        if (Input.GetButton("Fire1"))
        {
            if (canLaserAttackL) {
                canLaserAttackL = false;
                laserAttackedCountL = 0f;
                SoundSource.PlayOneShot(laserSFX);
                Instantiate(playerLaser, laserSpawner1.position, Quaternion.identity);
            }
        }
        if (Input.GetButton("Fire2"))
        {
            if (canLaserAttackR)
            {
                canLaserAttackR = false;
                laserAttackedCountR = 0f;
                SoundSource.PlayOneShot(laserSFX);
                Instantiate(playerLaser, laserSpawner2.position, Quaternion.identity);
            }
        }
    }
    public void DestroyPlayer()
    {
        SoundSource.PlayOneShot(explosionSCLP);
        GameObject explodeFX = Instantiate(playerExplosion, transform.position, Quaternion.identity);
        Destroy(explodeFX, 2f);
        isPlayerDestroyed = true;
        isColliding.enabled = false;
        setPlaneSpeed(0b111);
        playerLives-=1;
        playerSprite.enabled = false;
        if (playerLives>=0) {
            if (playerSprite.enabled == false) {
                RespawnPlayer();
            }
            LifeCounter();
        }
        else
        {
            GameOver();
        }
    }
    private void OnTriggerEnter2D(Collider2D enemyTag)
    {
        
        if (enemyTag.tag.Equals("EnemyUnit"))
        {
            DestroyPlayer();
        }
        if (enemyTag.tag.Equals("EnemyLaser"))
        {
            DestroyPlayer();
        }
    }
    void RespawnPlayer()
    {
        if (isPlayerDestroyed)
        {
            transform.position = respawnPoint.position;
            StartCoroutine(respawnAnimation());
            isPlayerDestroyed = false;
            GameObject respawn = Instantiate(respawnFX, transform.position, Quaternion.identity);
            Destroy(respawn,2f);
            
        }
    }
    void GameOver()
    {
        GameOverObject.isGameOver = true;
        campaignBool.isLevelComplete = false;
        Animator gameOverTransition = gameOverTExt.GetComponent<Animator>();
        gameOverTransition.Play("GameOver");
        Destroy(gameOverTransition,2f);
        Destroy(gameObject);
    }
    public void LifeCounter()
    {
        lifeCounter.text = playerLives.ToString() + "x";
    }
}

