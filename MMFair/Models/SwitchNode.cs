using MMFair.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMFair.Models
{
	/// <summary>
	/// Swtich node
	/// </summary>
	public class SwitchNode : BaseNode
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
		/// Switch children nodes
		/// </summary>
		public Dictionary<string, BaseNode> children
		{
			get;
			set;
		}

		/// <summary>
		/// Get Needed bandwidth
		/// </summary>
		public override float neededBandWidth
		{
			get
			{
				return children.Sum (x => x.Value.neededBandWidth);
			}
		}
		#endregion

		#region Methods
		/// <summary>
		/// Ctr
		/// </summary>
		public SwitchNode (string name, float width) : base (name, width)
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
			nodeType	= EnumNodeType.Switch;
			children	= new Dictionary<string, BaseNode> ();
		}

		/// <summary>
		/// Calc Real needed bandwidth
		/// </summary>
		public override void calculateRealBandwidth ()
		{
			float subWidth = children.Sum (x => x.Value.calculatedBandWidth);
			this.calculatedBandWidth	= Math.Min (subWidth, maximumBandWidth);
		}

		/// <summary>
		/// Calc needed bandwidth
		/// </summary>
		public void calcBandWidth ()
		{
			List<KeyValuePair<string, BaseNode>> children	= this.children.OrderBy ((KeyValuePair<string, BaseNode> x) => x.Value.calculatedBandWidth).ToList ();
			float remainWidth	= assignedWidth;
			float remainMean	= 0;

			while (0 < children.Count)
			{
				// Select first node and leave it from queue
				BaseNode	curNode	= children[0].Value;

				// Calculate Remain mean width
				remainMean = remainWidth / children.Count;

				// If this node is last node
				if (children.Count == 1)
					curNode.assignBandWidth (remainMean);
				// We have other nodes
				else
				{
					if (curNode.calculatedBandWidth < remainMean)
						curNode.assignBandWidth (curNode.calculatedBandWidth);
					else
						curNode.assignBandWidth (remainMean);
				}

				// Decrease remain width
				remainWidth	-= curNode.assignedWidth;

				// leave node from queue
				children.RemoveAt (0);
			}
		}

		/// <summary>
		/// Assign bandwidth
		/// </summary>
		/// <param name="width"></param>
		public override void assignBandWidth (float width)
		{
			base.assignBandWidth (width);
			calcBandWidth ();
		}
		#endregion
	}
}
