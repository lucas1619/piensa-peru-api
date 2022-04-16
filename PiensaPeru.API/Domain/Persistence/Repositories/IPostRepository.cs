﻿using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Persistence.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> ListAsync();
        Task<Post> FindById(int id);
        Task AddAsync(Post post);
        void Update(Post post);
        void Remove(Post post);
    }
}
