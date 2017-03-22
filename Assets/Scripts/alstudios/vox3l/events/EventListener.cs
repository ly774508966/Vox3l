//
//  EventListenerAttribute.cs
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

namespace alstudios.vox3l.events
{

	[System.AttributeUsage(System.AttributeTargets.Method)]
	public class EventListener : System.Attribute
	{

		#region Variables

		private EventPriority _priority;

		public EventPriority Priority
		{
			get { return _priority; }
			set { _priority = value; }
		}

		#endregion

		#region Constructors

		public EventListener()
		{
			_priority = EventPriority.NORMAL;
		}

		#endregion

	}

}

