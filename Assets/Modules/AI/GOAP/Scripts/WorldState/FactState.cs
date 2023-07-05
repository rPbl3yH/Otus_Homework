using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.GOAP
{
    [Serializable]
    public sealed class FactState : IFactState
    {
        [SerializeField]
        private Fact[] variables;

        public FactState(params Fact[] variables)
        {
            this.variables = variables;
        }

        public bool GetFact(string id)
        {
            for (int i = 0, count = this.variables.Length; i < count; i++)
            {
                var variable = this.variables[i];
                if (variable.id == id)
                {
                    return variable.value;
                }
            }

            throw new Exception($"Variable with {id} is not found");
        }

        public bool TryGetFact(string id, out bool value)
        {
            for (int i = 0, count = this.variables.Length; i < count; i++)
            {
                var variable = this.variables[i];
                if (variable.id == id)
                {
                    value = variable.value;
                    return true;
                }
            }

            value = default;
            return false;
        }

        public bool ContainsFact(string id)
        {
            for (int i = 0, count = this.variables.Length; i < count; i++)
            {
                var variable = this.variables[i];
                if (variable.id == id)
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<KeyValuePair<string, bool>> GetEnumerator()
        {
            for (int i = 0, count = this.variables.Length; i < count; i++)
            {
                var variable = this.variables[i];
                yield return new KeyValuePair<string, bool>(variable.id, variable.value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}