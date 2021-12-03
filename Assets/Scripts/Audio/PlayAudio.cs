using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip backgroundMusicSurface;
    #region Clip 
        
        // public AudioClip backgroundMusicMine;
        // public AudioClip walking;
        // public AudioClip voiceMine;
        // public AudioClip pickaxeMine;
        // public AudioClip fear;
        // public AudioClip minecart;
        // public AudioClip storeInteraction;
        // public AudioClip crystalChime;
        // public AudioClip oreDamage;
    #endregion
    #region Source
        public AudioSource m_backgroundMusicSurface = new AudioSource();
        public AudioSource m_backgroundMusicMine;
        public AudioSource m_walking;
        public AudioSource m_voiceMine;
        public AudioSource m_pickaxeMine;
        public AudioSource m_fear;
        public AudioSource m_minecart;
        public AudioSource m_storeInteraction;
        public AudioSource m_crystalChime;
        public AudioSource m_oreDamage;
    #endregion

    public void PlayBackgroundMusicSurface(){
        // Debug.Log(m_backgroundMusicSurface);
        // m_backgroundMusicSurface.Play();
    }
    // void StopBackgroundMusicSurface(){
    //     m_backgroundMusicSurface.clip = backgroundMusicSurface;
    //     m_backgroundMusicSurface.Stop();
    // }
    // void PlayBackgroundMusicMine(){
    //     m_backgroundMusicMine.clip = backgroundMusicMine;
    //     m_backgroundMusicMine.Play();
    // }
    // void StopBackgroundMusicMine(){
    //     m_backgroundMusicMine.clip = backgroundMusicMine;
    //     m_backgroundMusicMine.Stop();
    // }
    // void PlayWalking(){
    //     m_walking.clip = walking;
    //     m_walking.Play();
    // }
    // void StopWalking(){
    //     m_walking.clip = walking;
    //     m_walking.Stop();
    // }
    // void PlayVoiceMine(){
    //     m_voiceMine.clip = voiceMine;
    //     m_voiceMine.Play();
    // }
    // void StopVoiceMine(){
    //     m_voiceMine.clip = voiceMine;
    //     m_voiceMine.Stop();
    // }
    // void PlayPickaxeMine(){
    //     m_pickaxeMine.clip = pickaxeMine;
    //     m_pickaxeMine.Play();
    // }
    // void StopPickaxeMine(){
    //     m_pickaxeMine.clip = pickaxeMine;
    //     m_pickaxeMine.Stop();
    // }
    // void PlayFear(){
    //     m_fear.clip = fear;
    //     m_fear.Play();
    // }
    // void StopFear(){
    //     m_pickaxeMine.clip = pickaxeMine;
    //     m_pickaxeMine.Stop();
    // }
    // void PlayMinecart(){
    //     m_minecart.clip = minecart;
    //     m_minecart.Play();
    // }
    // void StopMinecart(){
    //     m_minecart.clip = minecart;
    //     m_minecart.Stop();
    // }
    // void PlayStoreInteraction(){
    //     m_storeInteraction.clip = storeInteraction;
    //     m_storeInteraction.Play();
    // }
    // void StopStoreInteraction(){
    //     m_storeInteraction.clip = storeInteraction;
    //     m_storeInteraction.Stop();
    // }
    // void PlayCrystalChime(){
    //     m_crystalChime.clip = crystalChime;
    //     m_crystalChime.Play();
    // }
    // void StopCrystalChime(){
    //     m_crystalChime.clip = crystalChime;
    //     m_crystalChime.Stop();
    // }
    // void PlayOreDamage(){
    //     m_oreDamage.clip = oreDamage;
    //     m_oreDamage.Play();
    // }
    // void StopOreDamage(){
    //     m_oreDamage.clip = oreDamage;
    //     m_oreDamage.Stop();
    // }
}
