using UnityEngine;
using UnityEngine.SceneManagement;

public class RigidBodyMovement : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    public Vector2 inputVector;
    public Rigidbody rb;
    public Vector3 velocity;
    public float velocityMagnitude;
    public bool canJump;
    public int itemsCollected;
    public TMPro.TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canJump = false;

    }

    // Update is called once per frame
    void Update()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        rb.AddForce(inputVector.x * speed, 0f, inputVector.y * speed, ForceMode.Impulse);

        velocity = rb.velocity;
        velocityMagnitude = velocity.magnitude;

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
            canJump = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Estas colisionando contra: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }


        if (collision.gameObject.CompareTag("KillZone"))
        {
            Debug.Log("SE ta muriendo");

            SceneManager.LoadScene(0);
        }

        if (collision.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene(1);
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            itemsCollected++;
            Destroy(collision.gameObject);
            //collision.gameObject.gameObject.SetActive(false);

            scoreText.text = "Score: " + itemsCollected.ToString();
        }

    }
}
