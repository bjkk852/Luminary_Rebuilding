using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePatturn2 : Patturn
{
    Vector3 v1, v2;
    bool isActivate;
    bool isDataSet;
    List<GameObject> shadows;
    List<GameObject> jellys;

    public override void Update()
    {
        if (issetData)
        {
            if (!isDataSet)
            {
                DunRoom currentRoom = GameManager.StageC.rooms[GameManager.StageC.currentRoom];
                mob.transform.position = currentRoom.gameObject.transform.position;
                (v1, v2) = currentRoom.roomRange();
                Debug.Log(v1);
                Debug.Log(v2);
                isDataSet = true;
            }
            if (!isActivate)
            {
                StartCoroutine(Action());
                isActivate = true;
            }
        }
    }

    public IEnumerator Action()
    {
        jellys = new List<GameObject>();
        shadows = new List<GameObject>();
        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 7; j++)
            {
                yield return new WaitForSeconds(0.15f);
                GameObject go = GameManager.Resource.Instantiate("Mobs/Slime/AttackPrefabs/RainShadow",transform);
                GameObject go2 = GameManager.Resource.Instantiate("Mobs/Slime/AttackPrefabs/Rain", transform);
                float rX = (float) GameManager.Random.getGeneralNext(v1.x, v2.x);
                float rY = (float)GameManager.Random.getGeneralNext(v1.y, v2.y);
                while (isNear(rX, rY))
                {
                    rX = (float)GameManager.Random.getGeneralNext(v1.x, v2.x);
                    rY = (float)GameManager.Random.getGeneralNext(v1.y, v2.y);
                }
                go.transform.position = new Vector3(rX, rY, 0);
                go2.transform.position = go.transform.position + new Vector3(0, 22, -22);
                go2.GetComponent<Rain>().shadow = go.GetComponent<RainShadow>();
                go2.GetComponent<MobAttack>().setData(mob);
                shadows.Add(go);
                jellys.Add(go2);
            }

            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(3f);
        foreach(GameObject go in shadows)
        {
            GameManager.Resource.Destroy(go);
        }
        shadows.Clear();

        yield return new WaitForSeconds(1f);

    }

    public bool isNear(float x, float y)
    {
        foreach(GameObject go in shadows)
        {
            Vector2 pos = go.transform.position;
            float distance = Mathf.Sqrt(Mathf.Pow(pos.x - x, 2) + Mathf.Pow(pos.y - y, 2));
            if (distance <= 0.25f)
                return true;
        }
        return false;
    }
}
