// Author   : Rifqi Candra
// Date     : 22 January 2023

using UnityEngine;

namespace ProjectDistressed.Hunter
{
    /// <summary>
    /// Controls target detection behaviour.
    /// </summary>
    public class DetectionController : MonoBehaviour
    {
        //==============================================================================
        // Functions
        //==============================================================================

        #region Observer pattern

        public delegate void OnDetectionEvent();
        public static OnDetectionEvent OnDetection;

        #endregion

        #region ProjectDistressed methods

        /// <summary>
        /// On trigger enter.
        /// </summary>
        /// <param name="collider"></param>
        private void OnTriggerEnter2D(Collider2D collider)
        {
            Vector2 targetDirection = collider.transform.position - transform.position;
            int layerMask = ~(LayerMask.GetMask("Ignore Raycast", "Physics"));

            RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDirection, Mathf.Infinity, layerMask);
            Debug.DrawRay(transform.position, targetDirection, Color.green);

            if (hit.collider != null && hit.transform.CompareTag("Player"))
            {
                OnDetection?.Invoke();
            }
        }

        #endregion
    }
}