using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum WeaponType
{
    Gun = 0,
    Rifle = 1,
    Rocket = 2,
    MAX
}

public abstract class IWeapon
{
    protected WeaponBaseAttr mBaseAttr;
    //暴击伤害
    protected int mAtkPlusValue;
    //武器拥有者
    protected ICharacter mOwner;
    //武器本身
    protected GameObject mGameObject;

    protected ParticleSystem mPariticle;
    protected LineRenderer mLine;
    protected Light mLight;
    protected AudioSource mAudio;

    //特效显示时间
    protected float mEffectDisplayTime = 0;

    public int atk { get { return mBaseAttr.atk; } }
    public float atkRange{ get { return mBaseAttr.atkRange; } }
    public ICharacter owner { set { mOwner = value; } }
    public GameObject gameObject { get { return mGameObject; } }

    public IWeapon(WeaponBaseAttr baseAttr, GameObject gameObject)
    {
        mBaseAttr = baseAttr;
        mGameObject = gameObject;

        Transform effect = mGameObject.transform.Find("Effect");
        mPariticle = effect.GetComponent<ParticleSystem>();
        mLine = effect.GetComponent<LineRenderer>();
        mLight = effect.GetComponent<Light>();
        mAudio = effect.GetComponent<AudioSource>();
    }

    public void Update()
    {
        if(mEffectDisplayTime > 0)
        {
            mEffectDisplayTime -= Time.deltaTime;
            if(mEffectDisplayTime <= 0)
            {
                //关闭特效
                DisableEffect();
            }
        }
    }

    //模板方法模式
    public  void Fire(Vector3 targetPosition)
    {
        //显示枪口特效
        PlayMuzzleEffect();

        //显示子弹轨迹
        PlayBulletEffect(targetPosition);

        //设置特效显示时间
        SetEffectDisplayTime();

        //播放声音
        PlaySound();
    }

    //设置特效显示时间
    protected abstract void SetEffectDisplayTime();

    //显示枪口特效
    protected virtual void PlayMuzzleEffect()
    {
        mPariticle.Stop();
        mPariticle.Play();
        mLight.enabled = true;
    }

    //显示子弹轨迹
    protected abstract void PlayBulletEffect(Vector3 targetPosition);

    protected void DoPlayBulletEffect(float width,Vector3 targetPosition)
    {
        mLine.enabled = true;
        mLine.startWidth = width; mLine.endWidth = width;
        mLine.SetPosition(0, mGameObject.transform.position);//设置开始位置
        mLine.SetPosition(1, targetPosition);//设置结束位置
    }

    //播放声音
    protected abstract void PlaySound();

    protected void DoPlaySound(string clipName)
    {
        AudioClip clip = FactoryManager.assetFactory.LoadAudioClip(clipName);
        mAudio.clip = clip;
        mAudio.Play();
    }

    private void DisableEffect()
    {
        mLine.enabled = false;
        mLight.enabled = false;
    }
}

