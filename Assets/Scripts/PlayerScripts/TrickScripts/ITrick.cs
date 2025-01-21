using UnityEngine;

public interface ITrick
{
    float trickDmg{ get;}
    float trickBaseDmg{ get;}
    float trickKnockback { get; }
    string trickParam { get; }
    float TrickPerformed(float dmgMult);
}
