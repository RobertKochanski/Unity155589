using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Ammo;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField]
    private AmmoType ammoType;
    [SerializeField]
    private int amountPickUp = 10;

    [SerializeField]
    private AudioClip audioClip;


    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, amountPickUp);
            AudioSource.PlayClipAtPoint(audioClip, transform.position);

            Destroy(gameObject);
        }
    }

}
