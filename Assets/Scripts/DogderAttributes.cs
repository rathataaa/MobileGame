using Unity.VisualScripting;
using UnityEngine;

public class DogderAttributes
{
    private int health;
    private int maxHealth;

    private int score;

    public DogderAttributes(int curHealth, int curMaxHealth, int curScore)
    {
        health = curHealth;
        maxHealth = curMaxHealth;
        score = curScore;
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetScore()
    {
        return score;
    }

   public void SettingHealth(int newHealth)
    {
        health = newHealth;
    }

   public void SettingScore(int newScore)
    {
        score = newScore;
    }







}   
