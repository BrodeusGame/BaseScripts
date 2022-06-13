namespace Base.Util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public class Factory : IFactory
    {
        public static IFactory Instace { get => Construction.Build(); }
        public static Builder Construction { get; private set; } = new Builder();

        private List<MyObject> _prefabs;

        private Factory()
        {
            _prefabs = new List<MyObject>();
        }

        public class Builder
        {
            private Factory _factory;

            public Builder()
            {
                _factory = new Factory();
            }

            public void AddPrefab(MyObject prefab)
            {
                if (!_factory._prefabs.Contains(prefab))
                    _factory._prefabs.Add(prefab);
            }

            public void AddPrefabOnPath(string path)
            {
                List<MyObject> prefabsOnPath = Resources.LoadAll<MyObject>(path).ToList();
                prefabsOnPath.ForEach(AddPrefab);
            }

            public void AddPrefabOnPathWithInstantiate(string path)
            {
                List<MyObject> prefabsOnPath = Resources.LoadAll<MyObject>(path).ToList();
                prefabsOnPath.ForEach(AddPrefab);
                prefabsOnPath.ForEach(p =>
                {
                    MonoBehaviour.Instantiate(p);
                });
            }

            public IFactory Build()
            {
                return _factory;
            }
        }


        public T GetObject<T>() where T : MyObject
        {
            if(!_prefabs.Any(p => p.GetType().Equals(typeof(T))))
            {
                Debug.LogError("Not exist in prefab : " + typeof(T).FullName);
                return null;
            }
            MyObject obj = _prefabs.Find(p => p.GetType().Equals(typeof(T)));
            return (T)MonoBehaviour.Instantiate(obj);
        }

        public T GetObject<T>(int variantID) where T : MyObject
        {
            if(!_prefabs.Any(p => p.GetType().Equals(typeof(T))))
            {
                Debug.LogError("Not exist in prefab : " + typeof(T).FullName);
                return null;
            }
            MyObject obj = _prefabs.Find(p => p.GetType().Equals(typeof(T)) && p.VariantID == variantID);
            return (T)MonoBehaviour.Instantiate(obj);
        }

        public T GetObject<T>(int variantID, Transform parent) where T : MyObject
        {
            if (!_prefabs.Any(p => p.GetType().Equals(typeof(T))))
            {
                Debug.LogError("Not exist in prefab : " + typeof(T).FullName);
                return null;
            }
            MyObject obj = _prefabs.Find(p => p.GetType().Equals(typeof(T)) && p.VariantID == variantID);
            return (T)MonoBehaviour.Instantiate(obj, parent);
        }

        public T GetObject<T>(Transform parent) where T : MyObject
        {
            return GetObject<T>(0, parent);
        }

        public MyObject GetObject(Type type)
        {
            if (!_prefabs.Any(p => p.GetType().Equals(type)))
            {
                Debug.LogError("Not exist in prefab : " + type.FullName);
                return null;
            }
            MyObject obj = _prefabs.Find(p => p.GetType().Equals(type));
            return MonoBehaviour.Instantiate<MyObject>(obj);
        }

        public MyObject GetObject(Type type, int variantID)
        {
            if (!_prefabs.Any(p => p.GetType().Equals(type)))
            {
                Debug.LogError("Not exist in prefab : " + type.FullName);
                return null;
            }
            MyObject obj = _prefabs.Find(p => p.GetType().Equals(type) && p.VariantID == variantID);
            return MonoBehaviour.Instantiate<MyObject>(obj);
        }

        public MyObject GetObject(Type type, int variantID, Transform parent)
        {
            if (!_prefabs.Any(p => p.GetType().Equals(type)))
            {
                Debug.LogError("Not exist in prefab : " + type.FullName);
                return null;
            }
            MyObject obj = _prefabs.Find(p => p.GetType().Equals(type) && p.VariantID == variantID);
            return MonoBehaviour.Instantiate<MyObject>(obj, parent);

        }
    }
}
