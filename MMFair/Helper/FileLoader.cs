using MMFair.Enums;
using MMFair.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MMFair.Helper
{
    /// <summary>
    /// File Loader
    /// </summary>
    public class FileLoader
    {
        #region Delegates
        #endregion

        #region Methods
        #endregion

        #region Constants
        #endregion

        #region Variables
        private string filename;
        #endregion

        #region Properties
        /// <summary>
        /// Map model
        /// </summary>
        public MapModel map
        {
            get;
            set;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Ctr
        /// </summary>
        public FileLoader(string filename)
        {
            this.filename = filename;
            map = new Models.MapModel();
        }

        /// <summary>
        /// Load File
        /// </summary>
        public void loadFile()
        {
			if (File.Exists (filename))
			{
				FileStream fs = File.Open(filename, FileMode.Open);
				StreamReader sr = new StreamReader(fs);

				// Clear old data
				map.clear();

				string curLine;

				while (!sr.EndOfStream)
				{
					curLine = sr.ReadLine();

					// Parese readed line
					parseLine(curLine);
				}

				fs.Close();
			}
        }

        /// <summary>
        /// Parse Line
        /// </summary>
        /// <param name="curLine">
        ///		NODE\tNAME,WIDTH
        ///		SWITCH\tNAME,TOTAL-WIDTH
        /// </param>
        private void parseLine(string curLine)
        {
			curLine	= curLine.Trim ();

            if (!curLine.Trim().StartsWith("#"))
            {
                string[] cmd = curLine.Trim().Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (1 < cmd.Length)
                {
                    // Command part
                    cmd[0] = cmd[0].Trim().ToLower();

                    if (cmd[0] == "node")
                        makeNode(cmd[1].Trim(), EnumNodeType.Node);
                    else if (cmd[0] == "switch")
                        makeNode(cmd[1].Trim(), EnumNodeType.Switch);
                    else if (cmd[0] == "connect")
                        connectNodes(cmd[1].Trim());
                }
            }
        }

        /// <summary>
        /// Connect nodes to switches
        /// </summary>
        /// <param name="args">
        ///		NODE-NAME,SWITCH-NAME
        /// </param>
        private void connectNodes(string args)
        {
            string[] parts = args.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (1 < parts.Length)
                map.connect(parts[0], parts[1]);
        }

        /// <summary>
        /// Make a node
        /// </summary>
        /// <param name="args">
        ///		NAME,WIDTH
        /// </param>
        private void makeNode(string args, EnumNodeType nodeType)
        {
            BaseNode node;
            string[] parts = args.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (1 < parts.Length)
            {
                string name;
                int width;

                #region Read args
                name = parts[0];
                if (!int.TryParse(parts[1], out width))
                    width = 0;
                #endregion

                // Make node
                if (nodeType == EnumNodeType.Node)
                    node = new BaseNode(parts[0].Trim(), width);
                else
                    node = new SwitchNode(parts[0].Trim(), width);
                node.nodeType = nodeType;

                // Add to output
                map.addNode(node);
            }
        }
        #endregion
    }
}