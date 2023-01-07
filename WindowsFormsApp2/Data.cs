using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Serialization;

namespace WindowsFormsApp2
{
    [Serializable]
    public class playXmlSerializerer
    {
        public Point point;
        public String name;
        public String color;

        public playXmlSerializerer()
        {
            
        }

        public playXmlSerializerer(string name, String color)
        {
            this.point = point;
            this.name = name;
            this.color = color;
        }
    }
    [Serializable]
    [XmlInclude(typeof(playXmlSerializerer))]
    public class Data
    {
        
        public List<playXmlSerializerer> db = new List<playXmlSerializerer>();
        
        public Data() {}

        public void add(string name, String color)
        {
            db.Add(new playXmlSerializerer(name,color));
        }

        public void update(Point point,int index)
        {
            db[index].point = point;
        }

        public void RemoveAll()
        {
            db.Clear();
        }

        public void RemoveLast()
        {
            db.RemoveAt(db.Count-1);
        }
    }
}