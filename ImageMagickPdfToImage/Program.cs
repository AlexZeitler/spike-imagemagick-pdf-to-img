// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using ImageMagick;
var input = "./in/asp.net-documentation.pdf";
Console.WriteLine($"Converting {input} to PNG.", input);

var settings = new MagickReadSettings
{
  // Settings the density to 300 dpi will create an image with a better quality
  Density = new Density(300, 300)
};

using var images = new MagickImageCollection();
// Add all the pages of the pdf file to the collection
var stopwatch = Stopwatch.StartNew();

images.Read(input, settings);

var page = 1;
foreach (var image in images)
{
  // Write page to file that contains the page number
  image.Write("./out/scan" + page + ".png");
  // Writing to a specific format works the same as for a single image
  page++;
}

stopwatch.Stop();

Console.WriteLine($"Converted {page} page(s) to PNG (results in ./out folder).");
Console.WriteLine($"Took {stopwatch.Elapsed.TotalSeconds} seconds.");
