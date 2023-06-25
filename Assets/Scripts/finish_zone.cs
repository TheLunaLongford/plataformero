using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish_zone : MonoBehaviour
{
   public character_health character_health;
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Save the current life amount
            PlayerPrefs.SetInt("player_life", character_health.current_health);
            // wait a little for writing the life
            load_next_scene();
        }
    }

    private void load_next_scene()
    {
        // Pass to the next Scene
        string scene_name = SceneManager.GetActiveScene().name;
        string next_scene = scene_name == "Game_lvl_1" ? "Game_lvl_2" : "Empty";
        SceneManager.LoadScene(next_scene);
    }
}
