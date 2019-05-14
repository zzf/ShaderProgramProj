using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNull : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //TestNull_01();
        TestNull_02();
	}

    void TestNull_01()
    {
        GameObject go = new GameObject();
        Object ob = new Object();
        GameLogger.Log("go == null : " + (go == null));     // false
        GameLogger.Log("ob == null : " + (ob == null));     //true

        /*
         * Instatiating a GameObject adds it to the scene so it’s completely initialized (!destroyed). 
            Instantiating a simple UnityEngine.Object has no such semantics, so the it stays in the ‘destroyed’ state which compares true to null.

            这段话的意思是 建立一个游戏对象添加到场景中，这个对象是完全被建立的（分配了内存空间） 
            建立一个简单的UnityEngine.Object 对象是没有明确的语义的，（也是就是说不明确的制定，Object是基类，可以这么理解，你只说了我要一个东西，却不知道要什么东西，所以系统也就没办法去给你分配东西） 
            所以它的存在是相当于 销毁状态的（也就是null的状态）。所以上边第二个结果就是返回true了，这个是一个特殊的情况
         */
    }

    void TestNull_02()
    {
        /*
         * 由于C#本身有GC机制，当对象的引用为0的时候就会被垃圾回收，对应的引用则会被置为null;
         * 但Unity里边，调Destroy删除一个Object，只是释放了Unity的资源，而在C#层面，这个Object对应的引用都还在;
         * 那么它便不会被当成垃圾回收掉，所以C#层的资源并没有释放，但是拿它的引用跟null做对比确实相等的。
         * 代码跟到Unity Object脚本的实现，Unity里的MonoBehaver是继承自Object的，包括所有的Component也都是。跟到Object类之后 发现以下几句：
         * public static bool operator ==(Object x, Object y);
         * public static bool operator !=(Object x, Object y);
         * Object类重载了操作符 == 和 !=  ，所以Destroy了一个Unity对象的之后，在C#层的资源其实并没有被释放掉;
         * 当拿对应的引用变量来跟null做== !=判定的时候，因为对应的这个实例其实还是存在的，所以就会走到 被重载的==和!=操作符里，然后Unity直接给返回了一个true.      
         * 到这里应该基本上都清楚了，不过今天跟同事讨论的时候，发现用System.object去引用一个Unity的Object对象，然后Destroy调这个Object，再拿这个system.object的引用去跟null比较，返回的也是true的;
         * 当时还没想通呢，因为System.object是C#自己的类，并没有重载== 和！=操作符，以为应该返回false才对。现在想想，当时竟然把面向对象的概念都忘了。
         * System.object在C#里是所有类的父类，而Unity.Object也是C#写的，自然System.object也是Unity.Object的父类，那么拿一个父类引用对象去指向一个子类实例，而子类实例重载了父类的方法，那么父类里的方法自然就被隐藏掉了;
         * 实际调起的就是子类重载后的方法了。所以在上面的这个System.object引用Unity.Object的情况里，Object被Destroy之后，由于C#层的实例并没有被释放;
         * 所以当用System.object引用跟null做==判定的时候实际上走的还是Unity.Object里重载的这个==，因为这里的Unity.Object实际上是System.oobject的子类。

         * 这里说一个C#里另一个用来判null的操作符，?? 这个操作符并没有被Unity.Object重载，用来判Destroy之后的对象就不会返回true啦。
         */
        System.Object so = new System.Object();
        
        GameObject go = GameObject.Instantiate(gameObject);
        go.name = "go";
        GameObject.DestroyImmediate(go);
        GameLogger.Log("go == null : " + (go == null));

        GameObject go_temp = new GameObject();
        go_temp.name = "go_temp";
        //?? 取左边的值，如果左边值为null则取右边的值
        GameObject go1 = go ?? go_temp;
        if(null == go1)
        {
            GameLogger.Log("go1 == null");
        }
        else
        {
            GameLogger.Log("go1.name = " + go1.name);
        }        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
