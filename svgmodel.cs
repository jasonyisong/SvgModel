// This program created by Yi Song 2021/10/16
// Function include
// 1. Export the canvas to a file in SVG、Adding shape、Deleting Shape、Updating Shape、Style、z-index、default line and fill styles
// Comment the code updated by Yi Song 2021/10/23
// Add function include  updated by Yi Song 2021/10/26
// 2. Grouping and ungrouping、Applying styles and translations to shape groups、Translating, rotating, skewing and scaling basic shapes、Adding styled and formatted text


using System;
using System.Collections.Generic;
//using System.Linq;

namespace svgmodel
{
    public class Transform {
        public string name {get; set;}
        public System.Nullable<double> a {get; set;}
        public System.Nullable<double> x {get; set;}
        public System.Nullable<double> y {get; set;}
    }
    //set up the class for Polyline and Polygon Points
    public class Points {
        public double x {get; set;}
        public double y {get; set;}
    }
    //set up the class for Path D
    public class D {
        public string c {get; set;}
        public System.Nullable<double> x {get; set;}
        public System.Nullable<double> y {get; set;}
        public System.Nullable<double> za {get; set;}
        public System.Nullable<double> zb {get; set;}
        public System.Nullable<double> zc {get; set;}
        public System.Nullable<double> zd {get; set;}
        public System.Nullable<double> ze {get; set;}
    }
   //set up shape class
   abstract class Shape
    {
        //declare shape variable
        //public int ZIndex { get ; set; }  
        public string Sname {  get ; set; } 
        public int Gfrom { get; set; }  // for Grouping begin index
        public int Gto { get; set; }    // for Grouping end index    
        public int X { get; set; }
        public int Y { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public int R { get; set; }
        public int CX { get; set; }
        public int CY { get; set; }
        public int RX { get; set; }
        public int RY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string SFill { get;  set; }
        public string SLColor { get;  set; }      
        public string SLBorder { get;  set; }

        // for text content and style 
        public string textcontent { get;  set; }
        public string fontfamily { get;  set; }
        public string fontsize { get;  set; }      
        public string fontsizeadjust { get;  set; }
        public string fontstretch { get;  set; }
        public string fontstyle { get;  set; }      
        public string fontvariant { get;  set; }
        public string fontweight { get;  set; }

        // reference https://stackoverflow.com/questions/36152199/declare-object-in-c-sharp-with-x-y-paramateres
        // create a list for Polyline and Polygon Points
        public List<Points> points= new List<Points>();
        // Polyline and Polygon Add a Point with x,y
        public void AddPoint(double x,double y) 
        {
            points.Add(new Points());
            points[points.Count-1].x=x;
            points[points.Count-1].y=y;
        }
        // create a list for path D command
        public List<D> d= new List<D>();
        // Path add D command
        public void AddD(string c,System.Nullable<double> x,System.Nullable<double> y,System.Nullable<double> za,System.Nullable<double> zb,System.Nullable<double> zc,System.Nullable<double> zd,System.Nullable<double> ze) 
        {
            d.Add(new D());
            d[d.Count-1].c=c;
            d[d.Count-1].x=x;
            d[d.Count-1].y=y;
            d[d.Count-1].za=za;
            d[d.Count-1].zb=zb;
            d[d.Count-1].zc=zc;
            d[d.Count-1].zd=zd;
            d[d.Count-1].ze=ze;
        }
        public List<Transform> transform= new List<Transform>();
        public void AddTransform(string name,System.Nullable<double> a,System.Nullable<double> x,System.Nullable<double> y) 
        {
            int cnt=0;
            int currcnt=-1;
            if(name=="rotate"||name=="translate"||name=="skewX"||name=="scale")
            {
                foreach(var tf in transform)
                {
                    if(tf.name==name)
                    {
                       currcnt=cnt;
                    }
                    cnt+=1;
                }
                if(currcnt==-1)
                {
                   transform.Add(new Transform());
                   currcnt=transform.Count-1;
                }
                transform[currcnt].name=name;
                transform[currcnt].a=a;
                transform[currcnt].x=x;
                transform[currcnt].y=y;
            }
        }

        public string GetTransform
        { 
            get
            {
                string disptransform="";
                string tmp="";
                string tname="";
                foreach(var tf in transform)
                {
                    if(tf.a!=null||tf.x!=null||tf.y!=null)
                    {
                        tname=tf.name+"(";
                        tmp=tf.a+" "+tf.x+" "+tf.y+" ";
                        disptransform+=tname+tmp.Trim()+") ";
                    }
                }  
                return disptransform;
            }
        }
        // set a default styles value for shape
        public Shape()
        {
            SFill = "grey"; SLColor = "black"; SLBorder="1pt";
        }
        // update the shape styles
        public Shape(string sfill, string slcolor, string slborder)
        {
            SFill = sfill;  SLColor = slcolor; SLBorder = slborder;
        }

        public abstract string ToSVGElement();

        // create a init list for Polyline and Polygon Points
        public List<Points> InitPoints= new List<Points>();

    }
    //Rectangle properties
    class RectanglePP : Shape
    {   
        // default position if unspecified, the default value
        public RectanglePP () { X = 100; Y = 100; Width = 100; Height=100; Sname = "Rectangle"; } // default position if unspecified
        // the default values are available to set
        public RectanglePP (int x, int y, int width, int height) 
        {         
            X = x; Y = y; Width = width; Height=height; Sname = "Rectangle";
        }    
        // show the shape content
        public override string ToSVGElement()
        {
            // convert the object to an SVG element display string for Rectangle
            string dispSVG = "".PadLeft(6, ' ')+$"<rect x=\"{X}\" y=\"{Y}\" width=\"{Width}\" height=\"{Height}\" fill=\"{SFill}\" stroke=\"{SLColor}\" stroke-width=\"{SLBorder}\" transform=\"{GetTransform.Trim()}\" />" + Environment.NewLine;; 
            return dispSVG;
        }    
    }//end class 

