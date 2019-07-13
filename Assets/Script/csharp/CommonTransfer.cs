using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CSharpLuaTest
{
    public class CommonTransfer
    {
        public static void SetPlayerInfo(int member_id, int open_id, string nick_name, int level = 0, int guid = 0)
        {
            GameLogger.Log("member_id = " + member_id.ToString() + "; open_id = " + open_id.ToString() + "; nick_name = " + nick_name + "; level = " + level.ToString() + "; guid = " + guid.ToString());
        }
    }
}

