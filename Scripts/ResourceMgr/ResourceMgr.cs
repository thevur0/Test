using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ResourceMgr : Singleton<ResourceMgr> {

    IAssetLoader m_Loader = null;
    public delegate void AssetLoadCompleted(int iHandle, UnityEngine.Object obj);
    public void Init()
    {
        m_Loader = new ResAssetLoader();
    }
    public T LoadAsset<T>(string sPath) where T : UnityEngine.Object
    {
        return m_Loader.LoadAsset<T>(sPath);
    }
    public int LoadAssetAsync<T>(string sPath, AssetLoadCompleted OnAssetLoadCompleted) where T : UnityEngine.Object
    {
        return m_Loader.LoadAssetAsync<T>(sPath, OnAssetLoadCompleted);
    }
}
