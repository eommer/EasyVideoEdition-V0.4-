using System;

namespace EasyVideoEdition.Model
{
        /// <summary>
        /// 
        /// </summary>
      class VideoPlayer : ObjectBase
       {

        #region Attributes
        private String _source = "";
        #endregion

        #region Get/Set
        /// <summary>
        /// Source of the video which will be showed
        /// </summary>
        public String source
        {
            get
            {
                return _source;
            }
            set
            {
                _source = value;
                RaisePropertyChanged("source");
            }
        }
        #endregion

        /// <summary>
        /// Creates a video player
        /// </summary>
        public VideoPlayer()
        {  
        }

    }       
}
