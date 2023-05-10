using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource winningSource;
    public AudioClip winningSound;
    public GameObject winningScreen;

    public AudioSource loosingSource;
    public AudioClip loosingSound;
    public GameObject loosingScreen;

    private bool gameOver = false;




    private void OnTriggerEnter(Collider other)
    {
        if(gameOver == false)
        {
        
            if (other.CompareTag("Goal"))
            {
                winningSource.PlayOneShot(winningSound);

                winningScreen.SetActive(true);
                gameOver = true;
            }
            if (other.CompareTag("OwnGoal") || other.CompareTag("GoalKeeper"))
            {
                loosingSource.PlayOneShot(loosingSound);

                loosingScreen.SetActive(true);
                gameOver = true;
            }
        }

    }
}
