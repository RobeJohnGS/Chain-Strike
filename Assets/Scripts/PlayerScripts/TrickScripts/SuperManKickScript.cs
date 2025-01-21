using UnityEngine;

public class SuperManKickScript : MonoBehaviour, ITrick
{
    //Superman Kick trick damage
    public float trickDmg => 2f;
    //Base damage of the trick without the multiplier
    public float trickBaseDmg => 2f;
    //Superman Kick trick knockback
    public float trickKnockback => 4f;
    //Trick animation parameter name.
    public string trickParam => "SuperManKick";
    //Function to make the trick perform and deal damage to the enemy
    public float TrickPerformed(float dmgMult)
    {
        return trickBaseDmg * dmgMult;
    }
}
