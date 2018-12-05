using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float camSpeed = 0.2f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CameraMoving();
    }

    private void CameraMoving()
    {
        if (Input.mousePosition.y > Screen.height * 0.95f)
        {
            transform.localPosition = transform.localPosition + (new Vector3(0, 0, camSpeed));
        }
        if (Input.mousePosition.y < Screen.height / 95f)
        {
            transform.localPosition = transform.localPosition + (new Vector3(0, 0, -camSpeed));
        }
        if (Input.mousePosition.x > Screen.width * 0.95f)
        {
            transform.localPosition = transform.localPosition + (new Vector3(camSpeed, 0, 0));
        }
        if (Input.mousePosition.x < Screen.width / 95f)
        {
            transform.localPosition = transform.localPosition + (new Vector3(-camSpeed, 0, 0));
        }
        float hMovement = Input.GetAxis("Horizontal");
        float vMovement = Input.GetAxis("Vertical");
        float yMovmeent = -1 * Input.GetAxis("Mouse ScrollWheel");

        transform.localPosition = transform.localPosition + (new Vector3(0, yMovmeent, 0));

    }
}
