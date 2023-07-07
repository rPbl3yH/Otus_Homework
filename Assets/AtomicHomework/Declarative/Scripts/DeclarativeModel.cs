using System;
using System.Collections.Generic;
using UnityEngine;

namespace Declarative
{
    public abstract class DeclarativeModel : MonoBehaviour
    {
        private Dictionary<Type, object> sections;

        private MonoContext monoContext;
        
        [SerializeField]
        private bool initOnAwake = true;

        public virtual void Initialize()
        {
            this.monoContext = new MonoContext(this);
            this.sections = SectionScanner.ScanSections(this);

            foreach (var section in this.sections.Values)
            {
                MonoContextInstaller.InstallElements(section, this.monoContext);
                SectionConstructor.ConstructSection(section, this);
            }
        }
        
        internal object GetSection(Type type)
        {
            return this.sections[type];
        }

        internal bool TryGetSection(Type type, out object section)
        {
            return this.sections.TryGetValue(type, out section);
        }

        private void Awake()
        {
            if (this.initOnAwake)
            {
                this.Initialize();
            }
            
            this.monoContext.Awake();
        }

        private void OnEnable()
        {
            this.monoContext.OnEnable();
        }

        private void Start()
        {
            this.monoContext.Start();
        }

        private void FixedUpdate()
        {
            this.monoContext.FixedUpdate(Time.fixedDeltaTime);
        }

        private void Update()
        {
            this.monoContext.Update(Time.deltaTime);
        }

        private void LateUpdate()
        {
            this.monoContext.LateUpdate(Time.deltaTime);
        }

        private void OnDisable()
        {
            this.monoContext.OnDisable();
        }

        private void OnDestroy()
        {
            this.monoContext.OnDestroy();
        }

#if UNITY_EDITOR
        [ContextMenu("Construct")]
        private void Construct()
        {
            this.Initialize();
            this.monoContext.Awake();
            this.monoContext.OnEnable();
            Debug.Log($"<color=#FF6235>: {this.name} successfully constructed!</color>");
        }

        [ContextMenu("Destruct")]
        private void Destruct()
        {
            if (this.monoContext != null)
            {
                this.monoContext.OnDisable();
                this.monoContext.OnDestroy();   
            }
            Debug.Log($"<color=#FF6235>: {this.name} successfully destructed!</color>");
        }
#endif
    }
}