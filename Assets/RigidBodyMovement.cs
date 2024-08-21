using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{
    public float jumpForce;

    public float speed;
    public Vector2 inputVector;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
        float jump = Input.GetAxis("Jump");

        rb.AddForce(inputVector.x * speed, 0f, inputVector.y * speed, ForceMode.Impulse);


        if (jump != 0)
        {
            rb.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(0f, -jumpForce, 0f, ForceMode.Impulse);
        }

    }
}
