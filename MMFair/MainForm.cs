using MMFair.Helper;
using MMFair.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMFair
{
	public partial class MainForm : Form
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
		#endregion

		#region Methods
		/// <summary>
		/// Ctr
		/// </summary>
		public MainForm ()
		{
			InitializeComponent ();

			init ();
		}

		/// <summary>
		/// Initialize
		/// </summary>
		private void init ()
		{
			prepare ();
			bindEvents ();
		}

		/// <summary>
		/// Prepare
		/// </summary>
		private void prepare ()
		{
			String appPath	= Application.StartupPath;
			sourceFileNameTextBox.Text	= Path.Combine (appPath, "sample.txt");
			outputFileNameTextBox.Text	= Path.Combine (appPath, "output.txt");
		}

		/// <summary>
		/// Bind Events
		/// </summary>
		private void bindEvents ()
		{
			sourceFileChooseButton.Click    += SourceFileChooseButton_Click;
			outputFileChooseButton.Click    += OutputFileChooseButton_Click;
			calcButton.Click				+= CalcButton_Click;
		}

		/// <summary>
		/// Output file button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OutputFileChooseButton_Click (object sender, EventArgs e)
		{
			chooseFile (outputFileNameTextBox);
		}

		/// <summary>
		/// Source file button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SourceFileChooseButton_Click (object sender, EventArgs e)
		{
			chooseFile (sourceFileNameTextBox);
		}


		/// <summary>
		/// Calc Button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CalcButton_Click (object sender, EventArgs e)
		{
			calc ();
		}

		/// <summary>
		/// Choose file dialog
		/// </summary>
		/// <param name="textbox"></param>
		private void chooseFile (TextBox textbox)
		{
			if (null != textbox)
			{
				OpenFileDialog	ofd	= new OpenFileDialog ();

				ofd.FileName	= textbox.Text;
				ofd.Filter	= "*.txt|*.txt";
				if (ofd.ShowDialog () == DialogResult.OK)
					textbox.Text	= ofd.FileName;
			}
		}

		/// <summary>
		/// Calculate
		/// </summary>
		private void calc ()
		{
			if (File.Exists (sourceFileNameTextBox.Text))
			{
				FileLoader	fileLoader	= new FileLoader (sourceFileNameTextBox.Text);
				fileLoader.loadFile ();

				MapModel	map	= fileLoader.map;

				map.assignBandWidth ();
				map.writeToFile (outputFileNameTextBox.Text.Trim ());

				MessageBox.Show("Finished, See output for result", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
				MessageBox.Show ("Source file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
		#endregion
	}
}
