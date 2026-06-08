using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider slider;
    [SerializeField] HealthManager playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
        slider.maxValue = playerHealth.GetHealth();
    }

    void Update()
    {
        scoreText.text = scoreKeeper.GetScore().ToString("0000000000");
        // int health = playerHealth.GetHealth();
        slider.value = playerHealth.GetHealth();
    }
}
