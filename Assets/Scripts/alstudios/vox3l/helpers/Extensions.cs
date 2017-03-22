//
//  Extensions.cs
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
using System.Collections.Generic;

namespace alstudios.vox3l
{
	
	public static class Extensions
	{

		#region Extensions

		public static bool IsNullOrEmpty(this System.Array array)
		{
			return array == null || array.Length == 0;
		}

		public static TValue TryOrCreate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
		{
			return dictionary.TryOrCreate(key, false);
		}

		public static TValue TryOrCreate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, bool deleteEntry)
		{
			TValue value;

			if(dictionary.TryGetValue(key, out value) && deleteEntry)
				dictionary.Remove(key);

			if(value == null)
				value = System.Activator.CreateInstance<TValue>();

			return value;
		}

		#endregion

	}

}

