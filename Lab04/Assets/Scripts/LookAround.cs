using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    // ruch wokó³ osi Y bêdzie wykonywany na obiekcie gracza, wiêc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;

    public float sensitivity = 200f;
    private Quaternion rotation;

    void Start()
    {
        // zablokowanie kursora na œrodku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
        rotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        // pobieramy wartoœci dla obu osi ruchu myszy
        rotation.x += Input.GetAxis("Mouse Y");
        rotation.y += Input.GetAxis("Mouse X");

        // ustawiamy limit dla rotacji osi x
        rotation.x = Mathf.Clamp(rotation.x, -90f, 90f);

        // wykonujemy rotacjê wokó³ osi Y
        player.Rotate(Vector3.up * Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime);

        // a dla osi X obracamy kamerê dla lokalnych koordynatów
        // -mouseYMove aby unikn¹æ efektu mouse inverse
        transform.localRotation = Quaternion.Euler(-rotation.x, 0, 0);
    }
}