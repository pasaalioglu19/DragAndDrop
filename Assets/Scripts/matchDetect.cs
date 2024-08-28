using UnityEngine;

public class MatchDetect : MonoBehaviour
{ 
    private float offset = 0.531F; // Offset value for possible y-axis translation cases
    void OnTriggerEnter2D(Collider2D other)
    {
        // Checking whether the tag of the placed field and the tag of the object are the same.
        if (other is CircleCollider2D && gameObject.tag == other.gameObject.tag)
        {
            // Sends exact location coordinates for each object
            dragAndDrop assetGO = other.gameObject.GetComponent<dragAndDrop>();
            Vector3 assetPlace = new Vector3(0, 0, 0);
            if (gameObject.tag == "robot")
                assetPlace = new Vector3(-1.948F, 3.587F - offset, -0.0519125F);
            else if (gameObject.tag == "dualBookH")
                assetPlace = new Vector3(-0.616F, 3.489F - offset, -0.0519125F);
            else if (gameObject.tag == "tinSoldier")
                assetPlace = new Vector3(0.632F, 3.487F - offset, -0.0519125F);
            else if (gameObject.tag == "jar")
                assetPlace = new Vector3(-2.328F, 2.273F - offset, -0.0519125F);
            else if (gameObject.tag == "threeBookV")
                assetPlace = new Vector3(-1.466F, 2.111F - offset, -0.0519125F);
            else if (gameObject.tag == "threeBookH")
                assetPlace = new Vector3(-0.767F, 2.051F - offset, -0.0519125F);
            else if (gameObject.tag == "cactus")
                assetPlace = new Vector3(-0.0819F, 2.1512F - offset, -0.0519125F);
            else if (gameObject.tag == "fiveBookV")
                assetPlace = new Vector3(0.614F, 2.17F - offset, -0.0519125F);
            else if (gameObject.tag == "camera")
                assetPlace = new Vector3(1.426F, 1.614F - offset, -0.0519125F);
            else if (gameObject.tag == "dualBookV")
                assetPlace = new Vector3(-1.921F, 0.963F - offset, -0.0519125F);
            else if (gameObject.tag == "sixBook")
                assetPlace = new Vector3(-1.064F, 0.841F - offset, -0.0519125F);
            else if (gameObject.tag == "fiveBookH")
                assetPlace = new Vector3(-0.154F, 0.886F - offset, -0.0519125F);
            else if (gameObject.tag == "dualBookV2")
                assetPlace = new Vector3(0.684F, 0.884F - offset, -0.0519125F);
            assetGO.matchDetect(assetPlace);
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
