using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset;

    [SerializeField] private Transform target;

    // Update is called once per frame
    private void Start()
    {
        offset = transform.position;
    }
    private void Update()
    {
        transform.position = target.position + offset;
    }
}
