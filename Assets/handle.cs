using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class handle : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource unlockSound;

    InputDevice hand;

    bool isGrabbing = false;
    public bool isUnlocked = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);

    }

    public void OnCollisionEnter(Collision other)
    {
        
        if (other.collider.name != "LeftHand Controller")
            return;

        hand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);

        if (hand.TryGetFeatureValue(CommonUsages.gripButton, out bool gripPressed))
        {
            Debug.Log(gripPressed);
            // if the object is gripped and grip button is pressed
            if (gripPressed && !isGrabbing)
            {
                isUnlocked = true;
                unlockSound.Play();

            }

            // on release unchild it
            if (!gripPressed && isGrabbing)
            {
                isGrabbing = false;
            }



        }
    }






}
