using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject handle;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (handle.GetComponent<handle>().isUnlocked)
        {
            gameObject.GetComponent<Rigidbody>().freezeRotation = false;
        }
    }
}
