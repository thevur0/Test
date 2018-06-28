using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AsyncItem
{
    public AsyncItem(AsyncOperation async, Action OnCompeleted)
    {
        AsyncOptn = async;
        CompeletedAction = OnCompeleted;
    }
    public AsyncOperation AsyncOptn { get;protected set; }
    public Action CompeletedAction { get; protected set; }
}

public class AsyncOperateMgr : Singleton<AsyncOperateMgr> {

    LinkedList<AsyncItem> m_AsyncList = new LinkedList<AsyncItem>();
    public void Init(GameObject s)
    {
    }
    public void AddAsyncOperation(AsyncItem async)
    {
        m_AsyncList.AddLast(async);
    }

    
    public void CheckOperateState()
    {
        var item = m_AsyncList.First;
        while (item != m_AsyncList.Last)
        {
            if (item.Value.AsyncOptn.isDone)
            {
                item.Value.CompeletedAction.Invoke();
                var del = item;
                item = item.Next;
                m_AsyncList.Remove(del);
            }
            else
            {
                item = item.Next;
            }
            
        }
    }
}
