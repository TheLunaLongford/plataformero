using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart_button : MonoBehaviour
{
    public music_box music_box;
    public void restart_game()
    {
        // Play Menu sound
        music_box.play_menu();
        Invoke("restart_action", 1.0f);
    }

    public void restart_action()
    {
        // Load PLayable level one
        SceneManager.LoadScene("Main_menu");
    }
}
