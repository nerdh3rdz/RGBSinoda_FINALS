using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MagnetGun : MonoBehaviour
{
    [SerializeField]
    List<GameObject> gunParts = new List<GameObject>();
    [SerializeField]
    Material activated, deactivated;
    [SerializeField]
    Transform gunTip;
    [SerializeField]
    float gunRange;

    GameObject target;

    public void Select()
    {
        foreach (GameObject part in gunParts)
            part.GetComponent<MeshRenderer>().material = activated;
    }
    public void Unselect()
    {
        foreach (GameObject part in gunParts)
            part.GetComponent<MeshRenderer>().material = deactivated;
    }
    public void Activate()
    {
        RaycastHit hit;

        if (Physics.Raycast(gunTip.position, gunTip.forward, out hit, gunRange)
            && hit.collider.gameObject.CompareTag("Interactables"))
        {
            target = hit.collider.gameObject;
            target.GetComponent<Target>().Pull();
        }
    }
    public void Deactivate()
    {
        target.GetComponent<Target>().Push();
        target = null;
    }
}
