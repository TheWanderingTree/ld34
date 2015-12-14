using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoPlayer : MonoBehaviour
{
    public MovieTexture movTexture;
    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().material.mainTexture = movTexture;
        movTexture.Play();
    }
    void Update()
    {
        MovieTexture tex = GetComponent<Renderer>().material.mainTexture as MovieTexture;
        if (!tex.isPlaying)
        {
            if (Input.anyKey)
            {
                startGame();
            }
        }
    }
    public void startGame()
    {
        AkSoundEngine.PostEvent("UI_confirmMenu", gameObject);

        SceneManager.LoadScene(1);
    }
}
