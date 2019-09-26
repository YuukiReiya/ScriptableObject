using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class Boss : MonoBehaviour
    {
        //  Load用パラメータ
        const string c_LoadPath = "EnemiesStaus";
        const int c_LoadIndex = 1;

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