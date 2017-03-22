//
//  DirectorySettings.cs
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
using System.IO;

namespace alstudios.vox3l.settings
{
	
	public class DirectorySettings
	{

		#region Variables

		public string Root { get; private set; }

		public string Logs { get { return Path.Combine(Root, "logs"); } }

		public string Mods { get { return Path.Combine(Root, "mods"); } }

		public string ResourcePacks { get { return Path.Combine(Root, "resourcepacks"); } }

		public string Saves { get { return Path.Combine(Root, "saves"); } }

		#endregion

		#region Constructors

		public DirectorySettings(string rootPath)
		{
			Root = rootPath;
		}

		#endregion

	}

}

