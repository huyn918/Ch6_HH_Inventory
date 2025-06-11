using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;
    Condition health { get { return uiCondition.health; } }

    [SerializeField]
    public float hpDecayRate;

    private void Update()
    {
        //health.Subtract(hpDecayRate * Time.deltaTime);

        if (health.curValue < 0f)
        {
            Die();
        }
    }
    public void HealHP(float amount)
    {
        health.Add(amount);
    }

    public void Die()
    {
        Debug.Log("플레이어가 죽었다.");
    }
    public void TakeDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
    }

}
