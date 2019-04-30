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

