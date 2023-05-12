using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickRock : MonoBehaviour
{
    public GameObject rock;

    public Animator animator;
    public GameObject affector;
    public float maxDistance = 4.0f;

    Vector3 ogPosition;
    Quaternion ogRot;
    Vector3 rockPosition;
    bool rockUp = false;

    void Start()
    {
        ogPosition = transform.position;
        rockPosition = rock.transform.position;
        ogRot = transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        // Check that the animator and affector exist.
        if (animator != null && affector != null)
        {
            // Check if the current distance is greater than maximum distance.
            Vector3 animatorPosition = gameObject.transform.position;
            Vector3 affectorPosition = affector.transform.position;
            
            float currentDistance = Vector3.Distance(animatorPosition, affectorPosition);
            /*Debug.Log("current: " + currentDistance);
            Debug.Log("max: " + maxDistance);*/
            if (currentDistance < maxDistance)
            {
                // if player is closer than the bubble's edge,

                animator.SetBool("Idle", false);
                animator.SetBool("Kick1", true);

                if (animator.GetBool("Kick1") == true && rockUp == false)
                {
                    StartCoroutine(UpRock());
                    //animator.SetBool("Kick1", false);
                }
            }
            // if player leaves range midkick, wait for it to finish
            else if (animator.GetBool("Kick1") == true)
            {
                StartCoroutine(WaitForKick1());

            }
            // same
            else if (animator.GetBool("Kick2") == true)
            {
                StartCoroutine(WaitForKick2());
                Debug.Log("Downing the rock");
                StartCoroutine(DownRock());
                Debug.Log("Rock downed");
            }
        }
    }

    IEnumerator WaitForKick1()
    {
        yield return new WaitForSeconds(1.0f);
        animator.SetBool("Kick1", false);
        animator.SetBool("Kick2", true);


        // hover the rock

    }
    IEnumerator WaitForKick2()
    {
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("Kick2", false);
        animator.SetBool("Idle", true);

        Debug.Log("Waited for kick2");
        //StartCoroutine(MoveBackwards());
        transform.position = ogPosition;
        transform.rotation = ogRot;
        yield return null;
        
    }

    IEnumerator UpRock()
    {
        rockUp = true;
        yield return new WaitForSeconds(0.5f);
        rock.transform.position = new Vector3(rockPosition.x, rockPosition.y + 0.5f, rockPosition.z);
        yield return new WaitForSeconds(0.5f);
        rock.transform.position = new Vector3(rockPosition.x, rockPosition.y + 1, rockPosition.z);
        yield return null;
    }

    IEnumerator DownRock()
    {
        rockUp = false;
        yield return new WaitForSeconds(1.0f);
        rock.transform.position = new Vector3(rockPosition.x, rockPosition.y, rockPosition.z);
        yield return null;
    }

    // when player enters range

    // play earthbending animation 1

    // float the rock


    // when player exits range

    // play earthbending animation 2

    // unfloat the rock
}
