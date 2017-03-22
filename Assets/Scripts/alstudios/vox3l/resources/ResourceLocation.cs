//
//  ResourceLocation.cs
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

namespace alstudios.vox3l.resources
{
	
	public class ResourceLocation
	{

		#region Variables

		public string Domain;
		public string Path;

		#endregion

		#region Constructors

		public ResourceLocation(string path)
		{
			string[] split = path.Split(':');

			if(split.Length == 1)
			{
				Domain = "vox3l";
				Path = path;
				return;
			}

			if(split.Length != 2)
				throw new System.Exception("ResourceLocation must be defined as either 'domain:path' (e.g. vox3l:textures/...) and not '" + path + "'.");

			Domain = split[0];
			Path = split[1];
		}

		public ResourceLocation(string domain, string path)
		{
			Domain = domain;
			Path = path;
		}

		#endregion

		#region ResourceLocation

		#endregion

		#region Object

		public override bool Equals(object obj)
		{
			if(!(obj is ResourceLocation))
				return false;

			ResourceLocation other = (ResourceLocation) obj;
			return Domain.Equals(other.Domain) && Path.Equals(other.Path);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = 47;

				hash *= 227 + Domain.GetHashCode();
				hash *= 227 + Path.GetHashCode();

				return hash;
			}
		}

		#endregion

	}

}

