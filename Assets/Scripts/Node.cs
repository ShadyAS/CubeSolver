using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] GameObject cube;

    public GameObject Cube { get => cube; set => cube = value; }

    public void UpdateCube()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.05f);

        foreach (Collider c in colliders)
        {
            if (c.CompareTag("Cube"))
            {
                cube = c.gameObject;
            }
        }
    }
}
