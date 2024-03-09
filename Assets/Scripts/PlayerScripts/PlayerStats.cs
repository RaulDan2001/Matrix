using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Slider slider;
    public int score = 0;

    public int MaxHealth = 100;
    public int CurrentHealth;

    public void Start()
    {
        CurrentHealth = MaxHealth;
        SetMaxHealth(MaxHealth);
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
