
using _0_FrameWork.Application;

namespace CommentManagement.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        OpretionResult Add(AddComment command);
        OpretionResult Confirm(long id);
        OpretionResult Cancel(long id);
        List<CommentViewModel> Search(CommentSearchModel searchModel);
    }
}
