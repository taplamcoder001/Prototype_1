using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string InputId;
    // [SerializeField] private float speed = 20.0f;
    [SerializeField] private float tunrspeed = 45.0f;
    [SerializeField] private float horsePower= 0;
    private float horizontalInput;
    private float verticalInput;
    public Camera cam1;
    public Camera cam3;
    public Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        cam1.enabled = false;
        cam3.enabled = true;
    }
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            cam1.enabled = !cam1.enabled;
            cam3.enabled = !cam3.enabled;
        }
        // Input controller
        verticalInput = Input.GetAxis("Vertical" + InputId);
        horizontalInput = Input.GetAxis("Horizontal" + InputId);
        playerRb.AddRelativeForce(Vector3.forward * verticalInput * horsePower);
        // Move the vehicle
        // transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Rotate(Vector3.up, tunrspeed * Time.deltaTime *horizontalInput);
    }
}
