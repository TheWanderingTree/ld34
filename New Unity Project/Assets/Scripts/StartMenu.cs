using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    void Update()
    {
        AkSoundEngine.SetState("Music", "Cutscene_Minor");
    }

    public void selectButton()
    {
        AkSoundEngine.PostEvent("UI_selectMenu", gameObject);
    }
}
