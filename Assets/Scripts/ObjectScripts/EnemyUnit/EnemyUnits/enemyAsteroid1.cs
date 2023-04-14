using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemyAsteroid1 : MonoBehaviour
{
    public bool canRotate;
    private float asteroidMaxHP = 400f;
    private bool canMove = true;
    private float enemySpeed = 3f;
    private float bound_Y = -6.5f;
    private float currentHealth;
    public int scoreCanGet = 30;
    [SerializeField] protected float rotate_enemySpeed = 50f;
    [SerializeField] protected Transform enemyAttackSpawner;
    [SerializeField] protected AudioSource explosionSFX;
    [SerializeField] private AudioClip explosionSCLP;
    [SerializeField] private GameObject rockDestoryFX;
    [SerializeField] private scoreSystem scores;
    void Awake()
    {
        explosionSFX = GetComponent<AudioSource>();
        currentHealth = asteroidMaxHP;
        if ((scores != null))
        {
            scores = FindObjectOfType<scoreSystem>().GetComponent<scoreSystem>();
        }
    }
    void Start()
    {
        if (canRotate)
        {
            if (Random.Range(0, 3) > 0)
            {
                rotate_enemySpeed = Random.Range(rotate_enemySpeed, rotate_enemySpeed + 20f);
                rotate_enemySpeed *= 0 - 1f;
            }
            else
            {
                rotate_enemySpeed = Random.Range(rotate_enemySpeed, rotate_enemySpeed + 20f);
            }
        }

    }
    void Update()
    {
        EnemyMove();
        EnemyRotate();
        if (currentHealth<=0)
        {
            DestroyEnemy();
        }
    }
    public void EnemyMove()
    {
        if (canMove)
        {
            Vector3 enemyDirection = transform.position;
            enemyDirection.y -= enemySpeed * Time.deltaTime;
            transform.position = enemyDirection;
            if (enemyDirection.y < bound_Y)
            {
                this.gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
        }
    }
    public void EnemyRotate()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotate_enemySpeed * Time.deltaTime), Space.World);

        }
    }
    public void DamageEnemy(float damageValue)
    {
        currentHealth -= damageValue;
    }
    public void DestroyEnemy()
    {
        scores.scoreValue += scoreCanGet;
        explosionSFX.PlayOneShot(explosionSCLP);
        GameObject explodeFX = Instantiate(rockDestoryFX,transform.position,Quaternion.identity);
        Destroy(explodeFX,2f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerUnit")
        {
            DestroyEnemy();
        }
    }
}
