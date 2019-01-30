using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    
    private double maxHealth = 1000;
    [SerializeField]
    private double currentHealth;
    private double damagePerFrame = 0.5;
    
    private double maxMana = 600;
    [SerializeField]
    private double currentMana = 400;
    private double manaPerFrame = 0.1;
    [SerializeField]
    private bool isDead = false;
    private double healthRestored = 100;
    private double manaSpent = 10;
    public Text health;
    public Text mana;
    public Text screen;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        //screen.text = "";
        if(currentHealth<=0)
        {
            currentHealth = 0;
            isDead = true;
            screen.text = "Game over";
            health.text = "";
            mana.text = "";
        }
        else
        {
            if(currentHealth-damagePerFrame<0)
            {
                currentHealth = 0;
                isDead = true;
                screen.text = "Game over";
                health.text = "";
                mana.text = "";
            }
            else
            {
                currentHealth -= damagePerFrame;
                health.text = "Health: " + currentHealth.ToString("0");
                screen.text = "";
            }
        }
        if (currentMana + manaPerFrame > maxMana && isDead==false)
        {
            currentMana = maxMana;
            mana.text = "Mana: " + currentMana.ToString("0");
            screen.text = "";
        }
        else
        {
            if (!isDead)
            {
                if (currentMana < 0)
                {
                    currentMana = 0;
                    mana.text = "Mana: " + currentMana.ToString("0");
                }
                else
                {
                    currentMana += manaPerFrame;
                    mana.text = "Mana: " + currentMana.ToString("0");
                }
            }
        }
       
    }

    private void LateUpdate() //I used GetKeyUp because if it was just GetKey it would be used multiple times from a single press
    {
       if (Input.GetKeyUp(KeyCode.Alpha1)||Input.GetKeyUp(KeyCode.Keypad1) && !isDead) 
        {
            if(currentMana>=manaSpent)
            {
                if(currentHealth+healthRestored>=maxHealth)
                {
                    currentHealth = maxHealth;
                    currentMana -= manaSpent;
                    health.text = "Health: " + currentHealth.ToString("0");
                    mana.text = "Mana: " + currentMana.ToString("0");
                }
                else
                {
                    currentHealth += healthRestored;
                    currentMana -= manaSpent;
                    health.text = "Health: " + currentHealth.ToString("0");
                    mana.text = "Mana: " + currentMana.ToString("0");
                }
            }
            if(currentMana<manaSpent)
            {
                screen.text = "Not enough mana";
            }
        }
    }
}
