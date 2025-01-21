using UnityEngine;
using UnityEngine.Animations;

public class ControlTrickScript : MonoBehaviour
{
    [Header("Player Animation")]
    [SerializeField] Animator playerAnimator;
    [Header("Tricks")]
    //Ground Trick 1
    [SerializeField] TrickScript barSpin;
    //Ground Trick 2
    [SerializeField] TrickScript groundTrick2;
    //Air Trick 1
    [SerializeField] TrickScript tailWhip;
    //Air Trick 2
    [SerializeField] TrickScript supermanKick;
    //Rail Trick 1
    [SerializeField] TrickScript railTrick1;
    //Rail Trick 2
    [SerializeField] TrickScript railTrick2;

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
                playerAnimator.SetTrigger(tailWhip.trickData.trickParam);
                Debug.Log("Air Trick1");
                break;
            case PlayerState.ONGROUND:
                playerAnimator.SetTrigger(barSpin.trickData.trickParam);
                Debug.Log("Ground Trick1");
                break;
            case PlayerState.ONRAIL:
                playerAnimator.SetTrigger(railTrick1.trickData.trickParam);
                Debug.Log("Rail Trick1");
                break;
        }
        
    }

    public void Trick2()
    {
        switch (playerState)
        {
            case PlayerState.INAIR:
                playerAnimator.SetTrigger(supermanKick.trickData.trickParam);
                Debug.Log("Air Trick2");
                break;
            case PlayerState.ONGROUND:
                playerAnimator.SetTrigger(groundTrick2.trickData.trickParam);
                Debug.Log("Ground Trick2");
                break;
            case PlayerState.ONRAIL:
                playerAnimator.SetTrigger(railTrick2.trickData.trickParam);
                Debug.Log("Rail Trick2");
                break;
        }

    }
}
