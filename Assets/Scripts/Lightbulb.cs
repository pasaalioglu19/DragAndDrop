using UnityEngine;

public class Lightbulb : MonoBehaviour
{
    public GameObject Assets; 
    public GameObject ShadowColliders;
    public Hand HandScript;

    public void ShowHint()
    {
        int childCount = Assets.transform.childCount;

        int randomIndex = Random.Range(0, childCount);

        // Rastgele seçilen indekse göre child objeyi al
        GameObject targetAsset = Assets.transform.GetChild(randomIndex).gameObject;
        Vector3 assetPosition = targetAsset.transform.position;
        string assetName = targetAsset.name;

        Transform targetShadow = null;
        foreach (Transform child in ShadowColliders.transform)
        {
            if (child.gameObject.name == assetName)
            {
                targetShadow = child;
                break;
            }
        }

        if (targetShadow != null)
        {
            Vector3 ShadowPosition = targetShadow.position;
            HandScript.UpdateHandPosition(assetPosition, ShadowPosition, false);
        }
    }
}
