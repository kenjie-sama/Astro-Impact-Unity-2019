using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
public class gameUnitsSpawnerScript : MonoBehaviour
{
    private float maximumX = 7.822473f;
    private float minimumX = -7.822473f;
    private float gameTime;
    private bool canSpawnPowerUp=false;
    private int powerUpsCounter;
    [SerializeField] private GameObject[] Asteroids;
    [SerializeField] private GameObject enemyPlane;
    [SerializeField] private GameObject enemyPlane2;
    [SerializeField] private float timer;
    [SerializeField] private Text timeShow;
    [SerializeField] private scoreSystem scores;
    [SerializeField] private playerPlaneScript playerUnit;
    [SerializeField] private GameObject[] powerUps=new GameObject[2];
    [SerializeField] private GameObject levelCompleteObject;
    void Start()
    {
        timer = UnityEngine.Random.Range(0.6f, 2.3f);
        StartCoroutine(prepareLevel());
        if (scores!=null)
        {
            scores = FindObjectOfType<scoreSystem>().GetComponent<scoreSystem>();
        }
        powerUpsCounter = 0;
    }
    void Update()
    {
        timer = UnityEngine.Random.Range(1f, 3f);
        gameTime = Mathf.Round( Time.timeSinceLevelLoad);
        timeShow.text = "Time: "+ string.Format("{0:.##}", gameTime).ToString();
        float randomizer = UnityEngine.Random.Range(63, 66);
        if ((gameTime >= randomizer && gameTime <= (randomizer+1)) && powerUpsCounter==0)
        {
                canSpawnPowerUp = true;
                spawnPowerUps();
        }
        if ((gameTime > (randomizer + Mathf.Abs(gameTime - randomizer))) && powerUpsCounter == 1) {
            powerUpsCounter = 0;
        }

    }
    IEnumerator prepareLevel()
    {
        yield return new WaitForSeconds(8f);
        Invoke("spawnUnits", timer);
    }
    IEnumerator resetSpawning()
    {
        yield return new WaitForSeconds(5f);
        Invoke("spawnUnits", timer);
    }
    void spawnDebris()
    {
        if (UnityEngine.Random.Range(0, 3) > 0)
        {
            float debrisPosition_X = UnityEngine.Random.Range(minimumX, maximumX);
            Vector3 debrisUnitDirection;
            debrisUnitDirection = transform.position;
            debrisUnitDirection.x = debrisPosition_X;
            Instantiate(Asteroids[UnityEngine.Random.Range(0, Asteroids.Length)], debrisUnitDirection, Quaternion.identity);;
        }
    }
    void spawnEnemyPlane1()
    {
        float position_X = UnityEngine.Random.Range(minimumX, maximumX);
        Vector3 planeUnitDirection;
        planeUnitDirection = transform.position;
        planeUnitDirection.x = position_X;
        Instantiate(enemyPlane, planeUnitDirection, Quaternion.Euler(0f, 0f, 180f));

    }
    void spawnEnemyPlane2()
    {
        float position_X = UnityEngine.Random.Range(minimumX, maximumX);
        Vector3 planeUnitDirection;
        planeUnitDirection = transform.position;
        planeUnitDirection.x = position_X;
        Instantiate(enemyPlane2, planeUnitDirection, Quaternion.Euler(0f, 0f, 180f));

    }

    void spawnUnits()
    {
        if (playerUnit.isPlayerDestroyed == false) {
            if (gameTime<37|| gameTime <60)
            {
                timer = UnityEngine.Random.Range(0.6f, 2.5f);
                spawnEnemyPlane1();
            }
            if (gameTime>37&&gameTime<62)
            {
                spawnEnemyPlane1();
                spawnEnemyPlane1();
            }
            if (gameTime>68&&gameTime<90)
            {
                timer = UnityEngine.Random.Range(1f, 2.8f);
                spawnEnemyPlane2();
                if (gameTime >75&& gameTime<90)
                {
                    spawnEnemyPlane2();
                    if (gameTime > 83 && gameTime < 90)
                    {
                        spawnEnemyPlane1();
                    }
                }
            }
            if (gameTime > 91 && gameTime < 130)
            {
                spawnDebris();
                if (gameTime > 95&&gameTime<120)
                {
                    timer = UnityEngine.Random.Range(0.3f, 2.5f);
                    spawnDebris();
                    spawnDebris();
                }
                if (gameTime>110)
                {
                    timer = UnityEngine.Random.Range(1f, 2f);
                    spawnEnemyPlane2();
                    if(gameTime > 117)
                    {
                        spawnEnemyPlane1();
                        spawnEnemyPlane1();
                    }
                }
            }
            if ((gameTime >= 130&& gameTime >= 300) && scores.scoreValue >= 300)
            {
                spawnDebris();
                timer = UnityEngine.Random.Range(0.3f, 2.5f);
                spawnDebris();
                if (gameTime >= 140)
                {
                    spawnEnemyPlane1();
                    timer = UnityEngine.Random.Range(0.3f, 2.5f);
                    spawnEnemyPlane1();
                    timer = UnityEngine.Random.Range(0.3f, 2.5f);
                    spawnEnemyPlane1();
                }
                if (gameTime >= 150)
                {
                    timer = UnityEngine.Random.Range(1f, 2.8f);
                    spawnEnemyPlane2();
                }
                if ((gameTime>=250&&gameTime >= 300)&& scores.scoreValue >= 300)
                {
                    StartCoroutine(wait());
                    LevelComplete();
                }
            }
            Invoke("spawnUnits", timer);
        }
        else
        {
            StartCoroutine(resetSpawning());
        }
        
    }
    void spawnPowerUps()
    {
        if (canSpawnPowerUp==true) {
            float randomXposition = UnityEngine.Random.Range(minimumX, maximumX);
            Vector3 powerUpDirection = transform.position;
            powerUpDirection.x = randomXposition;
            Instantiate(powerUps[(UnityEngine.Random.Range(0,powerUps.Length))], powerUpDirection, Quaternion.identity);
            canSpawnPowerUp = false;
            powerUpsCounter+=1;
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(5f);
    }
    public void LevelComplete()
    {
        levelCompleteObject.SetActive(true);
        playerUnit.enabled = false;
        GetComponent<gameUnitsSpawnerScript>().enabled = false;
    }
    
}
