using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int life = 100;
    public int shield = 100;
    private bool isDead = false;

    public GameObject fpsController;
    public GameObject hitFrame;

    // Start is called before the first frame update
    void Start()
    {
        fpsController.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (life <= 0)
            {
                life = 0;
                isDead = true;
            }
        }
        else
        {
            Debug.Log("Dead");
            fpsController.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        if (shield <= 0)
        {
            life -= damage;
            shield = 0;
        }
        else
        {
            shield -= damage;
            if (shield <= 0)
                shield = 0;
            life -= damage / 4;
        }
        hitFrame.GetComponent<Animator>().SetTrigger("Show");
    }


}
