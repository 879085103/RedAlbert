using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ResourcesAssetProxyFactory : IAssetFactory
{
    private ResourcesAssetFactory mAssetFactory = new ResourcesAssetFactory();

    private Dictionary<string, GameObject> mSoldierDicts = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mEnemyDicts = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mWeaponDicts = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mEffectDicts = new Dictionary<string, GameObject>();
    private Dictionary<string, AudioClip> mAudioDicts = new Dictionary<string,AudioClip>();
    private Dictionary<string, Sprite> mSpriteDicts = new Dictionary<string, Sprite>();

    public AudioClip LoadAudioClip(string name)
    {
        if (mAudioDicts.ContainsKey(name))
        {
            return mAudioDicts[name];
        }
        else
        {
            //常量要通过类名来访问
            AudioClip asset = mAssetFactory.LoadAudioClip(name);
            mAudioDicts.Add(name, asset);
            return asset;
        }
    }

    public GameObject LoadEffect(string name)
    {
        if (mEffectDicts.ContainsKey(name))
        {
            return GameObject.Instantiate(mEffectDicts[name]);
        }
        else
        {
            //常量要通过类名来访问
            GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.EffectPath + name) as GameObject;
            mEffectDicts.Add(name, asset);
            return GameObject.Instantiate(asset);
        }
    }

    public GameObject LoadEnemy(string name)
    {
        if (mEnemyDicts.ContainsKey(name))
        {
            return GameObject.Instantiate(mEnemyDicts[name]);
        }
        else
        {
            //常量要通过类名来访问
            GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.EnemyPath + name) as GameObject;
            mEnemyDicts.Add(name, asset);
            return GameObject.Instantiate(asset);
        }
    }

    public GameObject LoadSoldier(string name)
    {
        if(mSoldierDicts.ContainsKey(name))
        {
            return GameObject.Instantiate(mSoldierDicts[name]);
        }else
        {
            //常量要通过类名来访问
            GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.SoldierPath + name) as GameObject;
            mSoldierDicts.Add(name, asset);
            return GameObject.Instantiate(asset);
        }
    }

    public Sprite LoadSprite(string name)
    {

        if (mSpriteDicts.ContainsKey(name))
        {
            return mSpriteDicts[name];
        }
        else
        {
            //常量要通过类名来访问
            Sprite asset = mAssetFactory.LoadSprite(name);
            mSpriteDicts.Add(name, asset);
            return asset;
        }
    }

    public GameObject LoadWeapon(string name)
    {
        if (mWeaponDicts.ContainsKey(name))
        {
            return GameObject.Instantiate(mWeaponDicts[name]);
        }
        else
        {
            //常量要通过类名来访问
            GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.WeaponPath + name) as GameObject;
            mWeaponDicts.Add(name, asset);
            return GameObject.Instantiate(asset);
        }
    }
}

