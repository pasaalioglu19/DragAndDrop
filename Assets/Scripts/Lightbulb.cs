using UnityEngine;

public class Lightbulb : MonoBehaviour
{
    public GameObject Assets; 
    public GameObject ShadowColliders;
    public GameLogic LogicObject;
    public Hand HandScript;


    public void ShowHint()
    {
        int hintRemaning = LogicObject.GetHintRemaining();
        if (hintRemaning <= 0) //sor == yapsam riskli ama doðru
        {
            return;
        }
        LogicObject.DecreaseHintRemaining();
        int childCount = Assets.transform.childCount;

        int randomIndex = Random.Range(0, childCount);

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
