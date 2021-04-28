using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2020.04.04</para>
    /// <para>내    용 : 사운드에 대한 것을 관리하는 스크립트</para>
    /// </summary>
    public class DR_SoundManager : DR_Singlton<DR_SoundManager>
    {
        public AudioSource bgm;
        public AudioSource effect;
        Dictionary<string, AudioClip> clipContaniner = new Dictionary<string, AudioClip>();

        private void Reset()
        {
            bgm = gameObject.AddComponent<AudioSource>();
            effect = gameObject.AddComponent<AudioSource>();
        }

        private void Start()
        {
            if (bgm == null)
            {
                bgm = gameObject.AddComponent<AudioSource>();
            }
            if (effect == null)
            {
                effect = gameObject.AddComponent<AudioSource>();
            }

            SoundInit();
            GetVolume();
        }

        protected override void Func_Init()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void GetVolume()
        {
            bgm.volume = DR_ProgramManager.Instance.soundVolume.volume_BGM;
            effect.volume = DR_ProgramManager.Instance.soundVolume.volume_Effect;
        }

        private void SoundInit()
        {
            clipContaniner.Clear();
            ClipLoad();
        }

        private void ClipLoad()
        {
            LoadAllAudioClipFromPath(DR_PathDefine.Audio_BGMPath);
            LoadAllAudioClipFromPath(DR_PathDefine.Audio_EffectPath);
        }

        private void LoadAllAudioClipFromPath(string _folderPath)
        {
            UnityEngine.Object[] audioClipContainer = Resources.LoadAll(_folderPath);

            if (audioClipContainer == null)
            {
                return;
            }

            for (int i = 0; i < audioClipContainer.Length; i++)
            {
                if (clipContaniner.ContainsKey(audioClipContainer[i].name))
                {
                    clipContaniner.Remove(audioClipContainer[i].name);
                }
                clipContaniner.Add(audioClipContainer[i].name, (AudioClip)audioClipContainer[i]);
            }
        }

        public void BGMLoop(string _name)
        {
            bgm.clip = (clipContaniner[_name]);
            bgm.loop = true;
            bgm.Play();
        }

        public void EffectLoop(string _name)
        {
            effect.clip = (clipContaniner[_name]);
            effect.loop = true;
            effect.Play();
        }

        public void BGMPlayOneShot(string _name)
        {
            bgm.PlayOneShot(clipContaniner[_name]);
        }

        public void EffectPlayOneShot(string _name)
        {
            effect.PlayOneShot(clipContaniner[_name]);
        }

        public void EffectDelayOneShot(string _name, float _time)
        {
            StartCoroutine(Co_EffectDelayOneShot(_name, _time));
        }
        IEnumerator Co_EffectDelayOneShot(string _name, float _time)
        {
            yield return new WaitForSecondsRealtime(_time);
            effect.PlayOneShot(clipContaniner[_name]);
        }

        public void BGMPause()
        {
            bgm.Pause();
        }
        public void EffectPause()
        {
            effect.Pause();
        }

        public void BGMUnPause()
        {
            bgm.UnPause();
        }
        public void EffectUnPause()
        {
            effect.UnPause();
        }

        public void BGMStop()
        {
            bgm.loop = false;
            bgm.Stop();
        }
        public void EffectStop()
        {
            effect.Stop();
        }
    }
}