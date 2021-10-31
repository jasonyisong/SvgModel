# SvgModel

- This is a hard-coding by using C#

- Coding at Maynooth University

- Design and develop an object oriented soluCon in C# for maintaining a data model for a basic vector graphics applicaCon. The model include a means to represent a single two-dimensional (2D) canvas that maintains a list basic 2D shapes, e.g. rectangles, circles, etc. on a drawing canvas.

- No graphical user interface

- The attributes for the basic Shapes (elements) typically used in vector graphics applications, and Shapes, where appropriate, also have line styles, line thicknesses, line colours, fill colours, etc.

> *A Rectangle shape has four basic attributes that control the position and shape. x is the x position of the top led corner of the rectangle. y is the y position of the top led corner of the rectangle. width is the width of the rectangle. height is he height of the rectangle.

> A Circle shape has three basic attributes that control the position and size. r is the radius of the circle. cx is the x position of the centre of the circle. cy is the y position of the centre of the circle.

> An ellipse shape is a more general form of the circle element, where you can scale the x and y ra- dius of the circle separately and has four basic attributes. rx is the x radius of the ellipse. ry is the y radius of the ellipse. cx is the x position of the centre of the ellipse. cy is the y position of the centre of the ellipse.

> A line shape takes the positions of two points as parameters and draws a straight line between them and has four basic attributes. x1 is the x position of point 1. y1 is the y position of point 1. x2 is the x position of point 2. y2 is the y position of point 2.

> A polyline shape is a group of connected straight lines and contains a single attribute which is a list of points specifying the individual lines. The end point (x and y coordinates) of one line becomes the starting point for the next line.

> A polygon shape is similar to a polyline shape, as it is also composed of straight line segments connecting a list of points to form a closed shape, and contains a single attribute which is a list of points specifying the individual lines. For polygon shapes, however, the path automatically connects the last point with the first.

> A path shape is the most general shape that can be used to draw shapes. The path shape may be used to draw all other shapes and curves. The path shape has a single attribute that contains a list of instructions describing the path.

# Additional Function

- Functionality for grouping and ungrouping selected shape elements on the canvas

- Applying styles and translations to shape groups

- Implementing canvas methods for translating, rotating, skewing and scaling basic shapes

- Adding styled and formatted text to the canvas.