    //Circle properties
    class CirclePP : Shape
    {   
        // default position if unspecified, the default value
        public CirclePP () { CX = 100; CY = 100; R = 100; Sname = "Circle"; } 
        // the default values are available to set
        public CirclePP (int cx, int cy, int r) 
        {         
            CX = cx; CY = cy; R = r; Sname = "Circle";
        }  
        // show the shape content
        public override string ToSVGElement()
        {
            
            // convert the object to an SVG element display string for Circle
            string dispSVG = "".PadLeft(6, ' ')+$"<circle cx=\"{CX}\" cy=\"{CY}\" r=\"{R}\" fill=\"{SFill}\" stroke=\"{SLColor}\" stroke-width=\"{SLBorder}\" transform=\"{GetTransform.Trim()}\" />" + Environment.NewLine;
            return dispSVG;
        }      
    }//end class 

    //Ellipse properties
    class EllipsePP : Shape
    {
        // default position if unspecified, the default value
        public EllipsePP () { CX = 100; CY = 100; RX = 100;  RY = 100; Sname = "Ellipse"; } // default position if unspecified
        // the default values are available to set
        public EllipsePP (int cx, int cy, int rx, int ry) 
        {         // X and Y are available to set
            CX = cx; CY = cy; RX = rx;  RY = ry; Sname = "Ellipse";
        }  
        // show the shape content
        public override string ToSVGElement()
        {
            // convert the object to an SVG element display string for Ellipse
            string dispSVG = "".PadLeft(6, ' ')+$"<ellipse rx=\"{RX}\" ry=\"{RY}\" cx=\"{CX}\" cy=\"{CY}\" fill=\"{SFill}\" stroke=\"{SLColor}\" stroke-width=\"{SLBorder}\" transform=\"{GetTransform.Trim()}\" />" + Environment.NewLine;
            return dispSVG;
        }    
    }//end class 

