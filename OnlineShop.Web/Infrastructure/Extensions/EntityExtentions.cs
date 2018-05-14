using OnlineShop.Model.Models;
using OnlineShop.Web.Models;

namespace OnlineShop.Web.Infrastructure.Extensions
{
    public static class EntityExtentions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryVM)
        {
            postCategory.ID = postCategoryVM.ID;
            postCategory.Name = postCategoryVM.Name;
            postCategory.Alias = postCategoryVM.Alias;
            postCategory.Description = postCategoryVM.Description;
            postCategory.ParentID = postCategoryVM.ParentID;
            postCategory.DisplayOrder = postCategoryVM.DisplayOrder;
            postCategory.Image = postCategoryVM.Image;
            postCategory.HomeFlag = postCategoryVM.HomeFlag;
            postCategory.CreatedDate = postCategoryVM.CreatedDate;
            postCategory.CreatedBy = postCategoryVM.CreatedBy;
            postCategory.UpdatedDate = postCategoryVM.UpdatedDate;
            postCategory.UpdatedBy = postCategoryVM.UpdatedBy;
            postCategory.MetaKeyword = postCategoryVM.MetaKeyword;
            postCategory.MetaDescription = postCategoryVM.MetaDescription;
            postCategory.Status = postCategoryVM.Status;

        }
        public static void UpdatePost(this Post post, PostViewModel postVM)
        {
            post.ID = postVM.ID;
            post.Name = postVM.Name;
            post.Alias = postVM.Alias;
            post.CategoryID = postVM.CategoryID;
            post.Image = postVM.Image;
            post.Description = postVM.Description;
            post.Content = postVM.Content;
            post.HomeFlag = postVM.HomeFlag;
            post.HotFlag = postVM.HotFlag;
            post.ViewCount = postVM.ViewCount;
            post.CreatedDate = postVM.CreatedDate;
            post.CreatedBy = postVM.CreatedBy;
            post.UpdatedDate = postVM.UpdatedDate;
            post.UpdatedBy = postVM.UpdatedBy;
            post.MetaKeyword = postVM.MetaKeyword;
            post.MetaDescription = postVM.MetaDescription;
            post.Status = postVM.Status;
        }
        public static void UpdateProductCategory(this ProductCategory productCategory, ProductCategoryViewModel productCategoryVM)
        {
            productCategory.ID = productCategoryVM.ID;
            productCategory.Name = productCategoryVM.Name;
            productCategory.Alias = productCategoryVM.Alias;
            productCategory.Description = productCategoryVM.Description;
            productCategory.ParentID = productCategoryVM.ParentID;
            productCategory.DisplayOrder = productCategoryVM.DisplayOrder;
            productCategory.Image = productCategoryVM.Image;
            productCategory.HomeFlag = productCategoryVM.HomeFlag;
            productCategory.CreatedDate = productCategoryVM.CreatedDate;
            productCategory.CreatedBy = productCategoryVM.CreatedBy;
            productCategory.UpdatedDate = productCategoryVM.UpdatedDate;
            productCategory.UpdatedBy = productCategoryVM.UpdatedBy;
            productCategory.MetaKeyword = productCategoryVM.MetaKeyword;
            productCategory.MetaDescription = productCategoryVM.MetaDescription;
            productCategory.Status = productCategoryVM.Status;

        }
    }
}