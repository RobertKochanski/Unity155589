using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithCharacterController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool grounded;
    private float playerSpeed = 5.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;

    private void Start()
    {
        // zak³adamy, ¿e komponent CharacterController jest ju¿ podpiêty pod obiekt
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // wyci¹gamy wartoœci, aby mo¿liwe by³o ich efektywniejsze wykorzystanie w funkcji
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // dziêki parametrowi playerGrounded mo¿emy dodaæ zachowania, które bêd¹
        // mog³y byæ uruchomione dla ka¿dego z dwóch stanów
        grounded = controller.isGrounded;

        // zmiana z playerVelocity.y < 0f na playerVelocity.y < -0.5f poniewa¿ œrodowisko nie odczytuje kontaktu z pod³o¿em przy zerowej prêdkoœci y
        if (grounded && playerVelocity.y < -0.5f)
        {
            playerVelocity.y = -0.5f;
        }

        if (playerVelocity.x == 0 && playerVelocity.z == 0)
        {
            controller.Move(Vector3.zero);
        }

        // zmieniamy sposób poruszania siê postaci
        // Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // transform.right odpowiada za ruch wzd³u¿ osi x (pamiêtajmy, ¿e wartoœci bêd¹ zarówno dodatnie
        // jak i ujemne, a punkt (0,0) jest na œrodku ekranu) a transform.forward za ruch wzd³ó¿ osi z.
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            // wzór na si³ê 
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        // prêdkoœæ swobodnego opadania zgodnie ze wzorem y = (1/2 * g) * t-kwadrat 
        // okazuje siê, ¿e jest to zbyt wolne opadanie, wiêc zastosowano g * t-kwadrat
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}