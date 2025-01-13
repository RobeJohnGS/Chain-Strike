using Cinemachine;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    

    //Sensitivity x and sensitivity y
    [SerializeField] float sensX;
    [SerializeField] float sensY;
    float mouseX;
    float mouseY;

    //The game object that the camera looks at and follows
    [Header("Camera Objects")]
    [SerializeField] public GameObject cameraFollow;
    [SerializeField] CinemachineVirtualCamera mainCam;
    [SerializeField] CinemachineVirtualCamera aimCam;

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        cameraFollow.transform.rotation *= Quaternion.AngleAxis(mouseX, Vector3.up);
        cameraFollow.transform.rotation *= Quaternion.AngleAxis(mouseY, Vector3.right);
        var angles = cameraFollow.transform.localEulerAngles;
        angles.z = 0;
        var angle = cameraFollow.transform.localEulerAngles.x;

        if (angle > 180 && angle < 340)
        {
            angles.x = 340;
        }else if (angle < 180 && angle > 40)
        {
            angles.x = 40;
        }

        cameraFollow.transform.localEulerAngles = angles;
        
    }

    public void AimPressed(bool pressed)
    {
        aimCam.enabled = pressed;
        mainCam.enabled = !pressed;
    }
    

    public void RecieveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensX;
        mouseY = mouseInput.y * -sensY;
    }
}
