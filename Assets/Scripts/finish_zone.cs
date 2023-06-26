using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish_zone : MonoBehaviour
{
    public character_health character_health;
    public music_box music_box;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Play complete level sound
            music_box.play_complete_level();
            // Save the current life amount
            PlayerPrefs.SetInt("player_life", character_health.current_health);
            // wait a little the complete sound to be listened
            Invoke("load_next_scene", 1.0f);
        }
    }

    private void load_next_scene()
    {
        // Pass to the next Scene
        string scene_name = SceneManager.GetActiveScene().name;
        string next_scene = scene_name == "Game_lvl_1" ? "Game_lvl_2" : "end_screen";
        SceneManager.LoadScene(next_scene);
    }
}
