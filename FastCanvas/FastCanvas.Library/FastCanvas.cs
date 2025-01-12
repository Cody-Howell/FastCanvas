using System.Text.Json;

namespace FastCanvas.Library;

/// <summary>
/// <c>FastCanvas</c> provides a C# interface for all the JavaScript Canvas methods and properties. Method and property 
/// names have been chosen to as closely align to the JS syntax as possible. <br/> Once you finish making calls, 
/// call the JS Interop with the "Draw" property and the script name of "fastCanvasDraw".
/// </summary>
public class FastCanvas {
    private List<CanvasTranslation> translatedList { get; set; } = new List<CanvasTranslation>();

    /// <summary>
    /// Returns a JSON string of the inner list of commands. Mainly only used by my JS function for drawing. <br/>
    /// Empties the inner list after the call. 
    /// </summary>
    public string? Draw {
        get {
            var options = new JsonSerializerOptions {
                Converters = { new FastCanvasConverter() }
            };
            string? returnValue = JsonSerializer.Serialize(translatedList, options);
            translatedList.Clear();
            return returnValue;
        }
    }

    /// <summary>
    /// Takes in a <see cref="Direction"/> enum and defines the text direction. 
    /// </summary>
    public Direction direction {
        set {
            translatedList.Add(new CanvasTranslation("direction", [], [Enum.GetName(value)!]));
        }
    }

    /// <summary>
    /// Defines the font of the text.
    /// </summary>
    public string font {
        set {
            translatedList.Add(new CanvasTranslation("font", [], [value]));
        }
    }

    /// <summary>
    /// Taking in a <see cref="TextAlign"/> enum, sets the text alignment. 
    /// </summary>
    public TextAlign textAlign {
        set {
            translatedList.Add(new CanvasTranslation("textAlign", [], [Enum.GetName(value)!]));
        }
    }

    /// <summary>
    /// Taking in a <see cref="TextBaseline"/> enum, sets where the bottom of the text lies.
    /// </summary>
    public TextBaseline textBaseline {
        set {
            translatedList.Add(new CanvasTranslation("textBaseline", [], [Enum.GetName(value)!]));
        }
    }

    /// <summary>
    /// Sets the fill style of the fill methods. Use a name or a Hex code. Required to close an AddColorStop call (see wiki).
    /// </summary>
    public string fillStyle {
        set {
            translatedList.Add(new CanvasTranslation("fillStyle", [], [value]));
        }
    }

    /// <summary>
    /// Taking in a <see cref="LineCap"/> enum, sets the line cap of the endpoints.
    /// </summary>
    public LineCap lineCap {
        set {
            translatedList.Add(new CanvasTranslation("lineCap", [], [Enum.GetName(value)!]));
        }
    }

    /// <summary>
    /// Taking in a <see cref="LineJoin"/> enum, sets the way the joints between lines display.
    /// </summary>
    public LineJoin lineJoin {
        set {
            translatedList.Add(new CanvasTranslation("lineJoin", [], [Enum.GetName(value)!]));
        }
    }

    /// <summary>
    /// Sets the width of the lines. 
    /// </summary>
    public int lineWidth {
        set {
            translatedList.Add(new CanvasTranslation("lineWidth", [value], []));
        }
    }

    /// <summary>
    /// Pixel limit of the Miter setting on LineJoin. Sets how far the miter comes in to the joint.
    /// </summary>
    public int miterLimit {
        set {
            translatedList.Add(new CanvasTranslation("miterLimit", [value], []));
        }
    }

    /// <summary>
    /// Sets the blue distance of the shadow.
    /// </summary>
    public int shadowBlur {
        set {
            translatedList.Add(new CanvasTranslation("shadowBlur", [value], []));
        }
    }

    /// <summary>
    /// Sets the color of the shadow. Use a named color or a hex code. 
    /// </summary>
    public string shadowColor {
        set {
            translatedList.Add(new CanvasTranslation("shadowColor", [], [value]));
        }
    }

    /// <summary>
    /// Sets the horizontal offset (positive or negative) for the shadow.
    /// </summary>
    public int shadowOffsetX {
        set {
            translatedList.Add(new CanvasTranslation("shadowOffsetX", [value], []));
        }
    }

    /// <summary>
    /// Sets the vertical offset (positive or negative) for the shadow.
    /// </summary>
    public int shadowOffsetY {
        set {
            translatedList.Add(new CanvasTranslation("shadowOffsetY", [value], []));
        }
    }

