using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    // �ѧ��ѹ����Ѻ����¹�ҡ
    public void ChangeLevel(string lvlToLoad)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(lvlToLoad);
    }

    // �ѧ��ѹ����Ѻ�����͡�ҡ��
    public void QuitGame()
    {
        Application.Quit();
    }
}
