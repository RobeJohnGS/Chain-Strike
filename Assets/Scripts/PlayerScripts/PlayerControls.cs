using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField] CharacterController characterController;
    [SerializeField] float playerBikeSpeed = 3f;
    Vector2 wasdInput;
    [SerializeField] GameObject cameraFollow;

    [Header("Gravity/Jumping")]
    [SerializeField] float jumpHeight = 3f;
    bool jumped = false;
    [SerializeField] float gravity = -9.81f;
    //Vertical velocity
    Vector3 vVelocity = Vector3.zero;
    [SerializeField] LayerMask groundMask;
    bool isGrounded;

    private void Update()
    {
        //Vector3 hVelocity = (transform.right * wasdInput.x + transform.forward * wasdInput.y) * playerBikeSpeed;
        //characterController.Move(hVelocity * Time.deltaTime);

        Vector3 pos = (cameraFollow.transform.forward * wasdInput.y * playerBikeSpeed) +(cameraFollow.transform.right * wasdInput.x * playerBikeSpeed);
        characterController.Move(pos * Time.deltaTime);

        isGrounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 0.5f), 0.1f, groundMask);
        if (isGrounded)
        {
            vVelocity.y = 0;
        }

        if(jumped)
        {
            if (isGrounded)
            {
                vVelocity.y = Mathf.Sqrt(-2 * jumpHeight * gravity);
            }
            jumped = false;
        }

        vVelocity.y += gravity * Time.deltaTime;
        characterController.Move(vVelocity * Time.deltaTime);
    }

    public void ChangePlayerRotation(float cameraFollowRot)
    {
        transform.rotation = Quaternion.Euler(0, cameraFollowRot, 0);
    }

    public void RecieveInput(Vector2 wasdParam)
    {
        wasdInput = wasdParam;
    }

    public void OnJumpPressed()
    {
        jumped = true;
    }


    private void OnDrawGizmos()
    {
        
    }

}
