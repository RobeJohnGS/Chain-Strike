using UnityEngine;
using UnityEngine.Animations;

public class ChaserAnimationHandler : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void AttackAnimation()
    {
        animator.SetTrigger("ChaserAttack");
    }
}
