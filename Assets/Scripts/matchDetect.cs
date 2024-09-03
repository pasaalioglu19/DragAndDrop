using UnityEngine;

public class MatchDetect : MonoBehaviour
{ 
    void OnTriggerEnter2D(Collider2D other)
    {
        // Checking whether the tag of the placed field and the tag of the object are the same.
        if (other is CircleCollider2D && gameObject.tag == other.gameObject.tag)
        {
            dragAndDrop assetGO = other.gameObject.GetComponent<dragAndDrop>();
            assetGO.matchDetect(gameObject);
        }
    }

    // After the object is placed in the right place, if it leaves that area, the related class is notified
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other is CircleCollider2D && gameObject.tag == other.gameObject.tag)
        {
            dragAndDrop assetGO = other.gameObject.GetComponent<dragAndDrop>();
            assetGO.matchDetectEnd();
        }
    }
}
