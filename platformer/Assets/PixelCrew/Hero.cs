using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;


public class Hero : MonoBehaviour
{
    private Vector2 _movement;
   [SerializeField] private float _speed;
  public void SetDirection (Vector2 movement)
    {
        _movement = movement;
    }

    private void Update ()
    {
        if( _movement != Vector2.zero )
        {
            Vector3 delta = new Vector3(_movement.x, _movement.y, 0) * _speed * Time.deltaTime;
   
            transform.position += delta;
        }
    }

    public void SaySomething()
    {
        Debug.Log("Something!");
    }
}
