using UnityEngine;
using UnityEngine.UI;
public class UiParenter : MonoBehaviour
{

    void Start()
    {
        transform.SetParent(UiController.instance.gameObject.transform);
        GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }
}
