using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLBASE
{
    /// <summary>
    /// 音频管理类
    /// </summary>
    public class AudioSys : ISys
    {
        private AudioSource audioSources;
        private bool m_Mutes;

        /// <summary>
        /// 播放音频
        /// </summary>
        /// <param name="name"></param>
        public void PlayAudio(string name)
        {
            if (m_Mutes)
            {
                return;
            }
            GameObject go = new GameObject();
            go.name = "Audio:" + name;
            AudioSource audioSource = go.AddComponent<AudioSource>();
            AudioClip audioClip = Resources.Load("Audio/" + name) as AudioClip;
            audioSource.clip = audioClip;
            audioSource.Play();
            float length = audioClip.length;
            SysManager.ObjectBase.StartCoroutine(GameUtlis.Wait(length, () =>
            {
                Object.Destroy(go);
            }));
        }

        /// <summary>
        /// 播放指定音频
        /// </summary>
        /// <param name="audioClip"></param>
        public void PlayAudio(AudioClip audioClip)
        {
            if (m_Mutes)
            {
                return;
            }
            GameObject go = new GameObject();
            go.name = "Audio:" + audioClip.name;
            AudioSource audioSource = go.AddComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.Play();
            float length = audioClip.length;
            SysManager.ObjectBase.StartCoroutine(GameUtlis.Wait(length, () =>
            {
                Object.Destroy(go);
            }));
        }

        /// <summary>
        /// 播放指定背景音频
        /// </summary>
        /// <param name="name"></param>
        public void PlayBGAudio(string name)
        {
            if (m_Mutes)
            {
                return;
            }
            GameObject go = new GameObject();
            AudioSource audioSource = go.AddComponent<AudioSource>();
            AudioClip audioClip = Resources.Load("Audio/" + name) as AudioClip;
            audioSource.clip = audioClip;
            audioSource.loop = true;
            audioSource.Play();
            go.name = "Audio:" + name;
            audioSources = audioSource;
        }

        /// <summary>
        /// 关闭所有音乐
        /// </summary>
        public void CloseAudio()
        {
            if (audioSources != null)
                audioSources.Pause();
        }

        /// <summary>
        /// 打开所有音乐
        /// </summary>
        public void OpenAudio()
        {
            if (audioSources != null)
                audioSources.Play();
        }

        /// <summary>
        /// 设置静音状态
        /// </summary>
        /// <param name="mute"></param>
        public void SetMute(bool mute)
        {
            m_Mutes = mute;
            if (mute)
            {
                CloseAudio();
            }
            else
            {
                OpenAudio();
            }
        }
    }
}