    //Line properties
    class LinePP : Shape
    {
        // default position if unspecified, the default value
        public LinePP () { X1 = 100; Y1 = 100; X2 = 100; Y2 = 100; Sname = "Line"; } // default position if unspecified
        // the default values are available to set
        public LinePP (int x1, int y1, int x2, int y2) 
        {       
            X1 = x1; Y1 = y1; X2 = x2;  Y2 = y2; Sname = "Line";
        }  
        // show the shape content
        public override string ToSVGElement()
        {
            // convert the object to an SVG element display string for Line
            string dispSVG = "".PadLeft(6, ' ')+$"<line x1=\"{X1}\" y1=\"{Y1}\" x2=\"{X2}\" y2=\"{Y2}\" stroke=\"{SLColor}\" stroke-width=\"{SLBorder}\" transform=\"{GetTransform.Trim()}\" />" + Environment.NewLine;
            return dispSVG;
        }      
    }//end class 
    //Polyline properties
    class PolylinePP : Shape
    {
        // the default value
        public PolylinePP () 
        {      
            Sname = "Polyline";   

        } 
        // show the shape content
        public override string ToSVGElement()
        {
            
            string strpoint = "";
            // loop every point in points list
            foreach (var point in points)
            { 
               strpoint+=point.x + "," +  point.y + " ";
            } 
            // convert the object to an SVG element display string for Polyline
            string dispSVG = "".PadLeft(6, ' ')+$"<polyline points=\"{strpoint.Trim()}\" fill=\"{SFill}\" stroke=\"{SLColor}\" stroke-width=\"{SLBorder}\" transform=\"{GetTransform.Trim()}\" />" + Environment.NewLine;
            return dispSVG;
        }   
     
    }//end class 
    //Polygon properties
    class PolygonPP : Shape
    {
        // the default value
        public PolygonPP () 
        {       
            Sname = "Polygon";   

        } 
        // show the shape content
        public override string ToSVGElement()
        {
            
            string strpoint = "";
            // loop every point in points list
            foreach (var point in points)
            { 
               strpoint+=point.x + "," +  point.y + " ";
            } 
            // convert the object to an SVG element display string for Polygon
            string dispSVG = "".PadLeft(6, ' ')+$"<polygon points=\"{strpoint.Trim()}\" fill=\"{SFill}\" stroke=\"{SLColor}\" stroke-width=\"{SLBorder}\" transform=\"{GetTransform.Trim()}\" />" + Environment.NewLine;
            return dispSVG;
        }   
     
    }//end class 
    //Path properties
    class PathPP : Shape
    {
        // the default value
        public PathPP () 
        {       
            Sname = "Path";   

        } 
        // show the shape content
        public override string ToSVGElement()
        {
            
            string strdc = "";
            string tmp="";
            // loop every d command in d list
            foreach (var dc in d)
            { 
               tmp=dc.c + " " + dc.x + " " +  dc.y + " " +  dc.za + " " +  dc.zb + " " +  dc.zc + " " +  dc.zd + " " +  dc.ze ;
               strdc+=tmp.Trim()+" ";
            } 
            // convert the object to an SVG element display string for Path
            string dispSVG = "".PadLeft(6, ' ')+$"<path d=\"{strdc.Trim()}\" fill=\"{SFill}\" stroke=\"{SLColor}\" stroke-width=\"{SLBorder}\" transform=\"{GetTransform.Trim()}\" />" + Environment.NewLine;
            return dispSVG;
        }   
     
    }//end class

