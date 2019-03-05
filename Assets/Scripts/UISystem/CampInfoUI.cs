using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class CampInfoUI:IUISystem
{
    private Image mCampIcon;
    private Text mCampName;
    private Text mCampLevel;
    private Text mWeaponLevel;
    private Button mCampUpgradeBtn;
    private Button mWeaponUpgradeBtn;
    private Button mTrainBtn;
    private Text mTrainBtnText;
    private Button mCancelTrainBtn;
    private Text mAliveCount;
    private Text mTrainningCount;
    private Text mTrainTime;

    private ICamp mCamp;

    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "CampInfoUI");

        mCampIcon = UITools.FindChild<Image>(mRootUI, "CampIcon");
        mCampName = UITools.FindChild<Text>(mRootUI, "CampName");
        mCampLevel = UITools.FindChild<Text>(mRootUI, "CampLevel");
        mWeaponLevel = UITools.FindChild<Text>(mRootUI, "WeaponLevel");
        mCampUpgradeBtn = UITools.FindChild<Button>(mRootUI, "CaptainUpgradeButton");
        mWeaponUpgradeBtn = UITools.FindChild<Button>(mRootUI, "WeaponUpgradeButton");
        mTrainBtn = UITools.FindChild<Button>(mRootUI, "TrainButton");
        mTrainBtnText = UITools.FindChild<Text>(mRootUI, "TrainButtonText");
        mCancelTrainBtn = UITools.FindChild<Button>(mRootUI, "CancelTrainButton");
        mAliveCount = UITools.FindChild<Text>(mRootUI, "AliveCount");
        mTrainningCount = UITools.FindChild<Text>(mRootUI, "TrainningCount");
        mTrainTime = UITools.FindChild<Text>(mRootUI, "TrainTime");

        mTrainBtn.onClick.AddListener(OnTrainBtnClick);
        mCancelTrainBtn.onClick.AddListener(OnCancelTrainBtnClick);
        mCampUpgradeBtn.onClick.AddListener(OnCampUpgradeClick);
        mWeaponUpgradeBtn.onClick.AddListener(OnWeaponUpgradeClick);

        Hide();

    }

    public override void Update()
    {
        base.Update();
        if(mCamp != null )
        {
            ShowTrainingInfo();
        }        
    }

    private void OnCancelTrainBtnClick()
    {
        //能量回收
        mFacade.RecycleEnergy(mCamp.energyCostTrain);
        mCamp.CancelTrainCommand();
    }

    private void OnTrainBtnClick()
    {
        //判断能量是否足够 
        int energy = mCamp.energyCostTrain;
        if(mFacade.TakeEnergy(energy))
        {
            mCamp.Train();
        }
        else
        {
            mFacade.ShowMsg("训练士兵需要能量:" + energy + "能量不足,无法训练新的士兵");
        }
    }

    private void OnCampUpgradeClick()
    {
        int energy = mCamp.energyCostCampUpgrade;
        if(energy < 0)
        {
            mFacade.ShowMsg("兵营已到最大等级,无法再升级");
            return;
        }
        //消耗能量
        if(mFacade.TakeEnergy(energy))
        {
            mCamp.UpgradeCamp();
            //更新UI
            ShowCampInfo(mCamp);
        }
        else
        {
            mFacade.ShowMsg("升级兵营需要能量:" + energy + "能量不足,请稍后进行升级");
        }
    }
       

    private void OnWeaponUpgradeClick()
    {
        int energy = mCamp.energyCostWeaponUpgrade;
        if(energy < 0)
        {
            mFacade.ShowMsg("武器已到最大等级,无法再升级");
            return;
        }
        if(mFacade.TakeEnergy(energy))
        {
            mCamp.UpgradeWeapon();
            //更新UI
            ShowCampInfo(mCamp);
        }
        else
        {
            mFacade.ShowMsg("升级武器需要能量:" + energy + "能量不足,请稍后进行升级");
        }

    }

    public void ShowCampInfo(ICamp camp )
    {
        Show();
        mCamp = camp;

        mCampIcon.sprite = FactoryManager.assetFactory.LoadSprite(camp.iconSprite);
        mCampName.text = camp.name;
        mCampLevel.text = camp.level.ToString();
        ShowWeaponLevel(camp.weaponType);
        mTrainBtnText.text = "训练\n" + mCamp.energyCostTrain + "点能量";
        ShowTrainingInfo();
       
    }

    private void ShowTrainingInfo()
    {
        mTrainningCount.text = mCamp.TrainCount.ToString();
        mTrainTime.text = mCamp.RemainingTrainTime.ToString("0.00");

        if (mCamp.TrainCount == 0)
        {
            mCancelTrainBtn.interactable = false;
        }else
        {
            mCancelTrainBtn.interactable = true;
        }
    }

    void ShowWeaponLevel(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.Gun:
                mWeaponLevel.text = "短枪";
                break;
            case WeaponType.Rifle:
                mWeaponLevel.text = "长枪";
                break;
            case WeaponType.Rocket:
                mWeaponLevel.text = "火箭";
                break;
            default:
                break;
        }
        
    }

    
}

