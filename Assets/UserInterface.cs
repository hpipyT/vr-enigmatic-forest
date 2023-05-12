using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    public AudioSource music;

    public GameObject boundary;
    public Light[] lights;
    public Slider slide;

    public GameObject teleport;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AdjustLights();
    }

    public void ToggleMusic()
    {
        if (music.isPlaying)
        {
            music.Pause();
        }
        else
        {
            music.Play();
        }
    }

    public void AdjustLights()
    {
        foreach (Transform child in boundary.transform)
        {
            child.GetChild(0).GetComponent<Light>().intensity = slide.value * 1.16f;
        }
    }

    public void ToggleTeleport()
    {
        if (teleport.activeSelf)
            teleport.SetActive(false);
        else
            teleport.SetActive(true);
    }

}
