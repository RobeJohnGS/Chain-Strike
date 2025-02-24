using UnityEngine;
using UnityEngine.Animations;

public class PlayerAnimationHandler : MonoBehaviour
{
    [Header("Player Animation")]
    [SerializeField] Animator playerAnimator;
    public bool animationPlaying;
    [Header("Tricks")]
    //Ground Trick 1
    [SerializeField] TrickScript barSpin;
    //Ground Trick 2
    [SerializeField] TrickScript tireTap180;
    //Air Trick 1
    [SerializeField] TrickScript tailWhip;
    //Air Trick 2
    [SerializeField] TrickScript supermanKick;
    //Rail grinding bool
    [SerializeField] bool railGrinding;
    //Rail Trick 1
    [SerializeField] TrickScript railSpark;
    private bool railSparkPressed;
    //Rail Trick 2
    [SerializeField] TrickScript toothpick;
    public bool toothpickPressed;

    [Header("Player Attribues")]
    [SerializeField] PlayerControls playerControls;
    [SerializeField] PlayerManager playerManager;
    

    private void Update()
    {
        railGrinding = playerControls.playerState == PlayerControls.PlayerState.ONRAIL && (!railSparkPressed || !toothpickPressed);
        Debug.Log("On rail? " + (playerControls.playerState == PlayerControls.PlayerState.ONRAIL) + "\n" + "Rail sparking? " + railSparkPressed + "\n Toothpick pressed? " + toothpickPressed);
        //If the player is on a rail and not using the Rail Spark trick, then use the rail grinding animation
        playerAnimator.SetBool("RailGrinding", railGrinding);
    }
    //West Button
    public void Trick1()
    {
        if (!animationPlaying)
        {
            switch (playerControls.playerState)
            {
                case PlayerControls.PlayerState.INAIR:
                    playerAnimator.SetTrigger(tailWhip.trickData.trickParam);
                    playerManager.AddToCombo(tailWhip);
                    Debug.Log("Air Trick1");
                    break;
                case PlayerControls.PlayerState.ONGROUND:
                    playerAnimator.SetTrigger(barSpin.trickData.trickParam);
                    playerManager.AddToCombo(barSpin);
                    Debug.Log("Ground Trick1");
                    break;
            }
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
        //railSpark.gameObject.transform.parent = playerControls.gameObject.transform;
        //Sets the hitbox active
        railSpark.gameObject.SetActive(btnPressedAndOnRail);

    }

    public void Trick2()
    {
        if (!animationPlaying)
        {
            switch (playerControls.playerState)
            {
                case PlayerControls.PlayerState.INAIR:
                    playerAnimator.SetTrigger(supermanKick.trickData.trickParam);
                    playerManager.AddToCombo(supermanKick);
                    Debug.Log("Air Trick2");
                    break;
                case PlayerControls.PlayerState.ONGROUND:
                    playerAnimator.SetTrigger(tireTap180.trickData.trickParam);
                    playerManager.AddToCombo(tireTap180);
                    Debug.Log("Ground Trick2");
                    break;
                case PlayerControls.PlayerState.ONRAIL:
                    //The player can only do this trick if they are not rail sparking
                    if (!railSparkPressed)
                    {
                        playerAnimator.SetTrigger(toothpick.trickData.trickParam);
                        playerManager.AddToCombo(toothpick);
                        Debug.Log("Rail Trick2");
                    }
                    break;
            }
        }
    }
}
