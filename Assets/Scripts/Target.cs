using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    Transform gunTip;
    [SerializeField]
    float blastSpeed = 37.5f;
    bool pulled = false, pushed = false;

    // Update is called once per frame
    void Update()
    {
        if (pulled)
        {
            transform.SetParent(gunTip);
            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = Vector3.MoveTowards(transform.position, gunTip.position, blastSpeed * Time.deltaTime);
        }
        else if (pushed)
        {
            transform.parent = null;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().velocity = gunTip.forward * blastSpeed;
        }
    }

    public void Pull()
    {
        pulled = true;
        pushed = false;
    }
    public void Push()
    {
        pushed = true;
        pulled = false;
    }
}
