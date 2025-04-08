using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager instance;
    public List<ObjectInfo> objectInfoList;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        InitializePool();
    }
    public void InitializePool()
    {
        for(int i=0;i<objectInfoList.Count;i++)
        {
            objectInfoList[i].bulletParent=new GameObject("Object Pool(" +objectInfoList[i].bulletName+")");
            objectInfoList[i].bulletPool = new Queue<GameObject>();
            for (int j = 0; j < objectInfoList[i].poolSize; j++)
            {
                GameObject bullet = Instantiate(objectInfoList[i].bulletPrefab, objectInfoList[i].bulletParent.transform);
                bullet.gameObject.name = objectInfoList[i].bulletName;
                bullet.SetActive(false);
                objectInfoList[i].bulletPool.Enqueue(bullet);
            }
        }
        
        
    }

    public GameObject GetObjectFromPool(string bulletName)
    {
        for (int i = 0; i < objectInfoList.Count; i++)
        {
            if (objectInfoList[i].bulletName==bulletName)
            {
                if (objectInfoList[i].bulletPool.Count > 0)
                {
                    GameObject bullet = objectInfoList[i].bulletPool.Dequeue();
                    bullet.SetActive(true);
                    return bullet;
                }
                else
                {
                    GameObject bullet = Instantiate(objectInfoList[i].bulletPrefab, objectInfoList[i].bulletParent.transform);
                    return bullet;
                }
            }
        }
        return new GameObject();
    }
    public void ReturnObjectToPool(GameObject bullet)
    {
        bullet.SetActive(false);
        for (int i = 0; i < objectInfoList.Count; i++)
        {
            if (objectInfoList[i].bulletName == bullet.gameObject.name)
            {
                objectInfoList[i].bulletPool.Enqueue(bullet);
            }
        }
    }
}

[Serializable]
public class ObjectInfo
{
    public string bulletName;
    public GameObject bulletPrefab;
    public Queue<GameObject> bulletPool;
    public int poolSize;
    [HideInInspector]
    public GameObject bulletParent;
}