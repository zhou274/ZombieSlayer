﻿using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

namespace ZigZag
{
    /// <summary>
    /// Includes functions for loading levels and URLs. It's intended for use with UI Buttons
    /// </summary>
    public class ZIRLoadLevel : MonoBehaviour
    {
        [Tooltip("How many seconds to wait before loading a level or URL")]
        public float loadDelay = 1;

        [Tooltip("The name of the URL to be loaded")]
        public string urlName = "";

        [Tooltip("The name of the level to be loaded")]
        public string levelName = "";

        [Tooltip("The sound that plays when loading/restarting/etc")]
        public AudioClip soundLoad;

        [Tooltip("The tag of the source object from which sounds play")]
        public string soundSourceTag = "GameController";

        [Tooltip("The source object from which sounds play. You can assign this from the scene")]
        public GameObject soundSource;

        public string loadAnimation;

        public Transform transition;

        /// <summary>
        /// Start is only called once in the lifetime of the behaviour.
        /// The difference between Awake and Start is that Start is only called if the script instance is enabled.
        /// This allows you to delay any initialization code, until it is really needed.
        /// Awake is always called before any Start functions.
        /// This allows you to order initialization of scripts
        /// </summary>
        void Start()
        {
            // If there is no sound source assigned, try to assign it from the tag name
            if (!soundSource && GameObject.FindGameObjectWithTag(soundSourceTag)) soundSource = GameObject.FindGameObjectWithTag(soundSourceTag);
        }

        /// <summary>
        /// Loads the URL.
        /// </summary>
        /// <param name="urlName">URL/URI</param>
        public void LoadURL()
        {
            Time.timeScale = 1;

            // If there is a sound, play it from the source
            if (soundSource && soundLoad) soundSource.GetComponent<AudioSource>().PlayOneShot(soundLoad);

            // Execute the function after a delay
            Invoke("ExecuteLoadURL", loadDelay);
        }

        /// <summary>
        /// Executes the load URL function
        /// </summary>
        void ExecuteLoadURL()
        {
            Application.OpenURL(urlName);
        }

        /// <summary>
        /// Loads the level.
        /// </summary>
        /// <param name="levelName">Level name.</param>
        public void LoadLevel()
        {
            Time.timeScale = 1;

            // If there is a sound, play it from the source
            if (soundSource && soundLoad) soundSource.GetComponent<AudioSource>().PlayOneShot(soundLoad);

            if (transition) Instantiate(transition);

            // Execute the function after a delay
            Invoke("ExecuteLoadLevel", loadDelay);
        }

        /// <summary>
        /// Executes the Load Level function
        /// </summary>
        void ExecuteLoadLevel()
        {
            SceneManager.LoadScene(levelName);
        }

        /// <summary>
        /// Restarts the current level.
        /// </summary>
        public void RestartLevel()
        {
            Time.timeScale = 1;

            // If there is a sound, play it from the source
            if (soundSource && soundLoad) soundSource.GetComponent<AudioSource>().PlayOneShot(soundLoad);

            if (transition) Instantiate(transition);


            // Execute the function after a delay
            Invoke("ExecuteRestartLevel", loadDelay);
        }

        /// <summary>
        /// Executes the Load Level function
        /// </summary>
        void ExecuteRestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}