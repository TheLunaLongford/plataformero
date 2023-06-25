using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_start : MonoBehaviour
{
    public void Iniciar_juego()
    {
        // Set initial player life to 10
        PlayerPrefs.SetInt("player_life", 10);
        // Load PLayable level one
        SceneManager.LoadScene("Game_lvl_1");
    }
}
