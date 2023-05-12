using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ToggleUI : MonoBehaviour
{
    public GameObject UI;
    InputDevice left;

    bool toggled = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        left = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        if (left.TryGetFeatureValue(CommonUsages.secondaryButton, out bool isPressed))
        {
            if (isPressed && !toggled)
            {
                toggled = true;
                Debug.Log("toggling");
                Toggle();
            }

            if (!isPressed && toggled)
                toggled = false;

        }
    }




    public void Toggle()
    {
        if (UI.activeSelf)
        {
            Debug.Log("active, deactivating");
            UI.SetActive(false);
        }

        else
        {
            Debug.Log("inactive, activating");
            UI.SetActive(true);
        }
    }
}
