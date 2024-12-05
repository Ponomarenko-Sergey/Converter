using Converter.Core.Components;
using Converter.Core.Interfaces;
using Converter.Core.Services;

string inputPath = "input.txt";
string outputPath = "output.txt";

IInputHandler inputHandler = new InputHandler();
IConverterMapper converterMapper = new ConverterMapper();
IOutputHandler outputHandler = new OutputHandler();

var service = new ConverterService(inputHandler, converterMapper, outputHandler);

service.Process(inputPath, outputPath);

Console.WriteLine("Conversion completed. Check the output file.");