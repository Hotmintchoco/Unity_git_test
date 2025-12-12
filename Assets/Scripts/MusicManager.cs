using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip mainTheme;
    public AudioClip menuTheme;

    string sceneName;

    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        Invoke("PlayMusic", 0.2f);
    }

    // 1. 객체가 활성화될 때 이벤트 구독 (귀를 기울임)
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 2. 객체가 비활성화되거나 파괴될 때 이벤트 구독 해제 (중요! 안 하면 에러 남)
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // 3. 씬 로딩이 끝났을 때 실제로 실행될 로직 (기존 OnLevelWasLoaded의 내용)
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 영상의 로직을 그대로 가져오되, 씬 이름을 가져오는 방식이 더 쉬워졌습니다.
        string newSceneName = scene.name; // 로드된 씬의 이름을 바로 알 수 있음

        // --- 아래는 영상의 원래 로직과 동일합니다 ---
        if (newSceneName != sceneName)
        {
            sceneName = newSceneName;
            Invoke("PlayMusic", 0.2f); // 약간의 딜레이 후 음악 재생
        }
    }

    void PlayMusic()
    {
        AudioClip clipToPlay = null;

        if (sceneName == "Menu")
        {
            clipToPlay = menuTheme;
        } else if (sceneName == "Game")
        {
            clipToPlay = mainTheme;
        }

        if (clipToPlay != null)
        {
            AudioManager.instance.PlayMusic(clipToPlay, 2);
            Invoke("PlayMusic", clipToPlay.length);
        }
    }
}
