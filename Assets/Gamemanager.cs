using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gamemanager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public PinSpawner pinsp;
    public BigBallRotator rotator;
    public Animator animator;

    public void EndGame()
    {
        if (gameHasEnded)
            return;

        pinsp.enabled = false;
        rotator.enabled = false; 
        gameHasEnded = true;

        animator.SetTrigger("EndGame");
        FindObjectOfType<AudioManager>().Play("GameOver");
        Debug.Log("GAME IS ENDED");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
