using UnityEngine;

public class BarSpinTrickScript : MonoBehaviour, ITrick
{
    //Bar spin trick damage
    public float trickDmg => 1f;
    //Base damage of the trick without the multiplier
    public float trickBaseDmg => 1f;
    //Bar spin trick knockback
    public float trickKnockback => 2f;
    //Trick animation parameter name.
    public string trickParam => "BarSpin";
    //Function to make the trick perform and deal damage to the enemy
    public float TrickPerformed(float dmgMult)
    {
        return trickBaseDmg * dmgMult;
    }
}
