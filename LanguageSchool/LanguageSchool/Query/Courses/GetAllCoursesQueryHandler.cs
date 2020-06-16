using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LanguageSchool.Query.DTO;
using LanguageSchool.Repositories;

namespace LanguageSchool.Query.Courses
{
    public sealed class GetAllCoursesQueryHandler : IQueryHandler<GetAllCoursesQuery, List<CourseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCoursesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<CourseDto> Handle(GetAllCoursesQuery query)
        {
            var courses = _unitOfWork.CoursesRepository.GetAll();

            return courses.Select(item => new CourseDto(item.Name, item.Id)).ToList();
        }
    }
}
