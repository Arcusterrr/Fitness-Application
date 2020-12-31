using System;

namespace Domain.Entities
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }

        public int Age
        { 
            get 
            {
                DateTime timenow = DateTime.Today;
                int age = timenow.Year - BirthDate.Year;
                if (BirthDate > timenow.AddYears(-age)) age--;
                return age; 
            } 
        }
        
        public User(string name,
                    Gender gender,
                    DateTime birthDate,
                    double weight,
                    double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null.", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть null.", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1920") || birthDate >= DateTime.Parse("01.01.2021") || birthDate == null)
            {
                throw new ArgumentNullException("Невозможная дата рождения или null.", nameof(birthDate));
            }

            if(weight <= 0)
            {
                throw new ArgumentNullException("Вес не может быть меньше либо равным нулю.", nameof(weight));
            }

            if(height <= 0)
            {
                throw new ArgumentNullException("Рост не может быть меньше либо равным нулю.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть null.", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
