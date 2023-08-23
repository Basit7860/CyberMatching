﻿using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;

	public Sound[] sounds;

	private AudioSource[] allAudioSources;
	void Awake()
    {
        if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach(Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;
		}
    }

    public void Play(string sound)
    {
		Sound s = Array.Find(sounds, item => item.name == sound);
		if(s == null)
		{
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
    }

	

	public void StopAllAudio()
	{
		allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
		foreach (AudioSource audioS in allAudioSources)
		{
			audioS.Stop();
		}
	}
	
}
