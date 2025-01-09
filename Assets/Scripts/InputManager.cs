using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerControls playerControls;
    [SerializeField] CameraControls cameraControls;

    PlayerInputActions playerIA;
    PlayerInputActions.BikeGroundControlsActions bikeGroundControlsActions;
    PlayerInputActions.CameraControlsActions cameraControlsActions;

    Vector2 wasdInputManager;
    Vector2 mouseInputManager;
    
    private void Awake()
    {
        playerIA = new PlayerInputActions();
        bikeGroundControlsActions = playerIA.BikeGroundControls;
        cameraControlsActions = playerIA.CameraControls;

        bikeGroundControlsActions.Movement.performed += ctx => wasdInputManager = ctx.ReadValue<Vector2>();
        bikeGroundControlsActions.Jump.performed += _ => playerControls.OnJumpPressed();

        cameraControlsActions.MouseX.performed += ctx => mouseInputManager.x = ctx.ReadValue<float>();
        cameraControlsActions.MouseY.performed += ctx => mouseInputManager.y = ctx.ReadValue<float>();
    }

    private void Update()
    {
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
