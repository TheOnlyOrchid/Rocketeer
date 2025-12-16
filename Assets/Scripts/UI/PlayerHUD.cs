using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    [Header("Health UI")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text healthText;   // optional

    [Header("Score UI")]
    [SerializeField] private TMP_Text scoreText;

    private void OnEnable()
    {
        Player.OnStatsChanged += UpdateHUD;
        UpdateHUD();
    }

    private void OnDisable()
    {
        Player.OnStatsChanged -= UpdateHUD;
    }

    private void UpdateHUD()
    {
        // Health bar
        if (healthSlider != null)
        {
            healthSlider.maxValue = Player.MaxHealth;
            healthSlider.value = Player.Health;
        }

        // Health label
        if (healthText != null)
        {
            healthText.text = $"{Player.Health}/{Player.MaxHealth}";
        }

        // Score label
        if (scoreText != null)
        {
            scoreText.text = Player.Score.ToString();
        }
    }
}
