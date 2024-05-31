using UnityEngine;
using UnityEngine.UI;

public class TargetBoss : MonoBehaviour
{
    public float health;
    public Text ScoreText;
    public PlayerStats playerstats;
    public HealthBar healthBar;
    public Animator animator;

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
        animator.SetTrigger("Dead");    
    }

    void Dissapear()
    {
        Destroy(gameObject);
    }
}
