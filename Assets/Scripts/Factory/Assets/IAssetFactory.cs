using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//资源工厂
public interface IAssetFactory
{
    GameObject LoadSoldier(string name);
    GameObject LoadEnemy(string name);
    GameObject LoadWeapon(string name);
    GameObject LoadEffect(string name);
    AudioClip LoadAudioClip(string name);
    Sprite LoadSprite(string name);
}

