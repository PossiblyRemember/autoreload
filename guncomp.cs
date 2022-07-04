using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class QuickSpawn : MonoBehaviour {
    SpawnableAsset Entity;
    GameObject Entity2;
    CatalogBehaviour CG;
    GameObject mousePos;
    Category entities;
    public static QuickSpawn inst = null;

	public bool doActivator = false;

    void Awake(){
        CG = (CatalogBehaviour)FindObjectOfType(typeof(CatalogBehaviour));
        if(inst == null) {
            inst = this;
            //DontDestroyOnLoad(gameObject);
            //DontDestroyOnLoad(this);
            CatalogBehaviour.SpawnedGameObjects.Remove(gameObject);
            this.gameObject.layer = 31;
			if (doActivator){
            ModAPI.Notify("Quick Respawner / Auto Activator Acivated! Press H to quick spawn a copy of the entity you last spawned.");
			}
			else {
				ModAPI.Notify("Quick Respawner Acivated! Press H to quick spawn a copy of the entity you last spawned.");
			}
			

		}
        else
            Destroy(gameObject);

        mousePos = new GameObject("mousePos");

        entities = ModAPI.FindCategory("Entities");
        CatalogBehaviour.SpawnedGameObjects.Remove(gameObject);

    }            
    void Update(){
		//Debug.Log(Entity);

		if (doActivator){
			PersonBehaviour[] people = FindObjectsOfType<PersonBehaviour>();
			foreach (PersonBehaviour person in people) {
				ActiveHuman AH = person.gameObject.GetComponent<ActiveHuman>();
				if(!AH) {
					person.gameObject.AddComponent<ActiveHuman>();
				}
			}
		}

		Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        mousePos.transform.position = pz;
        if(Input.GetKeyUp("h") && Entity && Entity2) {
            //Debug.Log(Entity.name);
            Spawn(Entity, false);
        }
        else if(CG.SelectedItem.Category == entities && CG.SelectedCategory == entities) {

            //ModAPI.OnItemSpawned += (sender, being) => {
                //Debug.Log(ModAPI.FindSpawnable(being.Instance.name).Category);
               // if(ModAPI.FindSpawnable(being.Instance.name).Category == entities) {
                    //Debug.Log("entity");

                    Entity = CG.SelectedItem;
                    Entity2 = CG.SelectedItem.Prefab;
                    //Debug.Log(Entity);
                    //Debug.Log(Entity2);
                //}
                //
            //};
        }
    }

    private void Spawn(SpawnableAsset e, bool flipped) {
        if (Entity ){
            GameObject instance = UnityEngine.Object.Instantiate<GameObject>(Entity2, Global.main.MousePosition, Quaternion.identity);
            instance.AddComponent<DeregisterBehaviour>();
            if(flipped) {
                Vector3 localScale = instance.transform.localScale;
                localScale.x *= -1f;
                instance.transform.localScale = localScale;
            }
            instance.AddComponent<TexturePackApplier>();
            instance.AddComponent<AudioSourceTimeScaleBehaviour>();
            instance.AddComponent<SerialiseInstructions>().OriginalSpawnableAsset = e;
            instance.name = e.name;
            CatalogBehaviour.SpawnedGameObjects.Add(instance);
            UndoControllerBehaviour.RegisterAction((IUndoableAction)new ObjectCreationAction((UnityEngine.Object)instance));
            //StatManager.IncrementInteger(StatManager.Stat.TOTAL_SPAWNED_ITEMS, 1);
            CatalogBehaviour.PerformMod(e, instance);
        }
    }
}
