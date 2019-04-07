using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            float _currentY = FindObjectOfType<Player>().transform.position.y;
            FindObjectOfType<FollowPlayer>().setSmoothY(_currentY);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<FollowPlayer>().setSmoothY(null);
        }
    }

}
