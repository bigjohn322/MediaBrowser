using MediaBrowser.Model.Extensions;

namespace MediaBrowser.Model.Drawing
{
    /// <summary>
    /// Struct ImageSize
    /// </summary>
    public struct ImageSize
    {
        private double _height;
        private double _width;

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public bool Equals(ImageSize size)
        {
            return Width.Equals(size.Width) && Height.Equals(size.Height);
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}", Width, Height);
        }

        public ImageSize(string value)
        {
            _width = 0;

            _height = 0;

            ParseValue(value);
        }

        private void ParseValue(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                string[] parts = value.Split('-');

                if (parts.Length == 2)
                {
                    double val;

                    if (DoubleHelper.TryParseCultureInvariant(parts[0], out val))
                    {
                        _width = val;
                    }

                    if (DoubleHelper.TryParseCultureInvariant(parts[1], out val))
                    {
                        _height = val;
                    }
                }
            }
        }
    }
}