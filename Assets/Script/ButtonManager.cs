using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager: MonoBehaviour
{
    public void ToTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void ToPlayButton()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void ToRePlayButton()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);// ƒV[ƒ“Ä“Ç‚İ‚İ
    }
}
