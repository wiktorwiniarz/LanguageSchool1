using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageSchool.Query.DTO
{
    public class CourseDetailsDTO
    {
        public CourseDetailsDTO(Guid id, string name, int year, int trainingTime, List<TrainingDTO> trainings)
        {
            Id = id;
            Name = name;
            Trainings = trainings;
            Year = year;
            TrainingTime = trainingTime;
        }

        public Guid Id { get; }

        public string Name { get; }

        public int Year { get; }

        public int TrainingTime { get; }

        public List<TrainingDTO> Trainings { get;  }
   }
}
