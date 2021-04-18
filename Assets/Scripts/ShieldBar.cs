using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    private Image shieldbar;
    public float currentshield;
    private float maxShield = 100f;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        shieldbar = GetComponent<Image>();
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentshield = player.shield;
        shieldbar.fillAmount = currentshield / maxShield;
    }
}
