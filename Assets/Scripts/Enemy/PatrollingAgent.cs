using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PatrollingAgent : MonoBehaviour
{
    Rigidbody2D rb;

    public Transform Destination
    {
        get
        {
            return GetComponent<SeekBehavior>().target;
        }

        set
        {
            GetComponent<SeekBehavior>().target = value;
        }
    }

    public float RemainingDistance
    {
        get
        {
            return (Destination.position - transform.position).magnitude;
        }
    }

    public bool HasReachedDestination
    {
        get
        {
            return RemainingDistance < 0.1f;
        }
    }

    public Vector2 Velocity
    {
        get
        {
            return rb.velocity;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

}
