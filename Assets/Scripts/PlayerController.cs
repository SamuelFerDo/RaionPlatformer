using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerBehaviour
{
    protected float getAxis;
    protected InputApp controls;

    public bool onJump;

    private void Awake()
    {
        controls = new InputApp();
        controls.Player.Movement.performed += ctx => getAxis = ctx.ReadValue<float>();
        controls.Player.Movement.canceled += ctx =>
        {
            getAxis = 0;
            anim.SetBool("Walk", false);
        };
       //controls.Player.Jump.performed += ctx => onJump = true;
    }
    private void Start()
    {
        Init();
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    private void Update()
    {
        //GetAxisMovement();
        Movement(getAxis);
        JumpHold();
        //ModifyPhysic();
        //InputActionJump();
    }
    public void GetAxisMovement()
    {
        direction.x = Input.GetAxis("Horizontal");
        Movement(direction.x);
    }
    public void InputActionJump()
    {
        if(onJump && grounded)
        {
            Jump();
        }
        onJump = false;
    }
   
}
