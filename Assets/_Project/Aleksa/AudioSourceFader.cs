using UnityEngine;

namespace _Project.Aleksa
{
    public class AudioSourceFader
    {
        private readonly AudioSource _audioSource;
        private readonly float _duration;
        private readonly float _targetVolume;
        float _currentTime = 0;
        private float startVolume;


        public AudioSourceFader(AudioSource audioSource, float duration, float targetVolume)
        {
            _audioSource = audioSource;
            _duration = duration;
            _targetVolume = targetVolume;
            _currentTime = 0;
            startVolume = audioSource.volume;
        }

        public void StartFading()
        {
            var timedAction = AudioHolder.Instance.gameObject.AddComponent<TimedAction>();
            timedAction.AddTickAction(FadeTick);
            timedAction.StartTimedAction(()=> _audioSource.volume = _targetVolume, _duration);
        }
        
        public void StartFading(GameObject obj)
        {
            var timedAction = obj.AddComponent<TimedAction>();
            timedAction.AddTickAction(FadeTick);
            timedAction.StartTimedAction(()=> _audioSource.volume = _targetVolume, _duration);
        }

        private void FadeTick()
        {
            _currentTime += Time.deltaTime;
            _audioSource.volume = Mathf.Lerp(startVolume, _targetVolume, _currentTime / _duration);
        }
    }
}