using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BGMusicAstroRhythm : MonoBehaviour
{
    public void Awake()
    {
        if (getIntroBgMusic()!=null && getIntroBgMusic()!=this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            setIntroBgMusic(this);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    
    private static BGMusicAstroRhythm introBgMusic;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(16.0f);
        SceneManager.LoadScene(1);
    }
    public void setIntroBgMusic(BGMusicAstroRhythm BgMusic)
    {
        if (BgMusic!=null)
        {
            introBgMusic = BgMusic;
        }
    }
    public BGMusicAstroRhythm getIntroBgMusic()
    {
        return introBgMusic;
    }
    
}
