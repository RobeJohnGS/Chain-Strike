using UnityEngine;
using UnityEngine.Animations;

public class TrickScript : MonoBehaviour
{
    [Header("Player Animations")]
    [SerializeField] Animator playerAnimator;
    [SerializeField] string parameter1;

    [Header("Player Attribues")]
    [SerializeField] PlayerControls playerControls;
    public void Trick1()
    {
        Debug.Log("Trick1");
        playerAnimator.SetTrigger(parameter1);
    }
}
