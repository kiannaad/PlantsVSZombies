using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public enum BGMType
{
    Start_slow,
    Start_middle,
    UI_Start,
    Progress,
    Start_fast,
    ThemeSong
}

public enum FXType
{
    AreComming,
    EA,
    buttonclick,
    cheerybomb,
    chomp,
    chompsoft,
    coffee,
    sunPoints,
    seedift,
    shoot,
    siren,
    squash_hmr,
    winmusic,
    readysetpla,
}

public class AudioManager : MonoSingleton<AudioManager>
{
    public AudioSource SourceBGM;
    public AudioSource SourceFX;
    
    private Dictionary<string, AudioClip> BGMs = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> FXs = new Dictionary<string, AudioClip>();
    
    private void Awake()
    {
        StartCoroutine(InitDictionary(BGMs, "BGM"));
        StartCoroutine(InitDictionary(FXs, "FX"));
    }

    public void PlayBGM(BGMType type, AudioSource source)
    {
        source.Stop();
        if (BGMs.ContainsKey(type.ToString()))
        {
            source.clip = BGMs[type.ToString()];
        }
        source.Play();
    }

    public void PlayFX(FXType type, AudioSource source)
    {
        source.Stop();
        if (FXs.ContainsKey(type.ToString()))
        {
            source.clip = FXs[type.ToString()];
        }
        source.Play();
    }
    
    public bool isPlaying() => SourceBGM.isPlaying;

    private IEnumerator InitDictionary(Dictionary<string, AudioClip> dic, string label)
    {
        var loadHeadle = Addressables.LoadResourceLocationsAsync(label, typeof(AudioClip));
        
        if (!loadHeadle.IsDone)
            yield return loadHeadle;
        
        List<AsyncOperationHandle> handles = new List<AsyncOperationHandle>();
        
        foreach (var obj in loadHeadle.Result)
        {
            var objHandle = Addressables.LoadAssetAsync<AudioClip>(obj);

            objHandle.Completed += add =>
            {
                dic.Add(obj.PrimaryKey, objHandle.Result);
            };
                handles.Add(objHandle);
        }

        var Group = Addressables.ResourceManager.CreateGenericGroupOperation(handles);
        
        if (!Group.IsDone)
            yield return Group;
        
        Addressables.Release(Group);

        foreach (var obj in dic)
        {
            //Debug.Log(obj.Key + " : " + obj.Value);
        }
    }
}
