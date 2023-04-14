using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashPUScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float duration;
    [SerializeField] private playerPlaneScript playerUnit;
    [SerializeField] private GameObject HitFx;
    [SerializeField] private GameObject pickUpFX;
    [SerializeField] private GameObject poofFX;
    [SerializeField] Rigidbody2D powerUprRB;
    [SerializeField] private float powerUp_movementSpeed;
    [SerializeField] private AudioSource powerUpsSounds;
    [SerializeField] private AudioClip pickedSFX;
    [SerializeField] private SpriteRenderer spriteDash;
    [SerializeField] private CircleCollider2D colliderDash;

    private Vector3 directionPowerUp;
    private void Start()
    {
        if (playerUnit != null && powerUpsSounds != null)
        {
            playerUnit = FindObjectOfType<playerPlaneScript>().GetComponent<playerPlaneScript>();
        }
        powerUp_movementSpeed = 3f;
        duration = 20f;
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
        GameObject pickFX = Instantiate(pickUpFX, playerUnit.transform.position, Quaternion.identity);
        GameObject poof = Instantiate(poofFX, playerUnit.transform.position, Quaternion.identity);
        playerUnit.setPlaneSpeed(15f);
        Debug.Log("Speed = "+playerUnit.getPlaneSpeed());
        spriteDash.enabled = false;
        colliderDash.enabled = false;
        yield return new WaitForSeconds(duration);
        playerUnit.setPlaneSpeed(7f);
        Debug.Log("Speed = " + playerUnit.getPlaneSpeed());
        Destroy(gameObject);
    }
    void movePowerUp()
    {
        powerUprRB.velocity = -1 * (transform.up * powerUp_movementSpeed);
        directionPowerUp = transform.position;
        StartCoroutine(DestroyPowerUPOutside());
    }
    IEnumerator DestroyPowerUPOutside()
    {
        if (directionPowerUp.y <= -15)
        {
            powerUp_movementSpeed = 1f;
            yield return new WaitForSeconds(11f);
            Destroy(gameObject);
        }
    }
}
