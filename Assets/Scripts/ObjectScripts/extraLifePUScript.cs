using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extraLifePUScript : MonoBehaviour
{
    private float powerUp_movementSpeed = 3f;
    // Start is called before the first frame update
    [SerializeField] private playerPlaneScript playerUnit;
    [SerializeField] private GameObject HitFx;
    [SerializeField] private GameObject pickUpFX;
    [SerializeField] private GameObject poofFX;
    [SerializeField] Rigidbody2D powerUprRB;
    [SerializeField] private AudioSource powerUpsSounds;
    [SerializeField] private AudioClip pickedSFX;
    [SerializeField] private SpriteRenderer spriteXLife;
    [SerializeField] private CircleCollider2D colliderXLife;
    private Vector3 directionPowerUp;
    private void Start()
    {
        if (playerUnit!=null&& powerUpsSounds!=null)
        {
            playerUnit = FindObjectOfType<playerPlaneScript>().GetComponent<playerPlaneScript>();
        }
    }
    private void Update()
    {
        movePowerUp();
    }
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag.Equals("PlayerUnit"))
        {
            StartCoroutine(pickUpPowerUp());
        }
        if (player.tag.Equals("PlayerLaser"))
        {
            GameObject hit = Instantiate(HitFx, transform.position, Quaternion.identity);
            Destroy(hit, 1f);
        }
    }
    IEnumerator pickUpPowerUp()
    {
        powerUpsSounds.PlayOneShot(pickedSFX);
        GameObject pickFX = Instantiate(pickUpFX, playerUnit.transform.position,Quaternion.identity) ;
        GameObject poof = Instantiate(poofFX, playerUnit.transform.position, Quaternion.identity);
        playerUnit.playerLives +=1;
        spriteXLife.enabled = false;
        colliderXLife.enabled = false;
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);
    }
    public void movePowerUp()
    {
        powerUprRB.velocity = -1*(transform.up* powerUp_movementSpeed);
        directionPowerUp = transform.position;
        DestroyPowerUPOutside();
    }
    void DestroyPowerUPOutside()
    {
        if (directionPowerUp.y <= -6)
        {
            Destroy(this.gameObject);
        }
    }
}
