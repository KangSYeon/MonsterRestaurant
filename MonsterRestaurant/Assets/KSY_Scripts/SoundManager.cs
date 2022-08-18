using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount
    }

    AudioSource[] _audioSources = new AudioSource[(int)Sound.MaxCount];

    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    public void Init()
    {
        GameObject root = GameObject.Find("@Sound");
        if (root == null)
        {
            root = new GameObject { name = "@Sound" };
            Object.DontDestroyOnLoad(root);

            string[] SoundNames = System.Enum.GetNames(typeof(Sound));

            for (int i = 0; i < SoundNames.Length - 1; i++)
            {

                GameObject go = new GameObject { name = SoundNames[i] };

                _audioSources[i] = go.AddComponent<AudioSource>();

                go.transform.parent = root.transform;
            }

            _audioSources[(int)Sound.Bgm].loop = true;
        }
    }

    public void Clear()
    {
        foreach ( AudioSource audioSource in _audioSources)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }

        _audioClips.Clear();
    }

    public void Play(string path, Sound type = Sound.Effect, float pitch = 1.0f)
    {
        AudioClip audioClip = GetOrAddAudioClip(path, type);
        Play(audioClip, type, pitch);
    }

    public void Play(AudioClip audioClip, Sound type = Sound.Effect, float pitch = 1.0f)
    {
        if (audioClip == null)
            return;

        // 음원 종류가 Bgm일 경우
        if (type == Sound.Bgm)
        {
            AudioSource audioSource = _audioSources[(int)Sound.Bgm];
            
            // 이전에 다른 BGM을 재생하고 있었을 경우에는 Bgm을 끄고 다음 Bgm을 재생
            if (audioSource.isPlaying)
                audioSource.Stop();

            audioSource.pitch = pitch;
            // Play()에 audioClip을 직접 넘겨줄 수 없으므로
            // audioSource에 접근해서 Clipdmf audioClip으로 설정해준다
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            AudioSource audioSource = _audioSources[(int)Sound.Effect];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip);
        }
    }

    AudioClip GetOrAddAudioClip (string path, Sound type = Sound.Effect)
    {
        // path 경로에 Sounds가 존재하지 않을 경우
        if (path.Contains("Sounds/") == false)
            path = $"Sounds/{path}";

        AudioClip audioClip = null;

        if (type == Sound.Bgm)
        {
            audioClip = Resources.Load<AudioClip>(path);
        }
        else
        {
            if (_audioClips.TryGetValue(path, out audioClip) == false)
            {
                audioClip = Resources.Load<AudioClip>(path);
                _audioClips.Add(path, audioClip);
            }
        }

        if (audioClip == null)
            Debug.Log($"audioClip missing ! {path}");

        return audioClip;
    }
}