//
//  EventBus.cs
//
//  Author:
//       Tom Wright <arclight@alstudios.co.uk>
//
//  Copyright 2017  Tom Wright
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
using alstudios.vox3l.helpers;

using System.Collections.Generic;
using System.Reflection;

namespace alstudios.vox3l.events
{

	public class EventBus : Singleton<EventBus>
	{

		#region Variables

		private Dictionary<System.Type, Dictionary<EventPriority, List<MethodWrapper>>> _Listeners;

		#endregion

		#region Constructors

		private EventBus()
		{
			_Listeners = new Dictionary<System.Type, Dictionary<EventPriority, List<MethodWrapper>>>();
		}

		#endregion

		#region EventBus

		public void Trigger(Event eventArg)
		{
			foreach(KeyValuePair<EventPriority, List<MethodWrapper>> pair in _Listeners.TryOrCreate(eventArg.GetType(), false))
			{
				foreach(MethodWrapper listener in pair.Value)
				{
					if(eventArg.IsConsumed())
						break;

					listener.Invoke(eventArg);
				}
			}
		}

		public void Register(object eventListener)
		{
			foreach(MethodInfo method in eventListener.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public))
			{
				object[] attributes = method.GetCustomAttributes(typeof(EventListener), false);

				if(attributes.IsNullOrEmpty())
					continue;

				EventPriority priority = ((EventListener) attributes[0]).Priority;

				ParameterInfo[] parameters = method.GetParameters();

				if(parameters.Length != 1)
					continue;

				System.Type eventType = parameters[0].ParameterType;

				if(!eventType.IsSubclassOf(typeof(Event)))
					continue;

				Dictionary<EventPriority, List<MethodWrapper>> dictionary = _Listeners.TryOrCreate(eventType, true);

				if(dictionary.Count == 0)
				{
					dictionary.Add(EventPriority.HIGHEST, new List<MethodWrapper>());
					dictionary.Add(EventPriority.HIGHER, new List<MethodWrapper>());
					dictionary.Add(EventPriority.HIGH, new List<MethodWrapper>());
					dictionary.Add(EventPriority.NORMAL, new List<MethodWrapper>());
					dictionary.Add(EventPriority.LOW, new List<MethodWrapper>());
					dictionary.Add(EventPriority.LOWER, new List<MethodWrapper>());
					dictionary.Add(EventPriority.LOWEST, new List<MethodWrapper>());
				}

				List<MethodWrapper> listeners = dictionary.TryOrCreate(priority, true);
				listeners.Add(new MethodWrapper(eventListener, method));
				dictionary.Add(priority, listeners);
				_Listeners.Add(eventType, dictionary);
			}
		}

		#endregion

		private class MethodWrapper
		{

			#region Variables

			private object _Instance;
			private MethodInfo _Method;

			#endregion

			#region Constructors

			public MethodWrapper(object instance, MethodInfo method)
			{
				_Instance = instance;
				_Method = method;
			}

			#endregion

			#region MethodWrapper

			public void Invoke(Event eventArg)
			{
				_Method.Invoke(_Instance, new object[] { eventArg });
			}

			public object GetInstance()
			{
				return _Instance;
			}

			public MethodInfo GetMethod()
			{
				return _Method;
			}

			#endregion

			#region Object

			public override bool Equals(object obj)
			{
				if(!(obj is MethodWrapper))
					return false;

				MethodWrapper other = (MethodWrapper) obj;
				return _Instance.Equals(other.GetInstance()) && _Method.Equals(other.GetMethod());
			}

			public override int GetHashCode()
			{
				unchecked
				{
					int hash = 47;

					hash *= 227 + _Instance.GetHashCode();
					hash *= 227 + _Method.GetHashCode();

					return hash;
				}
			}

			#endregion

		}

	}

}

