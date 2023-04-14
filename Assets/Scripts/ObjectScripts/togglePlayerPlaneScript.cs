using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class togglePlayerPlaneScript : MonoBehaviour
{
    [SerializeField] private playerPlaneScript playerScript;
    private void Start()
    {
        if (playerScript != null)
        {
            playerScript = FindObjectOfType<playerPlaneScript>().GetComponent<playerPlaneScript>();
        }
    }
    private void Update()
    {
        toggleScript();
    }
    public void toggleScript()
    {
            playerScript.enabled = true;
            playerScript.gameObject.SetActive(true);
    }
}
