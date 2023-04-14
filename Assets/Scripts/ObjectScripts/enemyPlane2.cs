using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
public class enemyPlane2 : MonoBehaviour
{
    public bool canRotate;
    private bool canMove = true;
    private float enemySpeed = 3f;
    private float bound_Y = -6.5f;
    public int scoreCanGet = 10;
    public bool targetFound = false;
    public Rigidbody2D plane2RB;
    [SerializeField] protected float rotate_enemySpeed;
    [SerializeField] protected Transform enemyAttackSpawner;
    [SerializeField] protected AudioSource explosionSFX;
    [SerializeField] private AudioClip explosionSCLP;
    [SerializeField] private GameObject planeDestory2VFX;
    [SerializeField] private scoreSystem scores;
    void Awake()
    {
        explosionSFX = GetComponent<AudioSource>();
        if ((scores != null))
        {
            scores = FindObjectOfType<scoreSystem>().GetComponent<scoreSystem>();
        }
        canRotate = false;
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
        plane2RB = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        EnemyMove();
        EnemyRotate();
        if (transform.position.y <= 3.1f)
        {
            targetFound = true;
            canRotate = true;
            rotate_enemySpeed += 20;
            canMove = false;
            if (rotate_enemySpeed >= 800)
            {
                rotate_enemySpeed = 800;
                canMove = true;
                enemySpeed = 50f;
            }

        }
    }
    public void EnemyMove()
    {
        if (canMove)
        {
             Vector2 enemyDirection = transform.position;
             enemyDirection.y -= enemySpeed * Time.deltaTime;
             transform.position = enemyDirection;
            if (transform.position.y < bound_Y)
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
    public void DestroyEnemy()
    {
        scores.scoreValue += scoreCanGet;
        explosionSFX.PlayOneShot(explosionSCLP);
        GameObject explodeFX = Instantiate(planeDestory2VFX, transform.position, Quaternion.identity);
        Destroy(explodeFX, 2f);
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
