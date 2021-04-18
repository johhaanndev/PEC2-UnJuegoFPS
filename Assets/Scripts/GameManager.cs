using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject mediumProjector;

    public GameObject fadeOutImage;

    // Start is called before the first frame update
    void Start()
    {
        fadeOutImage.GetComponent<Animator>().SetBool("FadeOut", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().life <= 0)
        {
            Debug.Log("Player Dead");
        }

        if (mediumProjector.GetComponent<Projector>().life < 400)
        {
            fadeOutImage.GetComponent<Animator>().SetBool("FadeOut", true);
            Invoke(nameof(GoToFinalScene), 2f);
        }

        if (player.GetComponent<PlayerController>().life <= 0)
        {
            SceneManager.LoadScene("Main");
        }
    }

    private void GoToFinalScene()
    {
        SceneManager.LoadScene("FinalScene");
    }
}
