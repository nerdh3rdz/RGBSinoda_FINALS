using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lightsaber : MonoBehaviour
{
    [SerializeField]
    List<GameObject> saberParts = new List<GameObject>();
    [SerializeField]
    Material selected, unselected;
    [SerializeField]
    Transform rotatingParts;
    [SerializeField]
    float rotateSpeed = 10f;

    bool isRotate = false;

    public void Select()
    {
        foreach (GameObject part in saberParts)
            part.GetComponent<MeshRenderer>().material = selected;
    }
    public void Unselect()
    {
        foreach (GameObject part in saberParts)
            part.GetComponent<MeshRenderer>().material = unselected;
    }
    public void Activate()
    {
        isRotate = true;
    }
    public void Deactivate()
    {
        isRotate = false;
    }

    private void Update()
    {
        if(isRotate)
            rotatingParts.Rotate(0, 0, rotateSpeed);
    }
}
