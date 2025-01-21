using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerControls playerControls;
    [SerializeField] CameraControls cameraControls;
    [SerializeField] TrickScript trickControls;

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
        bikeGroundControlsActions.Trick3.performed += _ => trickControls.Trick3();

        cameraControlsActions.MouseX.performed += ctx => mouseInputManager.x = ctx.ReadValue<float>();
        cameraControlsActions.MouseY.performed += ctx => mouseInputManager.y = ctx.ReadValue<float>();
    }

    private void Update()
    {
        bikeGroundControlsActions.Movement.performed += ctx => wasdInputManager = ctx.ReadValue<Vector2>();
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
