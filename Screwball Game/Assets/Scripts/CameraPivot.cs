using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    private float yRotation;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float yRotation = transform.eulerAngles.y;

        // Need to adjust controls for shifting camera
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            // Need to clean this up to avoid beeg number but good for now
            Debug.Log("Update yRot:" + yRotation);
            yRotation = yRotation + 90;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
        }
    }
}
