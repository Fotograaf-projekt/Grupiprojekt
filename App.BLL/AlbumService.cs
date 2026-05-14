using App.DAL.EF.Repositories;
using App.Domain;

namespace App.BLL;

public class AlbumService(
    IAlbumRepository albumRepo,
    IPhotoRepository photoRepo,
    ICategoryRepository categoryRepo)
{
    public Task<List<Category>> AllCategoriesAsync() =>
        categoryRepo.AllAsync();

    public async Task AddCategoryAsync(Category category)
    {
        await categoryRepo.AddAsync(category);
        await categoryRepo.SaveChangesAsync();
    }

    public async Task RemoveCategoryAsync(int id)
    {
        await categoryRepo.RemoveAsync(id);
        await categoryRepo.SaveChangesAsync();
    }
    public Task<List<Album>> AlbumsForAsync(int photographerId) =>
        albumRepo.AllForPhotographerAsync(photographerId);

    public Task<Album?> GetAlbumWithPhotosAsync(int id) =>
        albumRepo.GetWithPhotosAsync(id);

    public async Task AddAlbumAsync(Album album)
    {
        await albumRepo.AddAsync(album);
        await albumRepo.SaveChangesAsync();
    }

    public async Task UpdateAlbumAsync(Album album)
    {
        albumRepo.Update(album);
        await albumRepo.SaveChangesAsync();
    }

    public async Task RemoveAlbumAsync(int id)
    {
        await albumRepo.RemoveAsync(id);
        await albumRepo.SaveChangesAsync();
    }

    public Task<List<Photo>> PhotosForAlbumAsync(int albumId) =>
        photoRepo.AllForAlbumAsync(albumId);

    public async Task AddPhotoAsync(Photo photo)
    {
        await photoRepo.AddAsync(photo);
        await photoRepo.SaveChangesAsync();
    }

    public async Task RemovePhotoAsync(int id)
    {
        await photoRepo.RemoveAsync(id);
        await photoRepo.SaveChangesAsync();
    }

    public Task<List<Album>> AllAlbumsAsync() =>
    albumRepo.AllAsync();

    public async Task UpdatePhotoAsync(Photo photo)
    {
        photoRepo.Update(photo);
        await photoRepo.SaveChangesAsync();
    }

    public Task<List<Album>> AlbumsByCategoryAsync(int categoryId) =>
        albumRepo.AllByCategoryAsync(categoryId);
}