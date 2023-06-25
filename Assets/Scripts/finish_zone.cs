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
            PlayerPrefs.SetFloat("player_life", character_health.current_health);
            // Pass to the next Scene
            SceneManager.LoadScene("Empty");
            Debug.Log("LEVEL: Haz iniciado el Level 2");
        }
    }
}
