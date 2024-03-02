using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public Text ScoreText;
    public PlayerStats playerstats;

    public void TakeDamage(float amount)
    {
        health -= amount;
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
