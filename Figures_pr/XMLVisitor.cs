using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Figures_pr
{
  public  class XMLVisitor
    {
        public string VisitRectangle(Rectangle_ element)
        {
            XmlDocument doc = new XmlDocument();

            // Create Rectangle element
            XmlElement rectangleElement = doc.CreateElement("Rectangle");

            // Set attributes
            rectangleElement.SetAttribute("type", element.type);
            rectangleElement.SetAttribute("x", element.point.X.ToString());
            rectangleElement.SetAttribute("y", element.point.Y.ToString());
            rectangleElement.SetAttribute("width", element.size.Width.ToString());
            rectangleElement.SetAttribute("height", element.size.Height.ToString());

            
            doc.AppendChild(rectangleElement);

            return doc.OuterXml;
        }
        public string VisitTriangle(Triangle element)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement triangleElement = doc.CreateElement("Triangle");

         
            triangleElement.SetAttribute("type", element.type);

          
            XmlElement pointsElement = doc.CreateElement("Points");

           
            XmlElement pointAElement = doc.CreateElement("Point");
            pointAElement.SetAttribute("Name", "A");
            pointAElement.SetAttribute("X", element.A.X.ToString());
            pointAElement.SetAttribute("Y", element.A.Y.ToString());
            pointsElement.AppendChild(pointAElement);

           
            XmlElement pointBElement = doc.CreateElement("Point");
            pointBElement.SetAttribute("Name", "B");
            pointBElement.SetAttribute("X", element.B.X.ToString());
            pointBElement.SetAttribute("Y", element.B.Y.ToString());
            pointsElement.AppendChild(pointBElement);

        
            XmlElement pointCElement = doc.CreateElement("Point");
            pointCElement.SetAttribute("Name", "C");
            pointCElement.SetAttribute("X", element.C.X.ToString());
            pointCElement.SetAttribute("Y", element.C.Y.ToString());
            pointsElement.AppendChild(pointCElement);

           
            triangleElement.AppendChild(pointsElement);

          
            doc.AppendChild(triangleElement);

            
            return doc.OuterXml;
        
    }
        public string VisitCube(Cube element)
        {
            XmlDocument doc = new XmlDocument();

         
            XmlElement cubeElement = doc.CreateElement("Cube");

          
            cubeElement.SetAttribute("type", element.type);

            
            XmlElement pointsElement = doc.CreateElement("Points");

           
            XmlElement pointAElement = doc.CreateElement("Point");
            pointAElement.SetAttribute("Name", "PointA");
            pointAElement.SetAttribute("X", element.point.X.ToString());
            pointAElement.SetAttribute("Y", element.point.Y.ToString());
            pointsElement.AppendChild(pointAElement);

            
            XmlElement pointBElement = doc.CreateElement("Point");
            pointBElement.SetAttribute("Name", "PointB");
            pointBElement.SetAttribute("X", (element.point.X + element.size.Width).ToString());
            pointBElement.SetAttribute("Y", element.point.Y.ToString());
            pointsElement.AppendChild(pointBElement);

            
            XmlElement pointCElement = doc.CreateElement("Point");
            pointCElement.SetAttribute("Name", "PointC");
            pointCElement.SetAttribute("X", (element.point.X + element.size.Width).ToString());
            pointCElement.SetAttribute("Y", (element.point.Y + element.size.Height).ToString());
            pointsElement.AppendChild(pointCElement);

            
            XmlElement pointDElement = doc.CreateElement("Point");
            pointDElement.SetAttribute("Name", "PointD");
            pointDElement.SetAttribute("X", element.point.X.ToString());
            pointDElement.SetAttribute("Y", (element.point.Y + element.size.Height).ToString());
            pointsElement.AppendChild(pointDElement);

            
            cubeElement.AppendChild(pointsElement);
            doc.AppendChild(cubeElement);

           
           return doc.OuterXml;
        }
        public string VisitCilindr(Cilindr element)
        {
           
                XmlDocument doc = new XmlDocument();

                XmlElement cilindrElement = doc.CreateElement("Cilindr");

                cilindrElement.SetAttribute("type", element.type);

                XmlElement sizeElement = doc.CreateElement("Size");
                sizeElement.SetAttribute("Width", element.size.Width.ToString());
                sizeElement.SetAttribute("Height", element.size.Height.ToString());
                cilindrElement.AppendChild(sizeElement);

                doc.AppendChild(cilindrElement);

               
                return doc.OuterXml;
        
        }
        public string VisitCircle(Circle element)
        {
            XmlDocument doc = new XmlDocument();

            XmlElement circleElement = doc.CreateElement("Circle");

            circleElement.SetAttribute("type", element.type);

            XmlElement sizeElement = doc.CreateElement("Size");
            sizeElement.SetAttribute("Radius", (element.size.Width / 2).ToString());
            circleElement.AppendChild(sizeElement);

            doc.AppendChild(circleElement);

            return doc.OuterXml;
        }
        public string VisitEllipse(Ellipse element)
        {
            XmlDocument doc = new XmlDocument();

            XmlElement ellipseElement = doc.CreateElement("Ellipse");

            ellipseElement.SetAttribute("type", element.type);

            XmlElement sizeElement = doc.CreateElement("Size");
            sizeElement.SetAttribute("Width", element.size.Width.ToString());
            sizeElement.SetAttribute("Height", element.size.Height.ToString());
            ellipseElement.AppendChild(sizeElement);

            doc.AppendChild(ellipseElement);

            return doc.OuterXml;
        }
       
    }
}
