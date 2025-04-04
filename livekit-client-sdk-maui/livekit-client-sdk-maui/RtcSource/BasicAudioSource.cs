using System;
using Plugin.Maui.Audio;
//using UnityEngine;

namespace LiveKit
{
    public class BasicAudioSource : RtcAudioSource
    {
        protected readonly IAudioPlayer Source;
        //UNITY

        public override event Action<float[], int, int> AudioRead;

        public BasicAudioSource(IAudioPlayer source, int channels = 2, RtcAudioSourceType sourceType = RtcAudioSourceType.AudioSourceCustom) : base(channels, sourceType)
        {
            Source = source;
            //UNITY
        }

        private void OnAudioRead(float[] data, int channels, int sampleRate)
        {
            AudioRead?.Invoke(data, channels, sampleRate);
        }

        public override void Play()
        {
            
            Source.Play();
        }

        public override void Stop()
        {
            
            Source.Stop();
        }
    }
}