using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void TaskChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void TaskEnableObject(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void TaskDisableObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void TaskCloseApplication()
    {
        Application.Quit();
    }
}
