using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MemInfo : ICloneable
{
    public string m_name = string.Empty;
    public string m_nickname = string.Empty;
    public int m_age = 0;

    public MemInfo(string name, string nickname, int age)
    {
        m_name = name;
        m_nickname = nickname;
        m_age = age;
    }

    public object Clone()
    {
        return MemberwiseClone();
    }

    public override string ToString()
    {
        return string.Format("{0} : {1} age is {2}", m_name, m_nickname, m_age);
    }
}


public class Team : ICloneable
{
    public List<MemInfo> m_mems = new List<MemInfo>();
    public Team()
    {

    }

    public Team(List<MemInfo> mems)
    {
        foreach(MemInfo mi in mems)
        {
            m_mems.Add(mi.Clone() as MemInfo);
        }
    }

    public void AddMember(MemInfo mi)
    {
        m_mems.Add(mi.Clone() as MemInfo);
    }

    public override string ToString()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        foreach(MemInfo mi in m_mems)
        {
            sb.AppendFormat("{0}\r\n", mi.ToString());
        }

        GameLogger.LogFormat("Team String : {0}", sb.ToString());

        return sb.ToString();
    }
    public object Clone()
    {
        //Deep Copy
        return new Team(m_mems);

        //Shallow Copy
        //return MemberwiseClone();
    }
}

public class ShallowDeepCopyTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // Create the original team.
        Team team = new Team();
        team.AddMember(new MemInfo("Anders", "Developer", 26));
        team.AddMember(new MemInfo("Bill", "Developer", 46));
        team.AddMember(new MemInfo("Steve", "CEO", 36));

        Team clone = team.Clone() as Team;

        // Display the original team.
        GameLogger.Log("Original Team:");
        GameLogger.Log(team.ToString());

        // Display the cloned team.
        GameLogger.Log("Clone Team:");
        GameLogger.Log(clone.ToString());

        // Make changes.
        GameLogger.Log("*** Make a change to original team ***");
        GameLogger.Log(Environment.NewLine);
        team.m_mems[0].m_nickname = "PM";
        team.m_mems[0].m_age = 30;

        // Display the original team.
        GameLogger.Log("Original Team:");
        GameLogger.Log(team.ToString());

        // Display the cloned team.
        GameLogger.Log("Clone Team:");
        GameLogger.Log(clone.ToString());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
