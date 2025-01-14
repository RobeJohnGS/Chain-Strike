using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class PlayerControls : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] GameObject cameraFollow;
    [SerializeField] Rigidbody rb;

    [Header("Controls")]
    [SerializeField] float playerBikeSpeed = 3f;
    [SerializeField] float playerBikeRotRate = 3f;
    Vector2 wasdInput;
    [SerializeField] public bool canMove;

    [Header("Rail Attributes")]
    public bool onRail;
    [SerializeField] float grindSpeed;
    [SerializeField] float heightOffset;
    float timeForFullSpline;
    float elapsedTime;
    [SerializeField] float lerpSpeed = 10f;
    [SerializeField] RailGrindScript railGrindScript;
    

    [Header("Jumping")]
    [SerializeField] float jumpHeight;
    bool jumped = false;
    //Vertical velocity
    [SerializeField] LayerMask groundMask;
    public bool isGrounded;

    private void FixedUpdate()
    {
        if (onRail)
        {
            MovePlayerAlongRail();
        }
    }

    private void Update()
    {
        //Creates a sphere at the bottom of the center of the bike, if it is overlapping with the ground, then you can jump.
        isGrounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), 0.1f, groundMask);

        if (onRail)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }
        /*Creates a vector 3 to move the player with these properites
         * The Vector input takes the direction the camera is looking (except the Y axis) and if the player is presssing W A S or D then it multiplies that input press with the bike speed and multiplies that by the camera direction to make the player go the way the camera is facing.
         * I did it this way because before it would see if the camera was facing up or down and try to force the player into the ground or air.
         */
        if (canMove) { 
            Vector3 pos = (new Vector3(cameraFollow.transform.forward.x, 0, cameraFollow.transform.forward.z) * wasdInput.y * playerBikeSpeed) + (new Vector3(cameraFollow.transform.right.x, 0, cameraFollow.transform.right.z) * wasdInput.x * playerBikeSpeed);
            //Takes the players position, adds the complicated vector and multiplies that by Time.deltaTime to move the bike.
            transform.position += pos * Time.deltaTime;

            //Rotate player to face pressed button direction
            RotatePlayer();
        }
        

        //If the player has jumped and they are grounded, then it adds the jumpHeight * 20 to the force making it go up.
        if(jumped)
        {
            if (isGrounded || onRail)
            {
                rb.AddForce(new Vector3(0, jumpHeight * 20, 0), ForceMode.Impulse);
            }
            //After the player presses jump, then it resets so they can again when they are on the ground.
            jumped = false;
        }
    }

    //Function to rotate the actual player model/bike model.
    private void RotatePlayer()
    {
        //Takes the forward direction the camera is facing
        Vector3 cameraForward = cameraFollow.transform.forward;
        //Sets the y to 0 so that the direction is flat
        cameraForward.y = 0;
        //NORMALIZE the vector
        cameraForward.Normalize();

        //Takes the right direction of the camera
        Vector3 cameraRight = cameraFollow.transform.right;
        //Sets the y to 0 so that the direction is flat
        cameraRight.y = 0;
        //NORMALIZE the vector
        cameraRight.Normalize();

        //Sets the direction the player is going to face after the camera moves and the input is pressed.
        Vector3 newDir = (cameraRight * wasdInput.x + cameraForward * wasdInput.y).normalized;

        //Will comment later
        if (newDir.sqrMagnitude > 0)
        {
            float rotAngle = Mathf.Atan2(newDir.x, newDir.z) * Mathf.Rad2Deg;
            Quaternion targetRot = Quaternion.Euler(0, rotAngle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * playerBikeRotRate);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Rail")
        {
            onRail = true;
            railGrindScript = other.gameObject.GetComponent<RailGrindScript>();
            CalculateAndSetRailPosition();
        }
    }

    private void CalculateAndSetRailPosition()
    {
        timeForFullSpline = railGrindScript.totalSplineLength / grindSpeed;
        Vector3 splinePoint;
        float normalisedTime = railGrindScript.CalculateTargetRailPoint(transform.position, out splinePoint);
        elapsedTime = timeForFullSpline * normalisedTime;
        float3 pos, forward, up;
        SplineUtility.Evaluate(railGrindScript.railSpline.Spline, normalisedTime, out pos, out forward, out up);
        railGrindScript.CalculateDirection(forward, transform.forward);
        transform.position = splinePoint + (transform.up * heightOffset);
    }

    private void ExitOffRail()
    {
        onRail = false;
        railGrindScript = null;
        transform.position += transform.forward * 1;
    }

    private void MovePlayerAlongRail()
    {
        if (railGrindScript != null && onRail)
        {
            float progress = elapsedTime / timeForFullSpline;
            if (progress < 0 || progress > 1f)
            {
                ExitOffRail();
                return;
            }
            float nextTimeNormalised;
            if (railGrindScript.normalDir)
            {
                nextTimeNormalised = (elapsedTime + Time.deltaTime) / timeForFullSpline;
            }
            else
            {
                nextTimeNormalised = (elapsedTime - Time.deltaTime) / timeForFullSpline;
            }

            float3 pos, tangent, up;
            float3 nextPosFloat, nextTan, nextUp;
            SplineUtility.Evaluate(railGrindScript.railSpline.Spline, progress, out pos, out tangent, out up);
            SplineUtility.Evaluate(railGrindScript.railSpline.Spline, nextTimeNormalised, out nextPosFloat, out nextTan, out nextUp);

            Vector3 worldPos = railGrindScript.LocalToWorldConversion(pos);
            Vector3 nextPos = railGrindScript.LocalToWorldConversion(nextPosFloat);

            transform.position = worldPos + (transform.up * heightOffset);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(nextPos - worldPos), lerpSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.up, up) * transform.rotation, lerpSpeed * Time.deltaTime);

            if (railGrindScript.normalDir)
            {
                elapsedTime += Time.deltaTime;
            }
            else
            {
                elapsedTime -= Time.deltaTime;
            }
        }
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
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), 0.1f);
        Gizmos.DrawCube(gameObject.GetComponent<Rigidbody>().centerOfMass, Vector3.one / 10);
    }

}
