// Author   : Rifqi Candra

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
        #endregion  



        #region ProjectDistressed methods
        /// <summary>
        /// Starts to chase the target.
        /// </summary>
        public void Chase()
        {
            destinationSetter.target = targetTransform;
        }
        #endregion
    }
}