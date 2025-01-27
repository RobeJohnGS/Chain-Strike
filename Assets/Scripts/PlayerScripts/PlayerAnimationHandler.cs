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
    private bool railSparkPressed;
    //Rail Trick 2
    [SerializeField] TrickScript railTrick2;

    [Header("Player Attribues")]
    [SerializeField] PlayerControls playerControls;
    [SerializeField] PlayerManager playerManager;
    

    private void Update()
    {
        //If the player is on a rail and not using the Rail Spark trick, then use the rail grinding animation
        playerAnimator.SetBool("RailGrinding", playerControls.playerState == PlayerControls.PlayerState.ONRAIL && !railSparkPressed);
    }
    //West Button
    public void Trick1()
    {
        switch (playerControls.playerState)
        {
            case PlayerControls.PlayerState.INAIR:
                playerAnimator.SetTrigger(tailWhip.trickData.trickParam);
                playerManager.AddToCombo(tailWhip.trickData.trickPoints, tailWhip.trickData.trickMult);
                Debug.Log("Air Trick1");
                break;
            case PlayerControls.PlayerState.ONGROUND:
                playerAnimator.SetTrigger(barSpin.trickData.trickParam);
                playerManager.AddToCombo(barSpin.trickData.trickPoints, barSpin.trickData.trickMult);
                Debug.Log("Ground Trick1");
                break;
        }
        
    }

    //Function for as long as the Trick 1 button is pressed, continue doing the Rail Spark Trick
    public void RailTrick1(bool isPressed)
    {
        //Bool to keep track if the trick 1 button is being held and the player is on a rail
        bool btnPressedAndOnRail = isPressed && playerControls.playerState == PlayerControls.PlayerState.ONRAIL;
        //Set the rail spark animation parameter to true or false, based on the previous bool.
        playerAnimator.SetBool(railSpark.trickData.trickParam, btnPressedAndOnRail);
        //Set the bool to also reflect if the Trick 1 button is being held and the players on the rail.
        railSparkPressed = btnPressedAndOnRail;
        //If the hitbox's parent is the bike like normal, then it would rotate with the animation, so I set the hitbox parent to the player
        railSpark.gameObject.transform.parent = playerControls.gameObject.transform;
        //Sets the hitbox active
        railSpark.gameObject.SetActive(btnPressedAndOnRail);

    }

    public void Trick2()
    {
        switch (playerControls.playerState)
        {
            case PlayerControls.PlayerState.INAIR:
                playerAnimator.SetTrigger(supermanKick.trickData.trickParam);
                playerManager.AddToCombo(supermanKick.trickData.trickPoints, supermanKick.trickData.trickMult);
                Debug.Log("Air Trick2");
                break;
            case PlayerControls.PlayerState.ONGROUND:
                playerAnimator.SetTrigger(tireTap180.trickData.trickParam);
                playerManager.AddToCombo(tireTap180.trickData.trickPoints, tireTap180.trickData.trickMult);
                Debug.Log("Ground Trick2");
                break;
            case PlayerControls.PlayerState.ONRAIL:
                //The player can only do this trick if they are not rail sparking
                if (!railSparkPressed)
                {
                    playerAnimator.SetTrigger(railTrick2.trickData.trickParam);
                    Debug.Log("Rail Trick2");
                }
                break;
        }

    }
}
