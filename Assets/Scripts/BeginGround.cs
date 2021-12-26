using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject, 3);
    }
}
