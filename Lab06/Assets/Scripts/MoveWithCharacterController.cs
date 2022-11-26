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
        // zak�adamy, �e komponent CharacterController jest ju� podpi�ty pod obiekt
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // wyci�gamy warto�ci, aby mo�liwe by�o ich efektywniejsze wykorzystanie w funkcji
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // dzi�ki parametrowi playerGrounded mo�emy doda� zachowania, kt�re b�d�
        // mog�y by� uruchomione dla ka�dego z dw�ch stan�w
        grounded = controller.isGrounded;

        // zmiana z playerVelocity.y < 0f na playerVelocity.y < -0.5f poniewa� �rodowisko nie odczytuje kontaktu z pod�o�em przy zerowej pr�dko�ci y
        if (grounded && playerVelocity.y < -0.5f)
        {
            playerVelocity.y = -0.5f;
        }

        if (playerVelocity.x == 0 && playerVelocity.z == 0)
        {
            controller.Move(Vector3.zero);
        }

        // zmieniamy spos�b poruszania si� postaci
        // Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // transform.right odpowiada za ruch wzd�u� osi x (pami�tajmy, �e warto�ci b�d� zar�wno dodatnie
        // jak i ujemne, a punkt (0,0) jest na �rodku ekranu) a transform.forward za ruch wzd�� osi z.
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            // wz�r na si�� 
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        // pr�dko�� swobodnego opadania zgodnie ze wzorem y = (1/2 * g) * t-kwadrat 
        // okazuje si�, �e jest to zbyt wolne opadanie, wi�c zastosowano g * t-kwadrat
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}