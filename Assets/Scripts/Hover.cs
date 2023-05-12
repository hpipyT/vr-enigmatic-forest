using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    bool isHovering = false;

    public float moveScale = 0.00025f;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        HoverRock();
    }

    // 
    void HoverRock()
    {
        if (isHovering == false)
            isHovering = true;

        // hover starts jittery because start position depends on time
        float bleh = moveScale * Mathf.Clamp(Mathf.Sin(Time.time * speed), -1.0f, 1.0f);

        gameObject.transform.Translate(0.0f, bleh, 0.0f, Space.Self);
    }


}
