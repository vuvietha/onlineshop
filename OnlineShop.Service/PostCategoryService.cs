using OnlineShop.Data.Infrastructure;
using OnlineShop.Data.Repositories;
using OnlineShop.Model.Models;
using System.Collections.Generic;

namespace OnlineShop.Service
{
    public interface IPostCategoryService
    {
        PostCategory Add(PostCategory postCategoy);

        void Update(PostCategory postCategoy);

        PostCategory Delete(int id);

        IEnumerable<PostCategory> GetAll();

        IEnumerable<PostCategory> GetAllByParentId(int parentId);

        IEnumerable<PostCategory> GetAllPaging(int page, int pageSize, out int totalRow);

        PostCategory GetById(int id);

        void SaveChanges();
    }

    public class PostCategoryService : IPostCategoryService
    {
        private IPostCategoryRepository _postCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public PostCategory Add(PostCategory postCategoy)
        {
           return  _postCategoryRepository.Add(postCategoy);
        }

        public PostCategory Delete(int id)
        {
            return _postCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParentId(int parentId)
        {
            return _postCategoryRepository.GetMulti(x => x.ParentID == parentId);
        }

        public IEnumerable<PostCategory> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _postCategoryRepository.GetMultiPaging(x => x.HomeFlag ?? false, out totalRow, page, pageSize);
        }

        public PostCategory GetById(int id)
        {
            return _postCategoryRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(PostCategory postCategoy)
        {
            _postCategoryRepository.Update(postCategoy);
        }
    }
}