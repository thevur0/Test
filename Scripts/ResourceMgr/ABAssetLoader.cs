using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABAssetLoader : IAssetLoader {

    public T LoadAsset<T>(string sPath) where T : UnityEngine.Object
    {
        return Resources.Load<T>(sPath);
    }
    public int LoadAssetAsync<T>(string sPath, ResourceMgr.AssetLoadCompleted OnAssetLoadCompleted) where T : UnityEngine.Object
    {
        return 0;
    }
}
