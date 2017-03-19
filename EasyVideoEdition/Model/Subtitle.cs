using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EasyVideoEdition.Model
{
    /// <summary>
    /// Unique subtitle
    /// </summary>
    class Subtitle : ObjectBase
    {
        #region Attributes
        private String _startTime;
        private String _endTime;
        private String _subtitleText;
        private static readonly Regex TIME_FORMAT = new Regex(@"^\d{2}:\d{2}:\d{2},\d{3}$");                                     //Format of a time (hh:mm:ss,msmsms)

        #endregion

        #region Get/Set
        /// <summary>
        /// Time when the subtile starts (hh:mm:ss,msmsms)
        /// </summary>
        public String startTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
                RaisePropertyChanged("startTime");
            }
        }
        /// <summary>
        /// Time when the subtile ends (hh:mm:ss,msmsms)
        /// </summary>
        public String endTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
                RaisePropertyChanged("endTime");
            }
        }
        /// <summary>
        /// Content text of the subtitle
        /// </summary>
        public String subtitleText
        {
            get
            {
                return _subtitleText;
            }
            set
            {
                _subtitleText = value;
                RaisePropertyChanged("subtitleText");
            }
        }
        #endregion

        /// <summary>
        /// Creates a subtitle
        /// </summary>
        public Subtitle() { }

        /// <summary>
        /// Creates a subtitle with properties
        /// </summary>
        /// <param name="startTime">Time when the subtitle will start</param>
        /// <param name="endTime">Time when the subtitle will end</param>
        /// <param name="text">Text that the subtitle will contain</param>
        public Subtitle(String startTime, String endTime, String text)
        {
            this.startTime = startTime;
            this.endTime = endTime;
            this.subtitleText = text;
        }

        /// <summary>
        /// Edits the subtitle
        /// </summary>
        /// <param name="startTime">Time when the subtitle will start</param>
        /// <param name="endTime">Time when the subtitle will end</param>
        /// <param name="text">Text that the subtitle will contain</param>
        public void EditSubtile(String startTime, String endTime, String text)
        {
            /* Check if the format of the strings are good */
            if (TIME_FORMAT.IsMatch(startTime))
                this.startTime = startTime;
            if (TIME_FORMAT.IsMatch(endTime))
                this.endTime = endTime;
            this.subtitleText = text;
        }

    }
}