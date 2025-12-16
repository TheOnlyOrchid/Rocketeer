using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Collectible Settings")]
    [SerializeField] private float healAmount = 0f;
    [SerializeField] private int scoreValue = 1;
    [SerializeField] private bool destroyOnCollect = true;

    public void Collect()
    {
        if (healAmount > 0f)
        {
            Player.Heal(healAmount);
        }

        if (scoreValue != 0)
        {
            Player.AddScore(scoreValue);
        }


        if (destroyOnCollect)
        {
            Destroy(gameObject);
        }
    }
}
