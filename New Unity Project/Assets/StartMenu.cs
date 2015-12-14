using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    void Update()
    {

    }

    public void selectButton()
    {
        AkSoundEngine.PostEvent("UI_selectMenu", gameObject);
    }
}
