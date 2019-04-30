using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTest
{
    public abstract class ConfigItem
    {
        public string Key { get { return m_key; } set { m_key = value; } }
        protected string m_key = string.Empty;

        public abstract void Test();
    }

    public class BackPackItem : ConfigItem
    {
        public string ItemName { get { return m_itemName; } set { m_itemName = value; } }
        private string m_itemName = string.Empty;

        public override void Test()
        {

        }
    }

    public class AnermyInfoItem : ConfigItem
    {
        public AnermyInfoItem(string key, int anermylevel, string enermyname)
        {
            m_key = key;
            m_anermyName = enermyname;
            m_anermyLevel = anermylevel;
        }
        public AnermyInfoItem(string key, string enermyname, int anermylevel, int anermyvalue)
        {
            m_key = key;
            m_anermyName = AnermyName;
            m_anermyLevel = anermylevel;
            m_anermyLiftValue = anermyvalue;
        }
        private string m_anermyName = string.Empty;
        public string AnermyName { get { return m_anermyName; } set { m_anermyName = value; } }

        private int m_anermyLevel = 0;
        public int EnermyLevel { get { return m_anermyLevel; } set { m_anermyLevel = value; } }

        private int m_anermyLiftValue = 0;
        public int EnermyLiftValue { get { return m_anermyLiftValue; } set { m_anermyLiftValue = value; } }

        public override void Test()
        {
            throw new NotImplementedException();
        }
    }

    public class AnermyInfoItemIndexer
    {
        Dictionary<string, BetterList<AnermyInfoItem>> arr = null;
        public AnermyInfoItemIndexer()
        {
            arr = new Dictionary<string, BetterList<AnermyInfoItem>>();
        }

        public BetterList<AnermyInfoItem> this[string key]
        {
            get
            {
                return arr[key];
            }
        }

        public AnermyInfoItem this[string key, int level]
        {
            get
            {
                BetterList<AnermyInfoItem> list = null;
                if(arr.TryGetValue(key, out list))
                {
                    foreach (AnermyInfoItem data in list)
                    {
                        if (data.EnermyLevel == level)
                            return data;
                    }

                    return null;
                }
                else
                {
                    return null;
                }
            }

            set
            {
                BetterList<AnermyInfoItem> list = null;
                if(arr.TryGetValue(key, out list))
                {
                    arr[key].Add(new AnermyInfoItem(key, level, value.AnermyName));
                    return;
                }
                else
                {
                    arr[key] = new BetterList<AnermyInfoItem>();
                    arr[key].Add(new AnermyInfoItem(key, level, value.AnermyName));
                }
            }
        }
    }

    public class ConfigFile<T> where T : ConfigItem
    {
        Dictionary<string, T> m_cfgItems = new Dictionary<string, T>();
        public ConfigFile(string filename)
        {

        }

        public T GetItem(string key)
        {
            return m_cfgItems[key];
        }
    }


}
