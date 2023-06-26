using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_start : MonoBehaviour
{
    public music_box music_box;
    public void Iniciar_juego()
    {
        // Play Menu sound
        music_box.play_menu();
        // Set initial player life to 10
        PlayerPrefs.SetInt("player_life", 10);
        // Wait 1 sec for listening menu sound, then passing to lvl 1
        Invoke("iniciar_lvl_1", 1.0f);
    }

    public void iniciar_lvl_1()
    {
        // Load PLayable level one
        SceneManager.LoadScene("Game_lvl_1");
    }
}
