using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SimpleProjectile projectilePrefab;
    [SerializeField] private Transform firePoint;

    [Header("Timing")]
    [SerializeField] private float firstShotDelay = 0.75f;
    [SerializeField] private float shotInterval = 1.5f;

    [Header("Targeting")]
    [SerializeField] private float projectileSpeed = 7.5f;
    [SerializeField] private float detectionRange = 14f;

    private Transform target;
    private float shotTimer;

    private void Awake()
    {
        shotTimer = firstShotDelay;
        if (firePoint == null)
        {
            firePoint = transform;
        }
    }

    private void Update()
    {
        AcquireTargetIfNeeded();
        if (target == null) return;

        Vector2 toTarget = target.position - firePoint.position;
        if (toTarget.sqrMagnitude > detectionRange * detectionRange) return;

        shotTimer -= Time.deltaTime;
        if (shotTimer <= 0f)
        {
            Shoot(toTarget.normalized);
            shotTimer = Mathf.Max(0.05f, shotInterval);
        }
    }

    private void Shoot(Vector2 direction)
    {
        if (projectilePrefab == null) return;

        SimpleProjectile proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        proj.Launch(direction * projectileSpeed);

        DamageDealer dealer = proj.GetComponent<DamageDealer>();
        if (dealer != null)
        {
            dealer.ResetCooldown();
        }
    }

    private void AcquireTargetIfNeeded()
    {
        if (target != null && target.gameObject.activeInHierarchy) return;

        Player playerComponent = FindObjectOfType<Player>();
        if (playerComponent != null)
        {
            target = playerComponent.transform;
        }
    }
}
