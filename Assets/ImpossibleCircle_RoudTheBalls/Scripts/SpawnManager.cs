using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Class in charge to pooled the particle to not have to instantiate and destroy them each time the player make a point (about 200 particles each time the player earns 1 point).
/// </summary>
public class SpawnManager : Singleton<SpawnManager> 
{
	public GameObject particle;
	//List<EllipsoidParticleEmitter> listParticle = new List<EllipsoidParticleEmitter>();

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	public void Init()
	{
		CreatePoolParticle();
	}

	void CreatePoolParticle()
	{
		/*while(listParticle.Count < 300)
		{
			var go = Instantiate(particle) as GameObject;
			go.gameObject.SetActive(false);
			go.transform.parent = transform;
			var epe = go.GetComponent<EllipsoidParticleEmitter>();
			listParticle.Add(epe);
		}*/
	}

	public void SpawnParticle(Color c, Vector3 pos, Vector3 rot)
	{
		/*EllipsoidParticleEmitter p = listParticle.Find(pa => pa.gameObject.activeInHierarchy == false);

		while(p == null)
		{
			var go = Instantiate(particle) as GameObject;
			go.gameObject.SetActive(false);
			go.transform.parent = transform;
			var epe = go.GetComponent<EllipsoidParticleEmitter>();
			listParticle.Add(epe);

			p = listParticle.Find(pa => pa.gameObject.activeInHierarchy == false);
		}


		p.GetComponent<ParticleRenderer>().material.SetColor("_TintColor", c);
		p.transform.position = pos;
		p.transform.eulerAngles = rot;
		p.gameObject.SetActive(true);
		p.Emit(5);*/
	}
}
