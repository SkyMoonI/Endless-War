using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    [SerializeField]public FixedJoystick _joystick;

    public float speed;
    public float rotationSpeed;

    Animator animator;
    int isRunningHash;

    static public bool attackPressed;
    static public bool rollPressed;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
        attackPressed = false;
        rollPressed=false;
    }
    
    // Update is called once per frame
    void Update()
    {

        float horizontalInput = _joystick.Horizontal;//Input.GetAxis("Horizontal");
        float verticalInput = _joystick.Vertical;//.GetAxis("Vertical");

        Vector3 addedPos = new Vector3(horizontalInput * speed * Time.deltaTime, 0, verticalInput*speed*Time.deltaTime);
        transform.position += addedPos;
        if (addedPos != Vector3.zero)
        {
            Vector3 direction = Vector3.forward * verticalInput + Vector3.right * horizontalInput;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
        }
        

        bool isRunning = animator.GetBool(isRunningHash);
        //bool forwardPressed = Input.GetKey("w");
        //bool leftPressed = Input.GetKey("a");
        //bool rightPressed = Input.GetKey("s");
        //bool backwardPressed = Input.GetKey("d");
        //bool clickPressed = Input.GetKey(KeyCode.Mouse0);
        //bool rollPressed = Input.GetKeyDown(KeyCode.Space);

        if (!isRunning && (/*forwardPressed || leftPressed || rightPressed || backwardPressed ||*/ horizontalInput!=0f|| verticalInput != 0f))
        {
            animator.SetBool(isRunningHash, true);
        }
        if (isRunning && !(/*forwardPressed || leftPressed || rightPressed || backwardPressed ||*/ horizontalInput != 0f || verticalInput != 0f))
        {
            animator.SetBool(isRunningHash, false);
        }
        if(rollPressed)
        {
            animator.SetBool("isRolling", true);
        }
        if (!rollPressed)
        {
            animator.SetBool("isRolling", false);
        }
        if (attackPressed) //clickPressed
        {
            animator.SetBool("isAttacking", true);
        }
        if (!attackPressed)//!clickPressed
        {
            animator.SetBool("isAttacking", false);
        }
        rollPressed = false;

    }
}
