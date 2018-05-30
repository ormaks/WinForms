using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WinForms.Shapes;

namespace WinForms.CircleBL
{
    public class CircleBL
    {

        public static void SerializeList(List<Circle> shapes, string path)
        {
            XmlSerializer formatterRectangle = new XmlSerializer(typeof(List<Circle>));
            shapes.ForEach(p => p.ColorArgb = p.CircleColor.ToArgb());
            List<Circle> rectangle = new List<Circle>();
            foreach (var it in shapes)
            {
                rectangle.Add((Circle)it);
            }
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatterRectangle.Serialize(fs, rectangle);
            }
        }

        public static List<Circle> DeserializeList(string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Circle>));
            List<Circle> shapes = null;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                shapes = (List<Circle>)formatter.Deserialize(fs);
            }

            if (shapes == null)
            {
                throw new ApplicationException(string.Format("cannot deserialize file {0}", path));
            }

            shapes.ForEach(p => p.CircleColor = Color.FromArgb(p.ColorArgb));

          

            return shapes;
        }

       

    }
}
