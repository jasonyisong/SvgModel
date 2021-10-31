// This program created by Yi Song 2021/10/16
// Function include
// 1. Export the canvas to a file in SVG、Adding shape、Deleting Shape、Updating Shape、Style、z-index、default line and fill styles
// Comment the code updated by Yi Song 2021/10/23
// Add function include  updated by Yi Song 2021/10/26
// 2. Grouping and ungrouping、Applying styles and translations to shape groups、Translating, rotating, skewing and scaling basic shapes、Adding styled and formatted text

using System;
using System.IO;

namespace assignment_02_21252880
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a canvas =====================================================
            svgmodel.Canvas co = new svgmodel.Canvas();  

            // add shapes =====================================================
            // draw a Rectangle shape
            svgmodel.Shape Rect= new svgmodel.RectanglePP(100,300,800,700);  
            // draw a Circle shape
            svgmodel.Shape Circle= new svgmodel.CirclePP(300,200,100); 
            // draw a Circle shape
            svgmodel.Shape Circle1= new svgmodel.CirclePP(300,200,100);  // Z-index 2
            // draw a Ellipse shape
            svgmodel.Shape Ellipse= new svgmodel.EllipsePP(250,100,250,100);  
            // draw a Line shape
            svgmodel.Shape Line= new svgmodel.LinePP(500,300,700,100); 
            // draw a null Polyline shape
            svgmodel.Shape Polyline= new svgmodel.PolylinePP(); 
            // draw a null Polygon shape 
            svgmodel.Shape Polygon= new svgmodel.PolygonPP(); 
            // draw a null Path shape
            svgmodel.Shape Path= new svgmodel.PathPP(); 
            // draw a null text shape
            svgmodel.Shape Text= new svgmodel.TextPP(200,200); 
             
            // add the Rectangle to canvas with a default value
            co.Addshape(Rect);

            // add the Circle to canvas with a default value
            co.Addshape(Circle);
            co.Addshape(Circle1);

            // add the Ellipse to canvas with a default value
            co.Addshape(Ellipse);

            // add the Line to canvas with a default value
            co.Addshape(Line);

            // add the Text to canvas with a default value
            co.Addshape(Text);
            
            // draw the Polyline points 
            Polyline.AddPoint(850,75);
            Polyline.AddPoint(58,137.5);
            Polyline.AddPoint(358,462.5);
            // add the Polyline to canvas
            co.Addshape(Polyline);    

            // draw the Polygon points  
            Polygon.AddPoint(50,375);
            Polygon.AddPoint(450,275);
            Polygon.AddPoint(550,325);
            // add the Polygon to canvas
            co.Addshape(Polygon);            
       
            // draw the Line D 
            Path.AddD("M",10,315,null,null,null,null,null);
            Path.AddD("L",110,215,null,null,null,null,null);
            Path.AddD("A",30,50,0,0,1,162.55,162.45);
            Path.AddD("L",172.55,152.45,null,null,null,null,null);
            Path.AddD("A",30,50,-45,0,1,215.1,109.9);
            Path.AddD("L",315,10,null,null,null,null,null);
            // add the Path to canvas
            co.Addshape(Path);    

            // update all shapes and translating, rotating, skewing and scaling basic shapes =====================================================
            // update the Rectangle default value
            Rect.X=100;
            Rect.Y=300;
            Rect.Width=800;
            Rect.Height=100;
            Rect.AddTransform("rotate",-10,50,100);
            Rect.AddTransform("translate",-36,45,null);
            Rect.AddTransform("skewX",40,null,null);
            Rect.AddTransform("scale",1,0.5,null);
            Rect.AddTransform("rotate",-10,200,300);

            // update the Circle default value
            Circle.CX=350;
            Circle.CY=250;
            Circle.R=200;
            Circle.AddTransform("rotate",-100,10,700);
            Circle.AddTransform("translate",16,55,null);
            Circle.AddTransform("skewX",30,null,null);
            Circle.AddTransform("scale",1,1.5,null);
            //Circle.AddTransform("rotate",-40,100,700);

            // update the Ellipse default value
            Ellipse.RX=150;
            Ellipse.RY=100;
            Ellipse.CX=350;
            Ellipse.CY=300;
            Ellipse.AddTransform("rotate",-101,20,300);
            Ellipse.AddTransform("translate",16,55,null);
            Ellipse.AddTransform("skewX",30,null,null);
            Ellipse.AddTransform("scale",1,1.5,null);
            Ellipse.AddTransform("rotate",-41,100,700);

            // update the Line default value
            Line.X1=100;
            Line.Y1=500;
            Line.X2=900;
            Line.Y2=100;
            Line.AddTransform("rotate",-102,20,300);
            Line.AddTransform("translate",16,55,null);
            Line.AddTransform("skewX",30,null,null);
            Line.AddTransform("scale",1,1.5,null);
            Line.AddTransform("rotate",-42,100,700);
            
            // update the Polyline points
            Polyline.points[0].x=100;
            Polyline.points[0].y=75;
            Polyline.AddTransform("rotate",-103,20,300);
            Polyline.AddTransform("translate",16,55,null);
            Polyline.AddTransform("skewX",30,null,null);
            Polyline.AddTransform("scale",1,1.5,null);
            Polyline.AddTransform("rotate",-43,100,700);

            // update the Polygon points
            Polygon.points[0].x=50;
            Polygon.points[0].y=275;
            Polygon.AddTransform("rotate",-104,20,300);
            Polygon.AddTransform("translate",16,55,null);
            Polygon.AddTransform("skewX",30,null,null);
            Polygon.AddTransform("scale",1,1.5,null);
            Polygon.AddTransform("rotate",-44,100,700);

            // update the Path d command, Path.AddD("A",30,50,0,0,1,162.55,162.45); 30 to 0
            Path.d[2].x=0;
            Path.AddTransform("rotate",-105,20,300);
            Path.AddTransform("translate",16,55,null);
            Path.AddTransform("skewX",30,null,null);
            Path.AddTransform("scale",2,4.5,null);
            Path.AddTransform("rotate",-45,100,700);


            // delete a shape =====================================================
            // remove the shape Circle1 with z-index
            co.Removeshape(2); // Z-index 2

            // list index =====================================================
            // show every shape the Z index 
            Console.WriteLine("Z-Index:");
            Console.WriteLine(co.ListZIndex());

            // reorder a shape with z-index =====================================================
            co.Reordershape(1,0); // change index 1 to 0 location
            Console.WriteLine("Reorder Z-Index:");
            Console.WriteLine(co.ListZIndex());

            // update the default styles =====================================================
            // update Rectangle style
            Rect.SFill="red";
            Rect.SLColor="blue";
            Rect.SLBorder="2pt";
            
            // update Circle style
            Circle.SFill="green";
            Circle.SLColor="yellow";
            Circle.SLBorder="3pt";           

            // update Ellipse style
            Ellipse.SFill="seagreen";
            Ellipse.SLColor="indigo";
            Ellipse.SLBorder="1.5pt";  

            // update Line style
            Line.SLColor="burlywood";
            Line.SLBorder="2.5pt";  

            // update Polyline style
            Polyline.SFill="indigo";
            Polyline.SLColor="lemonchiffon";
            Polyline.SLBorder="1.5pt";  

            // update Polygon style
            Polygon.SFill="peachpuff";
            Polygon.SLColor="slategray";
            Polygon.SLBorder="1.5pt";  

            // update Path style
            Path.SFill="lightgreen";
            Path.SLColor="limegreen";
            Path.SLBorder="1.5pt";  

            //update Text content and style
            Text.textcontent="text";
            Text.SFill="red";
            Text.fontfamily="Verdana";
            Text.fontsize="64";
            Text.fontsizeadjust="0.58";
            Text.fontstretch="condensed";
            Text.fontstyle="italic";
            Text.fontvariant="small-caps";
            Text.fontweight="bold";

            //Grouping and Ungrouping  =====================================================
            //create a G object
            svgmodel.Shape g= new svgmodel.G(); 
            // add the object to convas default is ungrouping
            co.Grouping(g);

            //-1 is default value, ungrouping
            g.Gfrom=-1;
            g.Gto=-1;

            //grouping from Z index from 0 to 1
            g.Gfrom=0;
            g.Gto=1;
            
            //applying styles and translations to shape groups =====================================================
            g.SFill="red";
            g.SLColor="grey";
            g.SLBorder="1.5pt"; 

            g.AddTransform("rotate",-10,100,300);
            g.AddTransform("translate",-36,45,null);
            g.AddTransform("skewX",40,null,null);
            g.AddTransform("scale",1,0.5,null);

            //show the canvas content
            Console.WriteLine(co.Show());
            
            //output the canvas to file svg.txt
            File.WriteAllText("svg.txt",co.Show());  
            // show message    
            Console.WriteLine("Wrote to file: svg.txt");
            Console.WriteLine();         
        }
    }
}
