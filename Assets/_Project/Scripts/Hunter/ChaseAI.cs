// Author   : Rifqi Candra
// Date     : 22 January 2023

using Pathfinding;
using UnityEngine;

namespace ProjectDistressed.Hunter
{
    /// <summary>
    /// AI controller for chasing target.
    /// </summary>
    public class ChaseAI : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        
        private AIDestinationSetter destinationSetter;
        private Animator animator;

        [Header("Object Attachments")]
        [SerializeField] private Transform targetTransform;


        
        //==============================================================================
        // Functions
        //==============================================================================
        
        #region MonoBehaviour methods

        private void Awake()
        {
            destinationSetter = gameObject.GetComponent<AIDestinationSetter>();
            animator = gameObject.GetComponentInParent<Animator>();
        }



        private void Start()
        {
            DetectionController.OnDetection += Chase;
        }

        #endregion

        #region ProjectDistressed methods

        /// <summary>
        /// Chase the target.
        /// </summary>
        private void Chase()
        {
            destinationSetter.target = targetTransform;
        }

        #endregion
    }
}