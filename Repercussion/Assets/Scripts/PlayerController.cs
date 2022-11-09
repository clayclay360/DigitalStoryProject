using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Camera")]
    public GameObject cam;

    [Header("Animators")]
    public Animator playerAnimator;
    public Animator rifleAnimator;

    [Header("Objects")]
    public GameObject soldier;

    private Rigidbody rb;
    private float moveX, moveZ;
    private float moveHorizontal;
    private float moveVertical;
    private float speed;
    private bool leftMouseBtnDown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Aim();
    }

    public void Movement()
    {
        #region Motion
        Vector3 forwardMovement = Vector3.zero;
        Vector3 rightMovement = Vector3.zero;

        GameManager.isPlayer.walking = false;

        if (GameManager.canPlayer.walk)
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");


            float movementMag = new Vector2(moveHorizontal, moveVertical).magnitude;
            playerAnimator.SetFloat("Movement", movementMag);
            rifleAnimator.SetFloat("Movement", movementMag);

            if (moveHorizontal != 0 || moveVertical != 0)
            {
                GameManager.isPlayer.walking = true;

                //sprint                    
                speed = GameManager.playerWalkSpeed;

                if (Input.GetKey(KeyCode.LeftShift) && !GameManager.isPlayer.jumping)
                {
                    speed = GameManager.playerSprintSpeed;
                }

                //move forward and backwards
                if (moveVertical != 0f)
                {
                    forwardMovement = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);
                }
                forwardMovement.Normalize();
                transform.position += forwardMovement * Time.deltaTime * speed * moveVertical;

                //move left and right
                if (moveHorizontal != 0f)
                {
                    rightMovement = new Vector3(cam.transform.right.x, 0, cam.transform.right.z);
                }
                rightMovement.Normalize();
                transform.position += rightMovement * Time.deltaTime * speed * moveHorizontal;

            }
        }

        //jump
        if (GameManager.canPlayer.jump && Input.GetKeyDown(KeyCode.Space) && !GameManager.isPlayer.jumping)
        {
            GameManager.isPlayer.jumping = true;

            Vector3 pushDir = new Vector3(0, 1, 0);
            rb.AddForce(pushDir * GameManager.playerJumpMagnitude);
        }
        #endregion
    }

    public void Aim()
    {
        leftMouseBtnDown = Input.GetMouseButton(1);
        playerAnimator.SetBool("Aim", leftMouseBtnDown);
        rifleAnimator.SetBool("Aim", leftMouseBtnDown);
    }

    private IEnumerator CanJumpAgain()
    {
        GameManager.canPlayer.jump = false;
        yield return new WaitForSeconds(0.075f);
        GameManager.isPlayer.jumping = false;
        GameManager.canPlayer.jump = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.isPlayer.jumping)
        {
            StartCoroutine(CanJumpAgain());
        }
    }

 }
