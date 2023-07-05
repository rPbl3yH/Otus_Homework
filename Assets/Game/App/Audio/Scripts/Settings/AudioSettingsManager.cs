using System;
using Game.SceneAudio;
using UnityEngine;

namespace Game.App
{
    public static class AudioSettingsManager
    {
        private const float MUSIC_VOLUME = 0.5f;

        private const float SOUND_VOLUME = 0.5f;

        public static event Action<float> OnMusicVolumeChangd;

        public static event Action<float> OnSoundVolumeChanged;

        public static float MusicVolume { get; private set; }

        public static float SoundVolume { get; private set; }

        public static void SetMusicVolumeDefault()
        {
            SetMusicVolume(MUSIC_VOLUME);
        }

        public static void SetSoundVolumeDefault()
        {
            SetSoundVolume(SOUND_VOLUME);
        }

        public static void SetMusicVolume(float volume)
        {
            volume = Mathf.Clamp01(volume);
            MusicVolume = volume;

            MusicManager.Volume = volume;
            OnMusicVolumeChangd?.Invoke(volume);
        }

        public static void SetSoundVolume(float volume)
        {
            volume = Mathf.Clamp01(volume);
            SoundVolume = volume;

            UISoundManager.Volume = volume;
            SceneAudioManager.SetVolumeAll(volume);

            OnSoundVolumeChanged?.Invoke(volume);
        }
    }
}