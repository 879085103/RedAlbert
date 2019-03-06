using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

public abstract class ICharacter
{
    //获取管理角色的属性类
    protected ICharacterAttribute mAttr;
    //当前脚本所关联的游戏物体
    protected GameObject mGameObject;
    //角色的导航组件
    protected NavMeshAgent mNavAgent;
    //角色的AudioSource组件
    protected AudioSource mAudio;
    //角色的武器
    protected IWeapon mWeapon;
    //角色的动画播放组件
    protected Animation mAnim;

    protected bool mIsKilled = false;
    protected bool mCanDestroy = false;
    protected float mDestroyTimer = 2f;

    public bool canDestroy { get { return mCanDestroy; } }

    //当前角色的位置
    public Vector3 position
    {
        get
        {
            if(mGameObject == null)
            {
                Debug.LogError("mGameObject is null");
                return Vector3.zero;
            }
            return mGameObject.transform.position;
        }
    }
    //角色的攻击距离
    public float atkRange{ get { return mWeapon.atkRange; } }

    public IWeapon weapon
    {
        set
        {
            mWeapon = value;
            mWeapon.owner = this;
            //使武器在手上
            GameObject child = UnityTool.FindChild(mGameObject, "weapon-point");
            UnityTool.Attach(child, mWeapon.gameObject);
        }
        get
        {
            return mWeapon;
        }
    }

    public ICharacterAttribute Attr { set { mAttr = value; }  get { return mAttr; } }

    public GameObject gameObject
    {
        set
        {
            mGameObject = value;
            mNavAgent = mGameObject.GetComponent<NavMeshAgent>();
            mAudio = mGameObject.GetComponent<AudioSource>();
            mAnim = mGameObject.GetComponentInChildren<Animation>();
        }
        get
        {
            return mGameObject;
        }
    }
    public bool isKilled { get { return mIsKilled; } }

    public abstract void UpdateFSMAI(List<ICharacter> targets);
    public abstract void RunVisitor(ICharacterVisitor visitor);

    public void Update()
    {
        if(mIsKilled)
        {
            mDestroyTimer -= Time.deltaTime;
            if(mDestroyTimer <= 0)
            {
                mCanDestroy = true;
            }
            return;
        }
        mWeapon.Update();
    }

    public void Attack(ICharacter targetCharacter)
    {
        mWeapon.Fire(targetCharacter.position);
        //角色朝向攻击方向
        mGameObject.transform.LookAt(targetCharacter.position);
        PlayAnim("attack");
        targetCharacter.UnderAttack(mWeapon.atk + mAttr.critValue);
    }
    //处理掉血效果
    public virtual void UnderAttack(int damage)
    {
        mAttr.TakeDamage(damage);
        //被攻击的特效 只有敌人有
        //死亡的特效 音效 只有战士有
    }

    public void PlayAnim(string animName)
    {
        mAnim.CrossFade(animName);
    }

    public void MoveTo(Vector3 targetPosition)
    {
        mNavAgent.SetDestination(targetPosition);
        PlayAnim("move");
    }

    public virtual void Killed()
    {
        mIsKilled = true;
        //角色死亡时停止寻路
        mNavAgent.isStopped = true;
    }
    //角色死亡释放资源
    public void Release()
    {
        GameObject.Destroy(mGameObject);
    }

    //播放不同角色需要的特效
    protected void DoPlayEffect(string effectName)
    {
        //加载特效
        GameObject effectGO = FactoryManager.assetFactory.LoadEffect(effectName);
        effectGO.transform.position = position;
        //控制销毁
        effectGO.AddComponent<DestroyForTime>();
    }

    protected void DoPlaySound(string soundName)
    {
        AudioClip clip = FactoryManager.assetFactory.LoadAudioClip(soundName);
        mAudio.clip = clip;
        mAudio.Play();
    }

    
}

