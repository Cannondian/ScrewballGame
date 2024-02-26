using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public float speed = .01f;
    private Rigidbody rb;
    public int objectsCollected = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(Vector3.right * speed);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddForce(-Vector3.right * speed);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddForce(Vector3.forward * speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddForce(-Vector3.forward * speed);
        }
        //MovePlayerRelativeToCamera();

        // Reset Game
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Restarts current level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void MovePlayerRelativeToCamera()
    {
        // Get Player Input
        float playerVerticalInput = Input.GetAxis("Vertical");
        float playerHorizontalInput = Input.GetAxis("Horizontal");

        // Get Camera Normalized Directional Vectors
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        // Inverse Transform
        //Vector3 forward = transform.InverseTransformVector(Camera.main.transform.forward);
        //Vector3 right = transform.InverseTransformVector(Camera.main.transform.right);

        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        // Create direction-relative-input vectors
        Vector3 forwardRelativeVerticalInput = playerVerticalInput * forward;
        Vector3 rightRelativeVerticalInput = playerHorizontalInput * right;

        // Create and apply camera relative movement
        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeVerticalInput;
        this.transform.Translate(cameraRelativeMovement, Space.World);
        //Vector3.Dot(cameraRelativeMovement, Space.World);

        //rb.AddForce(cameraRelativeMovement);
        // Its a transform issue, remember to use rigidbody for movement instead
    }
}
