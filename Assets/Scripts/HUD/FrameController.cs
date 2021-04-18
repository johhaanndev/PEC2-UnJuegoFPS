using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameController : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(Deactivate), 0.2f);
    }
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
