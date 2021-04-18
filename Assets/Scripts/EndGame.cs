using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject fadeOutLong;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            fadeOutLong.GetComponent<Animator>().SetTrigger("StartFade");
            Invoke(nameof(GoToFinalScene), 3f);
        }
            
    }

    public void GoToFinalScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
