using UnityEngine;
using UnityEngine.Animations;

public class PlayerAnimationHandler : MonoBehaviour
{
    [Header("Player Animation")]
    [SerializeField] Animator playerAnimator;
    [Header("Tricks")]
    //Ground Trick 1
    [SerializeField] TrickScript barSpin;
    //Ground Trick 2
    [SerializeField] TrickScript tireTap180;
    //Air Trick 1
    [SerializeField] TrickScript tailWhip;
    //Air Trick 2
    [SerializeField] TrickScript supermanKick;
    //Rail Trick 1
    [SerializeField] TrickScript railSpark;
    //Rail Trick 2
    [SerializeField] TrickScript railTrick2;

    [Header("Player Attribues")]
    [SerializeField] PlayerControls playerControls;
    

    private void Update()
    {
        playerAnimator.SetBool("RailGrinding", playerControls.playerState == PlayerControls.PlayerState.ONRAIL);
    }
    //West Button
    public void Trick1()
    {
        switch (playerControls.playerState)
        {
            case PlayerControls.PlayerState.INAIR:
                playerAnimator.SetTrigger(tailWhip.trickData.trickParam);
                Debug.Log("Air Trick1");
                break;
            case PlayerControls.PlayerState.ONGROUND:
                playerAnimator.SetTrigger(barSpin.trickData.trickParam);
                Debug.Log("Ground Trick1");
                break;
            case PlayerControls.PlayerState.ONRAIL:
                playerAnimator.SetBool(railSpark.trickData.trickParam, true);
                Debug.Log("Rail Trick1");
                break;
        }
        
    }

    public void Trick2()
    {
        switch (playerControls.playerState)
        {
            case PlayerControls.PlayerState.INAIR:
                playerAnimator.SetTrigger(supermanKick.trickData.trickParam);
                Debug.Log("Air Trick2");
                break;
            case PlayerControls.PlayerState.ONGROUND:
                playerAnimator.SetTrigger(tireTap180.trickData.trickParam);
                Debug.Log("Ground Trick2");
                break;
            case PlayerControls.PlayerState.ONRAIL:
                playerAnimator.SetTrigger(railTrick2.trickData.trickParam);
                Debug.Log("Rail Trick2");
                break;
        }

    }
}
