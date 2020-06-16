using System;
using System.Collections.Generic;
using System.Text;
using LanguageSchool.Entities;
using LanguageSchool.Repositories;

namespace LanguageSchool.Command.Bookings
{
    internal class BuyBookingCommandHandler : ICommandHandler<BuyBookingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BuyBookingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result Handle(BuyBookingCommand command)
        {
            var validationResult = new BuyBookingCommandValidator().Validate(command);
            if (validationResult.IsValid == false)
            {
                return Result.Fail(validationResult);
            }

            var booking = new Booking(command.Email, command.Quantity);
            var course = _unitOfWork.CoursesRepository.GetById(command.CourseId);
            var training = course.GetTrainingByDateAdnRoomId(command.TrainingDate);

            training.Add(booking);
            _unitOfWork.Commit();


            return Result.Ok();
        }
    }
}
