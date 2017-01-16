using MMFair.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MMFair.Models
{
	/// <summary>
	/// Base Node Class
	/// </summary>
	public class BaseNode
	{
		#region Delegates
		public delegate void WidthChange (int newWidth);
		#endregion
		
		#region Events
		public event WidthChange onWidthChange;
		#endregion

		#region Methods
		#endregion

		#region Constants
		#endregion

		#region Variables
		#endregion

		#region Properties
		private float? _calculatedBandWidth;
		public float calculatedBandWidth
		{
			get
			{
				if (null == _calculatedBandWidth)
					calculateRealBandwidth ();

				return _calculatedBandWidth.Value;
			}
			set
			{
				_calculatedBandWidth	= value;
			}
		}

		/// <summary>
		/// Needed bandwidth
		/// </summary>
		public virtual float neededBandWidth
		{
			get
			{
				return maximumBandWidth;
			}
		}

		/// <summary>
		/// Get Real bandwidth
		/// </summary>
		public virtual void calculateRealBandwidth ()
		{
			_calculatedBandWidth	= maximumBandWidth;
		}

		public float assignedWidth
		{
			get;
			set;
		}
		public float maximumBandWidth
		{
			get;
			set;
		}

		public BaseNode relatedNode
		{
			get;
			set;
		}

		public EnumNodeType nodeType
		{
			get;
			set;
		}

		public string name
		{
			get;
			set;
		}

		public Color color
		{
			get;
			set;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Ctr
		/// </summary>
		public BaseNode (string name, float bandwidth)
		{
			this.name				= name;
			this.maximumBandWidth	= bandwidth;
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
		}

		/// <summary>
		/// Assign bandwidth
		/// </summary>
		/// <param name="bandwidth"></param>
		public virtual void assignBandWidth (float bandwidth)
		{
			assignedWidth	= (float)Math.Min (calculatedBandWidth, bandwidth);
		}

		/// <summary>
		/// To String
		/// </summary>
		public override string ToString ()
		{
			string	result		= "{0}\t\tAssigned :{1}\tNeeded :{2}\tCalculated :{3}\tMaximum :{4}";
			result	= string.Format (result, name, assignedWidth.ToString ("f2"), neededBandWidth.ToString ("f2"),
				calculatedBandWidth.ToString ("f2"), maximumBandWidth.ToString ("f2"));

			return result;
		}
		#endregion
	}
}
