using Sirenix.OdinInspector;
using UnityEngine;

namespace AI.GOAP
{
    public abstract class Actor : MonoBehaviour, IActor
    {
        public IFactState ResultState
        {
            get { return this.resultState; }
        }

        public IFactState RequiredState
        {
            get { return this.requiredState; }
        }

        [ShowInInspector, ReadOnly, PropertyOrder(-10)]
        public bool IsPlaying
        {
            get { return this.isPlaying; }
        }
        
        [Space]
        [SerializeField]
        private bool validate = true;

        [Space]
        [SerializeField]
        protected FactState resultState;

        [SerializeField]
        protected FactState requiredState;
        
        protected WorldState worldState;

        private bool isPlaying;

        private IActor.Callback callback;

        public abstract int EvaluateCost();

        public abstract bool IsValid();

        public void Play(IActor.Callback callback)
        {
            if (this.isPlaying)
            {
                return;
            }
            
            if (this.validate)
            {
                if (!this.IsValid())
                {
                    callback?.Invoke(this, false);
                    return;
                }    
                
                this.worldState.UpdateFacts();
                if (!this.requiredState.EqualsTo(this.worldState))
                {
                    callback?.Invoke(this, false);
                    return;
                }
            }

            this.callback = callback;
            this.isPlaying = true;
            this.Play();
        }

        public void Cancel()
        {
            if (!this.IsPlaying)
            {
                return;
            }

            this.OnCancel();
            this.isPlaying = false;
            this.callback = null;
            this.OnDispose();
        }

        protected abstract void Play();

        protected virtual void Return(bool success)
        {
            if (!this.isPlaying)
            {
                return;
            }
            
            this.isPlaying = false;
            this.OnReturn();
            this.OnDispose();

            if (this.validate)
            {
                this.worldState.UpdateFacts();
                if (!this.resultState.EqualsTo(this.worldState))
                {
                    success = false;
                }
            }
            
            this.InvokeCallback(success);
        }

        #region Callbacks

        protected virtual void OnReturn()
        {
        }

        protected virtual void OnCancel()
        {
        }

        protected virtual void OnDispose()
        {
        }

        #endregion

        private void InvokeCallback(bool success)
        {
            if (this.callback == null)
            {
                return;
            }

            var callback = this.callback;
            this.callback = null;
            callback.Invoke(this, success);
        }

        public virtual void Construct(WorldState worldState)
        {
            this.worldState = worldState;
        }
    }
}