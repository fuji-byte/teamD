using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineSceneChanger : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public string RunGameScene_smartphone_system;
    private int flag = 0;

    void Start()
    {
        if (playableDirector != null)
        {
            playableDirector.stopped += OnPlayableDirectorStopped;
        }
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        if (Input.GetMouseButtonDown(0))
        {
            flag = 1;
            SkipScene();
        }
    }

    void OnPlayableDirectorStopped(PlayableDirector director)
    {
        if (flag == 0)
        {
            if (director == playableDirector)
            {
                SkipScene();
            }
        }
    }

    void SkipScene()
    {
        SceneManager.LoadScene(RunGameScene_smartphone_system);
    }

    void OnDestroy()
    {
        if (playableDirector != null)
        {
            playableDirector.stopped -= OnPlayableDirectorStopped;
        }
    }
}