using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad4 : MonoBehaviour
{
    private Vector3 playerVelocity;
    [SerializeField]
    private GameObject player;
    private CharacterController controller;

    private void Start()
    {
        controller = player.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerVelocity.y += Mathf.Sqrt(other.gameObject.GetComponent<MoveWithCharacterController>().jumpHeight * -3.0f * other.gameObject.GetComponent<MoveWithCharacterController>().gravityValue) * Time.deltaTime;
            other.gameObject.GetComponent<CharacterController>().Move(playerVelocity * Time.deltaTime);
        }
    }
}
