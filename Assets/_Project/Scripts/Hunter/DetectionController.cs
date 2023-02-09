// Author   : Rifqi Candra

using UnityEngine;
using UnityEngine.Events;

namespace ProjectDistressed.Hunter
{
    /// <summary>
    // Controls target detection behaviour.
    /// </summary>
    public class DetectionController : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private RaycastHit2D hit;
        [SerializeField] private UnityEvent detectedEvent;



        //==============================================================================
        // Functions
        //==============================================================================
        #region ProjectDistressed methods
        /// <summary>
        /// On trigger enter.
        /// </summary>
        /// <param name="collider"></param>
        private void OnTriggerEnter2D(Collider2D collider)
        {
            DrawRaycast(collider);
            CompareTag(collider);
        }



        /// <summary>
        /// Draw a Raycast2D to collision direction.
        /// </summary>
        private void DrawRaycast(Collider2D collider)
        {
            Vector2 targetDirection = collider.transform.position - transform.position;
            int layerMask = ~(LayerMask.GetMask("Ignore Raycast", "Physics"));

            hit = Physics2D.Raycast(transform.position, targetDirection, Mathf.Infinity, layerMask);
            
            // FIXME DEBUG
            Debug.DrawRay(transform.position, targetDirection, Color.green);
        }



        /// <summary>
        /// Compares tag from given collider.
        /// </summary>
        private void CompareTag(Collider2D collider)
        {
            if (hit.collider != null && hit.transform.CompareTag("Player"))
            {
                detectedEvent.Invoke();
            }
        }
        #endregion
        
    }
}