    /// <summary>
    /// Sets the stroke style. Use a named color or a hex code. Required to close an AddColorStop call (see wiki).
    /// </summary>
    public string strokeStyle {
        set {
            translatedList.Add(new CanvasTranslation("strokeStyle", [], [value]));
        }
    }

    /// <summary>
    /// Fills a rectangle with the given coordinates.
    /// </summary>
    /// <param name="x">Positive x coordinate</param>
    /// <param name="y">Positive y coordinate</param>
    /// <param name="width">Width of the rectangle</param>
    /// <param name="height">Height of the rectangle</param>
    public void fillRect(int x, int y, int width, int height) {
        translatedList.Add(new CanvasTranslation("fillRect", [x, y, width, height], []));
    }

    /// <summary>
    /// Makes a rectangle with the stroke configuration.
    /// </summary>
    /// <param name="x">Positive x coordinate</param>
    /// <param name="y">Positive y coordinate</param>
    /// <param name="width">Width of the rectangle</param>
    /// <param name="height">Height of the rectangle</param>
    public void strokeRect(int x, int y, int width, int height) {
        translatedList.Add(new CanvasTranslation("strokeRect", [x, y, width, height], []));
    }

    /// <summary>
    /// Simplification of the <see cref="clearRect(int, int, int, int)"/> method to clear the page. 
    /// Usually done at the start of the drawing process.
    /// </summary>
    /// <param name="x">Size of the page horizontally</param>
    /// <param name="y">Size of the page vertically</param>
    public void ClearPage(int x, int y) {
        clearRect(0, 0, x, y);
    }

    /// <summary>
    /// Clears a rectangle with the given paramters.
    /// </summary>
    /// <param name="x">Positive x coordinate</param>
    /// <param name="y">Positive y coordinate</param>
    /// <param name="width">Width of the rectangle</param>
    /// <param name="height">Height of the rectangle</param>
    public void clearRect(int x, int y, int width, int height) {
        translatedList.Add(new CanvasTranslation("clearRect", [x, y, width, height], []));
    }

    /// <summary>
    /// Starts a path.
    /// </summary>
    public void beginPath() {
        translatedList.Add(new CanvasTranslation("beginPath", [], []));
    }

    /// <summary>
    /// Closes a path.
    /// </summary>
    public void closePath() {
        translatedList.Add(new CanvasTranslation("closePath", [], []));
    }

