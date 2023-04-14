using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLaserScript : MonoBehaviour
{
    public float laserSpeed = 10f;
    public float deactive_playerLaserUnit = 4f;
    public float laserDamage = 30f;
    public Vector3 directionLaser;
    public GameObject hitFX;
    public Rigidbody2D playerLaserRB;
    void Start()
    {
        Invoke("DestroyLasersOutside", 0.1f);  
    }
    void Update()
    {
        moveLaser();
        
    }
    public void moveLaser()
    {
        playerLaserRB.velocity = transform.up * laserSpeed;
        directionLaser = transform.position;
        DestroyLasersOutside();
    }
    void DestroyLasersOutside()
    {
        if (directionLaser.y >= 5)
        {

            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag.Equals("EnemyLaser"))
        {
            GameObject hit = Instantiate(hitFX,transform.position,Quaternion.identity);
            Destroy(hit,2f);
            Destroy(gameObject);
        }
        if (target.tag.Equals("powerUps"))
        {
            GameObject hit = Instantiate(hitFX, transform.position, Quaternion.identity);
            Destroy(hit, 2f);
            Destroy(gameObject);
        }
        if (target.tag.Equals("EnemyUnit"))
        {
            enemyAsteroid1 asteroid1 = target.GetComponent<enemyAsteroid1>();
            enemyPlane1Script enemyPlane1 = target.GetComponent<enemyPlane1Script>();
            enemyPlane2 plane2 = target.GetComponent<enemyPlane2>();
            if (asteroid1!=null)
            {
                GameObject hitAsteroid = Instantiate(hitFX, transform.position, Quaternion.identity);
                Destroy(hitAsteroid, 2f);
                Destroy(gameObject);
                asteroid1.DamageEnemy(laserDamage);
            }
            if (enemyPlane1!=null)
            {
                GameObject hitPlane1 = Instantiate(hitFX, transform.position, Quaternion.identity);
                Destroy(hitPlane1, 2f);
                Destroy(gameObject);
                enemyPlane1.DamageEnemy(laserDamage);
            }
            if (plane2 != null)
            {
                GameObject hitPlane2 = Instantiate(hitFX, transform.position, Quaternion.identity);
                Destroy(hitPlane2, 2f);
                Destroy(gameObject);
            }
        }
    }
   
}
