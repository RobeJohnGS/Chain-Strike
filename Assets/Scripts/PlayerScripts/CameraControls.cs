using Cinemachine;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    

    //Sensitivity x and sensitivity y
    [SerializeField] float sensX;
    [SerializeField] float sensY;
    //mouseX input
    float mouseX;
    //mouseY input
    float mouseY;

    //The game object that the camera looks at and follows
    [Header("Camera Objects")]
    [SerializeField] public GameObject cameraFollow;
    //Main Camera to follow the player
    [SerializeField] CinemachineVirtualCamera mainCam;
    //Camera used for aiming
    [SerializeField] CinemachineVirtualCamera aimCam;

    private void Update()
    {
        //Locks the cursor to the center of the screen and makes it invisible
        Cursor.lockState = CursorLockMode.Locked;

        //Rotates the camera follow object according to the mouseX and mouseY input
        cameraFollow.transform.rotation *= Quaternion.AngleAxis(mouseX, Vector3.up);
        cameraFollow.transform.rotation *= Quaternion.AngleAxis(mouseY, Vector3.right);
        //Angle of the camera
        var angles = cameraFollow.transform.localEulerAngles;
        //Sets the z of camera to 0 because it doesnt need to be accounted for
        angles.z = 0;
        var angle = cameraFollow.transform.localEulerAngles.x;

        //Clamping of the camera
        if (angle > 180 && angle < 340)
        {
            angles.x = 340;
        }else if (angle < 180 && angle > 40)
        {
            angles.x = 40;
        }
        //transform the camera based on the player and mouse input
        cameraFollow.transform.localEulerAngles = angles;
        
    }

    //If the aim button is pressed, disable the main camera and enable the aim camera
    //the pressed parameter is if the button is pressed or not
    public void AimPressed(bool pressed)
    {
        aimCam.enabled = pressed;
        mainCam.enabled = !pressed;
    }
    
    //Function used in the input manager that applies the mouse InputAction to the vector2
    public void RecieveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensX;
        mouseY = mouseInput.y * -sensY;
    }
}
