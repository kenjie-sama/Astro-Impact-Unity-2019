using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{/*
    private float max_X= 7.822473f;
    private float max_Y=4;
    private float min_X=-7.822473f;
    private float min_Y=4;
    private float current_laserAttackedCountL;
    private float current_laserAttackedCountR;
    public bool canLaserAttackL;
    public bool canLaserAttackR;
    private float planeSpeed=7;
    private Vector3 direction;
    private float laserAttackedCountL;
    private float laserAttackedCountR;
    [SerializeField] private GameObject playerLaser;
    [SerializeField] private Transform laserSpawner1;
    [SerializeField] private Transform laserSpawner2;
    [SerializeField] private AudioSource SoundSource;
    [SerializeField] private AudioClip laserSFX;
    [SerializeField] protected Animator enemyAnimation;
    [SerializeField] private AudioClip explosionSFX;
    private void Start()
    {
        current_laserAttackedCountL = laserAttackedCountL;
        current_laserAttackedCountR = laserAttackedCountR;
    }
    private void Update()
    {
        planeController();
        Attack();
    }
    void planeController()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            direction = transform.position;
            direction.x = direction.x + this.planeSpeed * Time.deltaTime;
            if (direction.x > max_X)
            {
                direction.x = max_X;
            }
            transform.position = direction;
        }
        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            direction = transform.position;
            direction.x = direction.x - this.planeSpeed * Time.deltaTime;
            if (direction.x < min_X)
            {
                direction.x = min_X;
            }
            transform.position = direction;
        }
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            direction = transform.position;
            direction.y = direction.y + this.planeSpeed * Time.deltaTime;
            if (direction.y > max_Y)
            {
                direction.y = max_Y;
            }
            transform.position = direction;
        }
        if (Input.GetAxisRaw("Vertical") < 0f)
        {
            direction = transform.position;
            direction.y = direction.y - this.planeSpeed * Time.deltaTime;
            if (direction.y < min_Y)
            {
                direction.y = min_Y;
            }
            transform.position = direction;
        }
    }
        void Attack()
        {
            laserAttackedCountL += Time.deltaTime;
            if (laserAttackedCountL > current_laserAttackedCountL)
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
                if (canLaserAttackL)
                {
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
            void turnOffPlayerUnit()
            {
                Destroy(this.gameObject);
            }
            
        }*/
}
