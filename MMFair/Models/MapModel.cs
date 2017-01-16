using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMFair.Models
{
	/// <summary>
	/// Map Model
	/// </summary>
	public class MapModel
	{

		#region Delegates
		#endregion

		#region Methods
		#endregion

		#region Constants
		#endregion

		#region Variables
		#endregion

		#region Properties
		/// <summary>
		/// Switches list
		/// </summary>
		public Dictionary<string, SwitchNode> switches
		{
			get;
			set;
		}

		/// <summary>
		/// Nodes list
		/// </summary>
		public Dictionary<string, BaseNode> nodes
		{
			get;
			set;
		}

		/// <summary>
		/// All Nodes list
		/// </summary>
		public Dictionary<string, BaseNode> allNodes
		{
			get;
			set;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Ctr
		/// </summary>
		public MapModel ()
		{
			init ();
		}

		/// <summary>
		/// Initialize
		/// </summary>
		private void init ()
		{
			prepare ();
		}

		/// <summary>
		/// Prepare
		/// </summary>
		private void prepare ()
		{
			switches	= new Dictionary<string, SwitchNode>();
			nodes		= new Dictionary<string, BaseNode> ();
			allNodes	= new Dictionary<string, BaseNode> ();
		}

		#region Calculation
		/// <summary>
		/// Get final switch
		/// </summary>
		/// <returns></returns>
		public Dictionary<string, SwitchNode> finalSwitches ()
		{
			Dictionary<string, SwitchNode>	result	= new Dictionary<string, SwitchNode> ();

			foreach (KeyValuePair<string, SwitchNode> node in switches)
				if (null == node.Value.relatedNode)
					result.Add (node.Key, node.Value);

			return result;
		}

		/// <summary>
		/// Assign bandwidth to swtiches and nodes
		/// </summary>
		public void assignBandWidth ()
		{
			List<SwitchNode> switches = finalSwitches ().Values.ToList ();
		
			foreach (SwitchNode node in switches)
			{
				// Calculate real bandswith for root switches
				node.calculateRealBandwidth ();

				node.assignedWidth	= node.calculatedBandWidth;
				node.calcBandWidth ();
			}
		}
		#endregion

		#region Nodes Operations
		/// <summary>
		/// Add new node
		/// </summary>
		/// <param name="node"></param>
		public void addNode (object node)
		{
			if (node is BaseNode)
			{
				BaseNode baseNode = node as BaseNode;

				if (node is SwitchNode)
				{
					SwitchNode	switchNode = node as SwitchNode;
					switches.Add (switchNode.name, switchNode);
				}
				else
					nodes.Add (baseNode.name, baseNode);

				allNodes.Add (baseNode.name, baseNode);
			}
		}

		/// <summary>
		/// Remove a node
		/// </summary>
		/// <param name="node"></param>
		public void removeNode (object node)
		{
			if (node is BaseNode)
			{
				BaseNode baseNode = node as BaseNode;
				
				if (node is SwitchNode)
				{
					SwitchNode switchNode = node as SwitchNode;
					switches.Remove (switchNode.name);
				}
				else
					nodes.Remove (baseNode.name);

				allNodes.Remove (baseNode.name);
			}
		}

		/// <summary>
		/// Clear models 
		/// </summary>
		public void clear ()
		{
			allNodes.Clear ();
			nodes.Clear ();
			switches.Clear ();
		}

		/// <summary>
		/// Connect node to switch
		/// </summary>
		/// <param name="switchName"></param>
		/// <param name="nodeName"></param>
		public void connect (string nodeName, string switchName)
		{
			try
			{
				BaseNode	node		= null;
				SwitchNode	switchNode	= null;

				if (allNodes.ContainsKey (nodeName))
					node    = allNodes[nodeName];
				if (switches.ContainsKey (switchName))
					switchNode  = switches[switchName];

				if ((null != switchNode) && (null != node))
				{
					switchNode.children.Add (node.name, node);
					node.relatedNode    = switchNode;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show ("Error:\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		} 
		#endregion
		#endregion
	}
}
