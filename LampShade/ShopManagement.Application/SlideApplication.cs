using _0_Framework.Application;
using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly ISlideRepository _slideRepository;

        public SlideApplication(ISlideRepository slideRepository, IFileUploader fileUploader)
        {
            _fileUploader = fileUploader;
            _slideRepository = slideRepository;
        }

        public OpretionResult Create(CreateSlide command)
        {
            var operation = new OpretionResult();
            var pictureName = _fileUploader.Upload(command.Picture, "slides");

            var slide = new Slide(pictureName, command.PictureAlt, command.PictureTitle,
                command.Heading, command.Title, command.Text, command.Link, command.BtnText);

            _slideRepository.Create(slide);
            _slideRepository.SaveChanges();
            return operation.Succedded();
        }

        public OpretionResult Edit(EditSlide command)
        {
            var operation = new OpretionResult();
            var slide = _slideRepository.Get(command.Id);
            if (slide == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }
            var pictureName = _fileUploader.Upload(command.Picture, "slides");

            slide.Edit(pictureName, command.PictureAlt, command.PictureTitle,
                command.Heading, command.Title, command.Text, command.Link, command.BtnText);


            _slideRepository.SaveChanges();
            return operation.Succedded();
        }

        public OpretionResult Remove(long id)
        {
            var operation = new OpretionResult();
            var slide = _slideRepository.Get(id);
            if (slide == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }
            slide.Remove();
            _slideRepository.SaveChanges();
            return operation.Succedded();
        }

        public OpretionResult Restore(long id)
        {
            var operation = new OpretionResult();
            var slide = _slideRepository.Get(id);
            if (slide == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }
            slide.Restore();
            _slideRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditSlide GetDetails(long id)
        {
            return _slideRepository.GetDetails(id);
        }

        public List<SlideViewModel> GetList()
        {
            return _slideRepository.GetList();
        }
    }
}
