using UnityEngine;

public class TailWhipScript : MonoBehaviour, ITrick
{
    //Tailwhip trick damage
    public float trickDmg => 5f;
    //Base damage of the trick without the multiplier
    public float trickBaseDmg => 5f;
    //Tail whip trick knockback
    public float trickKnockback { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    //Trick animation parameter name.
    public string trickParam { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    //Function to make the trick perform and deal damage to the enemy
    public float TrickPerformed(float dmgMult)
    {
        return trickBaseDmg * dmgMult;
    }
}
