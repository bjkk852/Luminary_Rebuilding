using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public void Start()
    {
        transform.Rotate(Vector3.forward, -60);
        transform.Rotate(Vector3.left, 60);
        transform.localScale = new Vector3(1, 2, 1);
    }
}
