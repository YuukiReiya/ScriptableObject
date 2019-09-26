using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// ScriptableObjectの管理用データ
/// </summary>
namespace Sample
{
    /// <summary>
    /// 【ScriptableObjectの作り方①】
    /// Assets/Create にScriptableObjectを作るメニューを追加
    /// ※引数無しが可能
    /// </summary>
    [CreateAssetMenu(fileName ="EnemiesStatus",menuName ="ScriptableObjectSample/EnemiesStatus")]
    public class EnemiesStatus : ScriptableObject
    {
        public List<EnemyStatus> statusList;

        /// <summary>
        /// 【ScriptableObjectの作り方②】
        /// メニューウィンドウを用意し、関数を実行する従来のやり方も可能
        /// </summary>
        [MenuItem("ScriptableObject/Create/EnemiesStatus")]
        static void Create()
        {
            var inst = ScriptableObject.CreateInstance<EnemiesStatus>();
            inst.statusList = new List<EnemyStatus>();
            var mob = new EnemyStatus();
            var boss = new EnemyStatus();
            // Mob
            {
                mob.name = "mob";
                mob.hp = 10;
                mob.atk = 5;
                mob.def = 0;
                mob.spd = 3;
            }

            //Boss
            {
                boss.name = "boss";
                boss.hp = 100;
                boss.atk = 80;
                boss.def = 50;
                boss.spd = 70;
            }

            //  add list
            inst.statusList.Add(mob);
            inst.statusList.Add(boss);

            //  create asset
            AssetDatabase.CreateAsset(inst, "Assets/ScriptableObject/EnemiesStaus.asset");
        }
    }
    [System.Serializable]
    public struct EnemyStatus
    {
        public string name;//Names
        public int hp;//HP
        public int atk;//ATK
        public int def;//DEF
        public int spd;//SPEED
    }
}