    //Text properties
    class TextPP : Shape
    {   
        // default position if unspecified, the default value
        public TextPP () { X = 100; Y = 100; Sname = "Text"; } // default position if unspecified
        // the default values are available to set
        public TextPP (int x, int y) 
        {         
            X = x; Y = y;  Sname = "Text";
        }    
        // show the shape content
        public override string ToSVGElement()
        {
            // convert the object to an SVG element display string for Rectangle
            string dispSVG = "".PadLeft(6, ' ')+$"<text x=\"{X}\" y=\"{Y}\" fill=\"{SFill}\" font-family=\"{fontfamily}\" font-size=\"{fontsize}\" font-size-adjust=\"{fontsizeadjust}\" font-stretch=\"{fontstretch}\" font-style=\"{fontstyle}\" font-variant=\"{fontvariant}\" font-weight=\"{fontweight}\">{textcontent}</text>" + Environment.NewLine;
            return dispSVG;
        }    
    }//end class 
    class G : Shape
    {   
        // default position if unspecified, the default value
        public G () { Gfrom = -1; Gto = -1; Sname = "G"; } // default position if unspecified
        // the default values are available to set
        public G (int gfrom, int gto) 
        {   
            if(gfrom!=-1&&gto!=-1&&gto>gfrom)
            {
              Gfrom = gfrom; Gto = gto; Sname = "G";
            }
        }    
        // show the shape content
        public override string ToSVGElement()
        {
            // convert the object to an SVG element display string for Rectangle
            string dispSVG = "".PadLeft(3, ' ')+$"<g fill=\"{SFill}\" stroke=\"{SLColor}\" stroke-width=\"{SLBorder}\" transform=\"{GetTransform.Trim()}\">" + Environment.NewLine;
            return dispSVG;
        }    
    }//end class 

    //set up the class for canvas
    class Canvas   
        {
            public int Width { get;  set; }
            public int Height { get;  set; }  
            // the canvas default value
            public Canvas()
            {
                Width = 1000; Height = 500;
            }
            // update the canvas default value
            public Canvas(int width, int height)
            {
                Width = width;  Height = height;
            }

            //create a shape object for grouping
            Shape g = new G();
            public void Grouping(Shape s)
            {
                g = s;
            }
            // create a list for shape
            List<Shape> shapes = new List<Shape>();
            // add a shape
            public void Addshape(Shape s)
            {
                //s.ZIndex=shapes.Count+1;
                shapes.Add(s);
            }
            // remove a shape 
            public void Removeshape(int Ind) 
            {
                shapes.RemoveAt(Ind);
            }
            // reorder the shape location, from old index location to a new index location
            public void Reordershape(int OldInd,int NewInd) 
            {
                var TempShape=shapes[OldInd];
                shapes.RemoveAt(OldInd);
                shapes.Insert(NewInd,TempShape);
            }     
            // show the svg content
            public string Show()
            {
                 String svgOpen=$"<?xml version=\"1.0\" standalone=\"no\"?><svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\" viewBox=\"0 0 {Width} {Height}\" height=\"{Height}\" width=\"{Width}\"><desc>SVG Canvas Shapes</desc>"+Environment.NewLine;
                 String svgContent="";
                 String svgClose="</svg>";
                 int cnt=0;
                 // loop every shape from shapes list
                 foreach (var sp in shapes)
                 {
                    if(cnt==g.Gfrom&&g.Gto<=shapes.Count-1)
                    {
                        svgContent+=g.ToSVGElement();
                    }
                    svgContent+=sp.ToSVGElement(); 
                    if(cnt==g.Gto&&g.Gto<=shapes.Count-1)
                    {
                        svgContent+="".PadLeft(3, ' ')+"</g>"+Environment.NewLine;;
                    }         
                    cnt+=1;  
                 }        
                 // return svg content      
                 return svgOpen+svgContent+svgClose;
            }
            // list the shape z-index 
            public string ListZIndex()
            {
                 String svgContent="";
                 int cnt=0;
                 // loop every shape from shapes list
                 foreach (var sp in shapes)
                 {
                    svgContent+=cnt+". "+sp.ToSVGElement(); 
                    cnt+=1;                
                 }        
                 // return svg content      
                 return svgContent;
            }
        }
}