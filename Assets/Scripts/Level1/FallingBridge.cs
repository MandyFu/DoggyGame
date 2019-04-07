using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBridge : MonoBehaviour
{
    private Rigidbody _rdbody;

    private void Start()
    {
        _rdbody = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Invoke("BridgePartFalls", 1f);
        }
    }
    private void BridgePartFalls()
    {
        _rdbody.useGravity = true;
    }
}
