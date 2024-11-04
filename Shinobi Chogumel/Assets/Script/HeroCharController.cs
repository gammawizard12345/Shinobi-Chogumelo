using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float jumpHeight = 2f;

    private float gravity = -50f;
    private CharacterController charController;
    private TouchManager touchInput;
    private Vector3 velocity;
    private bool isGrounded;
    private float horizontalInput;

    public GameManager theGameManager;

    void Start()
    {
        charController = GetComponent<CharacterController>();
        touchInput = GetComponent<TouchManager>();
    }

   
    void Update()
    {
        horizontalInput = 1;

        //Face forward
        transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);

        // Is Grounded => Verifica se o player est� no ch�o
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayer, QueryTriggerInteraction.Ignore);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
            //Adiciona gravidade
            velocity.y += gravity * Time.deltaTime;
        }

        charController.Move(new Vector3(horizontalInput * runSpeed, 0, 0) * Time.deltaTime);
          //if (isGrounded && touchInput.checkSwiping())
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // Vertical Velocity
        charController.Move(velocity * Time.deltaTime);
   
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "killbox")
        {
            theGameManager.RestartGame();
        }
    }
}
