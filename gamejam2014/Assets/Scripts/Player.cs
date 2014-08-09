using UnityEngine;
using System.Collections;

public class Player {

    public int currentHP;
    public int maxHP;

    private int money;

    public int currentEngine;
    public int maxEngine;

    public Player(int hp, int engine){
        maxHP = currentHP = hp;
        money = 0;

        maxEngine = engine;
        currentEngine = 0;
    }

    public float getHpFactor()
    {
        return (float)(currentHP) / maxHP;
    }

    public float getEngineFactor()
    {
        return (float)(currentEngine) / maxEngine;
    }

    public void addEngine(int e)
    {
        currentEngine += e;
        if (currentEngine >= maxEngine)
        {
            currentEngine = maxEngine;
        }
    }

    public int getEnginePerTick()
    {
        return 5;
    }

    public bool isEngineFilled()
    {
        return currentEngine == maxEngine;
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

    public int getMoney()
    {
        return money;
    }

    public void addMoney(int m)
    {
        money += m;
    }

    public void removeMoney(int m)
    {
        money += m;
    }
}
