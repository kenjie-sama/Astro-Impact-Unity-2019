using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLaserScript : MonoBehaviour
{
    public GameObject laser;
    private float laserSpeed = 5f;
    private float deactive_playerLaserUnit = 3f;
    public Vector3 directionLaser;
    [SerializeField] GameObject enemyHitFX; 
    [HideInInspector] public bool isEnemyLaserRelease = false;
    void Start()
    {
        if (isEnemyLaserRelease)
        {
            laserSpeed *= -1f;
        }
        Invoke("DestroyLasersOutside",0.3f);
    }
    void Update()
    {
        moveLaser();
    }

    public void moveLaser()
    {
        directionLaser = transform.position;
        directionLaser.y += laserSpeed * Time.deltaTime;
        transform.position = directionLaser;
    }
    void DestroyLasersOutside()
    {
        if (directionLaser.y <= -6)
        {
            Destroy(this.gameObject);
        }
        Invoke("DestroyLasersOutside", 0.3f);
    }

    public void OnTriggerEnter2D(Collider2D target)
    {
        
        if (target.tag.Equals("PlayerUnit"))
        {
            GameObject hit1 = Instantiate(enemyHitFX, transform.position, Quaternion.identity);
            Destroy(hit1, 2f);
            Destroy(gameObject);
        }
        if (target.tag.Equals("PlayerLaser"))
        {
            GameObject hit2 = Instantiate(enemyHitFX, transform.position, Quaternion.identity);
            Destroy(hit2, 2f);
            Destroy(gameObject);
        }
    }
}
