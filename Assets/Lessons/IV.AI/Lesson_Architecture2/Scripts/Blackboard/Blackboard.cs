using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.AI.Architecture2
{
    public sealed class Blackboard : MonoBehaviour
    {
        public event Action<string, object> OnVariableAdded;
        
        public event Action<string, object> OnVariableRemoved;

        public event Action<string, object> OnVariableChanged;

        [ShowInInspector, ReadOnly]
        private readonly Dictionary<string, object> variables = new();

        public T GetVariable<T>(string key)
        {
            return (T) this.variables[key];
        }

        public bool TryGetVariable<T>(string key, out T value)
        {
            if (this.variables.TryGetValue(key, out var result))
            {
                value = (T) result;
                return true;
            }
            
            value = default;
            return false;
        }

        public bool HasVariable(string key)
        {
            return this.variables.ContainsKey(key);
        }
        

        
        [Title("Methods")]
        [Button]
        public void AddVariable(string key, object value)
        {
            if (this.variables.ContainsKey(key))
            {
                throw new Exception($"Variable {key} is already added!");
            }
            
            this.variables.Add(key, value);
            this.OnVariableAdded?.Invoke(key, value);
        }

        [Button]
        public void RemoveVariable(string key)
        {
            if (!this.variables.TryGetValue(key, out var value))
            {
                return;
            }

            this.variables.Remove(key);
            this.OnVariableRemoved?.Invoke(key, value);
        }

        public void ChangeVariable(string key, object value)
        {
            if (!this.variables.ContainsKey(key))
            {
                throw new Exception($"Variable {key} is not found!");
            }
            
            this.variables[key] = value;
            this.OnVariableChanged?.Invoke(key, value);
        }
    }
}