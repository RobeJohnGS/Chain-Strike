using UnityEngine;

public class RailGrindScript : MonoBehaviour
{
    [SerializeField] string playerTag;
    [SerializeField] GameObject playerGO;
    [SerializeField] float railSpeed;
    private bool grinding;

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            grinding = true;
            RailGrind();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        grinding = false;
    }

    public void RailGrind()
    {
        PlayerControls playerControls = playerGO.GetComponent<PlayerControls>();
        Rigidbody playerRB = playerGO.GetComponent<Rigidbody>();
        Transform playerTransform = playerGO.transform;
        if (grinding)
        {
            if (!playerControls.isGrounded)
            {
                while (grinding) { }
                    playerTransform.position += new Vector3(playerRB.linearVelocity.x * railSpeed * Time.deltaTime, 0, playerRB.linearVelocity.z * railSpeed * Time.deltaTime);
                }
            }
        }
    }
}
