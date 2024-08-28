using UnityEngine;

public class dragAndDrop : MonoBehaviour
{
    public GameLogic GameLogicObject;
    private Vector3 offset; // It will be used for the distance between the cursor and the object.
    private bool isDragging = false;
    private bool isPlacedCorrectly = false;
    private Vector3 originalScale;
    private Vector3 firstPosition; // Initial position information of objects
    private Vector3 realPosition; // Exact position where the object should be placed

    void Start()
    {
        originalScale = transform.localScale;
        firstPosition = transform.position;
        // Holding localScale value for future
    }
    void OnMouseDown()
    {
        if (!isPlacedCorrectly) // The object can only move if it is not placed in the right place
        {
            transform.localScale = originalScale * 1.18182f;
            offset = transform.position - GetMouseWorldPosition();
            isDragging = true;
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.sortingOrder = 3; //It is promoted in the hierarchy as it passes over other objects
        }
    }

    void OnMouseDrag()
    {
        // Object follows the cursor
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    // Handles actions taken when the click is released
    void OnMouseUp()
    {
        // returns to the initial position if the object was placed incorrectly
        if (!isPlacedCorrectly)
        {
            transform.localScale = originalScale;
            transform.position = firstPosition;
            GameLogicObject.IncorrectlyPlaced();
        }
        // returns to the exact position if the object was placed correctly
        else
        {
            GameLogicObject.CorrectlyPlaced();
            transform.position = transform.parent.TransformPoint(realPosition);
        }
        isDragging = false;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sortingOrder = 2; //The hierarchy is reset when the cursor is released.
    }

    // Converts screen coordinates to world coordinates
    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    // When the object is placed in the right place, it organises the relevant operations
    public void matchDetect(Vector3 exactPosition)
    {
        realPosition = exactPosition;
        isPlacedCorrectly = true;
    }

    // If the object leaves that area after being placed in the right place, the relevant variable is updated
    public void matchDetectEnd()
    {
        isPlacedCorrectly = false;
    }
}

