// Author   : Rifqi Candra
// Date     : 22 January 2023

using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjectDistressed.UI
{
    /// <summary>
    /// Controls joystick behaviour.
    /// </summary>
    public class JoystickController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        //==============================================================================
        // Variables
        //==============================================================================
        
        private Vector2 joystickOriginalPosition;
        private float joystickRadius;
        private Vector2 joystickVector;
        public Vector2 JoystickVector { get { return joystickVector; } }

        [Header("Object Attachments")]
        [SerializeField] private GameObject joystickCenter;
        [SerializeField] private GameObject joystickBackground;


        
        //==============================================================================
        // Functions
        //==============================================================================
        
        #region MonoBehaviour methods

        private void Start()
        {
            joystickOriginalPosition = joystickBackground.transform.position;
            joystickRadius = joystickBackground.GetComponent<RectTransform>().sizeDelta.y / 3f;
        }

        #endregion

        #region  ProjectDistressed methods

        /// <summary>
        /// On input pointer down.
        /// </summary>
        /// <param name="pointerEventData"></param>
        public void OnPointerDown(PointerEventData pointerEventData)
        {
            joystickCenter.transform.position = Input.mousePosition;
            joystickBackground.transform.position = Input.mousePosition;
        }



        /// <summary>
        /// On input dragging.
        /// </summary>
        /// <param name="pointerEventData"></param>
        public void OnDrag(PointerEventData pointerEventData)
        {
            Vector2 initialTouchPosition = pointerEventData.pressPosition;

            joystickVector = (pointerEventData.position - initialTouchPosition).normalized;
            float joystickDistance = Vector2.Distance(pointerEventData.position, initialTouchPosition);

            if (joystickDistance < joystickRadius)
            {
                joystickCenter.transform.position = initialTouchPosition + joystickVector * joystickDistance;
            }

            else
            {
                joystickCenter.transform.position = initialTouchPosition + joystickVector * joystickRadius;
            }
        }



        /// <summary>
        /// On input pointer up.
        /// </summary>
        /// <param name="pointerEventData"></param>
        public void OnPointerUp(PointerEventData pointerEventData)
        {
            joystickVector = Vector2.zero;
            joystickCenter.transform.position = joystickOriginalPosition;
            joystickBackground.transform.position = joystickOriginalPosition;
        }

        #endregion
    }
}