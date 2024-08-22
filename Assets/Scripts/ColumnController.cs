using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnController : MonoBehaviour
{
    [SerializeField] GameObject _point;
    public void SetActivatePoint ()
    {
        if (_point.GetComponent<BoxCollider2D>().enabled == false ) 
        _point.GetComponent<BoxCollider2D>().enabled = true;
    } 
}
