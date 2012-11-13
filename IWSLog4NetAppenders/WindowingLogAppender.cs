/*
   Copyright 2012 Intraweb Software Limited

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 */

#define TRACE

using System.Collections.Specialized;
using System.Collections.Generic;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;

namespace IWSLog4NetAppenders
{
	/// <summary>
	/// 
	/// </summary>
    /// <remarks>
	/// </remarks>
    /// <author>TIm Bartle</author>
	public class WindowingLogAppender : RollingFileAppender
	{
		#region Public Instance Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="WindowingLogAppender" />.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Default constructor.
		/// </para>
		/// </remarks>
		public WindowingLogAppender()
		{
            preEventWindow = 100;
            flushWindowAfterException = false;
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="WindowingLogAppender" /> 
		/// with a specified layout.
		/// </summary>
		/// <param name="layout">The layout to use with this appender.</param>
		/// <remarks>
		/// <para>
		/// Obsolete constructor.
		/// </para>
		/// </remarks>
		[System.Obsolete("Instead use the default constructor and set the Layout property")]
		public WindowingLogAppender(ILayout layout) : base()
		{
			Layout = layout;
		}

		#endregion Public Instance Constructors

		#region Public Instance Properties available for configuration

        public int preEventWindow { get; set; }

        public bool flushWindowAfterException { get; set; }

	    #endregion Public Instance Properties

		#region Override implementation of AppenderSkeleton

		/// <summary>
		/// Writes the logging event only if an exception occurs inside the window.
		/// </summary>
		/// <param name="loggingEvent">The event to log.</param>
		/// <remarks>
		/// <para>
		/// Writes the logging event to the <see cref="System.Diagnostics.Trace"/> system.
		/// </para>
		/// </remarks>
		override protected void Append(LoggingEvent loggingEvent) 
		{
            lock (_loggedEvents)
            {
                if (loggingEvent.GetExceptionString() == string.Empty)
                    AddToWindow(loggingEvent);
                else
                    AppendWindow(loggingEvent);
            }
		}

        protected override void Append(LoggingEvent[] loggingEvents)
        {
            foreach (var loggedEvent in loggingEvents)
                Append(loggedEvent);
        }

        private void AppendWindow(LoggingEvent loggingEvent)
        {
            AddToWindow(loggingEvent);
            foreach (var logged in _loggedEvents)
                base.Append(logged);

            if (flushWindowAfterException)
                _loggedEvents.Clear();
        }


        /// <summary>
        /// </summary>
        /// <param name="loggingEvent"></param>
        private void AddToWindow(LoggingEvent loggingEvent)
        {
            while (_loggedEvents.Count > preEventWindow)
                _loggedEvents.RemoveFirst();
            _loggedEvents.AddLast(loggingEvent);
        }


		#endregion Override implementation of RollingFileAppender

		#region Private Instance Fields

        private static LinkedList<LoggingEvent> _loggedEvents = new LinkedList<LoggingEvent>();

		#endregion Private Instance Fields
	}
}
