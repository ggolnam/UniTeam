
using UnityEngine;
using UnityEngine.UI;

public class TestSoundButton : MonoBehaviour {

    public SoundManager soundmanager;
    public Button button0;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    private void Awake()
    {
        button0.onClick.AddListener(delegate { soundmanager.SetSFX(SoundFXType.Test1); });
        button1.onClick.AddListener(delegate { soundmanager.SetSFX(SoundFXType.Test2); });
        button2.onClick.AddListener(delegate { soundmanager.SetSFX(SoundFXType.Test3); });
        button3.onClick.AddListener(delegate { soundmanager.SetSFX(SoundFXType.Test4); });
        button4.onClick.AddListener(delegate { soundmanager.SetSFX(SoundFXType.Test5); });
    }


}