    /// <summary>
    /// NOT YET IMPLEMENTED! I have no ideas for how I might get this; I might just do a local check 
    /// through the most recent calls, but that is not yet implemented.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public bool isPointInPath() {
        throw new NotImplementedException();
    }

    /// <summary>
    /// In a path, move to a point without drawing a line.
    /// </summary>
    public void moveTo(int x, int y) {
        translatedList.Add(new CanvasTranslation("moveTo", [x, y], []));
    }

    /// <summary>
    /// In a path, move to a point while drawing a line.
    /// </summary>
    public void lineTo(int x, int y) {
        translatedList.Add(new CanvasTranslation("lineTo", [x, y], []));
    }

    /// <summary>
    /// Given a closed path, fill the inner section.
    /// </summary>
    public void fill() {
        translatedList.Add(new CanvasTranslation("fill", [], []));
    }

    /// <summary>
    /// Add a rectangle to the current path.
    /// </summary>
    /// <param name="x">Positive x coordinate</param>
    /// <param name="y">Positive y coordinate</param>
    /// <param name="width">Width of the rectangle</param>
    /// <param name="height">Height of the rectangle</param>
    public void rect(int x, int y, int width, int height) {
        translatedList.Add(new CanvasTranslation("rect", [x, y, width, height], []));
    }

    /// <summary>
    /// Given a closed path, line stroke the bounds. 
    /// </summary>
    public void stroke() {
        translatedList.Add(new CanvasTranslation("stroke", [], []));
    }

    /// <summary>
    /// Takes in 2 control points and an ending point. See Mozilla for more exact docs.
    /// </summary>
    /// <param name="c1x">Control point 1 x-coord</param>
    /// <param name="c1y">Control point 1 y-coord</param>
    /// <param name="c2x">Control point 2 x-coord</param>
    /// <param name="c2y">Control point 2 y-coord</param>
    /// <param name="endX">End point x-coord</param>
    /// <param name="endY">End point y-coord</param>
    public void bezierCurveTo(int c1x, int c1y, int c2x, int c2y, int endX, int endY) {
        translatedList.Add(new CanvasTranslation("bezierCurveTo", [c1x, c1y, c2x, c2y, endX, endY], []));
    }

    /// <summary>
    /// Adds a Circle to the current path. 
    /// </summary>
    /// <param name="x">X-coordinate of the center</param>
    /// <param name="y">Y-coordinate of the center</param>
    /// <param name="radius">Radius of the circle</param>
    public void Circle(int x, int y, int radius) {
        arc(x, y, radius, 0, 2 * Math.PI);
    }

    /// <summary>
    /// Creates an Arc on the current path. <c>0</c> is Right and <c>90</c> is Down.
    /// </summary>
    /// <param name="x">X-coordinate of the center</param>
    /// <param name="y">Y-coordinate of the center</param>
    /// <param name="radius">Radius of the circle</param>
    /// <param name="startAngle">Start of the circle in degrees</param>
    /// <param name="endAngle">End of the circle in degrees</param>
    /// <param name="counterClockwise">Set to <c>True</c> to go counter-clockwise</param>
    public void arc(int x, int y, int radius, int startAngle, int endAngle, bool counterClockwise = false) {
        arc(x, y, radius, startAngle * Math.PI / 180, endAngle * Math.PI / 180, counterClockwise);    
    }

    /// <summary>
    /// Creates an Arc on the current path. <c>0</c> is Right and <c>Pi/2</c> is Down.
    /// </summary>
    /// <param name="x">X-coordinate of the center</param>
    /// <param name="y">Y-coordinate of the center</param>
    /// <param name="radius">Radius of the circle</param>
    /// <param name="startRadian">Start of the circle in radians</param>
    /// <param name="endRadian">End of the circle in radians</param>
    /// <param name="counterClockwise">Set to <c>True</c> to go counter-clockwise</param>
    public void arc(int x, int y, int radius, double startRadian, double endRadian, bool counterClockwise = false) {
        translatedList.Add(new CanvasTranslation("arc", [x, y, radius, startRadian, endRadian], [counterClockwise ? "true" : "false"]));
    }

    /// <summary>
    /// Adds an arc given control points and a radius.
    /// </summary>
    /// <param name="x1">Control point 1 x-coordinate</param>
    /// <param name="y1">Control point 1 y-coordinate</param>
    /// <param name="x2">Control point 2 x-coordinate</param>
    /// <param name="y2">Control point 2 y-coordinate</param>
    /// <param name="radius">Radius of the circle</param>
    public void arcTo(int x1, int y1, int x2, int y2, double radius) {
        translatedList.Add(new CanvasTranslation("arcTo", [x1, y1, x2, y2, radius], []));
    }

    /// <summary>
    /// Given a control point and an end point, draw a quadratic Bezier Curve.
    /// </summary>
    /// <param name="cx">Control point 1 x-coordinate</param>
    /// <param name="cy">Control point 1 y-coordinate</param>
    /// <param name="ex">End point x-coordinate</param>
    /// <param name="ey">End point y-coordinate</param>
    public void quadraticCurveTo(int cx, int cy, int ex, int ey) {
        translatedList.Add(new CanvasTranslation("quadraticCurveTo", [cx, cy, ex, ey], []));
    }

    /// <summary>
    /// Given a string of text, place it somewhere. If Max Width is specified, set that as the bound for the entire string.
    /// </summary>
    /// <param name="text">String to display</param>
    /// <param name="x">X-coordinate</param>
    /// <param name="y">Y-coordinate</param>
    /// <param name="maxWidth">Maximum width of the displayed text (if specified)</param>
    public void fillText(string text, int x, int y, int maxWidth = -1) {
        translatedList.Add(new CanvasTranslation("fillText", [x, y, maxWidth], [text]));
    }

    /// <summary>
    /// Given the current text configs, logs the width of the text in the Browser console.
    /// </summary>
    /// <param name="text">String to check</param>
    public void measureText(string text) {
        translatedList.Add(new CanvasTranslation("measureText", [], [text]));
    }

    /// <summary>
    /// Displays an outline of the given text.
    /// </summary>
    /// <param name="text">String to display</param>
    /// <param name="x">X-coordinate</param>
    /// <param name="y">Y-coordinate</param>
    /// <param name="maxWidth">Maximum width of the displayed text (if specified)</param>
    public void strokeText(string text, int x, int y, int maxWidth = -1) {
        translatedList.Add(new CanvasTranslation("strokeText", [x, y, maxWidth], [text]));
    }

    /// <summary>
    /// Required to be directly after either a Linear or Radial gradient call. 
    /// The position should be a number between 0 and 1, and you can specify as many as you want.
    /// </summary>
    /// <param name="position">Double between 0 and 1</param>
    /// <param name="color">Either a name or a hex code</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void addColorStop(double position, string color) {
        if (position < 0 || position > 1) { throw new ArgumentOutOfRangeException("position", "Position must be between 0 and 1."); }
        translatedList.Add(new CanvasTranslation("addColorStop", [position], [color]));
    }

    /// <summary>
    /// Starts a linear Gradient creation. 
    /// Add color stops (<see cref="addColorStop(double, string)"/>) and then finish by setting either 
    /// <see cref="fillStyle"/> or <see cref="strokeStyle"/> to an empty string.
    /// </summary>
    /// <param name="x1">Start point x-coordinate</param>
    /// <param name="y1">Start point y-coordinate</param>
    /// <param name="x2">End point x-coordinate</param>
    /// <param name="y2">End point y-coordinate</param>
    public void createLinearGradient(int x1, int y1, int x2, int y2) {
        translatedList.Add(new CanvasTranslation("createLinearGradient", [x1, y1, x2, y2], []));
    }

    /// <summary>
    /// Takes in an &lt;img&gt; element ID and a <see cref="Repeat"/> enum and assigns the <see cref="fillStyle"/> automatically. 
    /// </summary>
    /// <param name="elementId">ID of the image element to repeat</param>
    /// <param name="repeat"><see cref="Repeat"/> enum to repeat in the space</param>
    public void createPattern(string elementId, Repeat repeat = Repeat.Repeat) {
        string repeatValue = Enum.GetName(repeat)!.Replace('_', '-');
        translatedList.Add(new CanvasTranslation("createPattern", [], [elementId, repeatValue]));
    }

    /// <summary>
    /// Starts a radial Gradient creation. 
    /// Add color stops (<see cref="addColorStop(double, string)"/>) and then finish by setting either 
    /// <see cref="fillStyle"/> or <see cref="strokeStyle"/> to an empty string.
    /// </summary>
    /// <param name="x0">Starting circle x-coordinate</param>
    /// <param name="y0">Starting circle y-coordinate</param>
    /// <param name="r0">Starting circle radius</param>
    /// <param name="x1">Ending circle x-coordinate</param>
    /// <param name="y1">Ending circle y-coordinate</param>
    /// <param name="r1">Ending circle radius</param>
    public void createRadialGradient(int x0, int y0, double r0, int x1, int y1, double r1) {
        translatedList.Add(new CanvasTranslation("createRadialGradient", [x0, y0, r0, x1, y1, r1], []));
    }

    /// <summary>
    /// Scale the entire image by a given width and height value.
    /// </summary>
    public void scale(double width, double height) {
        translatedList.Add(new CanvasTranslation("scale", [width, height], []));
    }

    /// <summary>
    /// Rotate the entire image by a given angle.
    /// </summary>
    public void rotate(int angle) {
        rotate(angle * Math.PI / 180);
    }

    /// <summary>
    /// Rotate the entire image by a given radian.
    /// </summary>
    public void rotate(double radian) {
        translatedList.Add(new CanvasTranslation("rotate", [radian], []));
    }

    /// <summary>
    /// Translate the entire image by given coordinates.
    /// </summary>
    public void translate(int x, int y) {
        translatedList.Add(new CanvasTranslation("translate", [x, y], []));
    }

    /// <summary>
    /// Transform by the upper two lines of a given 3x3 matrix. Really, just go look at the 
    /// <a href="https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/transform" target="_blank">Mozilla docs</a>.
    /// </summary>
    public void transform(double a, double b, double c, double d, double e, double f) {
        translatedList.Add(new CanvasTranslation("transform", [a, b, c, d, e, f], []));
    }

    /// <summary>
    /// Resets any current skews, then transforms it given the above method (I think).
    /// </summary>
    public void setTransform(double a, double b, double c, double d, double e, double f) {
        translatedList.Add(new CanvasTranslation("setTransform", [a, b, c, d, e, f], []));
    }

}
