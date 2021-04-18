using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroyGO), 1);
    }

    public void DestroyGO()
    {
        Destroy(gameObject);
    }
}
