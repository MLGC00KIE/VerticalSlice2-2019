using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSlice : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Slice");
    }
}