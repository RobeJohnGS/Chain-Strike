using UnityEngine;
using UnityEngine.Animations;

public class TrickScript : MonoBehaviour
{
    [Header("Player Animations")]
    [SerializeField] Animator playerAnimator;
    [SerializeField] string airTrick1;
    [SerializeField] string airTrick2;
    [SerializeField] string airTrick3;

    [SerializeField] string groundTrick1;
    [SerializeField] string groundTrick2;
    [SerializeField] string groundTrick3;

    [SerializeField] string railTrick1;
    [SerializeField] string railTrick2;
    [SerializeField] string railTrick3;

    [Header("Player Attribues")]
    [SerializeField] PlayerControls playerControls;
    public enum PlayerState
    {
        INAIR,
        ONGROUND,
        ONRAIL
    }
    public PlayerState playerState;

    private void Update()
    {
        if (playerControls.isGrounded)
        {
            playerState = PlayerState.ONGROUND;
        }else if (!playerControls.isGrounded && !playerControls.onRail)
        {
            playerState = PlayerState.INAIR;
        }
        else if (playerControls.onRail) {
            playerState = PlayerState.ONRAIL;
        }
    }
    //West Button
    public void Trick1()
    {
        switch (playerState)
        {
            case PlayerState.INAIR:
                playerAnimator.SetTrigger(airTrick1);
                Debug.Log("Air Trick1");
                break;
            case PlayerState.ONGROUND:
                playerAnimator.SetTrigger(groundTrick1);
                Debug.Log("Ground Trick1");
                break;
            case PlayerState.ONRAIL:
                playerAnimator.SetTrigger(railTrick1);
                Debug.Log("Rail Trick1");
                break;
        }
        
    }

    public void Trick2()
    {
        switch (playerState)
        {
            case PlayerState.INAIR:
                playerAnimator.SetTrigger(airTrick2);
                Debug.Log("Air Trick2");
                break;
            case PlayerState.ONGROUND:
                playerAnimator.SetTrigger(groundTrick2);
                Debug.Log("Ground Trick2");
                break;
            case PlayerState.ONRAIL:
                playerAnimator.SetTrigger(railTrick2);
                Debug.Log("Rail Trick2");
                break;
        }

    }

    public void Trick3()
    {
        switch (playerState)
        {
            case PlayerState.INAIR:
                playerAnimator.SetTrigger(airTrick3);
                Debug.Log("Air Trick3");
                break;
            case PlayerState.ONGROUND:
                playerAnimator.SetTrigger(groundTrick3);
                Debug.Log("Ground Trick3");
                break;
            case PlayerState.ONRAIL:
                playerAnimator.SetTrigger(railTrick3);
                Debug.Log("Rail Trick3");
                break;
        }

    }
}
