using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_start : MonoBehaviour
{
    public void Iniciar_juego()
    {
        SceneManager.LoadScene("Game_lvl_1");
    }
}
