﻿using PipelineVM;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace EditorApplication.Processors
{
	public class CosineProcessor : Processor
	{
		#region Properties

		private InputChannel m_InputA;
		private InputChannel m_InputB;
		private OutputChannel m_Output;

		#endregion Properties

		#region Constructor

		public CosineProcessor(Pipeline pipeline)
			: base(pipeline)
		{
		}

		#endregion Constructor

		#region Methods
		public override void Rebuild()
		{
			base.Rebuild();
			m_InputA = GetInputChannel("Value") ?? new InputChannel(this) { Name = "A", AcceptedTypes = { typeof(IConvertible) } };
			m_Output = GetOutputChannel("Out") ?? new OutputChannel(this) { Name = "Out", OutputTypes = { typeof(double) } };
		}
		public override void Process()
		{
			//Since they are convertible, convert them to doubles, which is sufficient for most cases.
			double a = (m_InputA.Read() as IConvertible).ToDouble(CultureInfo.InvariantCulture);

			//Double is automaticly convertible
			m_Output.Write(Math.Cos(a));
		}

		#endregion Methods
	}
}