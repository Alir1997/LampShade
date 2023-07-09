using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;

        public SlideApplication(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public OpretionResult Create(CreateSlide command)
        {
            var operation = new OpretionResult();
            var slide = new Slide(command.Picture, command.PictureAlt,
                command.PictureTitle, command.Heading,
                command.Title, command.BtnText, command.Text);

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
            slide.Edit(command.Picture, command.PictureAlt,
                command.PictureTitle, command.Heading, command.Title,
                command.BtnText, command.Text);


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
