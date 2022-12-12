using Backend.Misc;
using Backend.Services.Interfaces;

namespace Backend.Services;

public class ImageService : IImageService
{
    private readonly string ImageFolder;
    private readonly IWebHostEnvironment _environment;

    public ImageService(IConfiguration config, IWebHostEnvironment environment)
    {
        _environment = environment;
        ImageFolder = config["ImageLocation"];
    }

    public async Task<(string, long)> SaveImage(IFormFile? image, string path)
    {
        if (image is null || image.Length == 0)
            return (string.Empty, 0);

        path = path.Clearify();
        string name = $"{GetRandomFileName()}{Path.GetExtension(image.FileName)}";

        CreateIfNotExist(Path.Combine(_environment.WebRootPath, ImageFolder));
        CreateIfNotExist(Path.Combine(_environment.WebRootPath, ImageFolder, path));

        var filePath = Path.Combine(_environment.WebRootPath, ImageFolder, path, name);

        using (var stream = File.Create(filePath))
        {
            await image.CopyToAsync(stream);
        }

        return (name, image.Length);
    }

    public bool DeleteImage(string path, string name)
    {
        var filePath = Path.Combine(_environment.WebRootPath, ImageFolder, path.Clearify(), name);

        if (!File.Exists(filePath))
            return false;
        File.Delete(filePath);
        return true;
    }

    private void CreateIfNotExist(string path)
    {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
    }

    private string GetRandomFileName()
    {
        return DateTime.Now.ToFileTimeUtc().ToString();
    }
}