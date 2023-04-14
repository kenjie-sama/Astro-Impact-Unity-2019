using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPlane1Script : MonoBehaviour
{
    public bool canAttack;
    private bool canMove = true;
    private float enemySpeed = 3f;
    private float bound_Y = -6.5f;
    private float plane1MaxHP = 120f;
    private float currentHealth;
    public int scoreCanGet=5;
    [SerializeField] protected float rotate_enemySpeed = 50f;
    [SerializeField] protected Transform enemyAttackSpawner;
    [SerializeField] protected GameObject enemyLaser;
    [SerializeField] protected GameObject enemyPlane1Explosion;
    [SerializeField] protected Animator enemyAnimation;
    [SerializeField] protected AudioSource explosionSFX;
    [SerializeField] private AudioClip explosionSCLP;
    [SerializeField] private scoreSystem scores;
    void Awake()
    {
        enemyAnimation = GetComponent<Animator>();
        explosionSFX = GetComponent<AudioSource>();
        if ((scores != null))
        {
            scores = FindObjectOfType<scoreSystem>().GetComponent<scoreSystem>();
        }
        currentHealth = plane1MaxHP;
    }
    void Start()
    {
        if (canAttack)
        {
            Invoke("enemyAttack", Random.Range(1f, 3f));
        }
    }
    void Update()
    {
        EnemyMove();
        if (currentHealth <= 0)
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
    void enemyAttack()
    {
        GameObject laser = Instantiate(enemyLaser, enemyAttackSpawner.position, Quaternion.identity);
        laser.GetComponent<enemyLaserScript>().isEnemyLaserRelease = true;
        if (canAttack)
        {
            Invoke("enemyAttack",Random.Range(1f,3f));
        }
;   }
    public void DamageEnemy(float damageValue)
    {
        currentHealth -= damageValue;

    }
    public void DestroyEnemy()
    {
        scores.scoreValue += scoreCanGet;
        explosionSFX.PlayOneShot(explosionSCLP);
        GameObject explodeFX = Instantiate(enemyPlane1Explosion, transform.position, Quaternion.identity);
        Destroy(explodeFX, 1f);
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
