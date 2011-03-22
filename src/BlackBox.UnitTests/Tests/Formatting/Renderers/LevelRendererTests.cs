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

using System;
using BlackBox.Formatting;
using NUnit.Framework;

namespace BlackBox.UnitTests.Tests.Formatting
{
	[TestFixture]
	public class LevelRendererTests
	{
		#region Private Helper Methods
		private string Render(string format, LogLevel level)
		{
			LogKernel kernel = new LogKernel(new LogConfiguration());
			ILogger logger = kernel.GetLogger();
			FormatPatternFactory factory = new FormatPatternFactory();
			FormatPattern pattern = factory.Create(format);
			ILogEntry entry = new LogEntry(DateTimeOffset.Now, level, "The log message.", logger, null);
			return pattern.Render(entry);
		}
		#endregion

		[Test]
		public void LevelRenderer_RenderName()
		{
			string format = "$(level(numeric=false))";
			Assert.AreEqual("Verbose", this.Render(format, LogLevel.Verbose));
		}

		[Test]
		public void LevelRenderer_RenderFullName()
		{
			string format = "$(level(numeric=true))";
			Assert.AreEqual("4", this.Render(format, LogLevel.Verbose));
		}
	}
}
