using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    private static Dictionary<int, int> layerDamage;

    private void Awake()
    {
        if (layerDamage == null)
        {
            layerDamage = new Dictionary<int, int>
            {
                { LayerMask.NameToLayer("Benign"),         0 },
                { LayerMask.NameToLayer("Enemy"),          1 },
                { LayerMask.NameToLayer("Projectile"),     1 },
                { LayerMask.NameToLayer("Scenery"),        1 },
                { LayerMask.NameToLayer("BossProjectile"), 2 }
            };
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleCollision(other.gameObject);
    }

    private void HandleCollision(GameObject other)
    {
        /**
         *  order: collectible -> goal -> damage layers -> not handled
         **/

        Collectible collectible = other.GetComponent<Collectible>();
        if (collectible != null)
        {
            UnityEngine.Debug.Log("Collectible picked up");
            collectible.Collect();
            return;
        }

        DamageDealer dealer = other.GetComponent<DamageDealer>();
        if (dealer != null)
        {
            dealer.DealDamage();
            return;
        }

        int layer = other.layer;

        if (layer == LayerMask.NameToLayer("Goal"))
        {
            SceneController.nextScene();
        }
        else if (layerDamage.TryGetValue(layer, out int damage))
        {
            if (damage > 0)
            {
                Player.ApplyDamage(damage);
            }
        }
        else
        {
            Debug.LogWarning($"Collided with unhandled layer: {LayerMask.LayerToName(layer)}");
        }
    }
}
