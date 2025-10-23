using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    // ฟังก์ชันสำหรับเปลี่ยนฉาก
    public void ChangeLevel(string lvlToLoad)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(lvlToLoad);
    }

    // ฟังก์ชันสำหรับปุ่มออกจากเกม
    public void QuitGame()
    {
        Application.Quit();
    }
}
