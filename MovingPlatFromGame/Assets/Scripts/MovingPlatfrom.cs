using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatfrom : MonoBehaviour
{
    [SerializeField]
    private Transform _movingTarget1, _movingTarget2;
    [SerializeField]
    private float _speed = 1f;
    bool _moveTarget1to2;
    bool _moveTarget2to1;
    void FixedUpdate()
    {
        MoveObjectOneToTwoAndReverse();
    }
    void MoveObjectOneToTwoAndReverse()
    {
        if (this.transform.position == _movingTarget1.position)
        {
            _moveTarget1to2 = true;
            _moveTarget2to1 = false;
        }
        else if (this.transform.position == _movingTarget2.position)
        {
            _moveTarget1to2 = false;
            _moveTarget2to1 = true;

        }

        if (_moveTarget1to2)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, _movingTarget2.position, Time.deltaTime * _speed);
        }
        else if (_moveTarget2to1)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, _movingTarget1.position, Time.deltaTime * _speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.CompareTo("Player")== 0)
        {
            other.transform.SetParent(this.transform);
        }
    }
  
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.CompareTo("Player") == 0)
        {
            other.transform.SetParent(null);
        }
    }
}
