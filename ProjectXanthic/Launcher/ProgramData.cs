using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher
{
	public class ProgramData
	{
		public string ProgramPath { get; }
		public string ProgramName { get; }
		public string BackgroundImagePath { get; }

		public ProgramData(string programPath, string programName, string imagePath)
		{
			ProgramPath = programPath;
			ProgramName = programName;
			BackgroundImagePath = imagePath;
		}
	}
}
