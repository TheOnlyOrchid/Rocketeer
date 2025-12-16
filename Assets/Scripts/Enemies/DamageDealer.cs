using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float damageAmount = 1f;
    [Tooltip("Destroy this GameObject after successfully damaging the player.")]
    [SerializeField] private bool destroyOnHit = false;
    [Tooltip("Minimum time between repeated hits when colliders stay overlapped.")]
    [SerializeField] private float repeatDelay = 0.15f;

    private float nextDamageTime;

    public float DamageAmount => damageAmount;

    public void DealDamage()
    {
        if (Time.time < nextDamageTime) return;

        Player.ApplyDamage(damageAmount);
        nextDamageTime = Time.time + Mathf.Max(0f, repeatDelay);

        if (destroyOnHit)
        {
            Destroy(gameObject);
        }
    }

    public void ResetCooldown()
    {
        nextDamageTime = Time.time + Mathf.Max(0f, repeatDelay);
    }
}
