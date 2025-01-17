using UnityEngine;

public class DummyEnemy : MonoBehaviour, IEnemy
{
    public float damageValue => 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerDamageHB"))
        {
            Debug.Log("Take Damage");
            TakeDamage(other.GetComponent<ITrick>().TrickPerformed(1));
        }
    }

    public void DealDamage()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float dmgTaken)
    {
        Debug.Log("Taken: " + dmgTaken);
    }
}
