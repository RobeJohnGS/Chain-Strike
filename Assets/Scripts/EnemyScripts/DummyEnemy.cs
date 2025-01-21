using UnityEngine;

public class DummyEnemy : MonoBehaviour, IEnemy
{
    public float health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public float damageValue => throw new System.NotImplementedException();

    public void DealDamage()
    {
        throw new System.NotImplementedException();
    }

    public float GetHealth()
    {
        throw new System.NotImplementedException();
    }

    public void SetHealth(float h)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float dmgTaken)
    {
        throw new System.NotImplementedException();
    }
}
