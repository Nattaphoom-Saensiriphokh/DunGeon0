using UnityEngine.InputSystem;
using UnityEngine;

public class GatherInput : MonoBehaviour
{
    private Controls myControl;
    public float valueX;
    public bool jumpInput;
    public bool tryAttack;

    public void Awake()
    {
        myControl = new Controls();
    }
    private void OnEnable()
    {
        myControl.Player.Move.performed += StartMove;
        myControl.Player.Move.canceled += StopMove;
        myControl.Player.Jump.performed += JumpStart;
        myControl.Player.Jump.canceled += JumpStop;
        myControl.Player.Attack.performed += TryToAttack;
        myControl.Player.Attack.canceled += StopTryToAttack;

        myControl.Player.Enable();
    }
    private void OnDisable()
    {
        myControl.Player.Move.performed -= StartMove;
        myControl.Player.Move.canceled -= StopMove;
        myControl.Player.Jump.performed -= JumpStart;
        myControl.Player.Jump.canceled -= JumpStop;
        myControl.Player.Attack.performed -= TryToAttack;
        myControl.Player.Attack.canceled -= StopTryToAttack;

        myControl.Player.Disable();
        //myControl.Disable();
    }
    private void JumpStart(InputAction.CallbackContext ctx)
    {
        jumpInput = true;
    }
    private void JumpStop(InputAction.CallbackContext ctx)
    {
        jumpInput = false;
    }
    private void StartMove(InputAction.CallbackContext ctx)
    {
        valueX = ctx.ReadValue<Vector2>().x;
    }
    private void StopMove(InputAction.CallbackContext ctx)
    {
        valueX = 0;
    }
    private void TryToAttack(InputAction.CallbackContext ctx)
    {
        tryAttack = true;
    }
    private void StopTryToAttack(InputAction.CallbackContext ctx)
    {
        tryAttack = false;
    }
    public void DisableControls()
    {
        myControl.Player.Move.performed -= StartMove;
        myControl.Player.Move.canceled -= StopMove;

        myControl.Player.Jump.performed -= JumpStart;
        myControl.Player.Jump.canceled -= JumpStop;

        myControl.Player.Attack.performed -= TryToAttack;
        myControl.Player.Attack.canceled -= StopTryToAttack;

        myControl.Player.Disable();
        valueX = 0;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
