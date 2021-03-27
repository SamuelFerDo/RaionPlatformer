using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerBehaviour
{
    [SerializeField] protected float getAxis;
    [SerializeField] protected bool onRun;
    protected InputApp controls;

    public bool onJump;

    private void Awake()
    {
        controls = new InputApp();
        controls.Player.Movement.performed += ctx => getAxis = ctx.ReadValue<float>();
        controls.Player.Movement.canceled += ctx =>
        {
            getAxis = 0;
            anim.SetBool("Run", false);
            anim.SetBool("Walk", false);
        };
        controls.Player.Run.performed += ctx => onRun = true;
        controls.Player.Run.canceled += ctx =>
        {
            onRun = false;
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
        JumpHold();
        if (onRun && getAxis != 0)
        {
            Run();
        }
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
