using _0_Framework.Application;
using System.Collections.Generic;
using _0_FrameWork.Application;

namespace BlogManagement.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        OpretionResult Create(CreateArticle command);
        OpretionResult Edit(EditArticle command);
        EditArticle GetDetails(long id);
        List<ArticleViewModel> Search(ArticleSearchModel searchModel);
    }
}
