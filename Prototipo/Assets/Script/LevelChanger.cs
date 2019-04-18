using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int LevelToLoad;
    public GameObject Player;


    void Update()
    {
        if (Input.GetKeyDown("n"))
        {
            FadeToNextLevel();
        }
    }

    public void FadeToNextLevel()
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;

        if (SceneManager.sceneCount +1 >= next)
            FadeToLevel(next);
    }

    public void FadeToLevel(int levelIndex)
    {
        LevelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
