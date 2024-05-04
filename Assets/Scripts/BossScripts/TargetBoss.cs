using UnityEngine;
using UnityEngine.UI;

public class TargetBoss : MonoBehaviour
{
    public float health = 500f;
    public Text ScoreText;
    public PlayerStats playerstats;
    public HealthBar healthBar;

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.SetHealth(health);

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        playerstats.score++;
        ScoreText.text = playerstats.score.ToString();
        Destroy(gameObject);
    }
}
