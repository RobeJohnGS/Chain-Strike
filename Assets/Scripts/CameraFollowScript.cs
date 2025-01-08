using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 1f, playerTransform.position.z);
    }
}
