using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Variables")]
    public float walkingSpeed;
    public float runningSpeed;
    public float turningSpeed;

    [Header("Camera")]
    public GameObject cam;

    private Rigidbody rb;
    private float moveX, moveZ;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.WalkingSpeed = walkingSpeed;
        GameManager.RunningSpeed = runningSpeed;
        GameManager.TurningSpeed = turningSpeed;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(moveX, 0, moveZ) * Time.deltaTime * walkingSpeed;
    }

}
