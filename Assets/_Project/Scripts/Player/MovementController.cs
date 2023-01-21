// Author   : Rifqi Candra
// Date     : 22 January 2023

using ProjectDistressed.UI;
using UnityEngine;

namespace ProjectDistressed.Player
{
    /// <summary>
    /// Controls player movement behaviour.
    /// </summary>
    public class MovementController : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        
        private Rigidbody2D playerRigidbody;
        private Animator animator;

        [Header("Attribute Configurations")]
        [SerializeField] private float movementSpeed = 5f;

        [Header("Object Attachments")]
        [SerializeField] private JoystickController joystick;


        
        //==============================================================================
        // Functions
        //==============================================================================
        
        #region MonoBehaviour methods

        private void Start()
        {
            playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
            animator = gameObject.GetComponent<Animator>();
        }



        private void FixedUpdate()
        {
            MovePlayer();
        }

        #endregion

        #region ProjectDistressed methods

        /// <summary>
        /// Move player based on joystick movement direction.
        /// </summary>
        private void MovePlayer()
        {
            Vector2 joystickVector = joystick.JoystickVector;

            if (joystickVector.x > 0)
            {
                playerRigidbody.velocity = transform.right * movementSpeed;
                animator.SetBool("IsWalking", true);
                animator.SetBool("IsFacingRight", true);
            }

            if (joystickVector.x < 0)
            {
                playerRigidbody.velocity = (transform.right * -1) * movementSpeed;
                animator.SetBool("IsWalking", true);
                animator.SetBool("IsFacingRight", false);
            }

            if (joystickVector == Vector2.zero)
            {
                playerRigidbody.velocity = Vector2.zero;
                animator.SetBool("IsWalking", false);
            }
        }

        #endregion
    }
}