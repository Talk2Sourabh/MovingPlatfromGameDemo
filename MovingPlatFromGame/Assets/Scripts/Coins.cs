﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("Player") == 0)
        {
            other.GetComponent<PlayerBehaviour>().CollectCoins();
            Destroy(this.gameObject);
        }
    }

}

