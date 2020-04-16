using System;
using System.Collections.Generic;
using UnityEngine;

namespace HackManC1
{
    public class Evently
    {
        // This class will be a singleton
        // It will have as public, static ref to itself -- instance -- that can be accessed from any other script
        // It should have 3 methods: Subscribe, Unsubscribe, and Publish
        private static Evently instance;
        public static Evently Instance => instance ?? (instance = new Evently());
        private readonly Dictionary<Type, Delegate> delegates = new Dictionary<Type, Delegate>();

        public void Publish<T>(T e)
        {
            if (e == null)
            {
                Debug.Log($"Invalid event argument: {e.GetType()}");
            }
            if (delegates.ContainsKey(e.GetType()))
            {
                delegates[e.GetType()].DynamicInvoke(e);
            }
        }

        public void Subscribe<T>(Action<T> action)
        {
            if (delegates.ContainsKey(typeof(T)))
            {
                delegates[typeof(T)] = Delegate.Combine(delegates[typeof(T)], action);
            }
            else
            {
                delegates[typeof(T)] = action;
            }
        }

        public void Unsubscribe<T>(Action<T> action)
        {
            if (!delegates.ContainsKey(typeof(T))) return;
            var currentAction = Delegate.Remove(delegates[typeof(T)], action);

            if (currentAction == null)
            {
                delegates.Remove(typeof(T));
            }
            else
            {
                delegates[typeof(T)] = currentAction;
            }
        }
    }
}