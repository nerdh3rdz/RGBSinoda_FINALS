using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MagnetGun : MonoBehaviour
{
    [SerializeField]
    List<GameObject> gunParts = new ();
    [SerializeField]
    Material activated, deactivated;
    [SerializeField]
    Transform gunTip;
    [SerializeField]
    float gunRange;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    Transform shootPoint;

    GameObject target;
    GameObject bullet;

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
        bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = shootPoint.forward * 25;
    }
    public void Deactivate()
    {
        target.GetComponent<Target>().Push();
        target = null;
    }
}
