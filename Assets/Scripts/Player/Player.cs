using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Base Health Settings")]
    [SerializeField] private float baseMaxHealth = 3f;
    [SerializeField] private int startScore = 0;

    [Header("Score Buffs")]
    [Tooltip("How much score is needed for +1 max HP.")]
    [SerializeField] private int scorePerMaxHealthIncrease = 10;

    public static float Health { get; private set; }
    public static float MaxHealth { get; private set; }
    public static int Score { get; private set; }

    // Keep the base and rule in static so static methods can use them.
    private static float _baseMaxHealth;
    private static int _scorePerMaxHealthIncrease;

    public static event Action OnStatsChanged;

    private void Awake()
    {
        _baseMaxHealth = baseMaxHealth;
        _scorePerMaxHealthIncrease = Mathf.Max(1, scorePerMaxHealthIncrease);

        Score = Mathf.Max(0, startScore);

        RecalculateMaxHealth();
        Health = MaxHealth; // start fully healed

        OnStatsChanged?.Invoke();
    }

    public static void ApplyDamage(float damageAmount)
    {
        if (damageAmount <= 0f) return;

        if (Health - damageAmount <= 0f)
        {
            Health = 0f;
            OnStatsChanged?.Invoke();
            KillPlayer();
            return;
        }

        Health -= damageAmount;
        Debug.Log("Player took damage. Health: " + Health);

        OnStatsChanged?.Invoke();
    }

    public static void Heal(float healAmount)
    {
        if (healAmount <= 0f) return;

        Health = Mathf.Min(Health + healAmount, MaxHealth);
        Debug.Log("Player healed. Health: " + Health);

        OnStatsChanged?.Invoke();
    }

    public static void AddScore(int amount)
    {
        if (amount == 0) return;

        Score += amount;
        Debug.Log("Score changed. New score: " + Score);

        RecalculateMaxHealth();

        OnStatsChanged?.Invoke();
    }

    private static void RecalculateMaxHealth()
    {
        int bonusHpFromScore = Score / _scorePerMaxHealthIncrease;

        float newMaxHealth = _baseMaxHealth + bonusHpFromScore;

        if (Math.Abs(newMaxHealth - MaxHealth) > Mathf.Epsilon)
        {
            MaxHealth = newMaxHealth;

            Health = MaxHealth;
        }
    }

    private static void KillPlayer()
    {
        int deathSceneIndex = 1;
        Debug.Log("Player Has Died");
        SceneController.setScene(1);
    }
}
