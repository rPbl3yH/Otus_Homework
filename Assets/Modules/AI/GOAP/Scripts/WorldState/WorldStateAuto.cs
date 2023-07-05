using System.Collections;
using UnityEngine;

namespace AI.GOAP
{
    [AddComponentMenu("AI/GOAP/World State Auto")]
    public class WorldStateAuto : WorldState
    {
        [Space]
        [SerializeField]
        private bool playOnStart = true;

        [Space]
        [SerializeField]
        private float minUpdatePeriod = 0.1f;

        [SerializeField]
        private float maxUpdatePeriod = 0.2f;
        
        private Coroutine coroutine;

        protected virtual void Start()
        {
            if (this.playOnStart)
            {
                this.Play();
            }
        }

        public void Play()
        {
            if (this.coroutine == null)
            {
                this.coroutine = this.StartCoroutine(this.UpdateLoop());
            }
        }

        public void Stop()
        {
            if (this.coroutine != null)
            {
                this.StopCoroutine(this.coroutine);
                this.coroutine = null;
            }
        }

        private IEnumerator UpdateLoop()
        {
            while (true)
            {
                var period = Random.Range(this.minUpdatePeriod, this.maxUpdatePeriod);
                yield return new WaitForSeconds(period);
                this.UpdateFacts();
            }
        }
    }
}