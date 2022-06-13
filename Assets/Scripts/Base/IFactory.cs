namespace Base.Util
{
    using System;
    using UnityEngine;

    public interface IFactory
    {
        T GetObject<T>() where T : MyObject;
        T GetObject<T>(int variantID) where T : MyObject;
        T GetObject<T>(int variantID, Transform parent) where T : MyObject;
        T GetObject<T>(Transform parent) where T : MyObject;
        MyObject GetObject(Type type);
        MyObject GetObject(Type type, int variantID);
        MyObject GetObject(Type type, int variantID, Transform parent);
    }
}
