using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Vector2 inputVector;

    public float speed;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Start");


    }

    // Update is called once per frame
    void Update()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        transform.Translate(inputVector.x * speed, 0f, inputVector.y * speed);


    }
}
