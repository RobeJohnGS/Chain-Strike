using UnityEngine;

public interface ITrick
{
    //Trick damage after the player's trick multiplier to it.
    float trickDmg{ get;}
    //Tricks base damage before the player's trick multiplier.
    float trickBaseDmg{ get;}
    //Trick knockback applied to the enemy.
    float trickKnockback { get; }
    //Trick animation parameter name
    string trickParam { get; }
    //Trick performed function to deal damage to the enemy
    float TrickPerformed(float dmgMult);
}
