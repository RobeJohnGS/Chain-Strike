using UnityEngine;

public class CameraControls : MonoBehaviour
{
    //Testing the camera look at rotation
    [SerializeField] public GameObject cameraFollow;

    //Sensitivity x and sensitivity y
    [SerializeField][Range(0.1f, 1f)] float sensX;
    [SerializeField] float sensY = 0.5f;
    float mouseX;
    float mouseY;

    private void Update()
    {

        cameraFollow.transform.rotation *= Quaternion.AngleAxis(mouseX * sensX, Vector3.up);
        cameraFollow.transform.rotation *= Quaternion.AngleAxis(mouseY * sensY, Vector3.right);
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
    

    public void RecieveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensX;
        mouseY = mouseInput.y * sensY;
    }
}
