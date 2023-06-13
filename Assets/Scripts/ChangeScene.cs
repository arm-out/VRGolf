using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Toggle armToggle;
    public static bool armSwing = false;
    public void LoadScene()
    {
        if (armToggle.isOn)
        {
            armSwing = true;
        }
        else
        {
            armSwing = false;
        }
        SceneManager.LoadScene(1);
    }

}
