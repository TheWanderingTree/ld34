using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class distanceCheck : MonoBehaviour
{
    public float minPoint;
    public float maxPoint;

    private float totalRange;
    
    void Start()
    {
        totalRange = maxPoint - minPoint;
        transform.parent.SetParent(UiController.instance.gameObject.transform);
        Debug.Log(transform.parent);
    }

    void Update()
    {
        float range = Mathf.Abs(GameController.instance.currentLevel.levelDistance - GameController.instance.remainingDistance) / GameController.instance.currentLevel.levelDistance;
        float xPos = minPoint + (totalRange * range);
        transform.localPosition = new Vector3(xPos, 0, 0);
    }
}
