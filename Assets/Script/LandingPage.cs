using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LandingPageVideo : MonoBehaviour
{
    private string nextSceneName = "HomepageSampleScene";

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
