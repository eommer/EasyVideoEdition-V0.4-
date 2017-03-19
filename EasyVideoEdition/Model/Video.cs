using NReco.VideoConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyVideoEdition.Model
{
    class Video : ObjectBase, IFile
    {

        #region Attributes
        private String _filePath;
        private String _fileName;
        private String _sizeLabel;
        private long _fileSize;
        private int _duration;
        private string _miniatPath;
        private FFMpegConverter ffMpegConverter = new FFMpegConverter();
        private bool _converted = false;
        #endregion

        #region Get/Set
        /// <summary>
        /// Get of set the path of the file
        /// </summary>
        public string filePath
        {
            get
            {
                return _filePath;
            }

            set
            {
                _filePath = value;
            }
        }

        /// <summary>
        /// Get or Set the name of the file
        /// </summary>
        public string fileName
        {
            get
            {
                return _fileName;
            }

            set
            {
                _fileName = value;
            }
        }

        /// <summary>
        /// Size of the file in octet
        /// </summary>
        public long fileSize
        {
            get
            {
                return _fileSize;
            }

            set
            {
                _fileSize = value;
            }
        }

        /// <summary>
        /// Duration of the video in sec
        /// </summary>
        public int duration
        {
            get
            {
                return _duration;
            }

            set
            {
                _duration = value;
            }
        }

        /// <summary>
        ///  Contains the label of the file size in the format "size + unit"
        /// </summary>
        public string sizeLabel
        {
            get
            {
                return _sizeLabel;
            }

            set
            {
                _sizeLabel = value;
            }
        }

        /// <summary>
        /// Gets or sets the miniat path.
        /// </summary>
        /// <value>
        /// The miniat path.
        /// </value>
        public string miniatPath
        {
            get
            {
                return _miniatPath;
            }

            set
            {
                _miniatPath = value;
                RaisePropertyChanged("miniatPath");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Video"/> is converted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if converted; otherwise, <c>false</c>.
        /// </value>
        public bool converted
        {
            get
            {
                return _converted;
            }

            set
            {
                _converted = value;
                RaisePropertyChanged("converted");
            }
        }


        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Video"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="name">The name.</param>
        /// <param name="size">The size.</param>
        public Video(String path, String name, long size)
        {
            this.filePath = path;
            this.fileName = name;
            videoScreenshotCreator vsc = new videoScreenshotCreator(filePath, fileName);
            this.fileSize = size;
            this.duration = 2017;
            this.miniatPath = "D:\\EVE\\loading.png";
            sizeLabel = calcSize(size);
            Task.Delay(2000).ContinueWith(_ =>
            {
                this.miniatPath = "D:\\Eve\\Temp\\Screenshot\\" + fileName.Split('.')[0] + ".jpeg";
            });
           
           
        }

        /// <summary>
        /// Converts the video in mp4 format with normalized settings.
        /// </summary>
        public void convertVideo(int width, int height, int frameRate)
        {

            var setting = new NReco.VideoConverter.ConvertSettings();

            setting.SetVideoFrameSize(width , height);
            setting.VideoFrameRate = frameRate;
            setting.VideoCodec = "h264";
            setting.AudioCodec = "ac3";

            var converter = new NReco.VideoConverter.FFMpegConverter();
            ffMpegConverter.ConvertMedia(filePath,
            null, // autodetect by input file extension 
            filePath + ".mp4",
            null, // autodetect by output file extension 
            setting
            );

            this.filePath = this.filePath + ".mp4";
            this.converted = true;
        }

        /// <summary>
        /// Calculates the size with the appropriate unit.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        protected string calcSize(long size)
        {
            String unit = "YOLO";
            double div;

            if (size > 1000000000)
            {
                unit = "Go";
                div = 1000000000;
            }
            else
            {
                if (size > 1000000)
                {
                    unit = "Mo";
                    div = 1000000;
                }
                else
                {
                    if (size > 1000)
                    {
                        unit = "Ko";
                        div = 1000;
                    }
                    else
                    {
                        unit = "octet(s)";
                        div = 1;
                    }
                }

            }

            return Math.Round(size / div, 1) + unit;
        }

    }
}
