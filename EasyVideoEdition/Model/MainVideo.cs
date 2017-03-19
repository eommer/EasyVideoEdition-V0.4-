using NReco.VideoConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasyVideoEdition.Model
{
    class MainVideo : ObjectBase
    {

        #region Attributes
        private static MainVideo singleton = new MainVideo();
        private Video _video;
        private FFMpegConverter ffMpegConverter = new FFMpegConverter();
        private long _ffmpegProcess;
        private long _ffmpegMaxProcess;
        private String _processPercentage = "100 %";
        long _percentage;
        #endregion

        #region Get/Set

        /// <summary>
        /// Get the instance of the mainVideo
        /// </summary>
        public static MainVideo INSTANCE
        {
            get
            {
                return singleton;
            }
        }

        /// <summary>
        /// Gets or sets the video that is the mainVideo of the project.
        /// </summary>
        /// <value>
        /// The new video.
        /// </value>
        public Video video
        {
            get
            {
                return _video;
            }
            set
            {
                _video = value;
                RaisePropertyChanged("video");
            }
        }

        /// <summary>
        /// Gets or sets the ffmpeg process (used for the progress bar).
        /// </summary>
        /// <value>
        /// The ffmpeg process.
        /// </value>
        public long ffmpegProcess
        {
            get
            {
                return _ffmpegProcess;
            }
            set
            {
                _ffmpegProcess = value;
                RaisePropertyChanged("ffmpegProcess");
            }
        }

        /// <summary>
        /// Gets or sets the ffmpeg maximum process (used for the progress bar).
        /// </summary>
        /// <value>
        /// The ffmpeg maximum process.
        /// </value>
        public long ffmpegMaxProcess
        {
            get
            {
                return _ffmpegMaxProcess;
            }
            set
            {
                _ffmpegMaxProcess = value;
                RaisePropertyChanged("ffmpegMaxProcess");
            }
        }

        /// <summary>
        /// Gets or sets the process percentage.
        /// </summary>
        /// <value>
        /// The process percentage.
        /// </value>
        public String processPercentage
        {
            get
            {
                return _processPercentage;
            }
            set
            {
                _processPercentage = value;
                RaisePropertyChanged("processPercentage");
            }
        }

        #endregion

        /// <summary>
        /// Prevents a default instance of the <see cref="MainVideo"/> class from being created.
        /// </summary>
        private MainVideo()
        {
        }

        /// <summary>
        /// Concat a second video at the end of the main video.
        /// </summary>
        /// <param name="secondVideo">The second video to add at the end of the main one.</param>
        public void concatVideos(Video secondVideo)
        {
            
            /* Conversion of both videos */
            //this.video.convertVideo();
            //secondVideo.convertVideo();
            
            /* Settings needed to concatenate the videos */
            String[] inputVideoPaths = new String[2];
            String outputVideoPath = this.video.filePath;
            String outputName = this.video.fileName;
            String newPath = "C:\\Users\\Théo\\Desktop\\videos\\final.mp4";
            String commandConcat = "- i \"concat:"+this.video.filePath+"|"+secondVideo.filePath+"\" - codec copy "+outputVideoPath;
            long outputSize = video.fileSize + secondVideo.fileSize;

            inputVideoPaths[0] = video.filePath;
            inputVideoPaths[1] = secondVideo.filePath;

            var concatSetting = new NReco.VideoConverter.ConcatSettings();

            //concatSetting.ConcatVideoStream = true;
            //concatSetting.ConcatAudioStream = false;
            //concatSetting.VideoCodec = "h264";
            //concatSetting.VideoFrameRate = 30;
            //concatSetting.SetVideoFrameSize(1280, 720);


            processPercentage = "0 %";
            ffMpegConverter.ConvertProgress += updateProgress;
            ffMpegConverter.ConcatMedia(inputVideoPaths, newPath , Format.mp4, concatSetting);


            video = new Model.Video(newPath, "final", outputSize);

        }

        /// <summary>
        /// Updates the progress of the process (use for the progress bar).
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ConvertProgressEventArgs"/> instance containing the event data.</param>
        private void updateProgress(object sender, ConvertProgressEventArgs e)
        {
            ffmpegMaxProcess = e.TotalDuration.Seconds;
            ffmpegProcess = e.Processed.Seconds;
            _percentage = (long)((float)(ffmpegProcess / ffmpegMaxProcess) * 100);
            processPercentage = _percentage + " %";
        }

    }
}
