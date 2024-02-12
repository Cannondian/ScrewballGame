using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

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

        // Reset Game
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Restarts current level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
