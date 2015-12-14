using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    public void startGame()
    {
        AkSoundEngine.PostEvent("UI_confirmMenu", gameObject);

        SceneManager.LoadScene(1);
    }
    public void selectButton()
    {
        AkSoundEngine.PostEvent("UI_selectMenu", gameObject);
    }
}
