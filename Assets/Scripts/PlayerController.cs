using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerBehaviour
{
    protected float getAxis;
    protected float onRun;
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
        controls.Player.Run.performed += ctx => onRun = ctx.ReadValue<float>();
        controls.Player.Run.canceled += ctx =>
        {
            onRun = 0;
            anim.SetBool("Run", false);
            moveSpeed = defaultSpeed;
        };

       //controls.Player.Jump.performed += ctx => onJump = true;
    }
    private void Start()
    {
        Init();
        defaultSpeed = moveSpeed;
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
        JumpHold();
        Run(onRun);
        //InputActionRunJump();
    }
    private void FixedUpdate()
    {
        MovementVelocity(getAxis);
    }
    public void InputActionRunJump()
    {
        if(onJump && grounded)
        {
            RunJump();
        }
        onJump = false;
        ModifyPhysic();
    }
   
}
