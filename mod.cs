using System.Collections;
using System;
using UnityEngine;
using System.Globalization;

namespace Mod
{
    public class Mod : MonoBehaviour
    {

        public static string ModTag = " <color=red>[PRMods]";
        public static string NameTag = " - <color=red>Possibly Remember";
        public static void Main()
        //public static Vector2(-4, 0);
        {
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("brick"),
                    NameOverride = "Spawn me!" + ModTag,
                    DescriptionOverride = "                                                                       hello" + NameTag,
                    CategoryOverride = ModAPI.FindCategory("Living"),
                    ThumbnailOverride = ModAPI.LoadSprite("sprites/item.png"),
                    AfterSpawn = (Instance) =>
                    {
                        //UnityEngine.Object.Destroy(Instance.GetComponent<Collider2D>());
                        //Instance.AddComponent<PolygonCollider2D>();
                        //Instance.GetComponent<PolygonCollider2D>().pathCount = 2;
                        //Instance.GetComponent<PolygonCollider2D>().autoTiling = true;
                        //UnityEngine.Object.Destroy(Instance.GetComponent<LaserReceiverBehaviour>().Light);
                        Instance.GetComponent<SpriteRenderer>().enabled = false;
                        UnityEngine.Object.Destroy(Instance.GetComponent<PhysicalBehaviour>());
                        UnityEngine.Object.Destroy(Instance.GetComponent<BoxCollider2D>());
                        UnityEngine.Object.Destroy(Instance.GetComponent<Rigidbody2D>());
                        Instance.AddComponent<guncomp>(); //why did I call it gun comp I'm replacing the gun not compressing it
                    }
                }
            );
        }
    }
    public class Reciever : object
    {

    }
}