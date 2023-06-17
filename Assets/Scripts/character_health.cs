using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_health : MonoBehaviour
{
    public int max_health = 10;
    private int current_health;

    private void Start()
    {
        current_health = max_health;
    }

    public void take_damage(int damage_amount)
    {
        Debug.Log(string.Format("HEALT: Tengo {0} vida", current_health));
        current_health -= damage_amount;
        Debug.Log(string.Format("HEALT: Me queda {0} vida", current_health));
        if (current_health <= 0)
        {
            // sonidos de morir
            current_health = 0;
            Debug.Log(string.Format("HEALT: Me corregi a {0} vida", current_health));
            player_die();
        }
    }

    public void heal_player(int heal_amount)
    {
        current_health += heal_amount;
        if(current_health > max_health)
        {
            current_health = max_health;
            // sonidos de recuperar vida
        }
    }

    public void player_die()
    {
        Debug.Log("HEALT: ya no tengo vidavida");
    }
}
