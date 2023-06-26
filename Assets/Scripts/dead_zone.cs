using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dead_zone : MonoBehaviour
{
    public character_health character_health;
    public int damage_amount;
    public player_controller player_controller;

    public music_box music_box;

    private void Start()
    {
        damage_amount = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Play sound when damage is taken
            music_box.play_damage();
            // Apply damage recoil to player to backward from damage
            player_controller.pit_recoil();
            character_health.take_damage(damage_amount);
            Debug.Log("OBJETO: Te hiciste daño wey");
        }
    }
}
