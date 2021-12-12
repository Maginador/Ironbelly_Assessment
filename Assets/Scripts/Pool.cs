using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

    public class Pool : MonoBehaviour
    {
        public int poolSize = 0;
        public List<IPoolable> activePool;
        public List<IPoolable> inactivePool;
        public GameObject poolablePrefab;


        private void Start()
        {
            InitialializePool();
        }

        void InitialializePool()
        {
            if (poolablePrefab.GetComponent<IPoolable>() == null)
            {
                Debug.LogError("The Prefab Needs to Have a 'IPoolable' Component");
                return;
            }
            poolSize = 0;
            activePool = new List<IPoolable>();
            inactivePool = new List<IPoolable>();
        }

        public void AddElement()
        {
            poolSize++;
            
            if (inactivePool.Count == 0)
            {
                IncreasePoolSize();
            }
            else
            {
                ActivatePoolElement();
            }
        }

        private void ActivatePoolElement()
        {
            activePool.Add(inactivePool[0]);
            inactivePool.RemoveAt(0);
            activePool.Last().ActivatePoolable();
        }

        private void IncreasePoolSize()
        {
           var obj =  Instantiate(poolablePrefab);
           activePool.Add(obj.GetComponent<IPoolable>());
           activePool.Last().ActivatePoolable();

        }

        public void RemoveElement()
        {
            if (poolSize == 0)
            {
                return;
            }
            poolSize--;
            
            inactivePool.Add(activePool[0]);
            activePool.RemoveAt(0);
            inactivePool.Last().InactivatePoolable();
        }


        public void AddElements(int quantity)
        {
            for (var i = 0; i < quantity; i++)
            {
                AddElement();
            }
        }

        public void RemoveElements(int quantity)
        {
            for (var i = 0; i < quantity; i++)
            {
                RemoveElement();
            }
        }
    }