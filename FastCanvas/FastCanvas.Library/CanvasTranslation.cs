namespace FastCanvas.Library;

internal class CanvasTranslation {
    public string Type { get; } 
    public double[] Numbers { get; }
    public string[] Strings { get; }

    public CanvasTranslation(string type, double[] numbers, string[] strings) {
        Type = type;
        Numbers = numbers;
        Strings = strings;
    }
}
