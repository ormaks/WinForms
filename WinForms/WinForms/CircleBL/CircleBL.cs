using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using WinForms.Shapes;

namespace WinForms.CircleBL
{
    public static class CircleBL
    {
        public static void SerializeList(List<Circle> shapes, string path)
        {
            var formatterRectangle = new XmlSerializer(typeof(List<Circle>));
            shapes.ForEach(p => p.ColorArgb = p.CircleColor.ToArgb());
            var rectangle = new List<Circle>();
            foreach (var it in shapes)
            {
                rectangle.Add(it);
            }

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatterRectangle.Serialize(fs, rectangle);
            }
        }

        public static List<Circle> DeserializeList(string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Circle>));
            List<Circle> shapes;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                shapes = (List<Circle>) formatter.Deserialize(fs);
            }

            if (shapes == null)
            {
                throw new ApplicationException($"cannot deserialize file {path}");
            }

            shapes.ForEach(p => p.CircleColor = Color.FromArgb(p.ColorArgb));

            return shapes;
        }
    }
}