using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart_button : MonoBehaviour
{
    public void restart_game()
    {
        SceneManager.LoadScene("Main_menu");
    }
}
