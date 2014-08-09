using UnityEngine;
using System.Collections;

public class Player {

    public int currentHP;
    public int maxHP;


    public Player(int hp){
        maxHP = currentHP = hp;
    }

    public float getHpFactor()
    {
        return (float)(currentHP) / maxHP;
    }

    public int getHpPercent()
    {
        return (int)(getHpFactor() * 100);
    }

    public void addHP(int hp){
        currentHP += hp;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

    public void removeHP(int hp)
    {
        currentHP -= hp;
        if (currentHP <= 0)
        {
            currentHP = 0;
            // TODO call game over event
        }
    }
}
