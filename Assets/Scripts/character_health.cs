using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_health : MonoBehaviour
{
    public int max_health;
    public int current_health;

    public GameObject heart_bar_UI;
    public heart_bar heart_bar;

    public GameObject player;
    public GameObject init_point;

    private void Awake()
    {
        max_health = 10;
        current_health = 10;
        heart_bar = heart_bar_UI.GetComponent<heart_bar>();
        //heart_bar = FindObjectOfType<heart_bar>();
        heart_bar.update_hearts_UI(current_health);
    }

    public void take_damage(int damage_amount)
    {
        Debug.Log(string.Format("HEALT: Tengo {0} vida", current_health));
        Debug.Log(string.Format("HEALT: Te hiciste {0} vida", damage_amount));
        current_health -= damage_amount;
        heart_bar.update_hearts_UI(current_health);
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
            heart_bar.update_hearts_UI(current_health);
            // sonidos de recuperar vida
        }
    }

    public void player_die()
    {
        player.transform.position = init_point.transform.position;
        // Appear Dead Screen

        // Dissapear Dead Screen

        // Restore Healt Bar
        current_health = max_health;
        heart_bar.update_hearts_UI(current_health);
        Debug.Log("HEALT: ya no tengo vidavida");
    }

    

}
