using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  ScriptableObjectの利用側スクリプト
/// </summary>
namespace Sample
{
    public class Mob : MonoBehaviour
    {
        //  Load用パラメータ
        //※ここを公開し、ロードするデータを変更すれば初期値が変えられる。
        //  同じスクリプトでステータスだけ違うものへの利用 → スクリプトが減る。
        const string c_LoadPath = "EnemiesStaus";
        const int c_LoadIndex = 0;

        //現在のステータス
        EnemyStatus status;

        // Start is called before the first frame update
        void Start()
        {
            if (!Init())
            {
                Debug.Log("初期化失敗");
            }
            Display();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public bool Init()
        {
            //作成したScriptableObjectのロード行う。
            //※ここではResources.Loadを用いた簡易ロードで実装
            var data = Resources.Load<EnemiesStatus>(c_LoadPath);
            if (!data) { return false; }
            status = data.statusList[c_LoadIndex];
            return true;
        }

        public void Display()
        {
            Debug.Log("Name = " + status.name);
            Debug.Log("HP = " + status.hp);
            Debug.Log("ATK = " + status.atk);
            Debug.Log("DEF = " + status.def);
            Debug.Log("SPEED = " + status.spd);
        }
    }

}