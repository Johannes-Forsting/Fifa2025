using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource source;
    public AudioClip goalSound;

    public GameObject canvas;

    public bool hasLost = false;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && hasLost == false)
        {
            source.PlayOneShot(goalSound);
            
            canvas.SetActive(true);
            if (canvas.CompareTag("LoosingScreen"))
            {
                hasLost = true;
            }
        }
    }



}
