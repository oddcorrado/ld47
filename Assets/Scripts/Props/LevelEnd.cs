using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var life = collision.gameObject.GetComponent<PlayerLife>();

        Debug.Log("PlayerKiller:  " + collision.gameObject + " " + life);

        if (life != null)
        {
            if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCount - 1)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            else
                SceneManager.LoadScene("MenuLevels");
        }        
    }
}
