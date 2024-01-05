using MovieTheater.Models;

namespace MovieTheater.Interfaces
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
        Task<List<Image>> GetImage(string name);
        Task<Image> GetByIdAsync(int id);
    }
}
