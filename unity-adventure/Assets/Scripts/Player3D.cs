using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player3D : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.2f;

    CharacterController controller;
    Transform cam;
    Vector3 velocity;
    bool grounded;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        if (Camera.main != null) cam = Camera.main.transform;
    }

    void Update()
    {
        grounded = controller.isGrounded;
        if (grounded && velocity.y < 0) velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = Vector3.zero;
        if (cam != null)
        {
            Vector3 forward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 right = cam.right;
            move = (forward * z + right * x).normalized;
        }
        else
        {
            move = new Vector3(x, 0, z).normalized;
        }

        controller.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
