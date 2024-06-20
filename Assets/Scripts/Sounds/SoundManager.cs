using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField][Range(0f, 1f)] private float musicVolume;
    [SerializeField][Range(0f, 1f)] private float effectVolume;

    private AudioSource musicAudioSource;
    public AudioClip[] musicClips;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        musicAudioSource = GetComponent<AudioSource>();
        musicAudioSource.volume = musicVolume;
        musicAudioSource.loop = true;
    }
    void Start()
    {
        // 처음 씬이 로드될 때 음악 재생
        PlayMusic(SceneManager.GetActiveScene().buildIndex);
    }

    public static SoundManager Instance
    {
        get
        {
            if (instance != null)
            {
                instance = FindObjectOfType<SoundManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("SoundManager");
                    instance = obj.AddComponent<SoundManager>();
                }
            }
            return instance;
        }
    }

    public void PlayMusic(int sceneIndex)
    {
        if (sceneIndex < 0 || sceneIndex >= musicClips.Length) return;
        musicAudioSource.clip = musicClips[sceneIndex];
        musicAudioSource.Play();
    }
}
