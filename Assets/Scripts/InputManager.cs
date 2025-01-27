using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerControls playerControls;
    [SerializeField] CameraControls cameraControls;
    [SerializeField] PlayerAnimationHandler trickControls;

    GameManagerScript gameManagerScript;

    PlayerInputActions playerIA;
    PlayerInputActions.BikeGroundControlsActions bikeGroundControlsActions;
    PlayerInputActions.CameraControlsActions cameraControlsActions;
    PlayerInputActions.PlayerControlsActions playerControlsActions;

    Vector2 wasdInputManager;
    Vector2 mouseInputManager;

    private void Awake()
    {
        gameManagerScript = gameObject.GetComponent<GameManagerScript>();
        playerIA = new PlayerInputActions();
        bikeGroundControlsActions = playerIA.BikeGroundControls;
        cameraControlsActions = playerIA.CameraControls;
        playerControlsActions = playerIA.PlayerControls;

        bikeGroundControlsActions.Jump.performed += _ => playerControls.OnJumpPressed();
        //Pause input
        playerControlsActions.Pause.performed += _ => gameManagerScript.PauseGame();
        //Trick Inputs

        bikeGroundControlsActions.Trick1.performed += _ => trickControls.Trick1();
        bikeGroundControlsActions.Trick2.performed += _ => trickControls.Trick2();
    }

    private void Update()
    {
        wasdInputManager = bikeGroundControlsActions.Movement.ReadValue<Vector2>();
        cameraControlsActions.MouseX.performed += ctx => mouseInputManager.x = ctx.ReadValue<float>();
        cameraControlsActions.MouseY.performed += ctx => mouseInputManager.y = ctx.ReadValue<float>();
        trickControls.RailTrick1(bikeGroundControlsActions.Trick1.IsPressed());
        playerControls.RecieveInput(wasdInputManager);
        cameraControls.RecieveInput(mouseInputManager);
        //playerControls.ChangePlayerRotation(cameraControls.cameraFollow.transform.rotation.eulerAngles.y);
        cameraControls.AimPressed(cameraControlsActions.Aim.IsPressed());
    }

    private void OnEnable()
    {
        playerIA.Enable();
    }

    private void OnDisable()
    {
        playerIA.Disable();
    }
}