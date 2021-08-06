using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;

namespace FaceDetector
{
    public static class FaceDetector
    {
        //static readonly CascadeClassifier classifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");
        static readonly CascadeClassifier classifier = new CascadeClassifier("haarcascade_frontalface_alt.xml");

        public static Rectangle[] Detect(string imageFilePath)
        {
            Image<Rgb, byte> im = new(imageFilePath);
            Rectangle[] faces = classifier.DetectMultiScale(im, 1.4, 1);
            return faces;
        }
    }
}
