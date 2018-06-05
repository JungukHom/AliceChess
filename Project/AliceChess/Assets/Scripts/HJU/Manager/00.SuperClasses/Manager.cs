using System;
using UnityEngine;
using UnityEngineInternal;

using Utility;

namespace Manager
{
    public class Manager : MonoBehaviour
    {
        protected GameManager gameManager;

        private void Awake()
        {
            gameManager = GameObject.FindGameObjectWithTag(Utility.DataManager.Tag.gameManager).GetComponent<GameManager>();
        }

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
                    throw new Exception($"Can't find class inherits MonoBehaviour.Manager.");
                }
            }
            return component;
        }

        public T GetManager<T>() where T : Manager
        {
            return GetOrCreateManager<T>();
        }

        /// <summary>
        /// Get component in generics with string objectname.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectName"></param>
        /// <returns></returns>
        protected T FindComponent<T>(string objectName) where T : Component
        {
            return GameObject.Find(objectName).GetComponent<T>();
        }

        protected GameManager GetGameManager()
        {
            return GetComponent<GameManager>();
        }

        protected void DoNothing()
        {
            // do nothing
        }
    }
}