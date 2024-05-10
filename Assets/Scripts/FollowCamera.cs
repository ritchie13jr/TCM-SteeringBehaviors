using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
       [ExecuteInEditMode]
   [SerializeField] private Vector3 offset;
   [SerializeField] private float damping;

   public Transform player;

   private Vector3 vel = new Vector3 (15,0,0);

   private void FixedUpdate() 
   {
        Vector3 targetPos = player.position + offset; 

        targetPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref vel, damping);
   }
}
