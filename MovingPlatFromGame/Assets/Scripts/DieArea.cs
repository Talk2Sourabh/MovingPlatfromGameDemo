using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieArea : MonoBehaviour
{
    [SerializeField]
    GameObject _respawingPlayer;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.CompareTo("Player") == 0)
        {
            other.GetComponent<PlayerBehaviour>().DamageLife();
            CharacterController ch = other.GetComponent<CharacterController>();
            ch.enabled = false;
            other.transform.position = _respawingPlayer.transform.position;
            ch.enabled = true;
        }
    }
}
