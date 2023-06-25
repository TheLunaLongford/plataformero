    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dead_zone : MonoBehaviour
{
    public character_health character_health;
    public int damage_amount;
    //public GameObject player;
    public player_controller player_controller;

    private void Start()
    {
        damage_amount = 1;
        //player_controller = player.GetComponent<player_controller>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            character_health.take_damage(damage_amount);
            Debug.Log("OBJETO: Te hiciste daño wey");
            player_controller.pit_recoil();
        }
    }
}
