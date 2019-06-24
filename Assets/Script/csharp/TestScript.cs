using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSharpTest;
using System.IO;

namespace CSharpTest
{
    public class TestScript : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            float base_number = 0;
            base_number = 16777200f;
            base_number = 16777200.22f;
            base_number = 16777216f;
            base_number = 16777216.6666f;
            base_number = 99999992f;
            base_number = 99999993f;
            base_number = 99999994f;
            base_number = 99999995f;
            base_number = 99999996f;
            base_number = 99999997f;
            base_number = 99999998f;
            base_number = 99999999f;

            decimal dec_number = 9999999999;
            dec_number = dec_number * 10;
            
            
            float proccess = Mathf.Lerp(0f, base_number, 1f);
            GameLogger.LogError("process = " + proccess.ToString());
            long long_process = (long)proccess;
            GameLogger.LogError("long_process = " + long_process.ToString());
            
            float long_process_ex = base_number * 1f;
            GameLogger.LogError("long_process_ex = " + long_process_ex.ToString());
            long long_process_exx = (long)long_process_ex;
            GameLogger.LogError("long_process_exx = " + long_process_exx.ToString());
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnGUI()
        {
            if (GUILayout.Button("T E S T"))
            {
                TestIndexer();
            }
        }

        private void TestIndexer()
        {
            AnermyInfoItemIndexer indexer = new AnermyInfoItemIndexer();
            indexer["key1", 1] = new AnermyInfoItem("key1", 1, "King0101");
            indexer["key1", 2] = new AnermyInfoItem("key1", 2, "King0102");
            indexer["key1", 3] = new AnermyInfoItem("key1", 3, "King0103");
            indexer["key2", 1] = new AnermyInfoItem("key2", 1, "King0201");
            indexer["key2", 2] = new AnermyInfoItem("key2", 2, "King0202");
            indexer["key2", 3] = new AnermyInfoItem("key2", 3, "King0203");

            BetterList<AnermyInfoItem> arr = indexer["key2"];
            foreach(AnermyInfoItem data in arr)
            {
                Debug.Log(data.AnermyName + Path.DirectorySeparatorChar + data.EnermyLevel.ToString());
            }
        }
    }
}

