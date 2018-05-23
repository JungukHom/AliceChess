using MyException;
using UnityEngine;
using UnityEngineInternal;

namespace Manager
{
    public class Manager : MonoBehaviour
    {
        /// <summary>
        /// Get or create Manager class.
        /// </summary>
        /// <typeparam name="T">Class inherits Manager class</typeparam>
        /// <returns></returns>
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public T GetOrCreateManager<T>() where T : Manager
        {
            T component = GetComponent<T>();
            if (!component)
            {
                Debug.Log("Component doesn't exist. Add manager component.");
                component = gameObject.AddComponent<T>(); // component = GetOrCreateManager<T>();

                if (!component)
                {
                    throw new InvalidClassException($"Can't find class inherits MonoBehaviour.");
                }
            }
            return component;
        }
    }
}