using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreColliderObject : MonoBehaviour
{
    public Transform ObjectForIgnore;

    void Start() => Physics.IgnoreCollision(ObjectForIgnore.GetComponent<Collider>(), GetComponent<Collider>());
}