using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float jumpHeight = 2.5f;
    public float gravityValue = 12f;
    public int loot = 0;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -gravityValue * 0.1f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * -gravityValue);
        }

        playerVelocity.y += -gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (loot >= 3)
        {
            gameOver.SetActive(true);
        }
    }
}
