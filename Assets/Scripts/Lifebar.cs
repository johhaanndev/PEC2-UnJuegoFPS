using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifebar : MonoBehaviour
{

    private Image lifebar;
    public float currentLife;
    private float maxLife = 100f;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        lifebar = GetComponent<Image>();
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentLife = player.life;
        lifebar.fillAmount = currentLife / maxLife;
    }
}
