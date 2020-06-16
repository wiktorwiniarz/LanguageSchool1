using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LanguageSchool.ValueObjects;
namespace LanguageSchool.Entities
{
    public class Course
    {
        protected Course()
        {
        }

        public Course(string name, int year, int trainingTime)
        {
            Id = new Id<Course>(Guid.NewGuid());
            Name = name;
            Year = year;
            TrainingTime = trainingTime;
        }

        public Id<Course> Id { get; protected set; }

        public string Name { get; protected set; }

        public int Year { get; protected set; }

        public int TrainingTime { get; protected set; }

        public virtual ICollection<Training> Trainings { get; protected set; }

        public Training GetTrainingByDateAdnRoomId(DateTime date)
        {
            return Trainings.SingleOrDefault(x => DateTime.Compare(x.Date, date) == 1);
        }

        public void SetName(string name)
        {

            Name = name;
        }

        public void SetYear(int year)
        {

            Year = year;
        }

        public void SetTrainingTime(int trainingTime)
        {
            TrainingTime = trainingTime;
        }
    }
}
