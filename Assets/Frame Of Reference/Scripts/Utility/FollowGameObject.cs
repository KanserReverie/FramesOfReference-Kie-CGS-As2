using System;
using UnityEngine;

namespace PrototypingPlayground.UsefulScripts
{
    public class FollowGameObject : MonoBehaviour
    {
        [SerializeField] private Transform transformToFollow;
        [SerializeField] private bool followRotation = false;
        [SerializeField] private Vector3 offsetPosition;
        [SerializeField] private Vector3 offsetRotation;
        
        void Update()
        {
            MoveToObject();
        }
        
        private void OnDrawGizmos()
        {
            MoveToObject();
        }
        
        void OnValidate()
        {
            MoveToObject();
        }

        private void MoveToObject()
        {
            if (transformToFollow == null)
                return;
            
            this.transform.position = transformToFollow.position + offsetPosition;
            
            if (followRotation)
            {
                this.transform.rotation = transformToFollow.rotation * Quaternion.Euler(offsetRotation);
            }
            else
            {
                this.transform.rotation = Quaternion.Euler(offsetRotation);
            }
        }
    }
}
