using MMFair.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MMFair
{
	/// <summary>
	/// Map class extensions
	/// </summary>
	public static class ExtensionsMap
	{
		/// <summary>
		/// Write to file
		/// </summary>
		public static void writeToFile (this MapModel model, string filename)
		{
			FileStream		filestream	= null;
			StreamWriter	sw			= null;

			try
			{
				filestream	= File.Open (filename, FileMode.Create);
				sw			= new StreamWriter (filestream);

				// Write total status
				sw.WriteLine ("-------------------\r\nTOTAL INFO");
				sw.WriteLine ("All Nodes count :{0},\tSwitches count :{1},\tNodes count :{2}", model.allNodes.Count, model.switches.Count, model.nodes.Count);
				sw.WriteLine ("-------------------\r\n\r\n-------------------\r\nDETAILS\r\n-------------------");

				// Write detail
				foreach (BaseNode node in model.allNodes.Values)
					sw.WriteLine (node.ToString ());
				sw.WriteLine ("-------------------");

				sw.Close ();
				filestream.Close ();
			}
			catch (Exception ex)
			{
			}
			finally
			{
				if (null != sw)
					sw.Dispose ();
				if (null != filestream)
					filestream.Dispose ();
			}
		}
	}
}
