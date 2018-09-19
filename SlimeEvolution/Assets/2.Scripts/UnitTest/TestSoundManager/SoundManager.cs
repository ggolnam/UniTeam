using UnityEngine.Audio;
using UnityEngine;


public enum SoundFXType
{
    Test1 = 0,
    Test2 = 1,
    Test3 = 2,
    Test4 = 3,
    Test5 = 4
}

public enum BGMType
{
    Village = 0,
    BricksDungeon = 1,
    IronDungeon = 2,
    WoodDungeon = 3,
    SheepDungeon = 4,
    BossDungeon = 5
}


public class SoundManager : MonoBehaviour//Singleton<SoundManager>
{
    //public static SoundManager instance;
   
    [SerializeField]
    AudioClip[] SFXClips;
    [SerializeField]
    AudioClip[] BGMClips;
    AudioSource[] SoundSources;

    const int numberOfSFX = 15;
    const int numberOfBGM = 6;
    const int numberOfAudioSources = 6;

    public float sfxVolume;
    public float bgmVolume;

    void Awake()
    {
        sfxVolume = 1.0f;
        bgmVolume = 1.0f;
        //SFXClips = new AudioClip[numberOfSFX];
        BGMClips = new AudioClip[numberOfBGM];
        SoundSources = new AudioSource[numberOfAudioSources];

        for (int i = 0; i < numberOfAudioSources; i++)
        {
            SoundSources[i] = gameObject.AddComponent<AudioSource>();
        }

        DontDestroyOnLoad(gameObject);
    }

    public void LoadSoundClips()
    {
        SFXClips[0] = Resources.Load("") as AudioClip;
        //SFXClips[0] = AssetBundleManager.Instance.LoadSound(BundleType.Common, "MainBGM");
        //SFXClips[1] = AssetBundleManager.Instance.LoadSound(BundleType.Common, "ButtonClick");
    }


    public void SetSFX(SoundFXType soundType)
    {
        AudioClip audioClip;
        audioClip = SFXClips[(int)soundType];
        PlaySFX(audioClip);
    }

    public void SetBGM(BGMType bgmType)
    {
        AudioClip bgmClip;
        bgmClip = BGMClips[(int)bgmType];
        PlayBGM(bgmClip);
    }

    void PlayBGM(AudioClip bgmClip)
    {
        SoundSources[0].clip = bgmClip;
        SoundSources[0].Play();
        SoundSources[0].volume = bgmVolume;
        SoundSources[0].loop = true;
    }
    
    void PlaySFX(AudioClip audioClip)
    {
        for (int i = 1; i < SoundSources.Length; i++)
        {
            if((!SoundSources[i].isPlaying) || (SoundSources[i].clip == null))
            {
                SoundSources[i].clip = audioClip;
                SoundSources[i].volume = sfxVolume;
                SoundSources[i].Play();
                break;
            }
        }
    }

    public void SetVolume(float bgmVolume, float sfxVolume)
    {
        for (int i = 1; i < SoundSources.Length; i++)
        {
            SoundSources[i].volume = sfxVolume;
        }
        SoundSources[0].volume = bgmVolume;
    }
}
