using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public class VideoEncoder
    {
        public delegate void VideoEncodedEventHandler(object source, EventArgs args);

        public event VideoEncodedEventHandler videoEncoded;
        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video {0} ...", video.Title);
            Thread.Sleep(3000);

            OnVideoEncoded();
        }

        protected virtual void OnVideoEncoded()
        {
            if (videoEncoded != null)
                videoEncoded(this, EventArgs.Empty);
        }
    }
}
