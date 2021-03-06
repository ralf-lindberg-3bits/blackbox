﻿//
// Copyright 2011 Patrik Svensson
//
// This file is part of BlackBox.
//
// BlackBox is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// BlackBox is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU Lesser Public License for more details.
//
// You should have received a copy of the GNU Lesser Public License
// along with BlackBox. If not, see <http://www.gnu.org/licenses/>.
//

using System.IO;
using System.Reflection;

namespace BlackBox.Formatting
{
	[FormatRendererType("basedir")]
	internal sealed class BaseDirectoryRenderer : FormatRenderer
	{
		private readonly string _baseDirectory;

		internal BaseDirectoryRenderer()
		{
			// Get the location of the executing assembly.
			Assembly assembly = Assembly.GetEntryAssembly();
			if (assembly == null)
			{
				throw new BlackBoxException("Cannot resolve base directory.");
			}
			_baseDirectory = Path.GetDirectoryName(assembly.Location);
		}

		public override string Render(ILogEntry context)
		{
			return _baseDirectory;
		}
	}
}
