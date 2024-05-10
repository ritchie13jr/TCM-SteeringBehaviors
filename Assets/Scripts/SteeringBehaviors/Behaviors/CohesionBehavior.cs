using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CohesionBehavior : Steering
{

        [SerializeField] private float threshold = 5f;
        [SerializeField]  private float cohesionCoefficient = 5f;

        private Transform [] targets;

        void Start() 
        {
            SteeringBehaviorController[] agents = FindObjectsOfType<SteeringBehaviorController>();
            targets = new Transform [agents.Length -1];
            int count = 0;

            foreach (SteeringBehaviorController agent in agents) 
            {
                if (agent.gameObject != gameObject) 
                {
                    targets[count++] = agent.transform;
                }
            }
        }
        public override SteeringData GetSteering(SteeringBehaviorController steeringController) 
        {
            SteeringData steering = new SteeringData();
            Vector3 centerOfMass = Vector3.zero;
            int neighborCount = 0;  
            foreach (Transform target in targets)
            {
                Vector2 direction =  target.position - steeringController.transform.position;
                float distance = direction.magnitude;
                
                if (distance < threshold) 
                {
                    centerOfMass += target.position; 
                    neighborCount++;
                }
            }        

            if (neighborCount > 0) 
            {
                centerOfMass /= neighborCount;
                Vector2 cohesionDirection = centerOfMass - steeringController.transform.position;
                float strength = Mathf.Min(cohesionCoefficient, steeringController.maxAcceleration);
                cohesionDirection.Normalize();
                steering.linear += strength * cohesionDirection;
            } 
            return steering; 
        }
}
